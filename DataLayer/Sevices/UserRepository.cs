using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserRepository : IUserRepository
    {
        private MyCmsContext db;
        public UserRepository(MyCmsContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }
        public User GetById(int userId)
        {
            return db.Users.Find(userId);
        }

        public bool InserUser(User user)
        {
            try
            {
                db.Users.Add(user);
                return true;
            }
            catch (Exception) { return false; }
        }
        public bool DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();

        }
        public bool DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> SearchUser(string search)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
