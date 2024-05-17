using DAO.DAO;
using Entity.Object;
using HumanRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanRepository.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly PositionDAO positionDAO;
        public PositionRepository()
        {
            positionDAO = new PositionDAO();
        }
        public void AddPosition(Position position)
        {
            positionDAO.AddNewPositions(position);
        }

        public List<Position> GetFormTypes()
        {
            return positionDAO.GetPositions();
        }

        public Position GetPositionByID(Guid Id)
        {
           return positionDAO.GetPositionById(Id);
        }

        public void RemovePositionbyID(Guid Id)
        {
           positionDAO.DeletePosition(Id);
        }

        public void UpdatePosition(Position position)
        {
            positionDAO.UpdatePosition(position);
        }
    }
}
