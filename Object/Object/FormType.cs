using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Object
{
    public class FormType
    {
        public Guid TypeID { get; set; }
        public string TypeName { get; set; }
        public  List<Form>? Forms { get; set; }
    }
}
