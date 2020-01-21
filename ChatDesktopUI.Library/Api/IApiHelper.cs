using ChatDesktopUI.Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatDesktopUI.Library.Api
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }

        Task<AuthenticatedUserModel> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}