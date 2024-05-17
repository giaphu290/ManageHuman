using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class UserDTO
    {
          public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public string role { get; set; }


    }
}
