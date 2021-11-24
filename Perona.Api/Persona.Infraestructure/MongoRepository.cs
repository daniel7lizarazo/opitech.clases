using MongoDB.Bson;
using MongoDB.Driver;
using Persona.Domain;
using Persona.Domain.Attributes;
using Persona.Domain.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Persona.Infraestructure
{
    public class MongoRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>, new()
        where TId : IComparable, IComparable<TId>
    {

        private readonly IMongoCollection<TEntity> mongoCollection;


        public MongoRepository(string host, string dbName)
        {
            var _client = new MongoClient(host);
            mongoCollection = _client.GetDatabase(dbName).GetCollection<TEntity>(typeof(TEntity).GetCustomAttribute<EntityAttribute>()?.CollectionName ?? typeof(TEntity).Name);
        }

        public bool Delete(TEntity entity)
        {
            return DeleteById(entity.Id);
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return await DeleteByIdAsync(entity.Id);
        }

        public bool DeleteById(TId id)
        {
          var result =   mongoCollection.DeleteOne(it => it.Id.Equals(id));
          return result.DeletedCount >= 1;
        }

        public async Task<bool> DeleteByIdAsync(TId id)
        {
            var result =await mongoCollection.DeleteOneAsync(it => it.Id.Equals(id));
            return result.DeletedCount >= 1;
        }

        public IEnumerable<TEntity> FindByAll()
        {
            return mongoCollection.Find(new BsonDocument()).ToEnumerable();
        }

        public async Task<IEnumerable<TEntity>> FindByAllAsync()
        {
            return (await mongoCollection.FindAsync(new BsonDocument())).ToEnumerable();
        }

        public IEnumerable<TEntity> FindByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return mongoCollection.Find(predicate).ToEnumerable();
        }

        public async Task<IEnumerable<TEntity>> FindByExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return (await mongoCollection.FindAsync(predicate)).ToEnumerable();
        }

        public TEntity FindById(TId id)
        {
            return mongoCollection.Find(it=> it.Id.Equals(id)).FirstOrDefault();
        }

        public async Task<TEntity> FindByIdAsync(TId id)
        {
            return  (await mongoCollection.FindAsync(it => it.Id.Equals(id))).FirstOrDefault();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return mongoCollection.Find(predicate).FirstOrDefault();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return (await mongoCollection.FindAsync(predicate)).FirstOrDefault();
        }

        public TEntity Insert(TEntity entity)
        {
           mongoCollection.InsertOne(entity);
           return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await mongoCollection.InsertOneAsync(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (Delete(entity))
            {
                return Insert(entity);
            }
            return default;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (await DeleteAsync(entity))
            {
                return await InsertAsync(entity);
            }
            return default;
        }
    }
}