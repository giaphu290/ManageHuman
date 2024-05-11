using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Object
{
    public class Claim
    {
        public Guid ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public List<ClaimUser> ClaimUser { get; set; }
    }
}
