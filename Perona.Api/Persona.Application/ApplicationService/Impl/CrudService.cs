using Persona.Domain;
using Persona.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persona.Application.ApplicationService.Impl
{
    public class CrudService<TEntity, TId> : ICrudService<TEntity, TId>
         where TEntity : Entity<TId>, new()
        where TId : IComparable, IComparable<TId>
    {


        private readonly IRepository<TEntity, TId> repository;

        
        public CrudService(IRepository<TEntity, TId> repository)
        {
            this.repository = repository;
        }

        public bool Delete(TEntity entity)
        {
            return repository.Delete(entity);
        }

        public Task<bool> DeleteAsync(TEntity entity)
        {
            return repository.DeleteAsync(entity);
        }

        public bool DeleteById(TId id)
        {
            return  repository.DeleteById(id);
        }

        public Task<bool> DeleteByIdAsync(TId id)
        {
            return repository.DeleteByIdAsync(id);
        }

        public IEnumerable<TEntity> FindByAll()
        {
            return repository.FindByAll();
        }

        public Task<IEnumerable<TEntity>> FindByAllAsync()
        {
            return repository.FindByAllAsync();
        }

        public IEnumerable<TEntity> FindByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return repository.FindByExpression(predicate);
        }

        public Task<IEnumerable<TEntity>> FindByExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return repository.FindByExpressionAsync(predicate);
        }

        public TEntity FindById(TId id)
        {
            return repository.FindById(id);

        }

        public Task<TEntity> FindByIdAsync(TId id)
        {
            return repository.FindByIdAsync(id);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return repository.FirstOrDefault(predicate);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return repository.FirstOrDefaultAsync(predicate);
        }

        public TEntity Insert(TEntity entity)
        {
            return repository.Insert(entity);
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            return repository.InsertAsync(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return repository.Update(entity);
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            return repository.UpdateAsync(entity);
        }
    }
}
