namespace MongoDb.Models
{
    using System;

    public class User : MongoIDs
    {

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public DateTime LogOn { get; set; }

    }
}
