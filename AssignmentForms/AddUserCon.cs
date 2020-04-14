using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AssignmentForms
{
    public partial class AddUserCon : UserControl
    {
        public AddUserCon()
        {
            InitializeComponent();
        }

        private void btnCalcSalary_Click(object sender, EventArgs e)
        {
            //exception for null txtbox messagebox?
            double amount = 0;
            double basicSalary = 5000;
            int numOfHours = int.Parse(txtHoursWorked.Text);
            amount = numOfHours * basicSalary;
            txtAmount.Text = amount.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeId.Clear();
            txtHoursWorked.Clear();
            txtAmount.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //when entering data in text boxes, save to database
            string conStr = "Data Source=LAPTOP-PRUQ23QK;Initial Catalog=UOMAssignmentApp;Integrated Security=True";
            string sqlStr = @"Insert into [dbo].[payroll]([EmployeeId],[HoursWorked],[Amount]) " +
                "values('" + txtEmployeeId.Text + "','" + txtHoursWorked.Text + "','" + txtAmount.Text + "'); ";
            SqlConnection Con = new SqlConnection(conStr);
            Con.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Data Saved Successfully");
        }
    }
}
