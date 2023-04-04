using Bookshop.Web.Models.Baskets;
using Bookshop.Web.Models.Discounts;
using Bookshop.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public BasketController(ICatalogService catalogService, IBasketService basketService)
        {
            _catalogService = catalogService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _basketService.Get());
        }

        public async Task<IActionResult> AddBasketItem(string bookId)
        {
            var book = await _catalogService.GetByBookId(bookId);

            var basketItem = new BasketItemViewModel { BookId = book.Id, BookName = book.Name, Price = book.Price };

            await _basketService.AddBasketItem(basketItem);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveBasketItem(string bookId)
        {
            var result = await _basketService.RemoveBasketItem(bookId);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ApplyDiscount(DiscountApplyInput discountApplyInput)
        {

            if (!ModelState.IsValid)
            {
                TempData["discountError"] = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).First();
                return RedirectToAction(nameof(Index));
            }

            var discountStatus = await _basketService.ApplyDiscount(discountApplyInput.Code);

            TempData["discountStatus"] = discountStatus;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CancelApplyDiscount()
        {
            await _basketService.CancelApplyDiscount();
            return RedirectToAction(nameof(Index));
        }
    }
}
