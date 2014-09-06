namespace MongoDb.Data
{
    using MongoDb.Models;

    public interface IMongoUow
    {

        IGenericRepository<Message> Messages { get; }

        IGenericRepository<User> Users { get; }

    }

}
