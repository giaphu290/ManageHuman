using BusinessObject.Object;
using System.ComponentModel.DataAnnotations;

namespace Entity.Object
{
    public class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public Guid RoleID { get; set; }
        public virtual Role Roles { get; set; }

        public virtual List<UserPosition> UserPositions { get; set; }

        public virtual List<Form>? Forms { get; set; }
        public virtual List<ClaimUser> ClaimUser { get; set; }


    }
}
