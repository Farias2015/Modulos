using System.Collections.Generic;
using Dapper;
using Modulos.IO.Domain.Clientes;
using Modulos.IO.Domain.Clientes.Repository;
using Modulos.IO.Domain.Common;
using Modulos.IO.Infra.Data.Context;

namespace Modulos.IO.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        DynamicParameters param;
        public ClienteRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }


        public void Atualizar(Cliente cliente)
        {
            #region Prams
            param = new DynamicParameters();
            param.Add("@Id", cliente.Id.ToString());
            param.Add("@RazaoSocial", cliente.RazaoSocial);
            param.Add("@NomeFantasia", cliente.NomeFantasia);
            param.Add("@Cnpj", cliente.Cnpj);
            #endregion

            Atualizar(Procedures.AtualizarCliente, param);
        }

        public void Adicionar(Cliente cliente)
        {
            #region Prams
            param = new DynamicParameters();
            param.Add("@RazaoSocial", cliente.RazaoSocial);
            param.Add("@NomeFantasia", cliente.NomeFantasia);
            param.Add("@Cnpj", cliente.Cnpj);
            #endregion

            Adicionar(Procedures.CadastraCliente, param);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return ObterTodos(Procedures.ObterTodosCliente);
        }
    }
}
