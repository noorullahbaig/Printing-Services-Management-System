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
    public partial class ManagerAssignTask : Form
    {
        private int userId;
        public ManagerAssignTask(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserRequests();
            LoadNewTasks();
            LoadWorkers();        }

        private void label4_Click(object sender, EventArgs e)
        {

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
            ManagerAllReq allReqForm = new ManagerAllReq(userId);
            allReqForm.Show();
            this.Hide();
        }

        private void AssignTaskBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
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

        private void NewTaskList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WorkerList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            LoadUserRequests();
            LoadNewTasks();
            LoadWorkers();
        }

        private void assignBtn_Click(object sender, EventArgs e)
        {

            if (New_Task_List.SelectedItem == null || Worker_List.SelectedItem == null)
            {
                MessageBox.Show("Please select both a task and a worker.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                string selectedTask = New_Task_List.SelectedItem.ToString();
                int taskId = int.Parse(selectedTask.Split(new string[] { "(ID: ", ")" }, StringSplitOptions.RemoveEmptyEntries)[1]);

                string selectedWorker = Worker_List.SelectedItem.ToString();
                int workerId = int.Parse(selectedWorker.Split(new string[] { "(ID: ", ")" }, StringSplitOptions.RemoveEmptyEntries)[1]);

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True";
                string updateQuery = @" UPDATE ServiceRequests SET AssignedWorkerID = @WorkerId, Status = 'Assigned' WHERE RequestID = @RequestId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@WorkerId", workerId);
                    command.Parameters.AddWithValue("@RequestId", taskId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserRequests(); 

                        }
                        else
                        {
                            MessageBox.Show("No changes were made. Please check your selections.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to assign task: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

    private void LoadNewTasks()
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True";
        string query = "SELECT RequestID, ServiceType, UrgentRequest FROM ServiceRequests WHERE Status = 'New' order by UrgentRequest desc";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable tasks = new DataTable("New Tasks");
        adapter.Fill(tasks);
        New_Task_List.Items.Clear();               
        foreach (DataRow row in tasks.Rows)
        {
            string displayText = $"{row["ServiceType"]} (ID: {row["RequestID"]}) (Urgent: {row["UrgentRequest"]})";
            New_Task_List.Items.Add(displayText);
        }
    }

        private void LoadWorkers()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True";
            string query = "SELECT UserID, Username FROM allusers WHERE Role = 'Worker'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable workers = new DataTable();
                adapter.Fill(workers);
                Worker_List.Items.Clear(); 
                foreach (DataRow row in workers.Rows)
                {
                    string displayText = $"{row["Username"]} (ID: {row["UserID"]})";
                    Worker_List.Items.Add(displayText);
                }
            }
        }

        private void NewTaskList_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Worker_List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
