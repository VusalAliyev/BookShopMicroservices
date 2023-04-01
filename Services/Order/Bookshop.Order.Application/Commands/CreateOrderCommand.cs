using Bookshop.Order.Application.Dtos;
using Bookshop.Shared.Dtos;
using MediatR;

namespace Bookshop.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }

        public AddressDto Address { get; set; }
    }
}
