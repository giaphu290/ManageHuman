using AutoMapper;
using Entity.Object;
using HumanRepository.IRepository;
using HumanService.IHumanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanService.HumanService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
          
        }
        public List<User> GetUsers()
        {
            return  _userRepository.GetUsers();
        }

        public void AddNewUser(User user)
        {
            _userRepository.AddNewUser(user);
        }

        public User CheckLogin(string username, string password)
        {
            return _userRepository
                .CheckLogin(username, password);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUserById(Guid Id)
        {
            _userRepository.DeleteUserById(Id);
        }

        public User GetUserByID(Guid Id)
        {
            return _userRepository.GetUserByID(Id);
        }
    }
}
