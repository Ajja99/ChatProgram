using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {

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
            set { _errorMessage = value; }
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
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public async Task LogIn()
        {
            UserName = "";
            Password = "";
        }

        public bool CanLogIn
        {
            get
            {
                bool output = false;
                if (_userName?.Length > 0)
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
