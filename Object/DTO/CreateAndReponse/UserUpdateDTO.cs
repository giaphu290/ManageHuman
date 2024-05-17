using Entity.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.CreateAndReponse
{
    public class UserUpdateDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }    
        public string? Name { get; set; }
        public long? PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? EmailAddress { get; set; }
        public Guid? PositionID { get; set; }
        public Guid? RoleID { get; set; }

    }
}
