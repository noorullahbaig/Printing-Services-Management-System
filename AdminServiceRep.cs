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
    public partial class AdminServiceRep : Form
    {
        private int userId;
        public AdminServiceRep()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void YearcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenBtn_Click(object sender, EventArgs e)
        {
            if (YearcomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a year.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            if (MonthcomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a month.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            int selectedYear = int.Parse(YearcomboBox.SelectedItem.ToString());
            int selectedMonth = MonthNameToNumber(MonthcomboBox.SelectedItem.ToString());

            string query = @"
    SELECT 
        COUNT(*) AS TotalRequests, 
        SUM(TotalPriceRM) AS TotalIncome 
    FROM ServiceRequests
    WHERE 
        YEAR(RequestDate) = @Year AND 
        MONTH(RequestDate) = @Month";

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True"))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Year", selectedYear);
                    command.Parameters.AddWithValue("@Month", selectedMonth);

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            dataGridView1.DataSource = null; 
                            MessageBox.Show("No data found for the selected month and year.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to retrieve data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void MonthcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
