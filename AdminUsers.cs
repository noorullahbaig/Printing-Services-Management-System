using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OopFinalProject
{
    public partial class AdminUsers : Form
    {
        private int userId;
        public AdminUsers()
        {
            InitializeComponent();
            LoadUserData();
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void DashBtn_Click(object sender, EventArgs e)
        {
            Admin adminForm = new Admin(userId);
            adminForm.Show();  
            this.Close();
        }

        private void ReportBtn_Click(object sender, EventArgs e)
        {
            AdminYearlyRep reportForm = new AdminYearlyRep();
            reportForm.Show();
            this.Hide();
        }

        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to sign out?", "Confirm Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void user_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void user_role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void user_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void user_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void user_fullname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void user_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(!ValidateInput())
                return;

            if (!string.IsNullOrWhiteSpace(user_id.Text) && int.TryParse(user_id.Text, out int userId))
            {
                if (DoesUserIdExist(userId))
                {
                    MessageBox.Show("User ID already exists. Please enter a different user ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string username = user_username.Text;
            if (!IsUsernameUnique(username))
            {
                MessageBox.Show("Username is already in use. Please choose a different username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = user_password.Text;
            string fullName = user_fullname.Text;
            string phoneNumber = user_number.Text;
            string role = user_role.SelectedItem.ToString();
            string status = user_status.SelectedItem.ToString();
            DateTime registrationDate = dateTimePicker1.Value;

            bool result = AddUser(username, password, role, fullName, phoneNumber, registrationDate, status);

            if (result)
            {
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserData();
            }
            else
            {
                MessageBox.Show("Failed to add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(user_username.Text) || user_username.Text.Length < 4)
            {
                MessageBox.Show("Username must be at least 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(user_password.Text) || user_password.Text.Length < 4 || !user_password.Text.Any(char.IsDigit) || !user_password.Text.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Password must be at least 4 characters long and include at least one number and one special character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(user_fullname.Text) || user_fullname.Text.Length <= 4)
            {
                MessageBox.Show("Full name must be more than 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(user_number.Text) || user_number.Text.Length != 10 || !user_number.Text.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must be exactly 10 digits long and contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (user_role.SelectedItem == null || string.IsNullOrWhiteSpace(user_role.Text))
            {
                MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (user_status.SelectedItem == null || string.IsNullOrWhiteSpace(user_status.Text))
            {
                MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DateTime registrationDate = dateTimePicker1.Value;  
            if (registrationDate > DateTime.Now)
            {
                MessageBox.Show("The registration date cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool AddUser(string username, string password, string role, string fullName, string phoneNumber, DateTime registrationDate, string status)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    
                    string insertQuery = "INSERT INTO allusers (Role, Username, Password, Registration_Date, FullName, PhoneNumber, Status) " +
                                         "VALUES (@Role, @Username, @Password, @RegistrationDate, @FullName, @PhoneNumber, @Status)";

                    
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@RegistrationDate", registrationDate);
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@Status", status);

                       
                        int rowsAffected = cmd.ExecuteNonQuery();

                        
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        private void UpdateBtn_Click(object sender, EventArgs e)
        {

            if (!ValidateInput())
                return;

            if (!int.TryParse(user_id.Text, out int userId))
            {
                MessageBox.Show("Please enter a valid user ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DoesUserIdExist(userId))
            {
                MessageBox.Show("User ID does not exist.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsUsernameUnique(user_username.Text, userId))
            {
                MessageBox.Show("Username is already in use. Please choose a different username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = user_username.Text;
            string password = user_password.Text;
            string fullName = user_fullname.Text;
            string phoneNumber = user_number.Text;
            string role = user_role.SelectedItem.ToString();
            string status = user_status.SelectedItem.ToString();
            DateTime registrationDate = dateTimePicker1.Value;

            bool result = UpdateUser(userId, username, password, role, fullName, phoneNumber, registrationDate, status);

            if (result)
            {
                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserData();
            }
            else
            {
                MessageBox.Show("Failed to update user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UpdateUser(int userId, string username, string password, string role, string fullName, string phoneNumber, DateTime registrationDate, string status)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                   
                    string updateQuery = "UPDATE allusers SET Username = @Username, Password = @Password, " +
                                         "Role = @Role, FullName = @FullName, PhoneNumber = @PhoneNumber, " +
                                         "Registration_Date = @RegistrationDate, Status = @Status WHERE UserID = @UserID";

                    
                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@RegistrationDate", registrationDate);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@UserID", userId);

                       
                        int rowsAffected = cmd.ExecuteNonQuery();

                       
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            } 
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(user_id.Text) || !int.TryParse(user_id.Text, out int userId))
            {
                MessageBox.Show("Please enter a valid user ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var confirmResult = MessageBox.Show("Are you sure you want to delete this user?",
                                                "Confirm Deletion",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                if (DeleteUser(userId))
                {
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserData(); 
                }
                else
                {
                    MessageBox.Show("Error deleting user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool DeleteUser(int userId)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
            List<UserData> listData = new List<UserData>();


            using (var connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    string deleteQuery = "DELETE FROM allusers WHERE UserID = @UserID";

                    using (var cmd = new SqlCommand(deleteQuery, connect))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        int result = cmd.ExecuteNonQuery();
                        return result > 0; 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting user: " + ex.Message);
                    return false;
                }
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            user_id.Text = string.Empty;
            user_username.Text = string.Empty;
            user_password.Text = string.Empty;
            user_fullname.Text = string.Empty;
            user_number.Text = string.Empty;

          
            user_role.SelectedIndex = -1;
            user_status.SelectedIndex = -1;


            dateTimePicker1.Value = DateTime.Now;

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void user_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadUserData()
        {
            try
            {
                UserData userData = new UserData();
                List<UserData> users = userData.GetUserListData();
                if (users.Any())
                {
                    dataGridView1.DataSource = users;
                }
                else
                {
                    MessageBox.Show("No data available.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        public bool IsUsernameUnique(string username, int? userId = null)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
            using (var connect = new SqlConnection(connectionString))
            {
                connect.Open();
                string query = userId == null ?
                    "SELECT COUNT(*) FROM allusers WHERE Username = @Username" :
                    "SELECT COUNT(*) FROM allusers WHERE Username = @Username AND UserID != @UserID";

                using (var cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    if (userId != null) cmd.Parameters.AddWithValue("@UserID", userId.Value);
                    int count = (int)cmd.ExecuteScalar();
                    return count == 0;
                }
            }
        }

        public bool DoesUserIdExist(int userId)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
            using (var connect = new SqlConnection(connectionString))
            {
                connect.Open();
                string query = "SELECT COUNT(*) FROM allusers WHERE UserID = @UserID";

                using (var cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                
                user_id.Text = row.Cells[0].Value.ToString(); 
                user_role.Text = row.Cells[1].Value.ToString(); 
                user_username.Text = row.Cells[2].Value.ToString(); 
                user_password.Text = row.Cells[3].Value.ToString(); 
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells[4].Value);
                user_fullname.Text = row.Cells[5].Value.ToString(); 
                user_number.Text = row.Cells[6].Value.ToString(); 
                user_status.Text = row.Cells[7].Value.ToString(); 
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
