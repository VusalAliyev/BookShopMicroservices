using Bookshop.Order.Application.Dtos;
using Bookshop.Shared.Dtos;
using MediatR;

namespace Bookshop.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
