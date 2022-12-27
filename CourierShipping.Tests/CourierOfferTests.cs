using NUnit.Framework;
using CourierShipping.Core.Services;
using CourierShipping.Data.Models;
using CourierShipping.Core.Services.Models;

namespace CourierShipping.UnitTests
{
    public class CourierOfferTests
    {
        [Test]
        public void Calculate_Cargo4you_Volume_Weight_Max()
        {

            //ARRANGE
            Cargo4You cargo4Yoy = new();

            //ACT
            var ret = cargo4Yoy.CalculatePrices(new CheckOffer
            {
                PackageWeight = 10.ToString(),
                PackageHeight = 10.ToString(),
                PackageWidth = 10.ToString(),
                PackageDepth = 10.ToString()
            });

            //ASSERT
            Assert.That(ret, Is.EqualTo(18));
        }

        [Test]
        public void Calculate_MaltaShip_Volume_Weight_Max()
        {

            //ARRANGE
            MaltaShip maltaShip = new();

            //ACT
            var ret = maltaShip.CalculatePrices(new CheckOffer  
            {
                PackageWeight = 20.ToString(),
                PackageHeight = 10.ToString(),
                PackageWidth = 10.ToString(),
                PackageDepth = 10.ToString()
            });
        
            //ASSERT
            Assert.That(Math.Round(ret, 2), Is.EqualTo(16.99));
        }

        [Test]
        public void Calculate_ShipFaster_Volume_Weight_Max()
        {

            //ARRANGE
            ShipFaster shipFaster= new();
           
            //ACT
            var ret = shipFaster.CalculatePrices(new CheckOffer { 
                PackageWeight = 30.ToString(),
                PackageHeight = 10.ToString(),
                PackageWidth = 10.ToString(),
                PackageDepth = 10.ToString()
            });
        
            //ASSERT
            Assert.That(Math.Round(ret, 3), Is.EqualTo(42.085));
        }
    }
}