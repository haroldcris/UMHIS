namespace Umhis.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanelCase = new System.Windows.Forms.RibbonPanel();
            this.BtnNewCase = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanelHome = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.BtnOpenPatientInfo = new System.Windows.Forms.RibbonButton();
            this.BtnPatientMasterList = new System.Windows.Forms.RibbonButton();
            this.BtnDoctor = new System.Windows.Forms.RibbonButton();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.BtnMedicine = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.BtnUserAccounts = new System.Windows.Forms.RibbonButton();
            this.BtnChangePassword = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.btnUser = new System.Windows.Forms.RibbonButton();
            this.ribbonLabel1 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabel2 = new System.Windows.Forms.RibbonLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Grid = new System.Windows.Forms.DataGridView();
            this.ribbonDescriptionMenuItem1 = new System.Windows.Forms.RibbonDescriptionMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(762, 154);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabSpacing = 4;
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.ribbonPanelCase);
            this.ribbonTab1.Panels.Add(this.ribbonPanelHome);
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Text = "Home";
            // 
            // ribbonPanelCase
            // 
            this.ribbonPanelCase.ButtonMoreVisible = false;
            this.ribbonPanelCase.Items.Add(this.BtnNewCase);
            this.ribbonPanelCase.Items.Add(this.ribbonButton2);
            this.ribbonPanelCase.Name = "ribbonPanelCase";
            this.ribbonPanelCase.Text = "Medical Case";
            // 
            // BtnNewCase
            // 
            this.BtnNewCase.Image = global::Umhis.Properties.Resources.AddFile_32px;
            this.BtnNewCase.LargeImage = global::Umhis.Properties.Resources.AddFile_32px;
            this.BtnNewCase.Name = "BtnNewCase";
            this.BtnNewCase.SmallImage = ((System.Drawing.Image)(resources.GetObject("BtnNewCase.SmallImage")));
            this.BtnNewCase.Text = "New Case";
            this.BtnNewCase.Click += new System.EventHandler(this.BtnNewCase_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = global::Umhis.Properties.Resources.Treatment_40px;
            this.ribbonButton2.LargeImage = global::Umhis.Properties.Resources.Treatment_40px;
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Case MasterList";
            this.ribbonButton2.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // ribbonPanelHome
            // 
            this.ribbonPanelHome.ButtonMoreVisible = false;
            this.ribbonPanelHome.Items.Add(this.ribbonButton1);
            this.ribbonPanelHome.Items.Add(this.BtnDoctor);
            this.ribbonPanelHome.Items.Add(this.BtnMedicine);
            this.ribbonPanelHome.Name = "ribbonPanelHome";
            this.ribbonPanelHome.Text = "Master List";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.DrawDropDownIconsBar = false;
            this.ribbonButton1.DropDownItems.Add(this.BtnOpenPatientInfo);
            this.ribbonButton1.DropDownItems.Add(this.BtnPatientMasterList);
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.ribbonButton1.Text = "Patients";
            // 
            // BtnOpenPatientInfo
            // 
            this.BtnOpenPatientInfo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.BtnOpenPatientInfo.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpenPatientInfo.Image")));
            this.BtnOpenPatientInfo.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnOpenPatientInfo.LargeImage")));
            this.BtnOpenPatientInfo.Name = "BtnOpenPatientInfo";
            this.BtnOpenPatientInfo.SmallImage = global::Umhis.Properties.Resources.FindUserMale_40px;
            this.BtnOpenPatientInfo.Text = "Open Patient Info";
            this.BtnOpenPatientInfo.Click += new System.EventHandler(this.BtnOpenPatientInfo_Click);
            // 
            // BtnPatientMasterList
            // 
            this.BtnPatientMasterList.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.BtnPatientMasterList.Image = ((System.Drawing.Image)(resources.GetObject("BtnPatientMasterList.Image")));
            this.BtnPatientMasterList.LargeImage = ((System.Drawing.Image)(resources.GetObject("BtnPatientMasterList.LargeImage")));
            this.BtnPatientMasterList.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.BtnPatientMasterList.Name = "BtnPatientMasterList";
            this.BtnPatientMasterList.SmallImage = ((System.Drawing.Image)(resources.GetObject("BtnPatientMasterList.SmallImage")));
            this.BtnPatientMasterList.Text = " Patient Master List";
            this.BtnPatientMasterList.Click += new System.EventHandler(this.BtnPatientMasterList_Click);
            // 
            // BtnDoctor
            // 
            this.BtnDoctor.DropDownItems.Add(this.ribbonButton3);
            this.BtnDoctor.Image = global::Umhis.Properties.Resources.MedicalDoctor_40px;
            this.BtnDoctor.LargeImage = global::Umhis.Properties.Resources.MedicalDoctor_40px;
            this.BtnDoctor.Name = "BtnDoctor";
            this.BtnDoctor.SmallImage = ((System.Drawing.Image)(resources.GetObject("BtnDoctor.SmallImage")));
            this.BtnDoctor.Text = "Doctors";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "ribbonButton3";
            // 
            // BtnMedicine
            // 
            this.BtnMedicine.Image = global::Umhis.Properties.Resources.Pills_40px;
            this.BtnMedicine.LargeImage = global::Umhis.Properties.Resources.Pills_40px;
            this.BtnMedicine.Name = "BtnMedicine";
            this.BtnMedicine.SmallImage = ((System.Drawing.Image)(resources.GetObject("BtnMedicine.SmallImage")));
            this.BtnMedicine.Text = "Treatment";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.BtnUserAccounts);
            this.ribbonPanel1.Items.Add(this.BtnChangePassword);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Security";
            // 
            // BtnUserAccounts
            // 
            this.BtnUserAccounts.Image = global::Umhis.Properties.Resources.Password_40px;
            this.BtnUserAccounts.LargeImage = global::Umhis.Properties.Resources.Password_40px;
            this.BtnUserAccounts.Name = "BtnUserAccounts";
            this.BtnUserAccounts.SmallImage = ((System.Drawing.Image)(resources.GetObject("BtnUserAccounts.SmallImage")));
            this.BtnUserAccounts.Text = "User Accounts";
            this.BtnUserAccounts.Click += new System.EventHandler(this.BtnUserAccounts_Click);
            // 
            // BtnChangePassword
            // 
            this.BtnChangePassword.Image = global::Umhis.Properties.Resources.Key_40px;
            this.BtnChangePassword.LargeImage = global::Umhis.Properties.Resources.Key_40px;
            this.BtnChangePassword.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.BtnChangePassword.Name = "BtnChangePassword";
            this.BtnChangePassword.SmallImage = ((System.Drawing.Image)(resources.GetObject("BtnChangePassword.SmallImage")));
            this.BtnChangePassword.Text = "Change Password...";
            this.BtnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.btnUser);
            this.ribbonPanel2.Items.Add(this.ribbonLabel1);
            this.ribbonPanel2.Items.Add(this.ribbonLabel2);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Current Session";
            // 
            // btnUser
            // 
            this.btnUser.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.Image")));
            this.btnUser.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUser.LargeImage")));
            this.btnUser.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.btnUser.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.btnUser.Name = "btnUser";
            this.btnUser.SmallImage = global::Umhis.Properties.Resources.MaleUser_16px;
            this.btnUser.Text = "Welcome User";
            // 
            // ribbonLabel1
            // 
            this.ribbonLabel1.Image = global::Umhis.Properties.Resources.Cancel_16px;
            this.ribbonLabel1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonLabel1.Name = "ribbonLabel1";
            this.ribbonLabel1.Text = "   ";
            this.ribbonLabel1.Value = "  ";
            // 
            // ribbonLabel2
            // 
            this.ribbonLabel2.Name = "ribbonLabel2";
            this.ribbonLabel2.Text = "   ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(762, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(0, 154);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(762, 400);
            this.Grid.TabIndex = 2;
            this.Grid.VirtualMode = true;
            this.Grid.Visible = false;
            // 
            // ribbonDescriptionMenuItem1
            // 
            this.ribbonDescriptionMenuItem1.DescriptionBounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ribbonDescriptionMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonDescriptionMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.Image")));
            this.ribbonDescriptionMenuItem1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.LargeImage")));
            this.ribbonDescriptionMenuItem1.Name = "ribbonDescriptionMenuItem1";
            this.ribbonDescriptionMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.SmallImage")));
            this.ribbonDescriptionMenuItem1.Text = "ribbonDescriptionMenuItem1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 576);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Unified Medical History Information System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanelHome;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton BtnDoctor;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonButton BtnMedicine;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RibbonButton BtnPatientMasterList;
        private System.Windows.Forms.RibbonButton BtnOpenPatientInfo;
        private System.Windows.Forms.RibbonPanel ribbonPanelCase;
        private System.Windows.Forms.RibbonButton BtnNewCase;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton BtnUserAccounts;
        private System.Windows.Forms.RibbonButton BtnChangePassword;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton btnUser;
        private System.Windows.Forms.RibbonDescriptionMenuItem ribbonDescriptionMenuItem1;
        private System.Windows.Forms.RibbonLabel ribbonLabel1;
        private System.Windows.Forms.RibbonLabel ribbonLabel2;
    }
}