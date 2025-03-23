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
    public partial class AdminCustomerRep : Form
    {
        private int userId;
        public AdminCustomerRep()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            Admin adminForm = new Admin(userId);
            adminForm.Show();
            this.Hide();
        }

        private void ReportBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
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

        private void RepTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RepTypecomboBox.SelectedItem != null)
            {
                string selectedType = RepTypecomboBox.SelectedItem.ToString();

                this.Hide();

                if (selectedType == "Yearly Report")
                {
                    AdminYearlyRep yearlyReportForm = new AdminYearlyRep();
                    yearlyReportForm.Show();
                }
                else if (selectedType == "Service Report")
                {
                    AdminServiceRep serviceReportForm = new AdminServiceRep();
                    serviceReportForm.Show();
                }
                else if (selectedType == "Customer Report")
                {
                    AdminCustomerRep customerReportForm = new AdminCustomerRep();
                    customerReportForm.Show();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MonthcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void YearcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null || YearcomboBox.SelectedItem == null || MonthcomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer, year, and month.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedCustomerItem = listBox1.SelectedItem.ToString();
            int idStart = selectedCustomerItem.IndexOf("ID: ") + 4;
            int idEnd = selectedCustomerItem.IndexOf(")", idStart);
            int customerId = int.Parse(selectedCustomerItem.Substring(idStart, idEnd - idStart));

            int selectedYear = int.Parse(YearcomboBox.SelectedItem.ToString());
            string selectedMonthName = MonthcomboBox.SelectedItem.ToString();

            int selectedMonth = MonthNameToNumber(selectedMonthName);

            if (selectedMonth == -1)
            {
                MessageBox.Show("Invalid month name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True";
            string query = @"
        SELECT COUNT(*) AS TotalRequests, SUM(TotalPriceRM) AS TotalIncome
        FROM ServiceRequests
        WHERE CustomerID = @CustomerId AND YEAR(RequestDate) = @Year AND MONTH(RequestDate) = @Month";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.Parameters.AddWithValue("@Year", selectedYear);
                command.Parameters.AddWithValue("@Month", selectedMonth);

                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found for the selected criteria.", "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private int MonthNameToNumber(string monthName)
        {
            var monthNames = new Dictionary<string, int>
    {
        {"January", 1}, {"February", 2}, {"March", 3},
        {"April", 4}, {"May", 5}, {"June", 6},
        {"July", 7}, {"August", 8}, {"September", 9},
        {"October", 10}, {"November", 11}, {"December", 12}
    };

            if (monthNames.TryGetValue(monthName, out int monthNumber))
            {
                return monthNumber;
            }
            return -1; 
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg";
                saveFileDialog.DefaultExt = "png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Export Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void LoadCustomers()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True";
            string query = "SELECT UserID, Username FROM allusers WHERE Role = 'Customer'"; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable customers = new DataTable();
                adapter.Fill(customers);
                listBox1.Items.Clear();
                foreach (DataRow row in customers.Rows)
                {
                    string displayText = $"{row["Username"]} (ID: {row["UserID"]})";
                    listBox1.Items.Add(displayText);
                }
            }
        }

        private void AdminCustomerRep_Load(object sender, EventArgs e)
        {

        }
    }
}
