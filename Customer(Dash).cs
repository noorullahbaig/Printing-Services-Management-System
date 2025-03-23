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
using System.Windows.Forms.DataVisualization.Charting;

namespace OopFinalProject
{
    public partial class Customer_Dash_ : Form
    {
        private int userId;

        public Customer_Dash_(int userId)
        {
            InitializeComponent();
            this.userId = userId;
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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
            this.Refresh();
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
            CustomerProfile ProfileForm = new CustomerProfile(userId);
            ProfileForm.Show();
            this.Hide();
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void RefreshData()
        {
            int totalRequests = GetCount("SELECT COUNT(*) FROM ServiceRequests WHERE CustomerID = @UserId");
            int progressRequests = GetCount("SELECT COUNT(*) FROM ServiceRequests WHERE CustomerID = @UserId AND Status IN ('New', 'Assigned', 'WIP')");
            int completedRequests = GetCount("SELECT COUNT(*) FROM ServiceRequests WHERE CustomerID = @UserId AND Status = @Status", "Completed");

            label7.Text = totalRequests.ToString();
            label8.Text = progressRequests.ToString();
            label9.Text = completedRequests.ToString();

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

        private void total_req_Chart_Click(object sender, EventArgs e)
        {

        }

        private void req_progress_Chart_Click(object sender, EventArgs e)
        {

        }

        private void completed_req_Chart_Click(object sender, EventArgs e)
        {

        }
    }
}
