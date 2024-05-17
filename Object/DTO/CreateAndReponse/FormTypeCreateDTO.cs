using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.CreateAndReponse
{
    public class FormTypeCreateDTO

    {
        [Required(ErrorMessage = "Name of form type is required.")]
        public string TypeName { get; set; }
    }
}
