using Bookshop.Web.Models;

namespace Bookshop.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}
