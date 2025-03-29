namespace QL_Diem
{
    partial class frmMain
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
            this.btnPersonalInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAcademicRank_4 = new System.Windows.Forms.Label();
            this.lblTotalCredits = new System.Windows.Forms.Label();
            this.lblAcademicRank_10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblGPA_10 = new System.Windows.Forms.Label();
            this.lblGPA_4 = new System.Windows.Forms.Label();
            this.cbxSemester = new System.Windows.Forms.ComboBox();
            this.cbxSchoolYear = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbShow = new System.Windows.Forms.GroupBox();
            this.lblMSV = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxSubject = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.txtMSV = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClassList = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddScore = new System.Windows.Forms.Button();
            this.btnEditScore = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.gbShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPersonalInfo
            // 
            this.btnPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonalInfo.Location = new System.Drawing.Point(513, 44);
            this.btnPersonalInfo.Name = "btnPersonalInfo";
            this.btnPersonalInfo.Size = new System.Drawing.Size(157, 26);
            this.btnPersonalInfo.TabIndex = 22;
            this.btnPersonalInfo.Text = "Thông tin cá nhân";
            this.btnPersonalInfo.UseVisualStyleBackColor = true;
            this.btnPersonalInfo.Click += new System.EventHandler(this.btnPersonalInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tìm kiếm theo MSV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(275, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Năm học:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(23, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Học kỳ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(618, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Số tín chỉ tích lũy: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(340, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Xếp loại học tập (Hệ 10):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(68, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Xếp loại học tập (Hệ 4):";
            // 
            // lblAcademicRank_4
            // 
            this.lblAcademicRank_4.AutoSize = true;
            this.lblAcademicRank_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcademicRank_4.ForeColor = System.Drawing.Color.Red;
            this.lblAcademicRank_4.Location = new System.Drawing.Point(249, 81);
            this.lblAcademicRank_4.Name = "lblAcademicRank_4";
            this.lblAcademicRank_4.Size = new System.Drawing.Size(37, 20);
            this.lblAcademicRank_4.TabIndex = 30;
            this.lblAcademicRank_4.Text = "Giỏi";
            // 
            // lblTotalCredits
            // 
            this.lblTotalCredits.AutoSize = true;
            this.lblTotalCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCredits.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCredits.Location = new System.Drawing.Point(758, 119);
            this.lblTotalCredits.Name = "lblTotalCredits";
            this.lblTotalCredits.Size = new System.Drawing.Size(27, 20);
            this.lblTotalCredits.TabIndex = 31;
            this.lblTotalCredits.Text = "90";
            // 
            // lblAcademicRank_10
            // 
            this.lblAcademicRank_10.AutoSize = true;
            this.lblAcademicRank_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcademicRank_10.ForeColor = System.Drawing.Color.Red;
            this.lblAcademicRank_10.Location = new System.Drawing.Point(530, 81);
            this.lblAcademicRank_10.Name = "lblAcademicRank_10";
            this.lblAcademicRank_10.Size = new System.Drawing.Size(37, 20);
            this.lblAcademicRank_10.TabIndex = 34;
            this.lblAcademicRank_10.Text = "Giỏi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(70, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "TBC tích lũy (Hệ 4):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(340, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 20);
            this.label11.TabIndex = 36;
            this.label11.Text = "TBC tích lũy (Hệ 10):";
            // 
            // lblGPA_10
            // 
            this.lblGPA_10.AutoSize = true;
            this.lblGPA_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPA_10.ForeColor = System.Drawing.Color.Red;
            this.lblGPA_10.Location = new System.Drawing.Point(530, 119);
            this.lblGPA_10.Name = "lblGPA_10";
            this.lblGPA_10.Size = new System.Drawing.Size(40, 20);
            this.lblGPA_10.TabIndex = 37;
            this.lblGPA_10.Text = "10.0";
            // 
            // lblGPA_4
            // 
            this.lblGPA_4.AutoSize = true;
            this.lblGPA_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPA_4.ForeColor = System.Drawing.Color.Red;
            this.lblGPA_4.Location = new System.Drawing.Point(251, 120);
            this.lblGPA_4.Name = "lblGPA_4";
            this.lblGPA_4.Size = new System.Drawing.Size(31, 20);
            this.lblGPA_4.TabIndex = 38;
            this.lblGPA_4.Text = "4.0";
            // 
            // cbxSemester
            // 
            this.cbxSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSemester.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbxSemester.FormattingEnabled = true;
            this.cbxSemester.Location = new System.Drawing.Point(90, 158);
            this.cbxSemester.Name = "cbxSemester";
            this.cbxSemester.Size = new System.Drawing.Size(154, 28);
            this.cbxSemester.TabIndex = 40;
            this.cbxSemester.SelectedIndexChanged += new System.EventHandler(this.cbxSemester_SelectedIndexChanged);
            // 
            // cbxSchoolYear
            // 
            this.cbxSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSchoolYear.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbxSchoolYear.FormattingEnabled = true;
            this.cbxSchoolYear.Location = new System.Drawing.Point(357, 158);
            this.cbxSchoolYear.Name = "cbxSchoolYear";
            this.cbxSchoolYear.Size = new System.Drawing.Size(167, 28);
            this.cbxSchoolYear.TabIndex = 41;
            this.cbxSchoolYear.SelectedIndexChanged += new System.EventHandler(this.cbxSchoolYear_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Cornsilk;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Crimson;
            this.btnExit.Location = new System.Drawing.Point(791, 651);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 26);
            this.btnExit.TabIndex = 43;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // gbShow
            // 
            this.gbShow.Controls.Add(this.lblMSV);
            this.gbShow.Controls.Add(this.label13);
            this.gbShow.Controls.Add(this.label8);
            this.gbShow.Controls.Add(this.cbxSubject);
            this.gbShow.Controls.Add(this.lblName);
            this.gbShow.Controls.Add(this.label9);
            this.gbShow.Controls.Add(this.label4);
            this.gbShow.Controls.Add(this.lblTotalCredits);
            this.gbShow.Controls.Add(this.label6);
            this.gbShow.Controls.Add(this.cbxSchoolYear);
            this.gbShow.Controls.Add(this.cbxSemester);
            this.gbShow.Controls.Add(this.lblAcademicRank_4);
            this.gbShow.Controls.Add(this.label11);
            this.gbShow.Controls.Add(this.label3);
            this.gbShow.Controls.Add(this.label5);
            this.gbShow.Controls.Add(this.label2);
            this.gbShow.Controls.Add(this.lblGPA_4);
            this.gbShow.Controls.Add(this.lblAcademicRank_10);
            this.gbShow.Controls.Add(this.lblGPA_10);
            this.gbShow.Controls.Add(this.label7);
            this.gbShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbShow.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbShow.Location = new System.Drawing.Point(12, 76);
            this.gbShow.Name = "gbShow";
            this.gbShow.Size = new System.Drawing.Size(882, 197);
            this.gbShow.TabIndex = 0;
            this.gbShow.TabStop = false;
            this.gbShow.Text = "Kết quả học tập sinh viên ";
            // 
            // lblMSV
            // 
            this.lblMSV.AutoSize = true;
            this.lblMSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSV.ForeColor = System.Drawing.Color.Red;
            this.lblMSV.Location = new System.Drawing.Point(104, 53);
            this.lblMSV.Name = "lblMSV";
            this.lblMSV.Size = new System.Drawing.Size(99, 20);
            this.lblMSV.TabIndex = 49;
            this.lblMSV.Text = "2255010137";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label13.Location = new System.Drawing.Point(17, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 20);
            this.label13.TabIndex = 48;
            this.label13.Text = "MSV:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(548, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "Môn học:";
            // 
            // cbxSubject
            // 
            this.cbxSubject.DropDownWidth = 250;
            this.cbxSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSubject.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbxSubject.FormattingEnabled = true;
            this.cbxSubject.Location = new System.Drawing.Point(628, 158);
            this.cbxSubject.MaxDropDownItems = 10;
            this.cbxSubject.Name = "cbxSubject";
            this.cbxSubject.Size = new System.Drawing.Size(248, 28);
            this.cbxSubject.TabIndex = 46;
            this.cbxSubject.SelectedIndexChanged += new System.EventHandler(this.cbxSubject_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(104, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(43, 20);
            this.lblName.TabIndex = 45;
            this.lblName.Text = "Minh";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(17, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 20);
            this.label9.TabIndex = 44;
            this.label9.Text = "Họ và tên:";
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(12, 279);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(882, 366);
            this.dgvResult.TabIndex = 43;
            // 
            // txtMSV
            // 
            this.txtMSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMSV.Location = new System.Drawing.Point(192, 12);
            this.txtMSV.Name = "txtMSV";
            this.txtMSV.Size = new System.Drawing.Size(267, 26);
            this.txtMSV.TabIndex = 43;
            this.txtMSV.TextChanged += new System.EventHandler(this.txtMSV_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(513, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(157, 26);
            this.btnFind.TabIndex = 44;
            this.btnFind.Text = "Xem Điểm";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Crimson;
            this.btnClear.Location = new System.Drawing.Point(765, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(129, 26);
            this.btnClear.TabIndex = 45;
            this.btnClear.Text = "Xóa tìm kiếm";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClassList
            // 
            this.btnClassList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassList.Location = new System.Drawing.Point(576, 651);
            this.btnClassList.Name = "btnClassList";
            this.btnClassList.Size = new System.Drawing.Size(180, 26);
            this.btnClassList.TabIndex = 46;
            this.btnClassList.Text = "Xem danh sách lớp";
            this.btnClassList.UseVisualStyleBackColor = true;
            this.btnClassList.Click += new System.EventHandler(this.btnClassList_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.Location = new System.Drawing.Point(192, 44);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(267, 26);
            this.txtSearchName.TabIndex = 48;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(32, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 20);
            this.label10.TabIndex = 47;
            this.label10.Text = "Tìm kiếm theo tên:";
            // 
            // btnAddScore
            // 
            this.btnAddScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddScore.Location = new System.Drawing.Point(12, 651);
            this.btnAddScore.Name = "btnAddScore";
            this.btnAddScore.Size = new System.Drawing.Size(146, 26);
            this.btnAddScore.TabIndex = 49;
            this.btnAddScore.Text = "Nhập điểm ";
            this.btnAddScore.UseVisualStyleBackColor = true;
            this.btnAddScore.Click += new System.EventHandler(this.btnAddScore_Click);
            // 
            // btnEditScore
            // 
            this.btnEditScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnEditScore.Location = new System.Drawing.Point(200, 651);
            this.btnEditScore.Name = "btnEditScore";
            this.btnEditScore.Size = new System.Drawing.Size(146, 26);
            this.btnEditScore.TabIndex = 50;
            this.btnEditScore.Text = "Sửa điểm";
            this.btnEditScore.UseVisualStyleBackColor = true;
            this.btnEditScore.Click += new System.EventHandler(this.btnEditScore_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.Green;
            this.btnExportExcel.Location = new System.Drawing.Point(388, 651);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(146, 26);
            this.btnExportExcel.TabIndex = 51;
            this.btnExportExcel.Text = "Xuất file Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(906, 681);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnEditScore);
            this.Controls.Add(this.btnAddScore);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClassList);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtMSV);
            this.Controls.Add(this.gbShow);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPersonalInfo);
            this.Name = "frmMain";
            this.Text = "Quản lý điểm Sinh viên Lớp 22CN2";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbShow.ResumeLayout(false);
            this.gbShow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPersonalInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAcademicRank_4;
        private System.Windows.Forms.Label lblTotalCredits;
        private System.Windows.Forms.Label lblAcademicRank_10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblGPA_10;
        private System.Windows.Forms.Label lblGPA_4;
        private System.Windows.Forms.ComboBox cbxSemester;
        private System.Windows.Forms.ComboBox cbxSchoolYear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox gbShow;
        private System.Windows.Forms.TextBox txtMSV;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClassList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxSubject;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMSV;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAddScore;
        private System.Windows.Forms.Button btnEditScore;
        private System.Windows.Forms.Button btnExportExcel;
    }
}