using BusinessObject.Object;
using Entity.Dbcontext;
using Entity.Object;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanDAO.DAO
{
    public class UserPositionDAO
    {
        private readonly HumanDbcontext _context;
        public UserPositionDAO()
        {
            _context = new HumanDbcontext();
        }
        public List<UserPosition> GetSalarys()
        {
            try
            {
                return _context.userPositions.Include(x => x.User).Include(x => x.Position).ToList();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<UserPosition> GetSalaryByUser(Guid id)
        {
            try
            {

              return _context.userPositions.Where(c => c.UserID == id).ToList();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public UserPosition GetUserPositionById(Guid id)
        {
            try
            {

                var data = _context.userPositions.SingleOrDefault(c => c.UserID == id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AddUserPosition(UserPosition userPosition)
        {
            try
            {

                _context.Add(userPosition);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateUserPosition(UserPosition userPosition)
        {
            try
            {
                var a = _context.userPositions!.SingleOrDefault(c => c.UserPositionId == userPosition.UserPositionId);

                _context.Entry(a).CurrentValues.SetValues(userPosition);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool UpdateStatusSalary(UserPosition userPosition)
        {
            var _salary = _context.userPositions.FirstOrDefault(c => c.UserPositionId.Equals(userPosition.UserPositionId));


            if (_salary == null)
            {
                return false;
            }
            else
            {
                _salary.Paid = false;
                _context.Entry(_salary).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }
    }
}
