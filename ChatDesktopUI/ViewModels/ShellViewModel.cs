using Caliburn.Micro;
using ChatDesktopUI.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object> , IHandle<LogOnEvent>, IHandle<RegisterEvent>
    {

        private IEventAggregator _events;
        private readonly RegisterViewModel _registerVm;

        public ShellViewModel(IEventAggregator events, RegisterViewModel registerVm)
        {
            _events = events;
            _registerVm = registerVm;

            _events.Subscribe(this);
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            // Todo - Add page to log into after valid login
        }

        public void Handle(RegisterEvent message)
        {
            ActivateItem(_registerVm);
        }
    }
}