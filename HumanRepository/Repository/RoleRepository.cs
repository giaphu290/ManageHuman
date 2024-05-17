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
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleDAO roleDAO;
        public RoleRepository() {
        roleDAO = new RoleDAO();
        
        }
        public void AddRoles(Role role)
        {
            roleDAO.AddNewRoles(role);
        }

        public Role GetRoleByID(Guid Id)
        {
            return roleDAO.GetRoleById(Id); 
        }

        public List<Role> GetRoles()
        {
           return roleDAO.GetRoles();

        }

        public void RemoveRolebyId(Guid Id)
        {
            roleDAO.DeleteRole(Id);
        }

        public void UpdateRole(Role role)
        {
            roleDAO.UpdateRole(role);
        }
    }
}
