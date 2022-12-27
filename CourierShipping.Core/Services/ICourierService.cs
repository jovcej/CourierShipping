using CourierShipping.Core.Services.Models;
using CourierShipping.Data.Entities;
using CourierShipping.Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierShipping.Core.Services
{
    public interface ICourierService
    {
        bool IsCourierEligible(CheckOffer checkOffer);
        Task<List<PackagePrice>> GetOffer(CheckOffer checkOffer);
        Task<int> AddOffer(OfferDto offerDto);
    }
}
