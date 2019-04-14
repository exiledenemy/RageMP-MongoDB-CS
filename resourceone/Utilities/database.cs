using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;


namespace Utilities
{
    public class DB
    {
        private static readonly IMongoClient Client = new MongoClient();
        private static readonly IMongoDatabase Database = Client.GetDatabase("XRP");

        public async void Insert<T>(T data)
        // USEAGE:  db.Insert<User>(user);
        {
            try
            {
                var collection = Database.GetCollection<T>(typeof(T).Name);
                await collection.InsertOneAsync(data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async void Update<T>(ObjectId id, string updateFieldName, string updateFieldValue)
        // USEAGE:  db.Update<User>("5cb3463b1d190531ec8d8693", "Email", "abc@123.com");
        {
            try
            { 
                var collection = Database.GetCollection<T>(typeof(T).Name);
                var filter = Builders<T>.Filter.Eq("_id", id);
                var update = Builders<T>.Update.Set(updateFieldName, updateFieldValue);
                await collection.UpdateOneAsync(filter, update);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async void Delete<T>(ObjectId id)
        // USEAGE:  db.Update<User>("5cb3463b1d190531ec8d8693");
        {
            try
            {
                var collection = Database.GetCollection<T>(typeof(T).Name);
                var filter = Builders<T>.Filter.Eq("_id", id);
                await collection.DeleteOneAsync(filter);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<T> GetSingle<T>(string fieldName, string fieldValue)
        // USEAGE:  var result = db.GetSingle<User>("Username", "Bob").Result;
        {
            try
            {
                var collection = Database.GetCollection<T>(typeof(T).Name);
                var filter = Builders<T>.Filter.Eq(fieldName, fieldValue);
                return await collection.Find(filter).SingleAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<T>> GetList<T>(string fieldName, string fieldValue)
        // USEAGE:  var result = db.GetList<User>("Username", "Bob").Result;
        {
            try
            {
                var collection = Database.GetCollection<T>(typeof(T).Name);
                var filter = Builders<T>.Filter.Eq(fieldName, fieldValue);
                return await collection.Find(filter).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
