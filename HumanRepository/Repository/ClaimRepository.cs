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
    public class ClaimRepository : IClaimRepository
    {
        private readonly ClaimDAO claimDAO;
        public ClaimRepository()
        {
            claimDAO = new ClaimDAO();
        }
        public void AddClaim(Claim claim)
        {
            claimDAO.AddNewClaim(claim);
        }

        public Claim GetClaimByID(Guid Id)
        {
            return claimDAO.GetClaimById(Id);
        }

        public List<Claim> GetClaims()
        {
            return claimDAO.GetClaims();
        }

        public void RemoveClaimbyID(Guid Id)
        {
            claimDAO.DeleteClaim(Id);
        }

        public void UpdateClaim(Claim claim)
        {
            claimDAO.UpdateClaim(claim);
        }
    }
}
