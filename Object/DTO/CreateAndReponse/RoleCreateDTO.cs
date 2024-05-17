using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.CreateAndReponse
{
    public class RoleCreateDTO
    {
        [Required(ErrorMessage = "Role name is required.")]
        public string RoleName { get; set; }
    }
}
