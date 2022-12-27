using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierShipping.Data.Entities
{
    public class CouriersOffer
    {
        public int Id { get; set; }
        public string CourierName { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public double PackagePrice { get; set; }
    }
}
