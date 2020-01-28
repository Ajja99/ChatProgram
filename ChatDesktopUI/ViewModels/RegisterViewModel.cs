using Caliburn.Micro;
using ChatDesktopUI.EventModels;
using ChatDesktopUI.Library.Api;
using ChatDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDesktopUI.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private readonly IEventAggregator _events;
        private readonly IRegisterUserEndpoint _registeruserEndpoint;
        public RegisterViewModel(IEventAggregator events, IRegisterUserEndpoint registerUserEndpoint)
        {
            _events = events;
            _registeruserEndpoint = registerUserEndpoint;
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

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
                {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanRegister); ;
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                NotifyOfPropertyChange(() => ConfirmPassword);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        private string _emailAddress;

        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                _emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }

        public void Register()
        {
            try
            {
                RegisterUserModel user = new RegisterUserModel
                {
                    Username = _userName,
                    Email = _emailAddress,
                    Password = _password,
                    ConfirmPassword = _confirmPassword
                };

                _registeruserEndpoint.PostRegisterUser(user);

                _events.PublishOnUIThread(new RegisteredEvent());
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }

        public bool CanRegister
        {
            get
            {
            /*
                bool output = false;

                if (UserName?.Length >= 1 &&  FirstName?.Length >= 1 && LastName?.Length >= 1 && EmailAddress?.Length >= 1 && LastName?.Length >= 1 && Password == ConfirmPassword)
                {
                    output = true;
                }*/

                return true;

            }
            
        }
    }
}
