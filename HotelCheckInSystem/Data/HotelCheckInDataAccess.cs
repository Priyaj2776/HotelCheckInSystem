using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelCheckInSystem.Models;
using System.Data.SqlClient;

namespace HotelCheckInSystem.Data
{
    public class HotelCheckInDataAccess : BaseDataAccess
    {
        private HotelCheckInDataAccess()
        { 
            //
        }
        public HotelCheckInDataAccess(string connectionString): base(connectionString)
        {
            //
        }
        public User GetUser(string userName, string password)
        {
            try
            {
                User currentUser = new User(); 
                using (SqlConnection conn = GetConnection())
                {
                    string sqlGetUser = string.Format("select Id, UserName, Password, isActive, RoleID from [User] where UserName = '{0}' and Password = '{1}' ", userName, password);
                    using (SqlCommand cmd = new SqlCommand(sqlGetUser, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if( reader.Read())
                            {
                                currentUser.Id = (int)reader["Id"];
                                currentUser.UserName = (string)reader["UserName"];
                                currentUser.Password = (String)reader["Password"];
                                currentUser.IsActive = (bool)reader["isActive"];
                                currentUser.Role = GetRole((int)reader["RoleID"]);
                            }
                        }
                    }
                }
                return currentUser;
            }
            catch
            {
                throw;
            }
        }

        public Role GetRole(int id)
        {
            try
            {
                Role role = new Role();
                using (SqlConnection conn = GetConnection())
                {
                    string sqlGetUser = string.Format("select Id, Description, isActive from dbo.Role where Id = {0}", id);
                    using (SqlCommand cmd = new SqlCommand(sqlGetUser, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                role.Id = (int)reader["Id"];
                                role.Description = (string)reader["Description"];
                                role.IsActive = (bool)reader["isActive"];
                            }
                        }
                    }
                }
                return role;
            }
            catch
            {
                throw;
            }
        }
    }
}
