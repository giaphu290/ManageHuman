using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Object
{
    public class ClaimUser
    {
        public int? Id { get; set; }
        public Guid UserID { get; set; }

        public Guid ClaimID { get; set; }
        // relation ship
        public User User { get; set; }
        public Claim Claim { get; set; }
    }
}
