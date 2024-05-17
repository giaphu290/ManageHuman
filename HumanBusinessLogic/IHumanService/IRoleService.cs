using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanService.IHumanService
{
    public interface IRoleService
    {
        public List<Role> GetRoles();
        public void AddRoles(Role role);
        public void RemoveRolebyId(Guid Id);
        public void UpdateRole(Role role);
        public Role GetRoleByID(Guid Id);
    }
}
