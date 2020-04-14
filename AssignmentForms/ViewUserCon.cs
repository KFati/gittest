using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AssignmentForms
{
    public partial class ViewUserCon : UserControl
    {
        public ViewUserCon()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            lviEmployees.Items.Clear();//clear to avoid data duplication
            //from database add to list view all stored data
            string conStr = "Data Source=LAPTOP-PRUQ23QK;Initial Catalog=UOMAssignmentApp;Integrated Security=True";
            //sql command to retrieve data from tblPayroll
            string sqlReadStr = @"SELECT * FROM [dbo].[payroll];";
            SqlConnection Con = new SqlConnection(conStr);
            Con.Open();
            SqlCommand cmd = new SqlCommand(sqlReadStr, Con);
            SqlDataReader reader = cmd.ExecuteReader();
            //adding items to list view using a while loop
            while (reader.Read())
            {
                ListViewItem lviEmployeeSalary = new ListViewItem(reader["EmployeeId"].ToString());
                lviEmployeeSalary.SubItems.Add(reader["HoursWorked"].ToString());
                lviEmployeeSalary.SubItems.Add(reader["Amount"].ToString());
                lviEmployees.Items.Add(lviEmployeeSalary);
            }
            Con.Close();
        }

        public void Clear()
        {
            lviEmployees.Items.Clear();
        }
    }
}
