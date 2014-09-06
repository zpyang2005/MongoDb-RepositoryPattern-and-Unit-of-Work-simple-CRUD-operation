namespace MongoDb.Data
{
    using MongoDb.Models;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;

    public class MongoUow : IMongoUow 
    {
        private MongoDatabase database;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();


        public MongoUow()
        {
            
        }


        public IGenericRepository<Message> Messages
        {
            get { return this.GetRepository<Message>(); }
        }

        public IGenericRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }



        private IGenericRepository<T> GetRepository<T>() where T : MongoIDs
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type));
            }

            return (IGenericRepository<T>)this.repositories[typeof(T)];
        }


    }
}
