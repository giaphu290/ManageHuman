using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.CreateAndReponse
{
    public class ClaimUserUpdateDTO
    {
        public Guid? UserID { get; set; }

        public Guid? ClaimID { get; set; }
    }
}
