using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanRepository.IRepository
{
    public interface IUserPositionRepository
    {
        public List<UserPosition> GetSalarys();
        public void AddUserPosition(UserPosition userPosition);
        public bool UpdateStatusSalary(UserPosition userPosition);
        public void UpdateUserPosition(UserPosition userPosition);
        public UserPosition GetSalaryByUser(Guid Id);
        public UserPosition GetUserPositionById(Guid Id);
    }
}
