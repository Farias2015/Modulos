using Modulos.IO.Domain.Interfaces;
using Modulos.IO.Infra.Data.Context;

namespace Modulos.IO.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public bool Commit()
        {
            return _context.RowsAffected > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
