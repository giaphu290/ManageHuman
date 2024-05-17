using BusinessObject.Object;
using HumanRepository.IRepository;
using HumanService.IHumanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanService.HumanService
{
    public class UserPositionService : IUserPositionService
    {
        private readonly IUserPositionRepository _repo;
        public UserPositionService(IUserPositionRepository repo)
        {
            _repo = repo;
        }

        public void AddUserPosition(UserPosition userPosition)
        {
            _repo.AddUserPosition(userPosition);
        }

        public List<UserPosition> GetSalaryByUser(Guid Id)
        {
            return _repo.GetSalaryByUser(Id);
        }

        public List<UserPosition> GetSalarys()
        {
            return _repo.GetSalarys();
        }

        public UserPosition GetUserPositionById(Guid Id)
        {
            return _repo.GetUserPositionById(Id);
        }

        public bool UpdateStatusSalary(UserPosition userPosition)
        {
            return _repo.UpdateStatusSalary(userPosition);
        }

        public bool UpdateTotalSalary(int id, Guid id)
        {
            return _repo.UpdateTotalSalary(id, id);
        }

        public void UpdateUserPosition(UserPosition userPosition)
        {
            _repo.UpdateUserPosition(userPosition);
        }

    }
}
