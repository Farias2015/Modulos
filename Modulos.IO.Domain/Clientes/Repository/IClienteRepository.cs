using Modulos.IO.Domain.Interfaces;
using System.Collections.Generic;

namespace Modulos.IO.Domain.Clientes.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        IEnumerable<Cliente> ObterTodos();
    }
}
