using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OopFinalProject
{
    class UserData
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public string Status { get; set; }

        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";

        public List<UserData> GetUserListData()
        {
            List<UserData> listData = new List<UserData>();

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT * FROM allusers"; 

                    using (SqlCommand command = new SqlCommand(selectData, connect))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserData userData = new UserData()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("UserID")),
                                Role = reader.IsDBNull(reader.GetOrdinal("Role")) ? null : reader.GetString(reader.GetOrdinal("Role")),
                                Username = reader.IsDBNull(reader.GetOrdinal("Username")) ? null : reader.GetString(reader.GetOrdinal("Username")),
                                Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? null : reader.GetString(reader.GetOrdinal("Password")),
                                RegistrationDate = reader.IsDBNull(reader.GetOrdinal("Registration_Date")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Registration_Date")),
                                FullName = reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString(reader.GetOrdinal("FullName")),
                                PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                Status = reader["Status"].ToString()
                            };
                            listData.Add(userData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching user data: " + ex.Message);
                }
            }
            return listData;
        }

        

    }
   
}
