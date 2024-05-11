using Entity.Dbcontext;
using Entity.Object;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class UserDAO
    {
        private readonly HumanDbcontext _context;
        public UserDAO()
        {
            _context = new HumanDbcontext();
        }

        public List<User> GetUsers()
        {
            try
            {
                return _context.Users.Include(x => x.Positions.NameOfPosition).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public User CheckLogin(string username, string password)
        {
            return _context.Users.Where(u => (u.UserName!.Equals(username) || u.EmailAddress!.Equals(username)) && u.Password!.Equals(password)).FirstOrDefault();
        }
        public void AddNewUser(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
