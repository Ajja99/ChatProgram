using ChatDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace ChatDesktopUI.Library.Api
{
    public interface IRegisterUserEndpoint
    {
        Task PostRegisterUser(RegisterUserModel user);
    }
}