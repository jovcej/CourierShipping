using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierShipping.Test
{
    public class OfferDto
    {
        public string CourierName { get; set; }
        public double PackageWidth { get; set; }
        public double PackageHeight { get; set; }
        public double PackageDepth { get; set; }
        public double PackageWeight { get; set; }
        public double OfferPrice { get; set; }
    }
}
