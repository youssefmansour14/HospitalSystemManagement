using System.Drawing;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    partial class HistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmBoxMonthlyHistory = new System.Windows.Forms.ComboBox();
            this.cmBoxYealyHistory = new System.Windows.Forms.ComboBox();
            this.dtimepHistory = new System.Windows.Forms.DateTimePicker();
            this.btnPrintHistory = new System.Windows.Forms.Button();
            this.txtSearchHistory = new System.Windows.Forms.TextBox();
            this.btnSearchHistory = new System.Windows.Forms.Button();
            this.btnPrintDept = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearchDept = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblCancel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Pangolin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.GridColor = System.Drawing.Color.White;
            this.dgvHistory.Location = new System.Drawing.Point(0, 115);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowTemplate.Height = 25;
            this.dgvHistory.Size = new System.Drawing.Size(866, 275);
            this.dgvHistory.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(149)))), ((int)(((byte)(153)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 39);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(149)))), ((int)(((byte)(153)))));
            this.label1.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(515, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "The History Of All Patient In Hospital";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.lblCancel);
            this.panel3.Controls.Add(this.cmBoxMonthlyHistory);
            this.panel3.Controls.Add(this.cmBoxYealyHistory);
            this.panel3.Controls.Add(this.dtimepHistory);
            this.panel3.Controls.Add(this.btnPrintHistory);
            this.panel3.Controls.Add(this.txtSearchHistory);
            this.panel3.Controls.Add(this.btnSearchHistory);
            this.panel3.Controls.Add(this.btnPrintDept);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Controls.Add(this.btnSearchDept);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(866, 67);
            this.panel3.TabIndex = 11;
            // 
            // cmBoxMonthlyHistory
            // 
            this.cmBoxMonthlyHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxMonthlyHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmBoxMonthlyHistory.FormattingEnabled = true;
            this.cmBoxMonthlyHistory.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmBoxMonthlyHistory.Location = new System.Drawing.Point(143, 8);
            this.cmBoxMonthlyHistory.Name = "cmBoxMonthlyHistory";
            this.cmBoxMonthlyHistory.Size = new System.Drawing.Size(88, 33);
            this.cmBoxMonthlyHistory.TabIndex = 36;
            this.cmBoxMonthlyHistory.SelectedIndexChanged += new System.EventHandler(this.cmBoxMonthlyHistory_SelectedIndexChanged);
            // 
            // cmBoxYealyHistory
            // 
            this.cmBoxYealyHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxYealyHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmBoxYealyHistory.FormattingEnabled = true;
            this.cmBoxYealyHistory.Location = new System.Drawing.Point(10, 8);
            this.cmBoxYealyHistory.Name = "cmBoxYealyHistory";
            this.cmBoxYealyHistory.Size = new System.Drawing.Size(125, 33);
            this.cmBoxYealyHistory.TabIndex = 35;
            this.cmBoxYealyHistory.SelectedIndexChanged += new System.EventHandler(this.cmBoxYealyHistory_SelectedIndexChanged);
            // 
            // dtimepHistory
            // 
            this.dtimepHistory.Font = new System.Drawing.Font("Pangolin", 12F);
            this.dtimepHistory.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtimepHistory.Location = new System.Drawing.Point(237, 10);
            this.dtimepHistory.Name = "dtimepHistory";
            this.dtimepHistory.Size = new System.Drawing.Size(118, 27);
            this.dtimepHistory.TabIndex = 12;
            this.dtimepHistory.ValueChanged += new System.EventHandler(this.dtimepHistory_ValueChanged);
            // 
            // btnPrintHistory
            // 
            this.btnPrintHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintHistory.Location = new System.Drawing.Point(812, 6);
            this.btnPrintHistory.Name = "btnPrintHistory";
            this.btnPrintHistory.Size = new System.Drawing.Size(44, 20);
            this.btnPrintHistory.TabIndex = 10;
            this.btnPrintHistory.Text = "Print";
            this.btnPrintHistory.UseVisualStyleBackColor = true;
            this.btnPrintHistory.Click += new System.EventHandler(this.btnPrintHistory_Click);
            // 
            // txtSearchHistory
            // 
            this.txtSearchHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSearchHistory.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtSearchHistory.Location = new System.Drawing.Point(662, 30);
            this.txtSearchHistory.Name = "txtSearchHistory";
            this.txtSearchHistory.Size = new System.Drawing.Size(194, 34);
            this.txtSearchHistory.TabIndex = 9;
            this.txtSearchHistory.TextChanged += new System.EventHandler(this.txtSearchHistory_TextChanged);
            this.txtSearchHistory.Enter += new System.EventHandler(this.txtSearchHistory_Enter);
            this.txtSearchHistory.Leave += new System.EventHandler(this.txtSearchHistory_Leave);
            // 
            // btnSearchHistory
            // 
            this.btnSearchHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchHistory.BackColor = System.Drawing.Color.White;
            this.btnSearchHistory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearchHistory.FlatAppearance.BorderSize = 0;
            this.btnSearchHistory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSearchHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSearchHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSearchHistory.ForeColor = System.Drawing.Color.Gray;
            this.btnSearchHistory.Location = new System.Drawing.Point(575, 29);
            this.btnSearchHistory.Name = "btnSearchHistory";
            this.btnSearchHistory.Size = new System.Drawing.Size(81, 32);
            this.btnSearchHistory.TabIndex = 8;
            this.btnSearchHistory.Text = "Search";
            this.btnSearchHistory.UseVisualStyleBackColor = false;
            this.btnSearchHistory.Click += new System.EventHandler(this.btnSearchHistory_Click);
            // 
            // btnPrintDept
            // 
            this.btnPrintDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintDept.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintDept.Location = new System.Drawing.Point(1293, 7);
            this.btnPrintDept.Name = "btnPrintDept";
            this.btnPrintDept.Size = new System.Drawing.Size(44, 20);
            this.btnPrintDept.TabIndex = 7;
            this.btnPrintDept.Text = "Print";
            this.btnPrintDept.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtSearch.Location = new System.Drawing.Point(1143, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(194, 34);
            this.txtSearch.TabIndex = 4;
            // 
            // btnSearchDept
            // 
            this.btnSearchDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchDept.BackColor = System.Drawing.Color.White;
            this.btnSearchDept.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearchDept.FlatAppearance.BorderSize = 0;
            this.btnSearchDept.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSearchDept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSearchDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDept.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSearchDept.ForeColor = System.Drawing.Color.Gray;
            this.btnSearchDept.Location = new System.Drawing.Point(1056, 29);
            this.btnSearchDept.Name = "btnSearchDept";
            this.btnSearchDept.Size = new System.Drawing.Size(81, 32);
            this.btnSearchDept.TabIndex = 3;
            this.btnSearchDept.Text = "Search";
            this.btnSearchDept.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(866, 9);
            this.panel5.TabIndex = 9;
            // 
            // lblCancel
            // 
            this.lblCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCancel.AutoSize = true;
            this.lblCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCancel.Font = new System.Drawing.Font("Pangolin", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancel.Location = new System.Drawing.Point(837, 37);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(17, 19);
            this.lblCancel.TabIndex = 37;
            this.lblCancel.Text = "X";
            this.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancel.Visible = false;
            this.lblCancel.Click += new System.EventHandler(this.lblCancel_Click);
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 390);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvHistory;
        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private Button btnPrintDept;
        private TextBox txtSearch;
        private Button btnSearchDept;
        private Panel panel5;
        private DateTimePicker dtimepHistory;
        private Button btnPrintHistory;
        private TextBox txtSearchHistory;
        private Button btnSearchHistory;
        private ComboBox cmBoxMonthlyHistory;
        private ComboBox cmBoxYealyHistory;
        private Label lblCancel;
    }
}