namespace MongoDb.Data
{
    using MongoDb.Models;
    using MongoDB.Driver;
    using System.Collections.Generic;

    public interface IGenericRepository<T> where T : MongoIDs
    {
        MongoCollection<T> GetCollection();

        IEnumerable<T> GetAll();

        void Insert(T entity);

        T GetById(string id);

        void Delete(string id);

        void Update(string id, IMongoUpdate update);

       

        

    }
}
