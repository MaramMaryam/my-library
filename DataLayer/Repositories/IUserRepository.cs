using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetAll();
        User GetById(int userId);
        bool InserUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool DeleteUser(int userId);
        void save();
        //IEnumerable<Page> TopBooks(int take = 4);
        //IEnumerable<Page> PagesInSlider();
        //IEnumerable<Page> LastBooks(int take = 3);
        //IEnumerable<Page> ShowPageByGroupId(int groupId);
        IEnumerable<User> SearchUser(string search);
    }
}
