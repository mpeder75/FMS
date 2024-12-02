using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitSlipService.Infrastructure
{
    using ExitslipService.Application.UnitOfWork;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using System.Data;

    namespace OnionDemo.Infrastructure
    {
        public class UnitOfWork<T>(T db) : IUnitOfWork
            where T : DbContext
        {
            private readonly DbContext _db = db;
            private IDbContextTransaction? _transaction;

            void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
            {
                if (_db.Database.CurrentTransaction != null) return;
                _transaction = _db.Database.BeginTransaction(isolationLevel);
            }

            void IUnitOfWork.Commit()
            {
                if (_transaction == null)
                    throw new InvalidOperationException("no active transaction to commit");
                _transaction.Commit();
                _transaction.Dispose();
            }

            void IUnitOfWork.Rollback()
            {
                if (_transaction == null)
                    throw new InvalidOperationException("no active transaction to commit");
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
            public byte[] ConvertHexToByteArray(string hex)
            {
                return Enumerable.Range(0, hex.Length / 2)
                                 .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
                                 .ToArray();
            }
        }
    }

}
