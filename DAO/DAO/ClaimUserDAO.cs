using Entity.Dbcontext;
using Entity.Object;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class ClaimUserDAO
    {
        private readonly HumanDbcontext _context;
        public ClaimUserDAO()
        {

            _context = new HumanDbcontext();
        }
        public List<ClaimUser> GetClaimUsers()
        {
            try
            {
                return _context.ClaimUsers.Include(x => x.User).Include(x => x.Claim).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void AddNewClaimUser(ClaimUser claimUser)
        {
            try
            {
                _context.Add(claimUser);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void UpdateClaimUser(ClaimUser claimUser)
        {
            try
            {
                var a = _context.ClaimUsers!.SingleOrDefault(c => c.Id == claimUser.Id);

                _context.Entry(a).CurrentValues.SetValues(claimUser);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteClaimUser(int id)
        {
            try
            {
                var data = _context.ClaimUsers.Where(x => x.Id == id);
                _context.Remove(data);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ClaimUser GetClaimUserById(int Id)
        {
            try
            {
                var data = _context.ClaimUsers.SingleOrDefault(c => c.Id == Id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

