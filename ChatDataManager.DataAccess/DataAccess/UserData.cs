using ChatDataManager.DataAccess.Models;
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
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.get_user_by_id", p, "DefaultConnection");

            return output;
        }

        public void InsertUser(UserModel user)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData("dbo.insert_user", user, "ChatData");
        }

       /* public List<TestEfModel> ReturnuserTestEf(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id };

            var output = sql.LoadData<TestEfModel, dynamic>("dbo.in", p, "DefaultConnection");

            return output;
        }*/
    }
}