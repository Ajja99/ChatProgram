using Caliburn.Micro;
using ChatDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object> , IHandle<LogOnEvent>, IHandle<RegisterEvent>, IHandle<RegisteredEvent>
    {

        private IEventAggregator _events;
        private readonly RegisterViewModel _registerVm;
        private readonly LoginViewModel _loginVm;

        public ShellViewModel(IEventAggregator events, RegisterViewModel registerVm, LoginViewModel loginVm)
        {
            _events = events;
            _registerVm = registerVm;
            _loginVm = loginVm;

            _events.Subscribe(this);
            ActivateItem(_loginVm);
        }

        public void Handle(LogOnEvent message)
        {
            // Todo - Add page to log into after valid login
        }

        public void Handle(RegisterEvent message)
        {
            ActivateItem(_registerVm);
        }

        public void Handle(RegisteredEvent message)
        {
            ActivateItem(_loginVm);
        }
    }
}