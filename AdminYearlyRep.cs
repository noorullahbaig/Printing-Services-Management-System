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
    public partial class AdminYearlyRep : Form
    {
        private int userId;
        public AdminYearlyRep()
        {
            InitializeComponent();
        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

            string selectedYear = YearcomboBox.SelectedItem.ToString();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Integrated Security=True";
            string query = @"
        SELECT 
            MONTH(RequestDate) AS Month, 
            SUM(TotalPriceRM) AS TotalIncome 
        FROM ServiceRequests
        WHERE YEAR(RequestDate) = @Year
        GROUP BY MONTH(RequestDate)
        ORDER BY MONTH(RequestDate)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Year", selectedYear);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dataTable; 
                            }
                            else
                            {
                                dataGridView1.DataSource = null; 
                                MessageBox.Show("No data found for the selected year.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve grand total: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
