using AutoMapper;
using Bookshop.Shared.Dtos;
using Catalog.Api.Dtos;
using Catalog.Api.Models;
using Catalog.Api.Settings;
using MongoDB.Driver;

namespace Catalog.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public Task<Response<CategoryDto>> CreateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();

            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
