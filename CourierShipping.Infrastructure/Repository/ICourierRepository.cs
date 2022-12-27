
using CourierShipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierShipping.Core.Repository
{
    public interface ICourierRepository
    {
        Task<CouriersOffer> Create(CouriersOffer couriers);
    }
}
