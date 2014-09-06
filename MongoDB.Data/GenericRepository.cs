namespace MongoDb.Data
{
    using MongoDb.Models;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using System.Collections.Generic;
    using System.Linq;

    public class GenericRepository<T> : IGenericRepository<T> where T : MongoIDs
    {
        private MongoDatabase database;
        private MongoCollection<T> collection;
        private readonly string connectionString =
                "mongodb://user:123@ds033740.mongolab.com:33740/mongorepository";

        private void GetDatabase()
        {
           
            var client = new MongoClient(this.connectionString);
            var server = client.GetServer();

            database = server.GetDatabase("mongorepository");
        }

        private IMongoQuery FindIdWithQuery(string id)
        {
            var query = Query<T>.EQ(x => x.Id, id);

            return query;
        }

        /// <summary>
        /// Return MongoCollection<T>
        /// </summary>
        /// <returns>MongoCollection<T></returns>
        public MongoCollection<T> GetCollection()
        {
            this.GetDatabase();
            collection = database.GetCollection<T>(typeof(T).Name + "s");

            return collection;
        }

        /// <summary>
        /// Add new Entity
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            
            this.GetCollection().Insert(entity);

        }

        /// <summary>
        /// Return  All object in collection
        /// </summary>
        /// <returns>Return IEnumerable<T></returns>
        public IEnumerable<T> GetAll()
        {
            var coll = this.GetCollection().FindAll();

            return coll;
        }

        /// <summary>
        /// Find entity by "_id"
        /// </summary>
        /// <param name="id">Mongo string "_Id"</param>
        /// <returns>TEntiy object</returns>
        public T GetById(string id )
        {

           var query = this.FindIdWithQuery(id);
           var entity = this.GetCollection().FindOne(query);

           return entity;

        }

        /// <summary>
        /// Detele object by "_id"
        /// </summary>
        /// <param name="id">Mongo string "_Id"</param>
        public void Delete(string id)
        {

            var query = this.FindIdWithQuery(id);

            this.GetCollection().Remove(query);
        }

       /// <summary>
       /// Update Mongo entity
        /// </summary>
        /// <param name="id">Mongo string "_Id" of the object you want to change </param>
        /// <param name="update">The update to perform on the matching document.</param>
        public void Update(string id, IMongoUpdate update)
        {
            var query = this.FindIdWithQuery(id);

            this.GetCollection().Update(query,update);
        }
    }
}
