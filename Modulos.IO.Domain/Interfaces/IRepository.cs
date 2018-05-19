using Dapper;
using Modulos.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Modulos.IO.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Adicionar(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        TEntity ObterPorId(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        IEnumerable<TEntity> ObterTodos(string nomeProcedure, CommandType commandType = CommandType.StoredProcedure);
        void Atualizar(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        void Remover(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        IEnumerable<TEntity> Buscar(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        IEnumerable<TEntity> ObterPorCriterio(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
    }
}
