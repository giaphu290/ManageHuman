using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.CreateAndReponse
{
    public class PositionCreateDTO
    {
        [Required(ErrorMessage = "Name of position is required.")]
        public string NameOfPosition { get; set; }
        [Required(ErrorMessage = "Salary is required.")]
        public double Salary { get; set; }
        [Required(ErrorMessage = "FromDate is required.")]
        public DateTime FromDate { get; set; }
        [Required(ErrorMessage = "ToDate is required.")]
        public DateTime ToDate { get; set; }
    }
}
