using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.CreateAndReponse
{
    public class FormUpdateDTO
    {
        public Guid? UsersID { get; set; }
        public Guid? TypeID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IFormFile? Attachments { get; set; }
        public DateTime? DateCreate { get; set; }

    }
}
