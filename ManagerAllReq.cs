using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OopFinalProject
{
    public partial class ManagerAllReq : Form
    {
        private int userId;
        public ManagerAllReq(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserRequests();
            RefreshData();
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
            ManagerDash managerDashboard = new ManagerDash(userId);
            managerDashboard.Show();
            this.Hide();
        }

        private void AllReqBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void AssignTaskBtn_Click(object sender, EventArgs e)
        {
            ManagerAssignTask managerAssignTaskForm = new ManagerAssignTask(userId);
            managerAssignTaskForm.Show();
            this.Hide();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            ManagerProfile managerProfileForm = new ManagerProfile(userId);
            managerProfileForm.Show();
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
        private void LoadUserRequests()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True"; 
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
            SELECT s.RequestID, s.ServiceType, s.FeesPerPageRM, s.Quantity, s.TotalPriceRM, s.UrgentRequest, s.Status, 
                   u.UserID, u.Username
            FROM ServiceRequests s
            JOIN allusers u ON s.CustomerID = u.UserID
            ORDER BY s.UrgentRequest DESC, s.RequestID ASC";  

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable; 
                        dataGridView1.AutoGenerateColumns = true; 
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        dataGridView1.Columns["UrgentRequest"].ReadOnly = true; 
                        dataGridView1.Columns["UrgentRequest"].HeaderText = "Urgent Request";
                        dataGridView1.Columns["UserID"].HeaderText = "User ID";
                        dataGridView1.Columns["Username"].HeaderText = "Username";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load request data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void total_req_Chart_Click(object sender, EventArgs e)
        {

        }

        private void pending_req_Chart_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void RefreshData()
        {
            int totalRequests = GetCount("SELECT COUNT(*) FROM ServiceRequests"); 
            int progressRequests = GetCount("SELECT COUNT(*) FROM ServiceRequests WHERE Status IN ('New', 'Assigned', 'WIP')");
            int completedRequests = GetCount("SELECT COUNT(*) FROM ServiceRequests WHERE Status = 'Completed'");

            UpdateChart(total_req_Chart, totalRequests, "Total Requests");
            UpdateChart(pending_req_Chart, progressRequests, "Requests in Progress");
            UpdateChart(completed_req_Chart, completedRequests, "Completed Requests");
        }

        private void UpdateChart(Chart chart, int count, string seriesName)
        {
            chart.Series.Clear();

            Series series = chart.Series.Add(seriesName);
            series.Points.Add(count);  

            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;  
            chart.ChartAreas[0].AxisY.Minimum = 0;  

            series.IsValueShownAsLabel = true;  
        }
        private int GetCount(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

                return result;
            }
        }
    }
}
