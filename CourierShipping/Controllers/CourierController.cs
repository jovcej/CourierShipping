using CourierShipping.Core.Services;
using CourierShipping.Core.Services.Models;
using CourierShipping.Data.Entities;
using CourierShipping.Data.Models;
using CourierShipping.Data.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace CourierShipping.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourierController : Controller
    {
        private readonly ICourierService _courierService;
        public CourierController(ICourierService courierService)
        {
            _courierService= courierService;
        }

        [HttpPost("GetCourierOffer")]
        public async Task<IActionResult> GetCourierPrice([FromBody] CheckOffer checkOffer)
        {
            var ret = await _courierService.GetOffer(checkOffer);

            if (ret.Count() == 0) throw new Exception();

            return Ok(ret);
        }

        [HttpPost("CreateOffer")]
        public async Task<IActionResult> AddOffer([FromBody] OfferDto offerDto)
        {        
            var offerModel = await _courierService.AddOffer(offerDto);
            return Ok(offerModel);
        }
    }
}
