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
    public class ClaimUserService : IClaimUserService
    {
        private readonly IClaimUserRepository _claimUserRepo;
        public ClaimUserService(IClaimUserRepository claimUserRepo) { _claimUserRepo = claimUserRepo; }
        public void AddClaimUser(ClaimUser claimUser)
        {
            _claimUserRepo.AddClaimUser(claimUser);
        }

        public List<ClaimUser> GetClaimUsers()
        {
           return _claimUserRepo.GetClaimUsers();
        }

        public void RemoveClaimUserbyID(int Id)
        {
            _claimUserRepo.RemoveClaimUserbyID(Id);
        }
        public ClaimUser GetClaimUserByID(int Id)
        {
            return _claimUserRepo.GetClaimUserByID(Id);
        }

        public void UpdateClaimUser(ClaimUser claimUser)
        {
            _claimUserRepo.UpdateClaimUser(claimUser);
        }
    }
}
