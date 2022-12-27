using CourierShipping.Core.Services.Models;
using CourierShipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CourierShipping.Data.Models
{
    public class Cargo4You
    {
        public virtual double CalculatePrices(CheckOffer checkOffer)
        {
            double finalPriceVolume = 0;
            double finalPriceWeight = 0;

            //calc volume
            var volume = Convert.ToDouble(checkOffer.PackageHeight) * Convert.ToDouble(checkOffer.PackageWidth) * Convert.ToDouble(checkOffer.PackageDepth);

            //calc weight 
            var packageweight = Convert.ToDouble(checkOffer.PackageWeight);

            //Calc Based on dimensions
            if (volume <= 1000)
            {
                finalPriceVolume = 10;
            }
            else if (volume > 1000 && volume <= 2000)
            {
                finalPriceVolume = 20;
            }

            //Calc Based on weight
            if (packageweight <= 2)
            {
                finalPriceWeight = 15;
            }
            else if (packageweight > 2 && packageweight <= 15)
            {
                finalPriceWeight = 18;
            }
            else if (packageweight > 15 && packageweight <= 20)
            {
                finalPriceWeight = 35;
            }

            return Math.Max(finalPriceVolume, finalPriceWeight);
        }
    }
    public class MaltaShip : Cargo4You
    {
        public override double CalculatePrices(CheckOffer checkOffer)
        {
            double finalPriceVolume = 0;
            double finalPriceWeight = 0;

            //calc volume
            var volume = Convert.ToDouble(checkOffer.PackageHeight) * Convert.ToDouble(checkOffer.PackageWidth) * Convert.ToDouble(checkOffer.PackageDepth);

            //calc weight 
            var packageweight = Convert.ToDouble(checkOffer.PackageWeight);

            //Calc Based on dimensions
            if (volume <= 1000)
            {
                finalPriceVolume = 9.50;
            }
            else if (volume > 1000 && volume <= 2000)
            {
                finalPriceVolume = 19.50;
            }
            else if (volume > 2000 && volume <= 5000)
            {
                finalPriceVolume = 48.50;
            }
            else if (volume > 5000)
            {
                finalPriceVolume = 147.50;
            }

            //Calc Based on weight
            if (packageweight > 10 && packageweight <= 20)
            {
                finalPriceWeight = 16.99;
            }
            else if (packageweight > 20 && packageweight <= 30)
            {
                finalPriceWeight = 33.99;
            }
            else if (packageweight > 30)
            {
                double addkilos = 0;
                double extrakilos = 0.41;
                var diff = packageweight - 25;

                for (int i = 0; i < diff; i++)
                {
                    addkilos = addkilos + extrakilos;
                }

                finalPriceWeight = 43.99 + addkilos;
            }

            return Math.Max(finalPriceVolume, finalPriceWeight);
        }
    }
    public class ShipFaster : Cargo4You
    {
        public override double CalculatePrices(CheckOffer checkOffer)
        {
            double finalPriceVolume = 0;
            double finalPriceWeight = 0;

            //calc volume
            var volume = Convert.ToDouble(checkOffer.PackageHeight) * Convert.ToDouble(checkOffer.PackageWidth) * Convert.ToDouble(checkOffer.PackageDepth);

            //calc weight 
            var packageweight = Convert.ToDouble(checkOffer.PackageWeight);

            //Calc Based on dimensions
            if (volume <= 1000)
            {
                finalPriceVolume = 11.99;
            }
            else if (volume > 1000 && volume <= 1700)
            {
                finalPriceVolume = 21.99;
            }

            //Calc Based on weight
            if (packageweight > 10 && packageweight <= 15)
            {
                finalPriceWeight = 16.50;
            }
            else if (packageweight > 15 && packageweight <= 25)
            {
                finalPriceWeight = 36.50;
            }
            else if (packageweight > 25)
            {
                double addkilos = 0;
                double extrakilos = 0.417;
                var diff = packageweight - 25;

                for (int i = 0; i < diff; i++)
                {
                    addkilos = addkilos + extrakilos;
                }
                finalPriceWeight = 40 + addkilos;
            }

            return Math.Max(finalPriceVolume, finalPriceWeight);
        }
    }
}
