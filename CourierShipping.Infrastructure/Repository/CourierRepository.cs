using CourierShipping.Data;
using CourierShipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierShipping.Core.Repository
{
    public class CourierRepository : ICourierRepository
    {
        private readonly CourierShippingContext _courierShippingContext;

        public CourierRepository(CourierShippingContext courierShippingContext)
        {
            _courierShippingContext = courierShippingContext;
        }

        public async Task<CouriersOffer> Create(CouriersOffer couriers)
        {
            if (couriers is null) throw new Exception();

            await _courierShippingContext.AddAsync(couriers);
            await _courierShippingContext.SaveChangesAsync();

            return couriers;
        }
    }
}
