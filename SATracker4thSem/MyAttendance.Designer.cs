namespace SATracker4thSem
{
    partial class MyAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyAttendance));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPrintAttendance = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMyRollNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBatch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadAttendance = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnPrintAttendance1 = new System.Windows.Forms.Button();
            this.btnLoadAttendance1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintAttendance
            // 
            this.btnPrintAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(89)))), ((int)(((byte)(165)))));
            this.btnPrintAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintAttendance.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPrintAttendance.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintAttendance.Image")));
            this.btnPrintAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintAttendance.Location = new System.Drawing.Point(890, 883);
            this.btnPrintAttendance.Name = "btnPrintAttendance";
            this.btnPrintAttendance.Size = new System.Drawing.Size(366, 51);
            this.btnPrintAttendance.TabIndex = 36;
            this.btnPrintAttendance.Text = "Print Attendance";
            this.btnPrintAttendance.UseVisualStyleBackColor = false;
            this.btnPrintAttendance.Click += new System.EventHandler(this.btnPrintAttendance_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(89)))), ((int)(((byte)(165)))));
            this.panel1.Controls.Add(this.txtMyRollNo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbBatch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 102);
            this.panel1.TabIndex = 35;
            // 
            // txtMyRollNo
            // 
            this.txtMyRollNo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtMyRollNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMyRollNo.Location = new System.Drawing.Point(841, 50);
            this.txtMyRollNo.Name = "txtMyRollNo";
            this.txtMyRollNo.Size = new System.Drawing.Size(200, 36);
            this.txtMyRollNo.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(836, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 29);
            this.label3.TabIndex = 22;
            this.label3.Text = "Roll No.";
            // 
            // cbBatch
            // 
            this.cbBatch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbBatch.FormattingEnabled = true;
            this.cbBatch.Items.AddRange(new object[] {
            "BCA - I",
            "BCA - II",
            "BCA - III",
            "BCA - IV",
            "BCA - V",
            "BCA - VI",
            "BCA - VII",
            "BCA - VIII"});
            this.cbBatch.Location = new System.Drawing.Point(464, 53);
            this.cbBatch.Name = "cbBatch";
            this.cbBatch.Size = new System.Drawing.Size(254, 33);
            this.cbBatch.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(459, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Batch";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.Control;
            this.dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(254, 34);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(83, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(89)))), ((int)(((byte)(165)))));
            this.label1.Location = new System.Drawing.Point(457, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 38);
            this.label1.TabIndex = 33;
            this.label1.Text = "My Attendance";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 193);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1110, 481);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnLoadAttendance
            // 
            this.btnLoadAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(89)))), ((int)(((byte)(165)))));
            this.btnLoadAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadAttendance.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLoadAttendance.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadAttendance.Image")));
            this.btnLoadAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadAttendance.Location = new System.Drawing.Point(64, 882);
            this.btnLoadAttendance.Name = "btnLoadAttendance";
            this.btnLoadAttendance.Size = new System.Drawing.Size(366, 51);
            this.btnLoadAttendance.TabIndex = 38;
            this.btnLoadAttendance.Text = "Load Attendance";
            this.btnLoadAttendance.UseVisualStyleBackColor = false;
            this.btnLoadAttendance.Click += new System.EventHandler(this.btnLoadAttendance_Click);
            // 
            // btnPrintAttendance1
            // 
            this.btnPrintAttendance1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintAttendance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(89)))), ((int)(((byte)(165)))));
            this.btnPrintAttendance1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintAttendance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintAttendance1.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPrintAttendance1.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintAttendance1.Image")));
            this.btnPrintAttendance1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintAttendance1.Location = new System.Drawing.Point(740, 694);
            this.btnPrintAttendance1.Name = "btnPrintAttendance1";
            this.btnPrintAttendance1.Size = new System.Drawing.Size(366, 51);
            this.btnPrintAttendance1.TabIndex = 39;
            this.btnPrintAttendance1.Text = "Print Attendance";
            this.btnPrintAttendance1.UseVisualStyleBackColor = false;
            this.btnPrintAttendance1.Click += new System.EventHandler(this.btnPrintAttendance1_Click);
            // 
            // btnLoadAttendance1
            // 
            this.btnLoadAttendance1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadAttendance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(89)))), ((int)(((byte)(165)))));
            this.btnLoadAttendance1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadAttendance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadAttendance1.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLoadAttendance1.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadAttendance1.Image")));
            this.btnLoadAttendance1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadAttendance1.Location = new System.Drawing.Point(33, 694);
            this.btnLoadAttendance1.Name = "btnLoadAttendance1";
            this.btnLoadAttendance1.Size = new System.Drawing.Size(366, 51);
            this.btnLoadAttendance1.TabIndex = 40;
            this.btnLoadAttendance1.Text = "Load Attendance";
            this.btnLoadAttendance1.UseVisualStyleBackColor = false;
            this.btnLoadAttendance1.Click += new System.EventHandler(this.btnLoadAttendance1_Click);
            // 
            // MyAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1134, 757);
            this.Controls.Add(this.btnLoadAttendance1);
            this.Controls.Add(this.btnPrintAttendance1);
            this.Controls.Add(this.btnLoadAttendance);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPrintAttendance);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(362, 82);
            this.Name = "MyAttendance";
            this.Text = "MyAttendance";
            this.Load += new System.EventHandler(this.MyAttendance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintAttendance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbBatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMyRollNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadAttendance;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnPrintAttendance1;
        private System.Windows.Forms.Button btnLoadAttendance1;
    }
}