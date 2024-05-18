using Entity.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.CreateAndReponse
{
    public class UserPositionUpdateDTO
    {
        public Guid UserPositionId { get; set; }
        public string Salary { get; set; }
        public DateTimeOffset timestart { get; set; }
        public DateTimeOffset timeend { get; set; }
        public bool Paid { get; set; }
        public Guid UserID { get; set; }
        public Guid PositionID { get; set; }
    }
}
