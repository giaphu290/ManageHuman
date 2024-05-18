using Entity.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.CreateAndReponse
{
    public class UserPositionCreateDTO
    {
        [Required(ErrorMessage = "Salary is required.")]
        public string Salary { get; set; }
        [Required(ErrorMessage = "Paid is required.")]
        public bool Paid { get; set; }
        [Required(ErrorMessage = "UserId is required.")]
        public Guid UserID { get; set; }
        [Required(ErrorMessage = "PositionID is required.")]
        public Guid PositionID { get; set; }
    }
}
