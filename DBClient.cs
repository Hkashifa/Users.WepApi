using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Core
{
    public class DBClient : IDBClient
    {
        //here we create our client,from which we get our database,
        //and from there we get our collection
        private readonly IMongoCollection<User>_users;
        public DBClient(IOptions<UserDBConfig> UserDbConfig)
        {
            var client = new MongoClient(UserDbConfig.Value.CONNECTION_STRING);
            var database = client.GetDatabase(UserDbConfig.Value.Database_Name);
            _users = database.GetCollection<User>(UserDbConfig.Value.User_Collection_Name); 
        }
        public IMongoCollection<User> GetUserCollection()
        {
            throw new NotImplementedException();
        }
    }
}
