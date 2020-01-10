using ChatDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.get_user_by_id", p, "ChatData");

            return output;
        }
    }
}
