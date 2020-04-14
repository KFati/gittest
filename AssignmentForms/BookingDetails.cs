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
    public partial class BookingDetails : Form
    {
        public BookingDetails()
        {
            InitializeComponent();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection("Data Source=LAPTOP-PRUQ23QK;Initial Catalog=UOMAssignmentApp;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from [UOMAssignmentApp].[dbo].[booking]", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["BookingId"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["CustomerId"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["EmployeeId"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["DiveName"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item["CourseName"].ToString();
            }
                



            
        }

        private void btnNextForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryAdmin inventoryAdmin = new InventoryAdmin();
            inventoryAdmin.Show();
        }
    }
}
