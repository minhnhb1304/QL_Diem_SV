namespace QL_Diem
{
    partial class frmClassList
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
            this.dgvClassList = new System.Windows.Forms.DataGridView();
            this.btnAddInfo = new System.Windows.Forms.Button();
            this.btnDeleteInfo = new System.Windows.Forms.Button();
            this.btnChangeInfo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClassList
            // 
            this.dgvClassList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassList.Location = new System.Drawing.Point(0, 0);
            this.dgvClassList.Name = "dgvClassList";
            this.dgvClassList.Size = new System.Drawing.Size(685, 360);
            this.dgvClassList.TabIndex = 0;
            // 
            // btnAddInfo
            // 
            this.btnAddInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInfo.ForeColor = System.Drawing.Color.Green;
            this.btnAddInfo.Location = new System.Drawing.Point(691, 30);
            this.btnAddInfo.Name = "btnAddInfo";
            this.btnAddInfo.Size = new System.Drawing.Size(155, 26);
            this.btnAddInfo.TabIndex = 23;
            this.btnAddInfo.Text = "Thêm sinh viên";
            this.btnAddInfo.UseVisualStyleBackColor = true;
            this.btnAddInfo.Click += new System.EventHandler(this.btnAddInfo_Click);
            // 
            // btnDeleteInfo
            // 
            this.btnDeleteInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteInfo.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteInfo.Location = new System.Drawing.Point(691, 94);
            this.btnDeleteInfo.Name = "btnDeleteInfo";
            this.btnDeleteInfo.Size = new System.Drawing.Size(155, 26);
            this.btnDeleteInfo.TabIndex = 24;
            this.btnDeleteInfo.Text = "Xóa sinh viên";
            this.btnDeleteInfo.UseVisualStyleBackColor = true;
            this.btnDeleteInfo.Click += new System.EventHandler(this.btnDeleteInfo_Click);
            // 
            // btnChangeInfo
            // 
            this.btnChangeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeInfo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnChangeInfo.Location = new System.Drawing.Point(691, 62);
            this.btnChangeInfo.Name = "btnChangeInfo";
            this.btnChangeInfo.Size = new System.Drawing.Size(155, 26);
            this.btnChangeInfo.TabIndex = 25;
            this.btnChangeInfo.Text = "Sửa thông tin ";
            this.btnChangeInfo.UseVisualStyleBackColor = true;
            this.btnChangeInfo.Click += new System.EventHandler(this.btnChangeInfo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(691, 323);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(155, 26);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmClassList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 361);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChangeInfo);
            this.Controls.Add(this.btnDeleteInfo);
            this.Controls.Add(this.btnAddInfo);
            this.Controls.Add(this.dgvClassList);
            this.Name = "frmClassList";
            this.Text = "Danh sách lớp 22CN2";
            this.Load += new System.EventHandler(this.frmClassList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClassList;
        private System.Windows.Forms.Button btnAddInfo;
        private System.Windows.Forms.Button btnDeleteInfo;
        private System.Windows.Forms.Button btnChangeInfo;
        private System.Windows.Forms.Button btnClose;
    }
}