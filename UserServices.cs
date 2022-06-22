using MongoDB.Driver;

namespace Users.Core
{


    public class UserServices : IUSerServices
    {
        private readonly IMongoCollection<User> _users;

        public UserServices(IDBClient dbclient)
        {
            _users = dbclient.GetUserCollection();
        }

        public User AddUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(user => user.id == id);
        }

        public User GetUser(string id) => _users.Find(User => User.id == id).First();
        

        public List<User> GetUsers() => _users.Find(User => true).ToList();

        public User UpdateUser(User user)
        {
            GetUser(user.id);

            _users.ReplaceOne(u => u.id == user.id,user);
            return user;
        }
    }
}