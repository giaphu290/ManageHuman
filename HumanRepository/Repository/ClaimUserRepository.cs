using DAO.DAO;
using Entity.Object;
using HumanRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanRepository.Repository
{
    public class ClaimUserRepository : IClaimUserRepository
    {
        private readonly ClaimUserDAO _claimUserDAO;
        public ClaimUserRepository()
        {
            _claimUserDAO = new ClaimUserDAO();
        }

        public void AddClaimUser(ClaimUser claimUser)
        {
            _claimUserDAO.AddNewClaimUser(claimUser);
        }

        public ClaimUser GetClaimUserByID(int Id)
        {
            return _claimUserDAO.GetClaimUserById(Id);
        }

        public List<ClaimUser> GetClaimUsers()
        {
            return _claimUserDAO.GetClaimUsers();
        }

        public void RemoveClaimUserbyID(int Id)
        {
            _claimUserDAO.DeleteClaimUser(Id);
        }

        public void UpdateClaimUser(ClaimUser claimUser)
        {
            _claimUserDAO.UpdateClaimUser(claimUser);
        }
    }
}
