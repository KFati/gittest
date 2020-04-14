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
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
        }

        string conStr = @"Data Source=LAPTOP-PRUQ23QK;Initial Catalog=UOMAssignmentApp;Integrated Security=True";
        string sqlStr = "SELECT * FROM Inventory";
        DataTable dt = new DataTable();

        private void AddItem_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conStr);
            sda.Fill(dt);
            sda.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow newRow = dt.NewRow();
            newRow["ItemId"] = txtItemId.Text;
            newRow["ItemName"] = txtItemName.Text;
            newRow["size"] = txtSize.Text;
            newRow["NumInStock"] = txtQuantity.Text;
            dt.Rows.Add(newRow);
            Save();

            txtItemId.Clear();
            txtItemName.Clear();
            txtSize.SelectedIndex = -1;
            txtQuantity.Clear();

            MessageBox.Show("Item Added", " ", MessageBoxButtons.OK);
        }
        private void Save()
        {
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conStr);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
            sda.Dispose();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
