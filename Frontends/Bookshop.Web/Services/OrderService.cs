using Bookshop.Web.Models.Orders;
using Bookshop.Web.Services.Interfaces;

namespace Bookshop.Web.Services
{
    public class OrderService : IOrderService
    {
        public Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderViewModel>> GetOrder()
        {
            throw new NotImplementedException();
        }

        public Task SuspendOrder(CheckoutInfoInput checkoutInfoInput)
        {
            throw new NotImplementedException();
        }
    }
}
