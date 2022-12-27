using CourierShipping.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierShipping.Data
{
    public class CourierShippingContext : DbContext
    {
        public CourierShippingContext(DbContextOptions<CourierShippingContext>
                options) : base(options)
        {

        }

        public virtual DbSet<CouriersOffer> CouriersOffer { get; set; }
    }
}
