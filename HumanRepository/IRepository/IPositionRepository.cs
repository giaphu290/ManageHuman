using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanRepository.IRepository
{
    public interface IPositionRepository
    {
        public List<Position> GetFormTypes();
        public void AddPosition(Position position);
        public void RemovePositionbyID(Guid Id);
        public void UpdatePosition(Position position);
        public Position GetPositionByID(Guid Id);
    }
}
