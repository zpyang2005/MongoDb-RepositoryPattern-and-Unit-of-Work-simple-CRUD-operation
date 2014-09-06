using System;
namespace MongoDb.Models
{


    public class Message : MongoIDs
    {


        public string Text { get; set; }

        public DateTime DateMessage { get; set; }

    }
}
