using Dapper;
using Modulos.IO.Domain.Common;
using Modulos.IO.Domain.Core.Models;
using Modulos.IO.Domain.Usuario;
using Modulos.IO.Domain.Usuario.Repository;
using Modulos.IO.Infra.Data.Context;
using System.Collections.Generic;
using System.Security.Claims;

namespace Modulos.IO.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        DynamicParameters param;
        public UsuarioRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Usuario Login(string login, string senha)
        {
            #region Params
            param = new DynamicParameters();
            param.Add("@Login", login);
            param.Add("@Senha", Encript.EncriptData(senha));
            #endregion

            return Login(Procedures.UsuarioLogin, param);
        }

        public IEnumerable<Claim> GetClaims(int? id)
        {
            #region Param
            param = new DynamicParameters();
            param.Add("@Id", id.ToString());
            #endregion

            return GetClaims(Procedures.UsuarioGetClaim, param);
        }
    }
}
