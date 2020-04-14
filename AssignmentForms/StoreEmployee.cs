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

namespace AssignmentForms
{
    public partial class StoreEmployee : Form
    {
        public StoreEmployee()
        {
            InitializeComponent();
        }

        private string conStr = @"Data Source=LAPTOP-PRUQ23QK;Initial Catalog=UOMAssignmentApp;Integrated Security=True";
        private string sqlStr = "SELECT * FROM Employee";
        DataTable dt = new DataTable();
        private int inc;
        private void NavigateRecords()
        {
            txtEmployeeId.Text = dt.Rows[inc]["EmployeeId"].ToString();
            txtEmpFname.Text = dt.Rows[inc]["EmpFname"].ToString();
            txtEmpLname.Text = dt.Rows[inc]["EmpLname"].ToString();
            txtEmpAddress.Text = dt.Rows[inc]["EmpAddress"].ToString();
            txtSex.Text = dt.Rows[inc]["gender"].ToString();
            txtPosition.Text = dt.Rows[inc]["position"].ToString();

        }
        private void Save()
        {
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conStr);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
            sda.Dispose();
            NavigateRecords();
        }

        private void StoreEmployee_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conStr);
            sda.Fill(dt);
            sda.Dispose();
            NavigateRecords();
        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            inc = 0;
            NavigateRecords();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (inc > 0)
                inc--;
            NavigateRecords();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (inc < dt.Rows.Count - 1)
                inc++;
            NavigateRecords();
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            inc = dt.Rows.Count - 1;
            NavigateRecords();
        }

        private void BtnPreviousfrm_Click(object sender, EventArgs e)
        {
            this.Hide();
            StoreCustomer MyCustomerDetails = new StoreCustomer();
            MyCustomerDetails.Show();
        }

        private void BtnNextfrm_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookingDetails MyList = new BookingDetails();
            MyList.Show();
        }
    }
}
