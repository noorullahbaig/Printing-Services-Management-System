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
    public partial class WorkerProfile : Form
    {
        private int userId;
        public WorkerProfile(int userId)
        {
            InitializeComponent();
            InitializeDataGridView();
            this.userId = userId;
            LoadUserData();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;  
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;  
        }
       
        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DashBtn_Click(object sender, EventArgs e)
        {
            WorkerDash workerDashboard = new WorkerDash(userId); 
            workerDashboard.Show();
            this.Hide();
        }

        private void AssignedTaskBtn_Click(object sender, EventArgs e)
        {
            WorkerTask workerTaskForm = new WorkerTask(userId);
            workerTaskForm.Show();
            this.Hide();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void worker_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void worker_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void worker_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void worker_fullname_TextChanged(object sender, EventArgs e)
        {

        }
        private bool UpdateUserData(int userId, string username, string password, string fullName, string phoneNumber)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = @"
            UPDATE allusers
            SET Username = @Username, Password = @Password, FullName = @FullName, PhoneNumber = @PhoneNumber
            WHERE UserID = @UserId";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@UserId", userId);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        private void LoadUserData()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True"; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT UserID, Role, Username,Password, FullName, PhoneNumber, Registration_Date FROM allusers WHERE UserID = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable; 
                    }
                    else
                    {
                        MessageBox.Show("No user data found for the specified ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private bool ValidateInputs()
        {
            if (!IsUsernameUnique(worker_username.Text, userId))
            {
                MessageBox.Show("Username is already in use. Please choose a different username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(worker_password.Text) || worker_password.Text.Length < 4 ||
                !worker_password.Text.Any(char.IsDigit) || !worker_password.Text.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Password must be at least 4 characters long and include at least one number and one special character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(worker_number.Text) || worker_number.Text.Length != 10 || !worker_number.Text.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must be exactly 10 digits long and contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        public bool IsUsernameUnique(string username, int? userId = null)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
            using (var connect = new SqlConnection(connectionString))
            {
                connect.Open();
                string query = userId.HasValue ?
                    "SELECT COUNT(*) FROM allusers WHERE Username = @Username AND UserID != @UserID" :
                    "SELECT COUNT(*) FROM allusers WHERE Username = @Username";

                using (var cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    if (userId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId.Value);
                    }
                    int count = (int)cmd.ExecuteScalar();
                    return count == 0;
                }
            }
        }


        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            string username = worker_username.Text;
            string password = worker_password.Text;
            string fullName = worker_fullname.Text;
            string phoneNumber = worker_number.Text;

            if (UpdateUserData(userId, username, password, fullName, phoneNumber))
            {
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearBtn_Click(object sender, EventArgs e)
        {
            worker_username.Clear();
            worker_password.Clear();
            worker_fullname.Clear();
            worker_number.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                worker_username.Text = Convert.ToString(row.Cells["Username"].Value); 
                worker_password.Text = Convert.ToString(row.Cells["Password"].Value); 
                worker_fullname.Text = Convert.ToString(row.Cells["FullName"].Value); 
                worker_number.Text = Convert.ToString(row.Cells["PhoneNumber"].Value); 
                                                                                         
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
