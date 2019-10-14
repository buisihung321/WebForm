using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class UserInfoData
    {
        private string strConnection = $"server=.\\SQLEXPRESS;database=SaleApp;integrated security = true";

        public UserInfoData()
        {
        }

        public void InsertUserInfo(UserInfo userInfo)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQLInsert = "INSERT UserInfo values (@UserName,@Password,@BirthDate,@Address,@Email)";
            SqlCommand cmd = new SqlCommand(SQLInsert,cnn);
            cmd.Parameters.AddWithValue("@Username", userInfo.Username);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
            cmd.Parameters.AddWithValue("@BirthDate", userInfo.BirthDate);
            cmd.Parameters.AddWithValue("@Address", userInfo.Address);
            cmd.Parameters.AddWithValue("@Email", userInfo.Email);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
            finally{ cnn.Close();}
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQLInsert = "UPDATE UserInfo set [Password] = @Password, BirthDate = @BirthDate," +
                               " [Address] = @Address, [Email] = @Email " +
                               " WHERE Username = @Username";
            SqlCommand cmd = new SqlCommand(SQLInsert, cnn);
            cmd.Parameters.AddWithValue("@Username", userInfo.Username);
            cmd.Parameters.AddWithValue("@Password", userInfo.Password);
            cmd.Parameters.AddWithValue("@BirthDate", userInfo.BirthDate);
            cmd.Parameters.AddWithValue("@Address", userInfo.Address);
            cmd.Parameters.AddWithValue("@Email", userInfo.Email);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { cnn.Close(); }
        }

        public void Delete(UserInfo userInfo)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQLInsert = "DELETE UserInfo WHERE Username = @Username";
            SqlCommand cmd = new SqlCommand(SQLInsert, cnn);
            cmd.Parameters.AddWithValue("@Username", userInfo.Username);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { cnn.Close(); }
        }

        public List<UserInfo> GetUserList()
        {
            List<UserInfo> data = new List<UserInfo>();
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQLInsert = "Select * from UserInfo";
            SqlCommand cmd = new SqlCommand(SQLInsert, cnn);
            try
            {
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dynamic u = new UserInfo
                        {
                            Username = dr["UserName"].ToString(),
                            Password = dr["Password"].ToString(),
                            Address = dr["Address"].ToString(),
                            Email = dr["Email"].ToString(),
                            BirthDate = DateTime.Parse(dr["BirthDate"].ToString())
                        };

                        data.Add(u);
                    }
                    

                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { cnn.Close(); }
            return data;

        }

    }
}