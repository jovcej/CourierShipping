
using CourierShipping.Core.Repository;
using CourierShipping.Core.Services.Models;
using CourierShipping.Data.Entities;
using CourierShipping.Data.Models;
using CourierShipping.Data.ModelsDTO;
using Microsoft.Extensions.Configuration;
//using CourierShipping.Shared.Mapper;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourierShipping.Core.Services
{
    public class CourierService : ICourierService
    {
        private readonly ICourierRepository _courierRepository;
        private readonly IConfiguration _configuration;

        public CourierService(ICourierRepository courierRepository, IConfiguration configuration)
        {
            _courierRepository = courierRepository;
            _configuration = configuration;
        }

        public bool IsCourierEligible(CheckOffer checkOffer)
        {
            //calc volume
            var volume = Convert.ToDouble(checkOffer.PackageHeight) * Convert.ToDouble(checkOffer.PackageWidth) * Convert.ToDouble(checkOffer.PackageDepth);

            //calc weight 
            var packageweight = Convert.ToDouble(checkOffer.PackageWeight);

            if ((packageweight <= 20 && volume < 2000) 
               || (packageweight > 10 && packageweight <= 30 && volume <= 1700) 
               || (packageweight >= 10 && volume >= 500))
            {              
                return true;
            }
            return false;
        }

        public async Task<List<PackagePrice>> GetOffer(CheckOffer checkOffer)
        {
            await RequiredField(checkOffer);

            List<PackagePrice> packagePrice = new();

            Cargo4You cargo4you = new();
            MaltaShip maltaShip = new();
            ShipFaster shipFaster = new();

            var listOfCouriers = new[] { cargo4you, maltaShip, shipFaster };

            if (IsCourierEligible(checkOffer) == true)
            {
                for (var i = 0; i < listOfCouriers.Length; i++)
                {
                    packagePrice.Add(new PackagePrice
                    {
                        CourierName = listOfCouriers[i].GetType().Name,
                        Price = listOfCouriers[i].CalculatePrices(checkOffer),

                    });
                }
            }

            return packagePrice;
        }

        public async Task<int> AddOffer(OfferDto offerDto)
        { 
            var couriersOffer = new CouriersOffer()
            {
                Weight = offerDto.PackageWeight,
                Width = offerDto.PackageWidth,
                Height = offerDto.PackageHeight,
                Depth = offerDto.PackageDepth,
                CourierName = offerDto.CourierName,
                PackagePrice = offerDto.OfferPrice
            };
       
            var addOffer = await _courierRepository.Create(couriersOffer);

            return addOffer.Id;
        }


        public async Task<bool> RequiredField(CheckOffer checkOffer)
        {
            Regex numberVal = new Regex(_configuration["Validation:Numbers"]);

            if (!numberVal.IsMatch(checkOffer.PackageWidth))
                throw new Exception();

            if (!numberVal.IsMatch(checkOffer.PackageHeight))
                throw new Exception();

            if (!numberVal.IsMatch(checkOffer.PackageDepth))
                throw new Exception();

            if (!numberVal.IsMatch(checkOffer.PackageWeight))
                throw new Exception();
      
            return await Task.FromResult(true);
        }
    }
}
