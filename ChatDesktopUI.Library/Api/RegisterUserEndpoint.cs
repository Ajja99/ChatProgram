using ChatDataManager.Models;
using ChatDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatDesktopUI.Library.Api
{
    public class RegisterUserEndpoint : IRegisterUserEndpoint
    {
        private readonly IApiHelper _apihelper;

        public RegisterUserEndpoint(IApiHelper apihelper)
        {
            _apihelper = apihelper;
        }

        public async Task PostRegisterUser(RegisterUserModel user)
        {

            RegisterBindingModel model = new RegisterBindingModel
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            using (HttpResponseMessage response = await _apihelper.ApiClient.PostAsJsonAsync("/api/Account/Register", model))
            {
                if (response.IsSuccessStatusCode)
                {
                    //Todo - Log registered user?
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
