using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanRepository.IRepository
{
    public interface IClaimRepository
    {
        public List<Claim> GetClaims();
        public void AddClaim(Claim claim);
        public void RemoveClaimbyID(Guid Id);
        public void UpdateClaim(Claim claim);
        public Claim GetClaimByID(Guid Id);
    }
}
