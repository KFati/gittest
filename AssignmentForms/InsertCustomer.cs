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
    public partial class InsertCustomer : Form
    {
        public InsertCustomer()
        {
            InitializeComponent();
        }

        public static int customerId;
        public static int employeeId;

        private string gender;

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            customerId = int.Parse(txtCustomerId.Text);
            employeeId = int.Parse(txtEmployeeId.Text);

            SqlConnection Con = new SqlConnection("Data Source=LAPTOP-PRUQ23QK;Initial Catalog=UOMAssignmentApp;Integrated Security=True");
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("InsertCustomer", Con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.Add("@CustomerId", SqlDbType.Int).Value = customerId;
            sda.SelectCommand.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
            sda.SelectCommand.Parameters.Add("@CustomerFname", SqlDbType.VarChar).Value = txtCustFname.Text;
            sda.SelectCommand.Parameters.Add("@CustomerLname", SqlDbType.VarChar).Value = txtCustLname.Text;
            if (radMale.Checked)
                sda.SelectCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = "Male";
            else if (radFemale.Checked)
                sda.SelectCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = "Female";



            sda.SelectCommand.Parameters.Add("@CustomerAddress", SqlDbType.VarChar).Value = txtCustAddress.Text;
            sda.SelectCommand.Parameters.Add("@MedicalStatement", SqlDbType.VarChar).Value = txtMedStatement.Text;
            sda.SelectCommand.Parameters.Add("@DiveInsuranceNum", SqlDbType.Int).Value = txtDiveInsuNum.Text;
            sda.SelectCommand.Parameters.Add("@DiverLevel", SqlDbType.VarChar).Value = txtDiverLevel.Text;
            sda.SelectCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = txtEmailAdd.Text;
            sda.SelectCommand.Parameters.Add("@PhoneNum", SqlDbType.Int).Value = txtPhoneNum.Text;

            sda.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Details added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Customer] ([EmployeeId], [CustomerFname], [CustomerLname],[gender], [CustomerAddress], [MedicalStatement], [DiveInsuranceNum], [DiverLevel], [EmailAddress], [PhoneNum])
            // VALUES
            //('" + txtEmployeeId.Text + "' , '" + txtCustFname.Text + "' , '" + txtCustLname.Text + "' , '" + gender + "' , '" + txtCustAddress.Text + "' , '" + txtMedStatement.Text + "' , '" + txtDiveInsuNum.Text + "' , '" + txtDiverLevel.Text + "' , '" + txtEmailAdd.Text + "' , '" + txtPhoneNum.Text +  "')", Con);
            //cmd.ExecuteNonQuery();
            Con.Close();
            LoadData();
        }

        public void LoadData()
        {
            SqlConnection Con = new SqlConnection("Data Source=LAPTOP-PRUQ23QK;Initial Catalog=UOMAssignmentApp;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from [UOMAssignmentApp].[dbo].[Customer]", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["CustomerId"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["EmployeeId"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["CustomerFname"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["CustomerLname"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["gender"].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item["CustomerAddress"].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item["MedicalStatement"].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item["DiveInsuranceNum"].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item["DiverLevel"].ToString();
                dataGridView1.Rows[n].Cells[9].Value = item["EmailAddress"].ToString();
                dataGridView1.Rows[n].Cells[10].Value = item["PhoneNum"].ToString();


            }


        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtCustFname.Clear();
            txtCustLname.Clear();
            txtCustAddress.Clear();
            txtMedStatement.Clear();
            txtDiveInsuNum.Clear();
            txtDiverLevel.Clear();
            txtEmailAdd.Clear();
            txtPhoneNum.Clear();
        }

        private void txtDiveInsuNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtPhoneNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void radMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerBooking MyBooking = new CustomerBooking();
            MyBooking.Show();
        }
    }
}
