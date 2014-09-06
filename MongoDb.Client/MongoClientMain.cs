namespace MongoDb.Client
{
    using MongoDb.Data;
    using System;
    using MongoDb.Models;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Driver.Builders;

    public class MongoClientMain
    {
        public static void Main()
        {

            MongoUow data = new MongoUow();

           // data.Messages.Insert(new Message { Text = "Hello world !", DateMessage = DateTime.Now });

            string id = "540b071c3af3f809c4c6678e";

            var findById = data.Messages.GetById(id);

            Console.WriteLine(findById.Text);

            //var linqOperating = data.Messages.GetAll().FirstOrDefault(x => x.Text == "Hello world !");

            //Console.WriteLine(linqOperating.DateMessage);

            //var update = Update<Message>.Set(x=> x.Text , "Good day!");

            //data.Messages.Update(id, update);

          //  data.Messages.Delete(id);

        }
    }
}
