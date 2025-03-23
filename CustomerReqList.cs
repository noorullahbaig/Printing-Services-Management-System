using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection.Emit;

namespace OopFinalProject
{
    public partial class CustomerReqList : Form
    {
        private int userId;
        public CustomerReqList(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserRequests();
            RefreshData();
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
                SELECT RequestID, ServiceType, FeesPerPageRM, Quantity, TotalPriceRM, UrgentRequest, Status 
                FROM ServiceRequests 
                WHERE CustomerID = @UserId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable; 
                        dataGridView1.AutoGenerateColumns = true; 
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        dataGridView1.Columns["UrgentRequest"].ReadOnly = true; 
                        dataGridView1.Columns["UrgentRequest"].HeaderText = "Urgent Request"; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load request data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            this.Refresh();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            CustomerProfile ProfileForm = new CustomerProfile(userId);
            ProfileForm.Show();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

      

        private void total_req_Chart_Click(object sender, EventArgs e)
        {

        }

        private void req_progress_Chart_Click(object sender, EventArgs e)
        {

        }

        private void completed_req_Chart_Click_1(object sender, EventArgs e)
        {

        }
        private int GetCount(string query, string status = null)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@UserId", userId);

                if (status != null)
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                connection.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();

                return result;
            }
        }

        private void RefreshData()
        {
            int totalRequests = GetCount("SELECT COUNT(*) FROM ServiceRequests WHERE CustomerID = @UserId");
            int progressRequests = GetCount("SELECT COUNT(*) FROM ServiceRequests WHERE CustomerID = @UserId AND Status IN ('New', 'Assigned', 'WIP')");
            int completedRequests = GetCount("SELECT COUNT(*) FROM ServiceRequests WHERE CustomerID = @UserId AND Status = @Status", "Completed");

            UpdateChart(total_req_Chart, totalRequests, "Total Requests");
            UpdateChart(req_progress_Chart, progressRequests, "Requests in Progress");
            UpdateChart(completed_req_Chart, completedRequests, "Completed Requests");
        }

        private void UpdateChart(Chart chart, int count, string seriesName)
        {
            chart.Series.Clear();  
            Series series = chart.Series.Add(seriesName);
            series.Points.Add(count);
            chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;  
            chart.ChartAreas[0].AxisY.Minimum = 0;  
            series.ChartType = SeriesChartType.Column;  
            series.IsValueShownAsLabel = true;  
        }

    }
    }
