using Bookshop.Web.Models.Catalog;

namespace Bookshop.Web.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<List<BookViewModel>> GetAllBookAsync();

        Task<List<CategoryViewModel>> GetAllCategoryAsync();

        Task<List<BookViewModel>> GetAllBookByUserIdAsync(string userId);

        Task<BookViewModel> GetByBookId(string bookId);

        Task<bool> CreateBookAsync(BookCreateInput bookCreateInput);

        Task<bool> UpdateBookAsync(BookUpdateInput bookUpdateInput);

        Task<bool> DeleteBookAsync(string bookId);
    }
}
