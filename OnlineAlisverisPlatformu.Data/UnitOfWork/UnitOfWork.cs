using Microsoft.EntityFrameworkCore.Storage;
using OnlineAlisverisPlatformu.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisPlatformu.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OSPContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(OSPContext db)
        {
            _db = db;
        }
        public async Task BeginTransaction()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }



        public async Task CommitTransaction()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            _db.Dispose();

        }

        public async Task RollbackTransaction()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
