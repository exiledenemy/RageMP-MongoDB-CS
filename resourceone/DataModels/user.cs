using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace DataModels
{
    public class User
    {
        public ObjectId _id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Client { get; set; }
    }
}
