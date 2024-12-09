﻿using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Data;
using FeedbackService.Application.UnitOfWork;

namespace FeedbackService.Infrastructure
{
    public class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        private readonly DbContext _db;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(T db)
        {
            _db = db;
        }

        void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
        {
            if (_db.Database.CurrentTransaction != null) return;
            _transaction = _db.Database.BeginTransaction(isolationLevel);
        }

        void IUnitOfWork.Commit()
        {
            if (_transaction == null) throw new Exception("You must call 'BeginTransaction' before Commit is called");
            _transaction.Commit();
            _transaction.Dispose();
        }

        void IUnitOfWork.Rollback()
        {
            if (_transaction == null) throw new Exception("You must call 'BeginTransaction' before Rollback is called");
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
