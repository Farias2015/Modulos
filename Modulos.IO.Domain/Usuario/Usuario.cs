using Modulos.IO.Domain.Core.Models;

namespace Modulos.IO.Domain.Usuario
{
    public class Usuario : Entity<Usuario>
    {
        public Usuario(int? id, string login, string senha)
        {
            Id = UsuarioId;
            Login = login;
            Senha = senha;
        }

        public Usuario() { }

        public int? UsuarioId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
