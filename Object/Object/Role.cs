using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Object
{
    public class Role
    {
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public virtual List<User>? Users { get; set; }
    }
}
