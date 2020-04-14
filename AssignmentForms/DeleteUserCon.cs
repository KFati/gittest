using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AssignmentForms
{
    public partial class DeleteUserCon : UserControl
    {
        public DeleteUserCon()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lviEmployees.CheckedItems.Count;// total num of checked items
            if (i >= 1)//at least one item checked
            {
                if (MessageBox.Show($"Are you sure you want to delete {i} item(s)?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (ListViewItem lvitem in lviEmployees.Items)
                    {
                        if (lvitem.Checked)//check if item is checked
                        {
                            lviEmployees.Items.Remove(lvitem);//remove item
                            //remove from database
                            string conStr = "Data Source=LAPTOP-PRUQ23QK;Initial Catalog=UOMAssignmentApp;Integrated Security=True";
                            string sqlReadStr = @" DELETE FROM [dbo].[payroll] WHERE EmployeeId=" + lvitem.Text + ";";
                            SqlConnection Con = new SqlConnection(conStr);
                            Con.Open();
                            SqlCommand cmd = new SqlCommand(sqlReadStr, Con);
                            cmd.ExecuteNonQuery();
                            Con.Close();
                        }
                    }
                }
            }
            else//no items checked
            {
                MessageBox.Show("No items have been selected.Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadData()
        {
            lviEmployees.Items.Clear();
            //enabling checkboxes
            lviEmployees.CheckBoxes = true;
            //upon load all data already appears:
            string conStr = "Data Source=LAPTOP-PRUQ23QK;Initial Catalog=UOMAssignmentApp;Integrated Security=True";
            //sql command to retrieve data from tblPayroll
            string sqlReadStr = @"SELECT * FROM [dbo].[Payroll];";
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
    }
}
