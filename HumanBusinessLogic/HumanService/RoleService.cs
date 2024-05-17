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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepo;
        public RoleService(IRoleRepository roleRepo)
        {
            _roleRepo = roleRepo;
        }
        public void AddRoles(Role role)
        {
            _roleRepo.AddRoles(role);
        }

        public Role GetRoleByID(Guid Id)
        {
            return _roleRepo.GetRoleByID(Id);
        }

        public List<Role> GetRoles()
        {
            return _roleRepo.GetRoles();
        }

        public void RemoveRolebyId(Guid Id)
        {
           _roleRepo.RemoveRolebyId(Id);
        }

        public void UpdateRole(Role role)
        {
           _roleRepo.UpdateRole(role);
        }
    }
}
