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
    public partial class WorkerDash : Form
    {
        private int userId;
        public WorkerDash(int userId)
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

        private void DashBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void AssignedTaskBtn_Click(object sender, EventArgs e)
        {
            WorkerTask workerTaskForm = new WorkerTask(userId);
            workerTaskForm.Show();
            this.Hide();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            WorkerProfile profileForm = new WorkerProfile(userId);
            profileForm.Show();
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void RefreshData()
        {
            int assignedTasks = GetCount("SELECT COUNT(*) FROM ServiceRequests WHERE AssignedWorkerID = @UserId AND Status = 'Assigned'");
            int progressTasks = GetCount("SELECT COUNT(*) FROM ServiceRequests WHERE AssignedWorkerID = @UserId AND Status IN ('WIP')");
            int completedTasks = GetCount("SELECT COUNT(*) FROM ServiceRequests WHERE AssignedWorkerID = @UserId AND Status = 'Completed'");

            label7.Text = assignedTasks.ToString();
            label8.Text = progressTasks.ToString();
            label9.Text = completedTasks.ToString();

            UpdateChart(assigned_task_Chart, assignedTasks, "Assigned Tasks");
            UpdateChart(task_in_prog_Chart, progressTasks, "Tasks in Progress");
            UpdateChart(completed_task_Chart, completedTasks, "Completed Tasks");
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
                object result = cmd.ExecuteScalar();
                connection.Close();

                return Convert.ToInt32(result);
            }
        }

        private void assigned_task_Chart_Click(object sender, EventArgs e)
        {

        }

        private void task_in_prog_Chart_Click(object sender, EventArgs e)
        {

        }

        private void completed_task_Chart_Click(object sender, EventArgs e)
        {

        }
    }
}
