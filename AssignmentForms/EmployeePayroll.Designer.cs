namespace AssignmentForms
{
    partial class EmployeePayroll
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.addUserCon1 = new AssignmentForms.AddUserCon();
            this.viewUserCon1 = new AssignmentForms.ViewUserCon();
            this.deleteUserCon1 = new AssignmentForms.DeleteUserCon();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnViewPanel = new System.Windows.Forms.Button();
            this.btnDeletePanel = new System.Windows.Forms.Button();
            this.btnAddPanel = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.btnCloseForm);
            this.panel2.Controls.Add(this.SidePanel);
            this.panel2.Controls.Add(this.btnViewPanel);
            this.panel2.Controls.Add(this.btnDeletePanel);
            this.panel2.Controls.Add(this.btnAddPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 471);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(174, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 29);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Navy;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(172, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(134, 81);
            this.panel3.TabIndex = 3;
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.Red;
            this.SidePanel.Location = new System.Drawing.Point(0, 94);
            this.SidePanel.Margin = new System.Windows.Forms.Padding(4);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(15, 47);
            this.SidePanel.TabIndex = 10;
            // 
            // addUserCon1
            // 
            this.addUserCon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(239)))));
            this.addUserCon1.Location = new System.Drawing.Point(172, 85);
            this.addUserCon1.Name = "addUserCon1";
            this.addUserCon1.Size = new System.Drawing.Size(708, 386);
            this.addUserCon1.TabIndex = 4;
            // 
            // viewUserCon1
            // 
            this.viewUserCon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(239)))));
            this.viewUserCon1.Location = new System.Drawing.Point(174, 82);
            this.viewUserCon1.Name = "viewUserCon1";
            this.viewUserCon1.Size = new System.Drawing.Size(707, 386);
            this.viewUserCon1.TabIndex = 5;
            // 
            // deleteUserCon1
            // 
            this.deleteUserCon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(239)))));
            this.deleteUserCon1.Location = new System.Drawing.Point(172, 82);
            this.deleteUserCon1.Name = "deleteUserCon1";
            this.deleteUserCon1.Size = new System.Drawing.Size(713, 386);
            this.deleteUserCon1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "PAYROLL";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseForm.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseForm.ForeColor = System.Drawing.Color.White;
            this.btnCloseForm.Image = global::AssignmentForms.Properties.Resources.icons8_delete_40;
            this.btnCloseForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseForm.Location = new System.Drawing.Point(23, 352);
            this.btnCloseForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(128, 43);
            this.btnCloseForm.TabIndex = 14;
            this.btnCloseForm.Text = "Close?";
            this.btnCloseForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnViewPanel
            // 
            this.btnViewPanel.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnViewPanel.FlatAppearance.BorderSize = 0;
            this.btnViewPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPanel.ForeColor = System.Drawing.Color.White;
            this.btnViewPanel.Image = global::AssignmentForms.Properties.Resources.icons8_view_40;
            this.btnViewPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewPanel.Location = new System.Drawing.Point(23, 277);
            this.btnViewPanel.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewPanel.Name = "btnViewPanel";
            this.btnViewPanel.Size = new System.Drawing.Size(128, 43);
            this.btnViewPanel.TabIndex = 13;
            this.btnViewPanel.Text = " View?";
            this.btnViewPanel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewPanel.UseVisualStyleBackColor = true;
            // 
            // btnDeletePanel
            // 
            this.btnDeletePanel.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnDeletePanel.FlatAppearance.BorderSize = 0;
            this.btnDeletePanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeletePanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePanel.ForeColor = System.Drawing.Color.White;
            this.btnDeletePanel.Image = global::AssignmentForms.Properties.Resources.icons8_delete_bin_40;
            this.btnDeletePanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeletePanel.Location = new System.Drawing.Point(23, 198);
            this.btnDeletePanel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletePanel.Name = "btnDeletePanel";
            this.btnDeletePanel.Size = new System.Drawing.Size(128, 47);
            this.btnDeletePanel.TabIndex = 12;
            this.btnDeletePanel.Text = "      Delete?";
            this.btnDeletePanel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeletePanel.UseVisualStyleBackColor = true;
            // 
            // btnAddPanel
            // 
            this.btnAddPanel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPanel.ForeColor = System.Drawing.Color.White;
            this.btnAddPanel.Image = global::AssignmentForms.Properties.Resources.icons8_add_user_group_man_man_45;
            this.btnAddPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPanel.Location = new System.Drawing.Point(23, 119);
            this.btnAddPanel.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPanel.Name = "btnAddPanel";
            this.btnAddPanel.Size = new System.Drawing.Size(128, 47);
            this.btnAddPanel.TabIndex = 11;
            this.btnAddPanel.Text = "    Add?";
            this.btnAddPanel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddPanel.UseVisualStyleBackColor = true;
            // 
            // EmployeePayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(231)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(880, 471);
            this.Controls.Add(this.deleteUserCon1);
            this.Controls.Add(this.viewUserCon1);
            this.Controls.Add(this.addUserCon1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeePayroll";
            this.Text = "EmployeePayroll";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Panel SidePanel;
        public System.Windows.Forms.Button btnViewPanel;
        public System.Windows.Forms.Button btnDeletePanel;
        public System.Windows.Forms.Button btnAddPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private AddUserCon addUserCon1;
        private ViewUserCon viewUserCon1;
        private DeleteUserCon deleteUserCon1;
    }
}