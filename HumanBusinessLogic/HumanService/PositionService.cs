using Entity.Object;
using HumanRepository.IRepository;
using HumanService.IHumanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanService.HumanService
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        public void AddPosition(Position position)
        {
            _positionRepository.AddPosition(position);
        }

        public Position GetPositionByID(Guid Id)
        {
            return _positionRepository.GetPositionByID(Id);
        }

        public List<Position> GetPositions()
        {
            return _positionRepository.GetFormTypes();
        }

        public void RemovePositionbyID(Guid Id)
        {
            _positionRepository.RemovePositionbyID(Id);
        }

        public void UpdatePosition(Position position)
        {
            _positionRepository.UpdatePosition(position);
        }
    }
}
