using System;

namespace ChatDesktopUI.Library.Models
{
    public interface ILoggedInUserModel
    {
        DateTime CreatedDate { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string lastName { get; set; }
        string Token { get; set; }
        string UserName { get; set; }
    }
}