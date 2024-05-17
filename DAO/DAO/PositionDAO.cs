using Entity.Dbcontext;
using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class PositionDAO
    {
        private readonly HumanDbcontext _context;
        public  PositionDAO()
        {

            _context = new HumanDbcontext();
        }
        public List<Position> GetPositions()
        {
            try
            {
                return _context.Positions.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public void AddNewPositions(Position position)
        {
            try
            {
                _context.Add(position);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void UpdatePosition(Position position)
        {
            try
            {
                var a = _context.Positions!.SingleOrDefault(c => c.PositionID == position.PositionID);

                _context.Entry(a).CurrentValues.SetValues(position);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeletePosition(Guid id)
        {
            try
            {
                var data = _context.Positions.Where(x => x.PositionID == id);
                _context.Remove(data);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Position GetPositionById(Guid id)
        {
            try
            {
                var data = _context.Positions.SingleOrDefault(c => c.PositionID == id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

