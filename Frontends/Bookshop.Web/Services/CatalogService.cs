using Bookshop.Shared.Dtos;
using Bookshop.Web.Helpers;
using Bookshop.Web.Models.Catalog;
using Bookshop.Web.Services.Interfaces;

namespace Bookshop.Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;
        private readonly IPhotoStockService _photoStockService;
        private readonly PhotoHelper _photoHelper;

        public CatalogService(HttpClient client, IPhotoStockService photoStockService, PhotoHelper photoHelper)
        {
            _client = client;
            _photoStockService = photoStockService;
            _photoHelper = photoHelper;
        }

        public async Task<bool> CreateBookAsync(BookCreateInput bookCreateInput)
        {

            //  var resultPhotoService = await _photoStockService.UploadPhoto(bookCreateInput.PhotoFormFile);

            //if (resultPhotoService != null)
            //{
            //    bookCreateInput.Picture = resultPhotoService.Uri;
            //}

            var response = await _client.PostAsJsonAsync<BookCreateInput>("books", bookCreateInput);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBookAsync(string bookId)
        {
            var response = await _client.DeleteAsync($"books/{bookId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<List<BookViewModel>> GetAllBookAsync()
        {
            var response = await _client.GetAsync("books");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<BookViewModel>>>();
            responseSuccess.Data.ForEach(x =>
            {
                x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
            });

            return responseSuccess.Data;
        }

        public async Task<List<BookViewModel>> GetAllBookByUserIdAsync(string userId)
        {
            var response = await _client.GetAsync($"books/GetAllByUserId/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<BookViewModel>>>();
            responseSuccess.Data.ForEach(x =>
            {
                x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
            });

            return responseSuccess.Data;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
        {
            var response = await _client.GetAsync("categories");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();

            return responseSuccess.Data;
        }

        public async Task<BookViewModel> GetByBookId(string bookId)
        {
            var response = await _client.GetAsync($"books/{bookId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadFromJsonAsync<Response<BookViewModel>>();

            responseSuccess.Data.StockPictureUrl = _photoHelper.GetPhotoStockUrl(responseSuccess.Data.Picture);

            return responseSuccess.Data;
        }

        public async Task<bool> UpdateBookAsync(BookUpdateInput bookUpdateInput)
        {
            //var resultPhotoService = await _photoStockService.UploadPhoto(bookUpdateInput.PhotoFormFile);

            //if (resultPhotoService != null)
            //{
            //    await _photoStockService.DeletePhoto(bookUpdateInput.Picture);
            //    bookUpdateInput.Picture = resultPhotoService.Uri;
            //}

            var response = await _client.PutAsJsonAsync<BookUpdateInput>("books", bookUpdateInput);

            return response.IsSuccessStatusCode;
        }
    }
}
