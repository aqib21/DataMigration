
namespace DataMigration
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_EmployeeName = new System.Windows.Forms.ComboBox();
            this.cmb_EmployeeCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Move = new System.Windows.Forms.Button();
            this.txt_Message = new System.Windows.Forms.TextBox();
            this.lbl_EmployeeID = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btn_Report = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Move employee data from InVan to Sonic";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employee Name:";
            // 
            // cmb_EmployeeName
            // 
            this.cmb_EmployeeName.FormattingEnabled = true;
            this.cmb_EmployeeName.Location = new System.Drawing.Point(131, 46);
            this.cmb_EmployeeName.Name = "cmb_EmployeeName";
            this.cmb_EmployeeName.Size = new System.Drawing.Size(223, 23);
            this.cmb_EmployeeName.TabIndex = 2;
            this.cmb_EmployeeName.SelectedIndexChanged += new System.EventHandler(this.Cmb_SelectedIndexChanged);
            // 
            // cmb_EmployeeCode
            // 
            this.cmb_EmployeeCode.FormattingEnabled = true;
            this.cmb_EmployeeCode.Location = new System.Drawing.Point(533, 46);
            this.cmb_EmployeeCode.Name = "cmb_EmployeeCode";
            this.cmb_EmployeeCode.Size = new System.Drawing.Size(116, 23);
            this.cmb_EmployeeCode.TabIndex = 4;
            this.cmb_EmployeeCode.SelectedIndexChanged += new System.EventHandler(this.Cmb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Employee Code:";
            // 
            // btn_Move
            // 
            this.btn_Move.Enabled = false;
            this.btn_Move.Location = new System.Drawing.Point(12, 78);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(97, 23);
            this.btn_Move.TabIndex = 5;
            this.btn_Move.Text = "Move Data";
            this.btn_Move.UseVisualStyleBackColor = true;
            this.btn_Move.Click += new System.EventHandler(this.Btn_Move_Click);
            // 
            // txt_Message
            // 
            this.txt_Message.AcceptsReturn = true;
            this.txt_Message.AcceptsTab = true;
            this.txt_Message.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txt_Message.Location = new System.Drawing.Point(13, 148);
            this.txt_Message.Multiline = true;
            this.txt_Message.Name = "txt_Message";
            this.txt_Message.ReadOnly = true;
            this.txt_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Message.Size = new System.Drawing.Size(636, 220);
            this.txt_Message.TabIndex = 6;
            this.txt_Message.Text = resources.GetString("txt_Message.Text");
            // 
            // lbl_EmployeeID
            // 
            this.lbl_EmployeeID.AutoSize = true;
            this.lbl_EmployeeID.Location = new System.Drawing.Point(414, 82);
            this.lbl_EmployeeID.Name = "lbl_EmployeeID";
            this.lbl_EmployeeID.Size = new System.Drawing.Size(76, 15);
            this.lbl_EmployeeID.TabIndex = 7;
            this.lbl_EmployeeID.Text = "Employee ID:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 108);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(636, 34);
            this.progressBar.TabIndex = 8;
            // 
            // btn_Report
            // 
            this.btn_Report.Location = new System.Drawing.Point(131, 78);
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(97, 23);
            this.btn_Report.TabIndex = 9;
            this.btn_Report.Text = "Report";
            this.btn_Report.UseVisualStyleBackColor = true;
            this.btn_Report.Click += new System.EventHandler(this.Button1_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(662, 383);
            this.Controls.Add(this.btn_Report);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbl_EmployeeID);
            this.Controls.Add(this.txt_Message);
            this.Controls.Add(this.btn_Move);
            this.Controls.Add(this.cmb_EmployeeCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_EmployeeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Employee Data Migration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_EmployeeName;
        private System.Windows.Forms.ComboBox cmb_EmployeeCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Move;
        private System.Windows.Forms.TextBox txt_Message;
        private System.Windows.Forms.Label lbl_EmployeeID;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btn_Report;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

