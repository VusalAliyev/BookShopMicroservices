using Bookshop.Shared.Services;
using Bookshop.Web.Models.Catalog;
using Bookshop.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookshop.Web.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BooksController(ICatalogService catalogService, ISharedIdentityService sharedIdentityService)
        {
            _catalogService = catalogService;
            _sharedIdentityService = sharedIdentityService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _catalogService.GetAllBookByUserIdAsync(_sharedIdentityService.GetUserId));
        }
        public async Task<IActionResult> Create()
        {
            var categories = await _catalogService.GetAllCategoryAsync();

            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookCreateInput bookCreateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            bookCreateInput.UserId = _sharedIdentityService.GetUserId;

            await _catalogService.CreateBookAsync(bookCreateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var book = await _catalogService.GetByBookId(id);
            var categories = await _catalogService.GetAllCategoryAsync();

            if (book == null)
            {
                //mesaj göster
                RedirectToAction(nameof(Index));
            }
            ViewBag.categoryList = new SelectList(categories, "Id", "Name", book.Id);
            BookUpdateInput bookUpdateInput = new()
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                Price = book.Price,
                Feature = book.Feature,
                CategoryId = book.CategoryId,
                UserId = book.UserId,
                Picture = book.Picture
            };

            return View(bookUpdateInput);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookUpdateInput bookUpdateInput)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name", bookUpdateInput.Id);
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _catalogService.UpdateBookAsync(bookUpdateInput);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _catalogService.DeleteBookAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
