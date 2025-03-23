using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OopFinalProject
{
    public partial class Form1 : Form
    {
        
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            login_password.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void login_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void login_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = checkBox1.Checked ? '\0' : '*';
            login_password.Refresh();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(login_username.Text) || string.IsNullOrWhiteSpace(login_password.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State == ConnectionState.Closed)
                {
                    try
                    {
                        connect.Open();
                        string selectData = "SELECT Role, UserID FROM allusers WHERE Username = @Username AND Password = @Password";
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@Username", login_username.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", login_password.Text.Trim());

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read()) 
                                {
                                    string role = reader["Role"].ToString().Trim();
                                    int userId = Convert.ToInt32(reader["UserID"]); 

                                    if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                                    {
                                        MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                        Admin adminForm = new Admin(userId);
                                        adminForm.Show();
                                    }
                                    else if (role.Equals("customer", StringComparison.OrdinalIgnoreCase))
                                    {
                                        MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Hide();
                                        Customer_Dash_ customerDashboard = new Customer_Dash_(userId);
                                        customerDashboard.Show();
                                    }
                                    else if (role.Equals("worker", StringComparison.OrdinalIgnoreCase))
                                    {
                                        MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        WorkerDash workerDashboard = new WorkerDash(userId);
                                        workerDashboard.Show();
                                        this.Hide();
                                    }
                                    else if (role.Equals("manager", StringComparison.OrdinalIgnoreCase))
                                    {
                                        MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ManagerDash managerDashboard = new ManagerDash(userId);
                                        managerDashboard.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Access Denied: You do not have the correct privileges.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Username/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registeration regForm = new Registeration();
            regForm.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
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
    }
}
