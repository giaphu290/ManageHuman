using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Object
{
    public class Position
    {
        public Guid PositionID { get; set; }
        public string NameOfPosition { get; set; }
        public List<UserPosition> UserPositions { get; set; }

    }
}
