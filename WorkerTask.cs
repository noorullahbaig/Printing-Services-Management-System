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
    public partial class WorkerTask : Form
    {
        private int userId;
        public WorkerTask(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserRequests();
            LoadNewTasks();
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
            this.Refresh();
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            JOIN allusers u ON s.AssignedWorkerID = u.UserID
            WHERE s.AssignedWorkerID = @UserId"; 

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId); 

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable; 
                        dataGridView2.AutoGenerateColumns = true; 
                        dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        dataGridView2.Columns["UrgentRequest"].ReadOnly = true; 
                        dataGridView2.Columns["UrgentRequest"].HeaderText = "Urgent Request";
                        dataGridView2.Columns["UserID"].HeaderText = "User ID";
                        dataGridView2.Columns["Username"].HeaderText = "Username";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString()); 
                    MessageBox.Show("Failed to load request data: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void New_Task_List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadNewTasks()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True";
            
            string query = "SELECT RequestID, ServiceType, UrgentRequest FROM ServiceRequests WHERE Status IN ('Assigned', 'WIP') AND AssignedWorkerID = @UserId ORDER BY UrgentRequest DESC";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);  

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable tasks = new DataTable("Assigned Tasks");
                adapter.Fill(tasks);
                New_Task_List.Items.Clear();                 

                foreach (DataRow row in tasks.Rows)
                {
                    string displayText = $"{row["ServiceType"]} (ID: {row["RequestID"]}) (Urgent: {row["UrgentRequest"]})";
                    New_Task_List.Items.Add(displayText);
                }
            }
        }

        private void WorkInProgBtn_Click(object sender, EventArgs e)
        {
            UpdateTaskStatus("WIP");
        }

        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            UpdateTaskStatus("Completed");
        }

        private void UpdateTaskStatus(string newStatus)
        {
            if (New_Task_List.SelectedItem == null)
            {
                MessageBox.Show("Please select a task from the list.", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedTask = New_Task_List.SelectedItem.ToString();
            int taskIdIndex = selectedTask.IndexOf("ID: ") + 4;
            int endIndex = selectedTask.IndexOf(')', taskIdIndex);
            string taskIdString = selectedTask.Substring(taskIdIndex, endIndex - taskIdIndex);
            int taskId = int.Parse(taskIdString);

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string getStatusQuery = "SELECT Status FROM ServiceRequests WHERE RequestID = @RequestID";
                SqlCommand getStatusCommand = new SqlCommand(getStatusQuery, connection);
                getStatusCommand.Parameters.AddWithValue("@RequestID", taskId);

                try
                {
                    connection.Open();
                    string currentStatus = getStatusCommand.ExecuteScalar().ToString();

                    if (newStatus == "Completed" && currentStatus != "WIP")
                    {
                        MessageBox.Show("A task must be in 'Work In Progress' status before it can be set to 'Completed'.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string updateQuery = "UPDATE ServiceRequests SET Status = @NewStatus WHERE RequestID = @RequestID";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@NewStatus", newStatus);
                    updateCommand.Parameters.AddWithValue("@RequestID", taskId);

                    int result = updateCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Task status updated to " + newStatus, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNewTasks(); 
                    }
                    else
                    {
                        MessageBox.Show("Failed to update task status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating task status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            LoadUserRequests();  
            LoadNewTasks();

        }
    }
}
