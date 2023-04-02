using Bookshop.Shared.Dtos;
using Bookshop.Web.Models;
using IdentityModel.Client;

namespace Bookshop.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SigninInput signinInput);

        Task<TokenResponse> GetAccessTokenWithRefreshToken();

        Task RemoveRefrestToken();
    }
}
