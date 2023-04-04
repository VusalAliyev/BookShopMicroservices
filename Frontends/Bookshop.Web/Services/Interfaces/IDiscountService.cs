using Bookshop.Web.Models.Discounts;

namespace Bookshop.Web.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<DiscountViewModel> GetDiscount(string discountCode);
    }
}
