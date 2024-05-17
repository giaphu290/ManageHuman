using BusinessObject.DTO;
using DAO.DAO;
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
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepo;
        public ClaimService(IClaimRepository claimRepo)
        {
            _claimRepo = claimRepo;
        }
        List<Claim> IClaimService.GetClaims()
        {
            return _claimRepo.GetClaims();
        }

        public void AddClaim(Claim claim)
        {
            _claimRepo.AddClaim(claim);
        }
        public Claim GetClaimByID(Guid Id)
        {
            return _claimRepo.GetClaimByID(Id);
        }

        public void UpdateClaim(Claim claim)
        {
           _claimRepo.UpdateClaim(claim);
        }

        public void RemoveClaimbyID(Guid Id)
        {
            _claimRepo.RemoveClaimbyID(Id);
        }
    }
}
