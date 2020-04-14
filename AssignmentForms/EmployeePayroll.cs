using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentForms
{
    public partial class EmployeePayroll : Form
    {
        public EmployeePayroll()
        {
            InitializeComponent();
        }

        private void BtnAddPanel_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnAddPanel.Height;
            SidePanel.Top = btnAddPanel.Top;
            addUserCon1.BringToFront();

        }

        private void BtnDeletePanel_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnDeletePanel.Height;
            SidePanel.Top = btnDeletePanel.Top;
            deleteUserCon1.BringToFront();
            deleteUserCon1.LoadData();//load data upon clicking on side btn by using method in user control
        }

        private void BtnViewPanel_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnViewPanel.Height;
            SidePanel.Top = btnViewPanel.Top;
            viewUserCon1.BringToFront();
            viewUserCon1.Clear();//clear to avoid seeing previous data :o
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
