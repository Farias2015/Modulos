using Modulos.IO.Domain.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;

namespace Modulos.IO.Domain.Usuario.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario Login(string login, string senha);
        IEnumerable<Claim> GetClaims(int? id);
    }
}
