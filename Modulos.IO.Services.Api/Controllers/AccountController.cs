using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Modulos.IO.Domain.Core.Notifications;
using Modulos.IO.Domain.Interfaces;
using Modulos.IO.Domain.Usuario;
using Modulos.IO.Domain.Usuario.Repository;
using Modulos.IO.Infra.Data.CrossCutting.Identity.Authorization;
using Modulos.IO.Services.Api.ViewModels;

namespace Modulos.IO.Services.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly TokenDescriptor _tokenDescriptor;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public AccountController(INotificationHandler<DomainNotification> notifications,
                                    IMediatorHandler mediator,
                                    TokenDescriptor tokenDescriptor,
                                    IUsuarioRepository usuarioRepository) : base(notifications, mediator)
        {
            _usuarioRepository = usuarioRepository;
            _mediatorHandler = mediator;
            _tokenDescriptor = tokenDescriptor;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("usuario-login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var user = _usuarioRepository.Login(model.Login, model.Senha);

            if (user != null)
            {
                var _user = GerarTokenUsuario(user);
                return Response(_user);
            }
            else
            {
                NotificarErro("", "Erro ao fazer Login, tente novamente!");
                return Response();
            }
        }

        private object GerarTokenUsuario(Usuario user)
        {
            var userClaims = _usuarioRepository.GetClaims(user.UsuarioId).ToList();

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UsuarioId.ToString()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Login));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            // Necessário converver para IdentityClaims
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(userClaims);

            var handler = new JwtSecurityTokenHandler();
            var signingConf = new SigningCredentialsConfiguration();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenDescriptor.Issuer,
                Audience = _tokenDescriptor.Audience,
                SigningCredentials = signingConf.SigningCredentials,
                Subject = identityClaims,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(_tokenDescriptor.MinutesValid)
            });

            var encodedJwt = handler.WriteToken(securityToken);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = DateTime.Now.AddMinutes(_tokenDescriptor.MinutesValid),
                user = new
                {
                    id = user.UsuarioId,
                    nome = user.Login,
                    claims = userClaims.Select(c => new { c.Type, c.Value }).FirstOrDefault()
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
     => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
