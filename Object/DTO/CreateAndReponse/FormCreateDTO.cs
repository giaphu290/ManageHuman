using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace BusinessObject.DTO.CreateDTO
{
    public class FormCreateDTO
    {

        [Required(ErrorMessage = "Type form is required.")]
        public Guid TypeID { get; set; }
        [Required(ErrorMessage = "Tille is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Desciption is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Attachments is required.")]
        public IFormFile Attachments { get; set; }


    }
}
