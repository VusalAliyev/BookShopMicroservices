using Bookshop.Shared.ControllerBases;
using Bookshop.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : CustomBaseController
    {
        [HttpPost]
        public IActionResult ReceivePayment()
        {
            return CreateActionResultInstance(Response<NoContent>.Success(200));
        }
    }
}
