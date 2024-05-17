using Entity.Dbcontext;
using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class ClaimDAO
    {
        private readonly HumanDbcontext _context;
        public ClaimDAO()
        {

            _context = new HumanDbcontext();
        }
        public List<Claim> GetClaims()
        {
            try
            {
                return _context.Claims.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void AddNewClaim(Claim claim)
        {
            try
            {
                _context.Add(claim);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void UpdateClaim(Claim claim)
        {
            try
            {
                var a = _context.Claims!.SingleOrDefault(c => c.ClaimID == claim.ClaimID);

                _context.Entry(a).CurrentValues.SetValues(claim);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteClaim(Guid id)
        {
            try
            {
                var data = _context.Claims.Where(x => x.ClaimID == id);
                _context.Remove(data);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Claim GetClaimById(Guid id)
        {
            try
            {
                var data = _context.Claims.SingleOrDefault(c => c.ClaimID == id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

