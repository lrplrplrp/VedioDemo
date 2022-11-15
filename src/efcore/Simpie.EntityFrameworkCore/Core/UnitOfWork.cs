using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Simple.EntityFrameworkCore.Core;
using Simple.EntityFrameworkCore.Core.Base;

namespace Simpie.EntityFrameworkCore.Core
{
    public class UnitOfWork<IDbContext> : IUnitOfWork
        where IDbContext : MasterDbContext<IDbContext>, IDisposable
    {


        public bool IsDisposable { get;private set; }
        public bool IsCompleted { get;private set; }

        public IDbContext _dbContext { get; set; }

        public UnitOfWork(IDbContext dbContext)
        {
            this._dbContext=dbContext;
        }
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            IsCompleted=false;
            await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if(IsCompleted){
                return;
            }

            IsCompleted=true;
            ApplyChangeConventions();
            try
            {
                //提交事务
                await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                await _dbContext.Database.CommitTransactionAsync(cancellationToken).ConfigureAwait(false);

            }
            catch (Exception)
            {
                //发生异常回滚事务
                await RollbackTransactionAsync(cancellationToken).ConfigureAwait(false);
                throw;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.RollbackTransactionAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyChangeConventions();
            return await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        private void ApplyChangeConventions(){
            _dbContext.ChangeTracker.DetectChanges();
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch(entry.State){
                    case EntityState.Added:
                    UnitOfWork<IDbContext>.SetCreation(entry);
                    break;
                }
            }
        }

        private static void SetCreation(EntityEntry entry){
            if(entry.Entity is Entity creator){
                creator.CreateTime=DateTime.Now;
            }
        }
    }
}