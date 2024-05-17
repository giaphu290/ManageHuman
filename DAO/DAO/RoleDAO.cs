using Entity.Dbcontext;
using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
    public class RoleDAO
    {
        private readonly HumanDbcontext _context;
        public RoleDAO() { 
        
        _context = new HumanDbcontext();
        }
        public List<Role> GetRoles()
        {
            try
            {
                return _context.Roles.ToList();
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            
            }
        }
        public void AddNewRoles(Role role)
        {
            try
            {
                _context.Add(role);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }

        }
        public void UpdateRole(Role role)
        {
            try
            {
                var a = _context.Roles!.SingleOrDefault(c => c.RoleID == role.RoleID);

                _context.Entry(a).CurrentValues.SetValues(role);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteRole(Guid id)
        {
            try
            {
                var data = _context.Roles.Where(x => x.RoleID == id);
                _context.Remove(data);
                    _context.SaveChanges();
            }catch (Exception ex)
            {
                    throw new Exception(ex.Message);
            }
        }
        public Role GetRoleById(Guid id)
        {
            try
            {
                var data = _context.Roles.SingleOrDefault(c => c.RoleID == id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
