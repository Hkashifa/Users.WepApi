using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Core { 
    public interface IDBClient
    {
        IMongoCollection<User> GetUserCollection();
    }
}
