using Bookshop.Shared.ControllerBases;
using Catalog.Api.Dtos;
using Catalog.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : CustomBaseController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> GetAll()
        {
            var response = await _bookService.GetAllAsync();

            return CreateActionResultInstance(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _bookService.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _bookService.GetAllByUserIdAsync(userId);

            return CreateActionResultInstance(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookCreateDto bookCreateDto)
        {
            var response = await _bookService.CreateAsync(bookCreateDto);

            return CreateActionResultInstance(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(BookUpdateDto bookUpdateDto)
        {
            var response = await _bookService.UpdateAsync(bookUpdateDto);

            return CreateActionResultInstance(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _bookService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }


    }
}
