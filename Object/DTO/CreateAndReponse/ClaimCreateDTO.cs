using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.CreateAndReponse
{
    public class ClaimCreateDTO
        
    {
        private string sub;
        private string? v;

        public ClaimCreateDTO(string sub, string? v)
        {
            this.sub = sub;
            this.v = v;
        }

        [Required(ErrorMessage = "Claim type is required.")]
        public string ClaimType { get; set; }
        [Required(ErrorMessage = "Claim value is required.")]
        public string ClaimValue { get; set; }
    }
}
