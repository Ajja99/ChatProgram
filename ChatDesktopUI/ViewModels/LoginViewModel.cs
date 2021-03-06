﻿using Caliburn.Micro;
using ChatDesktopUI.EventModels;
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
        private readonly IApiHelper _apiHelper;
        private readonly IEventAggregator _events;

        public LoginViewModel(IApiHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }

        public bool IsErrorVisible
        {
            get
            {
                bool output = false;

                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }

                return output;

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
                NotifyOfPropertyChange(() => IsErrorVisible);
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

                ErrorMessage = "LOGGED IN!";
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
            _events.PublishOnUIThread(new RegisterEvent());
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
