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
using System.Drawing.Printing;

namespace AssignmentForms
{
    public partial class CustomerPayment : Form
    {
        public CustomerPayment()
        {
            InitializeComponent();
        }

        string conStr = @"Data Source=LAPTOP-PRUQ23QK;Initial Catalog=UOMAssignmentApp;Integrated Security=True";
        private string sqlStr = "SELECT * FROM Payment";
        DataTable dt = new DataTable();

        public static double total = 0;


        private void Save()
        {
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conStr);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
            sda.Dispose();
        }

        private void CustomerPayment_Load(object sender, EventArgs e)
        {
            txtCustomerId.Text = InsertCustomer.customerId.ToString();
            txtEmployeeId.Text = InsertCustomer.employeeId.ToString();
            txtDivePrice.Text = CustomerBooking.divePrice.ToString();
            txtCoursePrice.Text = CustomerBooking.coursePrice.ToString();
            txtProductPrice.Text = InventoryEmployees.finalPrice.ToString();
            lblDate.Text = DateTime.Now.ToString("dd MMMM,yyyy");
        }

        private void btnCalTotal_Click(object sender, EventArgs e)
        {
            total = double.Parse(txtDivePrice.Text) + double.Parse(txtCoursePrice.Text) + double.Parse(txtProductPrice.Text);
            txtTotal.Text = total.ToString("C2");
        }

        string paymentMethod;

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (radCreditCard.Checked)
            {
                paymentMethod = "Credit Card";
                if (MessageBox.Show("Print Receipt", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    PrintDocument doc = new PrintDocument();
                    doc.PrintPage += this.Doc_PrintPage;
                    PrintDialog dlgSettings = new PrintDialog();
                    dlgSettings.Document = doc;
                    if (dlgSettings.ShowDialog() == DialogResult.OK)
                    {
                        doc.Print();
                    }
                }
            }

            else if (radMCBJuice.Checked)
            {
                paymentMethod = "MCB Juice";
                MessageBox.Show("101030300200000", "Diving Centre’s Account Number", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (radCash.Checked)
            {
                paymentMethod = "Cash";
                if (MessageBox.Show("Print Receipt", "Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    PrintDocument doc = new PrintDocument();
                    doc.PrintPage += this.Doc_PrintPage;
                    PrintDialog dlgSettings = new PrintDialog();
                    dlgSettings.Document = doc;
                    if (dlgSettings.ShowDialog() == DialogResult.OK)
                    {
                        doc.Print();
                    }
                }
            }

            lblCustomerID.Text = txtCustomerId.Text;
            lblEmployeeID.Text = txtEmployeeId.Text;
            lblDivePrice.Text = txtDivePrice.Text;
            lblCoursePrice.Text = txtCoursePrice.Text;
            lblProductPrice.Text = txtProductPrice.Text;
            lblTotal.Text = txtTotal.Text;

            DataRow newRow = dt.NewRow();
            newRow["AccountNumber"] = txtAccountNo.Text;
            newRow["CustomerId"] = txtCustomerId.Text;
            newRow["EmployeeId"] = txtEmployeeId.Text;
            newRow["NumberOfDives"] = txtNoOfDives.Text;
            newRow["CoursePrice"] = txtDivePrice.Text;
            newRow["CoursePrice"] = txtCoursePrice.Text;
            newRow["ProductPrice"] = txtProductPrice.Text;
            newRow["PaymentMethod"] = paymentMethod;

            dt.Rows.Add(newRow);
            Save();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.groupBox1.Width, this.groupBox1.Height);
            this.groupBox1.DrawToBitmap(bmp, new Rectangle(0, 0, this.groupBox1.Width, this.groupBox1.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMenu myEmployee = new EmployeeMenu();
            myEmployee.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
