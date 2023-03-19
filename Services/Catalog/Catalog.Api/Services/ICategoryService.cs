using Bookshop.Shared.Dtos;
using Catalog.Api.Dtos;
using Catalog.Api.Models;

namespace Catalog.Api.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(string id);
        Task<Response<CategoryDto>> CreateAsync(Category category);
    }
}
