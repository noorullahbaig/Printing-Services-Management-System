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
    public partial class CustomerProfile : Form
    {
        private int userId;

        public CustomerProfile(int userId)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DashBtn_Click(object sender, EventArgs e)
        {
            Customer_Dash_ CustomerDash = new Customer_Dash_(userId);
            CustomerDash.Show();
            this.Close();
        }

        private void NewReqBtn_Click(object sender, EventArgs e)
        {
            CustomerNewReq newReqForm = new CustomerNewReq(userId);
            newReqForm.Show();
            this.Hide();
        }

        private void ReqStatusBtn_Click(object sender, EventArgs e)
        {
            CustomerReqList reqListForm = new CustomerReqList(userId);
            reqListForm.Show();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void customer_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_fullname_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            string username = customer_username.Text;
            string password = customer_password.Text;
            string fullName = customer_fullname.Text;
            string phoneNumber = customer_number.Text;

            if (UpdateUserData(userId, username, password, fullName, phoneNumber))
            {
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (!IsUsernameUnique(customer_username.Text, userId))
            {
                MessageBox.Show("Username is already in use. Please choose a different username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(customer_password.Text) || customer_password.Text.Length < 4 ||
                !customer_password.Text.Any(char.IsDigit) || !customer_password.Text.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Password must be at least 4 characters long and include at least one number and one special character.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(customer_number.Text) || customer_number.Text.Length != 10 || !customer_number.Text.All(char.IsDigit))
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



        private void ClearBtn_Click(object sender, EventArgs e)
        {
            customer_username.Clear();
            customer_password.Clear();
            customer_fullname.Clear();
            customer_number.Clear();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                customer_username.Text = Convert.ToString(row.Cells["Username"].Value); 
                customer_password.Text = Convert.ToString(row.Cells["Password"].Value); 
                customer_fullname.Text = Convert.ToString(row.Cells["FullName"].Value); 
                customer_number.Text = Convert.ToString(row.Cells["PhoneNumber"].Value); 
                                                                                        
            }

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
