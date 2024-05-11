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
        public List<Role> GetRoles()
        {
            var _context = new HumanDbcontext();
            return _context.Roles.ToList();
        }
    }
}
