using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OopFinalProject
{
    public partial class Admin : Form
    {
        private int userId;
        public string LoggedInUsername { get; set; }
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True");

        public Admin(int userId)
        {
            InitializeComponent();
            this.Load += Admin_Load;
            this.userId = userId;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            int totalUsers = GetCount("SELECT COUNT(UserID) FROM allusers"); 
            int activeUsers = GetCount("SELECT COUNT(UserID) FROM allusers WHERE status = @Status", "active"); 
            int inactiveUsers = GetCount("SELECT COUNT(UserID) FROM allusers WHERE status = @Status", "inactive"); 

            label7.Text = totalUsers.ToString();
            label8.Text = activeUsers.ToString();
            label9.Text = inactiveUsers.ToString();

            UpdateChart(Total_Users_Chart, totalUsers);
            UpdateChart(Active_Users_Chart, activeUsers);
            UpdateChart(Inctive_Users_Chart, inactiveUsers);
        }

        private void UpdateChart(Chart chart, int count)
        {
            
            chart.Series[0].Points.Clear();

           
            chart.Series[0].Points.AddY(count);
        }




        private int GetCount(string query, string status = null)
        {
        if (connect.State != ConnectionState.Open)
            connect.Open();

        try
        {
            using (SqlCommand cmd = new SqlCommand(query, connect))
            {
                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return 0;
        }
        finally
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
        }
    }


    private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DashBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void ReportBtn_Click(object sender, EventArgs e)
        {
            AdminYearlyRep reportForm = new AdminYearlyRep();
            reportForm.Show();
            this.Hide();
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            AdminUsers adminUsersForm = new AdminUsers();
            adminUsersForm.Show();
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

        private void MinBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Total_Users_Chart_Click(object sender, EventArgs e)
        {
            

        }

        private void Active_Users_Chart_Click(object sender, EventArgs e)
        {
           

        }

        private void Inctive_Users_Chart_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

