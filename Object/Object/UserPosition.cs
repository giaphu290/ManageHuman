using Entity.Object;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Object
{
    public class UserPosition
    {
        public Guid UserPositionId { get; set; }
        public string Salary {  get; set; }
        public DateTimeOffset timestart { get; set; }
        public DateTimeOffset timeend { get; set; }
        public bool Paid { get; set; }
        public Guid UserID { get; set; }
        public virtual User User { get; set; }
        public Guid PositionID { get; set; }
        public virtual Position Position { get; set; }
   

    }
}
