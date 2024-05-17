using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanService.IHumanService
{
    public interface IClaimUserService
    {
        public List<ClaimUser> GetClaimUsers();
        public void AddClaimUser(ClaimUser claimUser);
        public void RemoveClaimUserbyID(int Id);
        public void UpdateClaimUser(ClaimUser claimUser);
        public ClaimUser GetClaimUserByID(int Id);
    }
}
