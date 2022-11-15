using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simple.EntityFrameworkCore.Core;
using Simple.EntityFrameworkCore.Core.Base;

namespace Simpie.EntityFrameworkCore.Core
{
    public class Repository<IEntity,IDbContext> : IRepository<IEntity> 
    where IEntity : Entity
    where IDbContext:MasterDbContext<IDbContext>
    {
        protected readonly IDbContext _dbContext;
        protected readonly DbSet<IEntity> DbSet;

        public Repository(IDbContext dbContext)
        {
            this._dbContext=dbContext;
            this.DbSet=_dbContext.Set<IEntity>();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity=await DbSet.FirstOrDefaultAsync(x=>x.id.Equals(id),cancellationToken:cancellationToken);
            if(entity!=null){
                DbSet.Remove(entity);
            }
        }

        public Task DeleteAsync(IEntity entity, CancellationToken cancellationToken = default)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task DeleteManyAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            var entities=DbSet.Where(x=>ids.Contains(x.id));
            DbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public Task DeleteManyAsync(IEnumerable<IEntity> entities, CancellationToken cancellationToken = default)
        {
            DbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public async Task<IEntity> FirstAsync(Expression<Func<IEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstAsync(predicate,cancellationToken:cancellationToken);
        }

        public async Task<IEntity?> FirstOfDefaultAsync(Expression<Func<IEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(predicate,cancellationToken:cancellationToken);
        }

        public async Task<List<IEntity>> GetListAsync(Expression<Func<IEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<IQueryable<IEntity>> GetQueryAsync(Expression<Func<IEntity, bool>> predicate)
        {
            return await Task.FromResult(DbSet.Where(predicate));
        }

        public async Task<IQueryable<IResult>> GetQueryAsync<IResult>(Expression<Func<IEntity, bool>> predicate, Expression<Func<IEntity, IResult>> selector)
        {
            return await Task.FromResult(DbSet.Where(predicate).Select(selector));
        }

        public async Task<IEntity> InsertAsync(IEntity entity, CancellationToken cancellationToken = default)
        {
           
            return (await DbSet.AddAsync(entity)).Entity;
        }

        public async Task InsertManyAsync(IEnumerable<IEntity> entities, CancellationToken cancellationToken = default)
        {
            
            await DbSet.AddRangeAsync(entities,cancellationToken);
        }

        public async Task<bool> isExistAsync(Expression<Func<IEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(predicate,cancellationToken)>0;
        }

        public async Task<IEntity> UpdateAsync(IEntity entity)
        {
            DbSet.Update(entity);
            return await Task.FromResult(entity);
        }

        public Task UpdateManyAsync(IEnumerable<IEntity> entities)
        {
            DbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }
    }
}