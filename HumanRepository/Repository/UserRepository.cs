using DAO.DAO;
using Entity.Object;
using HumanRepository.IRepository;

namespace HumanRepository.Repository
{
    public class UserRepository : IUserRepository

    {
        private readonly UserDAO _userDAO;
        public UserRepository()
        {
            _userDAO = new UserDAO();
        }
        public void AddNewUser(User user)
        {
            _userDAO.AddNewUser(user);
        }

        public User CheckLogin(string username, string password)
        {
            return _userDAO.CheckLogin(username, password);
        }

        public void DeleteUserById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByID(Guid Id)
        {
            return _userDAO.GetUserById(Id);
        }

        public List<User> GetUsers()
        {
            return _userDAO.GetUsers();
        }

        public void UpdateUser(User user)
        {
            _userDAO.UpdateUser(user);
        }
    }
}
