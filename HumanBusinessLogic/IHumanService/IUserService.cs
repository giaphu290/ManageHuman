using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanService.IHumanService
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public void AddNewUser(User user);
        public User CheckLogin(string username, string password);
        public void UpdateUser(User user);
        public void DeleteUserById(Guid Id);
        public User GetUserByID(Guid Id);
        
    }
}
