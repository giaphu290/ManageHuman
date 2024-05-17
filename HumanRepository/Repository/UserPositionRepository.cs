using BusinessObject.Object;
using DAO.DAO;
using HumanDAO.DAO;
using HumanRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanRepository.Repository
{
    public class UserPositionRepository : IUserPositionRepository
    {
        private readonly UserPositionDAO _dao;
        public UserPositionRepository()
        {
            _dao = new UserPositionDAO();
        }
        public void AddUserPosition(UserPosition userPosition)
        {
            _dao.AddUserPosition(userPosition);
        }

        public List<UserPosition> GetSalaryByUser(Guid Id)
        {
            return _dao.GetSalaryByUser(Id);
        }

        public List<UserPosition> GetSalarys()
        {
            return _dao.GetSalarys();
        }

        public UserPosition GetUserPositionById(Guid Id)
        {
            return _dao.GetUserPositionById(Id);
        }

        public bool UpdateStatusSalary(UserPosition userPosition)
        {
            return _dao.UpdateStatusSalary(userPosition);
        }


        public void UpdateUserPosition(UserPosition userPosition)
        {
            _dao.UpdateUserPosition(userPosition);
        }

        public bool UpdateTotalSalary(int id, Guid id2)
        {
           return _dao.UpdateTotalSalary(id,id2);
        }
    }
}
