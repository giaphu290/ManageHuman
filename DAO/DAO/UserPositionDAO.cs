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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<UserPosition> GetSalaryByUser(Guid id)
        {
            try
            {

                return _context.userPositions.Include(x => x.Position).Include(x => x.User).Where(c => c.UserID == id).ToList();

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
            }
            catch (Exception ex)
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
                _salary.Paid = true;
                _context.Entry(_salary).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }
        public bool UpdateTotalSalary(double n, Guid userId)
        {
            try
            {
                var userPositions = _context.userPositions
                    .Where(up => up.UserID == userId && up.Paid ==false)
                    .ToList();

                if (userPositions == null)
                {
                    return false;
                }

                foreach (var userPosition in userPositions)
                {
                    double rate = 22 - n;
                    if (double.TryParse(userPosition.Salary, out double salary))
                    {
                        double rateMoney = salary / rate;
                        double newSalary = salary - n * rateMoney;
                        if (newSalary < 0)
                        {
                            newSalary = 0;
                        }
                        userPosition.Salary = newSalary.ToString();
                        _context.SaveChanges();
                    }

                }
                
                return true;
            }
            catch (Exception ex)
            {  
                Console.WriteLine($"Error updating total salary: {ex.Message}");
                return false;
            }
        }
    }
}
