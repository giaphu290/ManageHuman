using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Object
{
    public class Form
    {
        public Guid FormID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Attachments { get; set; }

        public DateTime DateCreate { get; set; }
        public Guid UsersID { get; set; }
 
        public Guid TypeID { get; set; }
        //realtionship
        public  User Users { get; set; }
        public  FormType FormType { get; set; }
    }
}
