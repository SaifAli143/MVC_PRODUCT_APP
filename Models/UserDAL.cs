using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_PRODUCT_APP.Models
{
    public class UserDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public UserDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public int Save(User u)
        {
            string q = "insert into USER_TABLE values(@Full_Name,@Email_Id,@password,@Role_id)";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@Full_Name", u.Full_Name);
            cmd.Parameters.AddWithValue("@Email_Id", u.Email_Id);
            cmd.Parameters.AddWithValue("@password", u.Password);
            cmd.Parameters.AddWithValue("@Role_id", u.RoleId);
            /*cmd.Parameters.AddWithValue("@User_id", 101);*/

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public bool Verify(User u)
        {
            string email;
            string pass;
            string q = "Select Email_Id,password from USER_TABLE where Email_Id=@Email";
            cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@Email", u.Email_Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                email = dr["Email_Id"].ToString();
                pass = dr["Password"].ToString();
            }
            else
            {
                con.Close();
                return false;
            }
            if (email == u.Email_Id && pass == u.Password)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
    }
}
