using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierShipping.Core.Services.Models
{
    public class CheckOffer
    {
        [Required]
        public string PackageWidth { get; set; }
        [Required]
        public string PackageHeight { get; set; }
        [Required]
        public string PackageDepth { get; set; }
        [Required]
        public string PackageWeight { get; set; }
    }
}
