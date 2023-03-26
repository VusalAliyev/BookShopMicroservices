using Bookshop.Basket.Dtos;
using Bookshop.Shared.Dtos;

namespace Bookshop.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string userId);



    }
}
