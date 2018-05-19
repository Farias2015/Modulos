using Dapper;
using Modulos.IO.Domain.Core.Models;
using Modulos.IO.Domain.Interfaces;
using Modulos.IO.Infra.Data.Context;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace Modulos.IO.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        private readonly ApplicationDbContext Db;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            Db = applicationDbContext;
        }

        public virtual void Adicionar(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            Db.RowsAffected = Db.Database.GetDbConnection().Execute(nomeProcedure, param, commandType: commandType);
        }

        public virtual void Atualizar(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            Db.RowsAffected = Db.Database.GetDbConnection().Execute(nomeProcedure, param, commandType: commandType);
        }

        public virtual IEnumerable<TEntity> Buscar(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            return Db.Database.GetDbConnection().Query<TEntity>(nomeProcedure, param, commandType: commandType);
        }

        public virtual TEntity ObterPorId(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            return Db.Database.GetDbConnection().Query<TEntity>(nomeProcedure, param, commandType: commandType).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> ObterTodos(string nomeProcedure, CommandType commandType = CommandType.StoredProcedure)
        {
            return Db.Database.GetDbConnection().Query<TEntity>(nomeProcedure, commandType: commandType);
        }

        public virtual IEnumerable<TEntity> ObterPorCriterio(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            return Db.Database.GetDbConnection().Query<TEntity>(nomeProcedure, param, commandType: commandType);
        }

        public virtual void Remover(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            Db.RowsAffected = Db.Database.GetDbConnection().Execute(nomeProcedure, param, commandType: commandType);
        }

        public virtual TEntity Login(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            return Db.Database.GetDbConnection().Query<TEntity>(nomeProcedure, param, commandType: commandType).FirstOrDefault();
        }

        public IEnumerable<Claim> GetClaims(string nomeProcedure, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        {
            return Db.Database.GetDbConnection().Query<Claim>(nomeProcedure, param, commandType: commandType);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
