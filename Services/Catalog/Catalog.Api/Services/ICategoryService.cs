using Bookshop.Shared.Dtos;
using Catalog.Api.Dtos;

namespace Catalog.Api.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(string id);
        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);
    }
}
