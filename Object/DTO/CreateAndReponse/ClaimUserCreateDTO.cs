using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.CreateDTO
{
    public class ClaimUserCreateDTO
    {
        [Required(ErrorMessage = "Id is required.")]
        public int? Id { get; set; }
        [Required(ErrorMessage = "User is required.")]
        public Guid UserID { get; set; }
        [Required(ErrorMessage = "Claim is required.")]
        public Guid ClaimID { get; set; }
    }
}
