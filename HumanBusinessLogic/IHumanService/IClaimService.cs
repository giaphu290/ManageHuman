using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanService.IHumanService
{
    public interface IClaimService
    {
        public List<Claim> GetClaims();
        public void AddClaim(Claim claim);
        public void RemoveClaimbyID(Guid Id);
        public void UpdateClaim(Claim claim);
        public Claim GetClaimByID(Guid Id);
    }
}
