using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class UserPositionDTO
    {
        public Guid UserPositionId { get; set; }
        public string Salary { get; set; }
        public DateTimeOffset timestart { get; set; }
        public DateTimeOffset timeend { get; set; }
        public bool Paid { get; set; }
        public string username { get; set; }
        public string position { get; set; }
        public bool paid { get; set; }

    }
}
