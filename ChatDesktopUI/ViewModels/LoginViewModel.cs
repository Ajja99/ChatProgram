using Caliburn.Micro;
using ChatDesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private IApiHelper _apiHelper;

        public LoginViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public bool IsErrorVisible
        {
            get
            {
                return false;
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        private string _userName = "";

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        private string _password = "";

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public async Task LogIn()
        {
            //UserName = "";
            //Password = "";

            try
            {
                //ErrorMessage = "";
                var result = await _apiHelper.Authenticate(UserName, Password);

                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                UserName = "LOGGED IN";
            }
            catch (Exception error)
            {

                ErrorMessage = error.Message;
            }
        }

        public bool CanLogIn
        {
            get
            {
                bool output = false;
                if (_userName?.Length > 0 && _password?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }


        public void Register()
        {

        }

        public bool CanRegister
        {
            get
            {
                return true;
            }
        } 

    }
    
}
