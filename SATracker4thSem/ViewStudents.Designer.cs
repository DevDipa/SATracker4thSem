namespace SATracker4thSem
{
    partial class ViewStudents
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewStudents));
            this.label1 = new System.Windows.Forms.Label();
            this.cbBatch = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPrintRecord = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(89)))), ((int)(((byte)(165)))));
            this.label1.Location = new System.Drawing.Point(429, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Batch";
            // 
            // cbBatch
            // 
            this.cbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbBatch.FormattingEnabled = true;
            this.cbBatch.Items.AddRange(new object[] {
            "",
            "BCA - I",
            "BCA - II",
            "BCA - III",
            "BCA - IV",
            "BCA - V",
            "BCA - VI",
            "BCA - VII",
            "BCA - VIII"});
            this.cbBatch.Location = new System.Drawing.Point(578, 25);
            this.cbBatch.Name = "cbBatch";
            this.cbBatch.Size = new System.Drawing.Size(196, 46);
            this.cbBatch.TabIndex = 9;
            this.cbBatch.SelectedIndexChanged += new System.EventHandler(this.cbBatch_SelectedIndexChanged);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1110, 588);
            this.dataGridView1.TabIndex = 10;
            // 
            // btnPrintRecord
            // 
            this.btnPrintRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(89)))), ((int)(((byte)(165)))));
            this.btnPrintRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintRecord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrintRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintRecord.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPrintRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintRecord.Image")));
            this.btnPrintRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintRecord.Location = new System.Drawing.Point(810, 694);
            this.btnPrintRecord.Name = "btnPrintRecord";
            this.btnPrintRecord.Size = new System.Drawing.Size(300, 51);
            this.btnPrintRecord.TabIndex = 33;
            this.btnPrintRecord.Text = "Print Record";
            this.btnPrintRecord.UseVisualStyleBackColor = false;
            this.btnPrintRecord.Click += new System.EventHandler(this.btnPrintRecord_Click);
            this.btnPrintRecord.MouseEnter += new System.EventHandler(this.btnPrintRecord_MouseEnter);
            this.btnPrintRecord.MouseLeave += new System.EventHandler(this.btnPrintRecord_MouseLeave);
            // 
            // ViewStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 757);
            this.Controls.Add(this.btnPrintRecord);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbBatch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewStudents";
            this.Text = "ViewStudents";
            this.Load += new System.EventHandler(this.ViewStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBatch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPrintRecord;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}