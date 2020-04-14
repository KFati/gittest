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
    public partial class CustomerBooking : Form
    {
        public CustomerBooking()
        {
            InitializeComponent();
            radDiscoverSD.CheckedChanged += Compute;
            radNormalD.CheckedChanged += Compute;
            radSafariD.CheckedChanged += Compute;
            radNightD.CheckedChanged += Compute;

            cbCourse.TextChanged += Compute;

            nupNormalD.Click += Compute;

            txtNoPerson.TextChanged += Compute;
        }

        public static decimal coursePrice;
        public static decimal divePrice;

        string conStr = @"Data Source=LAPTOP-PRUQ23QK;Initial Catalog=UOMAssignmentApp;Integrated Security=True";
        string sqlStr = "SELECT * FROM Booking";
        DataTable dt = new DataTable();

        string dataCourse;
        string newbookingid;

        string DiveNameL; //This one will be displayed in the listbox
        string DiveNameD; //This value is the one that will be sent to the database

        string CourseNameL;
        string CourseNameD;

        private void CustomerBooking_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conStr);
            sda.Fill(dt);
            sda.Dispose();

            //This will find the last Booking Id in the database and add 1 to it to make a new database
            int last;
            string lastbookingid;
            last = dt.Rows.Count - 1; //assign total number of rows in the database to variable last
            lastbookingid = (dt.Rows[last][0]).ToString(); //assign the bookingif of the last variable to lastbookingid
            newbookingid = (double.Parse(lastbookingid) + 1).ToString(); // increment lastbookingid and save the value in newbooking id
            lblBookingId.Text = newbookingid; // show newbookingid in lblbookingid          

            //This will take value from other forms to fill this one, form name and variable name may differ
            txtCusId.Text = InsertCustomer.customerId.ToString();
            txtEmpId.Text = InsertCustomer.employeeId.ToString();
        }

        private void Save()
        {
            SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conStr);
            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
            sda.Update(dt); sda.Dispose();
        }

        private void Clear()
        {
            radDiscoverSD.Checked = false;
            radNormalD.Checked = false;
            radNightD.Checked = false;
            radSafariD.Checked = false;

            chkBeginner.Checked = false;
            chkQualified.Checked = false;

            //cbCourse.SelectedIndex = -1;

        }

        //Check if only one of the checkbox(beginner and qualified) is selected
        private void checkbox()
        {
            int numberChecked = 0;
            CheckBox[] array = new CheckBox[] { chkBeginner, chkQualified };
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Checked)
                    numberChecked++;
            }

            if (numberChecked > 1)
            {
                MessageBox.Show("Please select only ONE Diver Level", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("You have checked " + numberChecked.ToString() + " checkBoxes. Only one is allowed.");
                chkBeginner.Checked = false;
                chkQualified.Checked = false;
            }
        }

        //Prevent user from selecting a radio button(a dive) if no level is selcted
        private void radiobutton()
        {
            int numberChecked = 0;
            RadioButton[] array = new RadioButton[] { radDiscoverSD, radNormalD, radNightD, radSafariD };
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Checked)
                    numberChecked++;
            }

            if (numberChecked >= 1)
            {
                int numberChecked1 = 0;
                CheckBox[] array1 = new CheckBox[] { chkBeginner, chkQualified };
                for (int j = 0; j < array1.Length; j++)
                {
                    if (array1[j].Checked)
                        numberChecked1++;
                }
                if (numberChecked1 < 1)
                {
                    MessageBox.Show("Please select the diver's level!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void chkBeginner_CheckedChanged(object sender, EventArgs e)
        {
            //Call checkbox() if user check chkBeginner
            checkbox();
        }

        private void chkQualified_CheckedChanged(object sender, EventArgs e)
        {
            //Call checkbox() if user check chkQualified
            checkbox();
        }

        //Add value to the listbox 
        private void listbox()
        {
            try
            {

                lstCart.Items.Clear();
                lstCart.Items.Add(DiveNameL);
                lstCart.Items.Add(CourseNameL);
            }
            catch
            {

            }
        }

        private void Compute(object sender, EventArgs e)
        {
            radiobutton();

            //Check if the user selected the correct dives according to their level. 
            //For e.g. someone with a beginner level cannot do a normal dive
            if (chkBeginner.Checked)
            {
                bool flag = false;
                foreach (RadioButton rdo in gbQualified.Controls.OfType<RadioButton>())
                {
                    if (rdo.Checked)
                    {
                        flag = true;
                        Clear();
                        break;
                    }
                }
                if (flag)
                {
                    MessageBox.Show("Qualified level required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (chkQualified.Checked)
            {
                bool flag1 = false;

                foreach (RadioButton rdo in gbBeginner.Controls.OfType<RadioButton>())
                {
                    if (rdo.Checked)
                    {
                        flag1 = true;
                        Clear();
                        break;
                    }
                }
                if (flag1)
                {
                    MessageBox.Show("Please choose from the section for Qualified Divers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Add value to the total according to the radio button chosen
            decimal total = 0;
            decimal NoDive;
            int NoPerson;
            decimal finalTotal;
            decimal NormalDiveTotal;
            decimal NormalDiveTotalMinus;

            if (radDiscoverSD.Checked)
            {
                total += 2500;
                divePrice += 2500;
                DiveNameL = "Discover Scuba Diving   (Rs 2, 500)";
                DiveNameD = "Discover Scuba Diving";
            }
            if (radNormalD.Checked)
            {
                DiveNameD = "Normal Dive";
                NoDive = nupNormalD.Value;
                if (NoDive < 5)
                {
                    NormalDiveTotal = 1500 * NoDive;
                    divePrice += NormalDiveTotal;
                    total += NormalDiveTotal;
                    DiveNameL = "Normal Dive   (Rs " + NormalDiveTotal + ")";
                }
                else if (NoDive >= 5 && NoDive < 10)
                {
                    //Applying 5 Dive Package
                    NormalDiveTotal = 7000 + (1400 * (NoDive - 5));
                    divePrice += NormalDiveTotal;
                    total += NormalDiveTotal;
                    NormalDiveTotalMinus = 1400 * (NoDive - 5);
                    DiveNameL = "5 Dive Package   (Rs 7, 000) + Normal Dive  (Rs " + NormalDiveTotalMinus + ")";
                }
                else if (NoDive >= 10)
                {
                    //Applying 10 Dive Package
                    NormalDiveTotal = 13500 + (1350 * (NoDive - 10));
                    divePrice += NormalDiveTotal;
                    total += NormalDiveTotal;
                    NormalDiveTotalMinus = 1350 * (NoDive - 10);
                    DiveNameL = "10 Dive Package   (Rs 13, 500) + Normal Dive  (Rs " + NormalDiveTotalMinus + ")";
                }
            }
            if (radNightD.Checked)
            {
                divePrice += 2000;
                total += 2000;
                DiveNameL = "Night Dive   (Rs 2, 000)";
                DiveNameD = "Night Dive";
            }

            if (radSafariD.Checked)
            {
                divePrice += 5000;
                total += 5000;
                DiveNameL = "Safari Dive   (Rs 5, 000)";
                DiveNameD = "Safari Dive";
            }


            string course = cbCourse.Text;
            switch (course)
            {
                case "Open Water Course   (Rs 17, 000)":
                    coursePrice += 17000;
                    total += 17000;
                    CourseNameL = "Open Water Course   (Rs 17, 000)";
                    CourseNameD = "Open Water Course";
                    break;

                case "Advanced Open Water Course   (Rs 15, 000)":
                    if (dataCourse.Equals("Open Water Course"))
                    {
                        coursePrice += 15000;
                        total += 15000;
                        CourseNameL = "Advanced Open Water Course   (Rs 15, 000)";
                        CourseNameD = "Advanced Open Water Course";
                    }
                    else
                    {
                        MessageBox.Show("You must do the previous course before attempting this one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbCourse.SelectedIndex = -1;
                    }
                    break;

                case "Rescue Diver Course   (Rs 20, 000)":
                    if (dataCourse.Equals("Advanced Open Water Course"))
                    {
                        coursePrice += 20000;
                        total += 20000;
                        CourseNameL = "Rescue Diver Course   (Rs 20, 000)";
                        CourseNameD = "Rescue Diver Course";
                    }
                    else
                    {
                        MessageBox.Show("You must do the previous course before attempting this one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbCourse.SelectedIndex = -1;
                    }
                    break;

                case "Dive Master Course   (Rs 45, 000)":
                    if (dataCourse.Equals("Rescue Diver Course"))
                    {
                        coursePrice += 45000;
                        total += 45000;
                        CourseNameL = "Dive Master Course   (Rs 45, 000)";
                        CourseNameD = "Dive Master Course";
                    }
                    else
                    {
                        MessageBox.Show("You must do the previous course before attempting this one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbCourse.SelectedIndex = -1;
                    }
                    break;
            }

            try
            {
                listbox();
            }
            catch
            {

            }

            try
            {
                lblTotal.Text = (total).ToString("C2");
                lblNoPerson.Text = txtNoPerson.Text;
                NoPerson = int.Parse(txtNoPerson.Text);
                finalTotal = NoPerson * total;
                txtFinalPrice.Text = (finalTotal).ToString("C2");
            }
            catch
            {
                MessageBox.Show("Please input 'No. of person to book for'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clear();
            }
            try
            {
                listbox();
            }
            catch
            {

            }

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            DataRow newRow = dt.NewRow();
            newRow["BookingId"] = newbookingid;
            newRow["CustomerId"] = txtCusId.Text;
            newRow["EmployeeId"] = txtEmpId.Text;
            newRow["DiveName"] = DiveNameD;
            newRow["CourseName"] = CourseNameD;

            dt.Rows.Add(newRow);
            Save();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMenu MyMenu = new EmployeeMenu();
            MyMenu.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNextForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryEmployees MyInventoryEmployee = new InventoryEmployees();
            MyInventoryEmployee.Show();
        }
    }
}
