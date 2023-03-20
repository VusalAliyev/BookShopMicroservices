using Bookshop.Shared.Dtos;
using Catalog.Api.Dtos;

namespace Catalog.Api.Services
{
    public interface IBookService
    {
        Task<Response<List<BookDto>>> GetAllAsync();
        Task<Response<List<BookDto>>> GetAllByUserIdAsync(string UserId);
        Task<Response<BookDto>> GetByIdAsync(string id);
        Task<Response<BookDto>> CreateAsync(BookCreateDto bookCreateDto);
        Task<Response<NoContent>> UpdateAsync(BookUpdateDto bookUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
