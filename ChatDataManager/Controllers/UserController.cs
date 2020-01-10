using ChatDataManager.Library.DataAccess;
using ChatDataManager.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatDataManager.Controllers
{
    public class UserController : ApiController
    {
        public UserModel GetById()
        {
            var userId = RequestContext.Principal.Identity.GetUserId();

            UserData data = new UserData();

            return data.GetUserById(userId).First();
        }
    }
}