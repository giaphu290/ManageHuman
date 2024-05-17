using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class FormDTO
    {
        public string FullName { get; set; }
        public string TypeName { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Attachments { get; set; }

        public DateTime DateCreate { get; set; }

    

    }
}
