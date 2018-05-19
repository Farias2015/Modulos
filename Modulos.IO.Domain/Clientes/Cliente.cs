using Modulos.IO.Domain.Core.Models;

namespace Modulos.IO.Domain.Clientes
{
    public class Cliente : Entity<Cliente>
    {

        public Cliente(int? id, string razaoSocial, string nomeFantasia, string cnpj)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
        }

        public Cliente() { }

        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }

    }
}

