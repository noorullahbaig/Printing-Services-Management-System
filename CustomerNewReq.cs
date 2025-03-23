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
    public partial class CustomerNewReq : Form
    {
        private int userId;
        private List<PrintingService> services = new List<PrintingService>(); 
        public CustomerNewReq(int userId)
        {
            InitializeComponent();
            InitializeServices();
            InitializeDataGridView();
            this.userId = userId;
        }

        private void InitializeServices()
        {
            services.Add(new PrintingService(1, "Printing - Black and White", "A4", 0.80M, 100, 0.10M));
            services.Add(new PrintingService(2, "Printing - Color", "A4", 2.50M, 100, 0.10M));
            services.Add(new PrintingService(3, "Binding - Comb Binding", "n/a", 5.50M, 0, 0M));
            services.Add(new PrintingService(4, "Binding - Thick Cover", "n/a", 9.30M, 0, 0M));
            services.Add(new PrintingService(5, "Printing - Poster", "A0", 6.00M, 100, 0.10M));
            services.Add(new PrintingService(6, "Printing - Poster", "A1", 6.00M, 100, 0.10M));
            services.Add(new PrintingService(7, "Printing - Poster", "A2", 3.00M, 100, 0.10M));
            services.Add(new PrintingService(8, "Printing - Poster", "A3", 3.00M, 100, 0.10M));
        }
        private void CustomerNewReq_Load(object sender, EventArgs e)
        {

        }

      
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void service_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            size.Items.Clear(); 

            if (service_type.SelectedItem != null)
            {
                string selectedServiceType = service_type.SelectedItem.ToString();
                var relevantSizes = services.Where(s => s.ServiceType.Contains(selectedServiceType))
                                            .Select(s => s.Size)
                                            .Distinct();

                foreach (var sizeOption in relevantSizes)
                {
                    size.Items.Add(sizeOption);
                }

                if (size.Items.Count > 0)
                {
                    size.SelectedIndex = 0; 
                }

                UpdateFeesAndDiscounts(); 
            }
        }

        private void UpdateFeesAndDiscounts()
        {
            if (service_type.SelectedItem != null && size.SelectedItem != null)
            {
                var selectedService = services.FirstOrDefault(s => s.ServiceType == service_type.SelectedItem.ToString() && s.Size == size.SelectedItem.ToString());
                if (selectedService != null)
                {
                    fee_perpage.Text = selectedService.FeesPerUnit.ToString("0.00");
                    CalculateAndDisplayTotalPrice();
                }
            }
        }

            private void label4_Click(object sender, EventArgs e)
        {

        }

        private void size_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFeesAndDiscounts();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(quantity.Text))
            {
                if (int.TryParse(quantity.Text, out int qty) && qty > 1000 && qty < 1)
                {
                    MessageBox.Show("The quantity cannot exceed 1000.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    quantity.Text = "";
                }
            }
            CalculateAndDisplayTotalPrice();

        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void fee_perpage_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void total_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void urgent_request_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayTotalPrice();
        }

        private void CalculateAndDisplayTotalPrice()
        {
            if (service_type.SelectedItem != null && int.TryParse(quantity.Text, out int qty))
            {
                var selectedService = services.FirstOrDefault(s => s.ServiceType == service_type.SelectedItem.ToString());
                bool isUrgent = urgent_request.Checked;
                if (selectedService != null)
                {
                    decimal totalPrice = selectedService.CalculateTotalCost(qty, isUrgent);
                    total_price.Text = totalPrice.ToString("0.00");
                }
            }
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(quantity.Text, out int qty) && qty <= 1000 && qty > 0) 
            {
                string serviceType = service_type.SelectedItem?.ToString() ?? "N/A";
                string size = this.size.SelectedItem?.ToString() ?? "N/A";
                string feesPerPage = fee_perpage.Text;
                string totalPrice = total_price.Text;
                string urgent = urgent_request.Checked ? "Yes" : "No";

                dataGridView1.Rows.Add(serviceType, size, qty, feesPerPage, totalPrice, urgent);
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity (1-1000).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantity.Text = ""; 
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Add("ServiceType", "Service Type");
            dataGridView1.Columns.Add("Size", "Size");
            dataGridView1.Columns.Add("Quantity", "Quantity");
            dataGridView1.Columns.Add("FeesPerPage", "Fees Per Page (RM)");
            dataGridView1.Columns.Add("TotalPrice", "Total Price (RM)");
            dataGridView1.Columns.Add("Urgent", "Urgent Request");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.ReadOnly = true;
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            service_type.SelectedIndex = -1;
            size.SelectedIndex = -1;
            quantity.Clear();
            fee_perpage.Clear();
            total_price.Clear();
            urgent_request.Checked = false;
        }

        private void SubReqBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0 || (dataGridView1.Rows.Count == 1 && dataGridView1.Rows[0].IsNewRow))
            {
                MessageBox.Show("There are no requests to submit.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;"); 
                connect.Open();

                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string serviceType = row.Cells["ServiceType"].Value.ToString();
                            string size = row.Cells["Size"].Value.ToString();
                            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                            decimal feesPerPage = Convert.ToDecimal(row.Cells["FeesPerPage"].Value);
                            decimal totalPrice = Convert.ToDecimal(row.Cells["TotalPrice"].Value);
                            bool urgent = row.Cells["Urgent"].Value.ToString().Equals("Yes");
                            string status = "New"; 
                            int assignedWorkerID = 0; 

                            string query = "INSERT INTO ServiceRequests (ServiceType, FeesPerPageRM, Quantity, CustomerID, TotalPriceRM, UrgentRequest, Status, AssignedWorkerID) VALUES (@ServiceType, @FeesPerPage, @Quantity, @CustomerID, @TotalPrice, @UrgentRequest, @Status, @AssignedWorkerID)";

                            using (SqlCommand cmd = new SqlCommand(query, connect))
                            {
                                cmd.Parameters.AddWithValue("@ServiceType", serviceType);
                                cmd.Parameters.AddWithValue("@FeesPerPage", feesPerPage);
                                cmd.Parameters.AddWithValue("@Quantity", quantity);
                                cmd.Parameters.AddWithValue("@CustomerID", this.userId);
                                cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                                cmd.Parameters.AddWithValue("@UrgentRequest", urgent);
                                cmd.Parameters.AddWithValue("@Status", status);
                                cmd.Parameters.AddWithValue("@AssignedWorkerID", assignedWorkerID);

                                cmd.ExecuteNonQuery(); 
                            }
                        }
                    }

                    MessageBox.Show("Requests submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to submit requests: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close(); 
                }
            }
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

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void NewReqBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void ProfileBtn_Click(object sender, EventArgs e)
        {
            CustomerProfile ProfileForm = new CustomerProfile(userId);
            ProfileForm.Show();
            this.Hide();
        }

        private void DashBtn_Click(object sender, EventArgs e)
        {
            Customer_Dash_ CustomerDash = new Customer_Dash_(userId);
            CustomerDash.Show();
            this.Close();
        }

        private void ReqStatusBtn_Click(object sender, EventArgs e)
        {
            CustomerReqList reqListForm = new CustomerReqList(userId);
            reqListForm.Show();
            this.Hide();
        }
    }
}
