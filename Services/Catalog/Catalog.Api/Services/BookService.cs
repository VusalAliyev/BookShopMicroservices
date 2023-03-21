using AutoMapper;
using Bookshop.Shared.Dtos;
using Catalog.Api.Dtos;
using Catalog.Api.Models;
using Catalog.Api.Settings;
using MongoDB.Driver;

namespace Catalog.Api.Services
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<Book> _bookCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public BookService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bookCollection = database.GetCollection<Book>(databaseSettings.BookCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task<Response<List<BookDto>>> GetAllAsync()
        {
            var books = await _bookCollection.Find(book => true).ToListAsync();

            if (books.Any())
            {
                foreach (var book in books)
                {
                    book.Category = await _categoryCollection.Find<Category>(x => x.Id == book.CategoryId).FirstAsync();
                }
            }
            else
            {
                books = new List<Book>();
            }

            return Response<List<BookDto>>.Success(_mapper.Map<List<BookDto>>(books), 200);
        }

        public async Task<Response<List<BookDto>>> GetAllByUserIdAsync(string userId)
        {
            var books = await _bookCollection.Find<Book>(x => x.UserId == userId).ToListAsync();

            if (books.Any())
            {
                foreach (var book in books)
                {
                    book.Category = await _categoryCollection.Find<Category>(x => x.Id == book.CategoryId).FirstAsync();
                }
            }
            else
            {
                books = new List<Book>();
            }

            return Response<List<BookDto>>.Success(_mapper.Map<List<BookDto>>(books), 200);
        }

        public async Task<Response<BookDto>> GetByIdAsync(string id)
        {
            var book = await _bookCollection.Find<Book>(x => x.Id == id).FirstOrDefaultAsync();
            if (book == null)
            {
                return Response<BookDto>.Fail("Book not found", 404);
            }

            book.Category = await _categoryCollection.Find<Category>(x => x.Id == book.CategoryId).FirstAsync();

            return Response<BookDto>.Success(_mapper.Map<BookDto>(book), 200);
        }
        public async Task<Response<BookDto>> CreateAsync(BookCreateDto bookCreateDto)
        {
            var newBook = _mapper.Map<Book>(bookCreateDto);
            newBook.CreatedDate = DateTime.Now;

            await _bookCollection.InsertOneAsync(newBook);

            return Response<BookDto>.Success(_mapper.Map<BookDto>(newBook), 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(BookUpdateDto bookUpdateDto)
        {
            var updateBook = _mapper.Map<Book>(bookUpdateDto);
            var result = await _bookCollection.FindOneAndReplaceAsync(x => x.Id == bookUpdateDto.Id, updateBook);
            if (result == null)
            {
                return Response<NoContent>.Fail("Course not found", 404);
            }
            return Response<NoContent>.Success(204);

        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _bookCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("Book not found", 404);
            }
        }
    }
}
