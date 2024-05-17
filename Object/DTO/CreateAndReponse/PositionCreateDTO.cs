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

    }
}
