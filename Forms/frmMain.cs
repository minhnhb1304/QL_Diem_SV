using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QL_Diem
{
    public partial class frmMain : Form
    {
        ConnectData cn = new ConnectData();

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPersonalInfo_Click(object sender, EventArgs e)
        {
            string maSV = txtMSV.Text.Trim(); // Lấy MSV từ ô nhập liệu
            string name = txtSearchName.Text.Trim(); // Lấy tên từ ô nhập liệu

            if (string.IsNullOrEmpty(maSV) && string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên hoặc tên sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu nhập tên, lấy Mã SV tương ứng 
            if (string.IsNullOrEmpty(maSV) && !string.IsNullOrEmpty(name))
            {
                string queryGetMaSV = "SELECT TOP 1 MaSV FROM SinhVien WHERE HoTen LIKE N'%" + name + "%'";
                DataTable dtMaSV = cn.Execute(queryGetMaSV);

                if (dtMaSV.Rows.Count > 0)
                {
                    maSV = dtMaSV.Rows[0]["MaSV"].ToString();
                    txtMSV.Text = maSV;  // Cập nhật lại textbox Mã SV
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            frmPersonalInfo formInfo = new frmPersonalInfo(maSV); // Khởi tạo form thông tin cá nhân, truyền vào mã sinh viên
            formInfo.ShowDialog(); // Mở cửa sổ thông tin cá nhân
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<string> schoolYears = new List<string>
                {
                    "---Chọn năm học----", "2022-2023", "2023-2024", "2024-2025", "2025-2026", "2026-2027"
                };
            cbxSchoolYear.Items.AddRange(schoolYears.Distinct().ToArray());
            cbxSchoolYear.SelectedIndex = 0;
            cbxSemester.Items.Add("---Chọn học kỳ----");
            cbxSemester.Items.Add("Học kỳ 1");
            cbxSemester.Items.Add("Học kỳ 2");
            cbxSemester.SelectedIndex = 0;
            lblName.Text = "";
            lblAcademicRank_4.Text = "";
            lblAcademicRank_10.Text = "";
            lblGPA_10.Text = "";
            lblGPA_4.Text = "";
            lblTotalCredits.Text = "";
            cbxSchoolYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            DataGridViewHelper.Customize(dgvResult);
            LoadSubjects();
            cbxSubject.SelectedIndex = 0;
            lblMSV.Text = "";
            txtMSV.Focus();
        }

        public void LoadSubjects()
        {
            string querySubject = "SELECT DISTINCT TenMon FROM MonHoc ";
            DataTable dt = cn.Execute(querySubject); // Hàm GetData sẽ lấy dữ liệu từ SQL

            DataRow dr = dt.NewRow();
            dr["TenMon"] = "---Chọn môn học---";
            dt.Rows.InsertAt(dr, 0); // Chèn vào đầu danh sách


            cbxSubject.DataSource = dt;
            cbxSubject.DisplayMember = "TenMon"; // Hiển thị tên môn học
            cbxSubject.ValueMember = "TenMon";   // Giá trị của từng item trong ComboBox
        }

        public DataTable SubjectData
        {
            get { return (DataTable)cbxSubject.DataSource; }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string maSV = txtMSV.Text.Trim();
            string tenSV = txtSearchName.Text.Trim();

            // Nếu nhập tên, lấy Mã SV tương ứng
            if (string.IsNullOrEmpty(maSV) && !string.IsNullOrEmpty(tenSV))
            {
                string queryGetMaSV = "SELECT TOP 1 MaSV FROM SinhVien WHERE HoTen LIKE N'%" + tenSV + "%'";
                DataTable dtMaSV = cn.Execute(queryGetMaSV);

                if (dtMaSV.Rows.Count > 0)
                {
                    maSV = dtMaSV.Rows[0]["MaSV"].ToString();
                    txtMSV.Text = maSV;  // Cập nhật lại textbox Mã SV
                    lblMSV.Text = maSV;  // Hiển thị Mã SV lên label
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Nếu không có mã sinh viên hoặc tên, hiển thị toàn bộ danh sách
            if (string.IsNullOrWhiteSpace(maSV))
            {
                LoadAllStudentScores();
                return;
            }

            // Query tìm điểm theo MaSV
            string queryByMSV = @"SELECT d.MaSV AS 'Mã Sinh Viên', mh.MaMon AS 'Mã Môn', mh.TenMon AS 'Tên Môn',
                    d.HeSoDiem AS 'Hệ số điểm', d.DiemThanhPhan AS 'Điểm thành phần', d.DiemThi AS 'Điểm thi',
                    d.DiemTBCHP AS 'Điểm TBCHP', d.DiemThang4 AS 'Điểm thang 4', d.DiemChu AS 'Điểm chữ',
                    d.TrangThai AS 'Trạng thái', mh.KiHoc AS 'Kì học', mh.NamHoc AS 'Năm học'
                    FROM Diem d 
                    INNER JOIN MonHoc mh ON d.MaMon = mh.MaMon
                    WHERE d.MaSV = '" + maSV + "'";

            DataTable dt = cn.Execute(queryByMSV);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu điểm của sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị dữ liệu lên DataGridView
            LoadStudentScores(maSV);
            dgvResult.DataSource = dt;
        }

        private void LoadAllStudentScores()
        {
            string queryAll = @"SELECT d.MaSV AS 'Mã Sinh Viên', mh.MaMon AS 'Mã Môn', mh.TenMon AS 'Tên Môn',
                                d.HeSoDiem AS 'Hệ số điểm', d.DiemThanhPhan AS 'Điểm thành phần', d.DiemThi AS 'Điểm thi',
                                d.DiemTBCHP AS 'Điểm TBCHP', d.DiemThang4 AS 'Điểm thang 4', d.DiemChu AS 'Điểm chữ',
                                d.TrangThai AS 'Trạng thái', mh.KiHoc AS 'Kì học', mh.NamHoc AS 'Năm học'
                                FROM Diem d
                                INNER JOIN MonHoc mh ON d.MaMon = mh.MaMon";

            DataTable allData = cn.Execute(queryAll);
            dgvResult.DataSource = allData;
            // Reset các label
            lblName.Text = "";
            lblMSV.Text = "";
            lblGPA_10.Text = "";
            lblGPA_4.Text = "";
            lblAcademicRank_10.Text = "";
            lblAcademicRank_4.Text = "";
            lblTotalCredits.Text = "";
            cbxSchoolYear.SelectedIndex = 0;
            cbxSemester.SelectedIndex = 0;
            cbxSubject.SelectedIndex = 0;
        }

        private void LoadStudentScores(string maSV)
        {
            lblMSV.Text = maSV;
            string AcaRank_10, AcaRank_4;
            string queryAll = $"SELECT * FROM Diem WHERE MaSV = '{maSV}'"; // Truy vấn SQL
            DataTable dtDiem = cn.Execute(queryAll); // Thực thi truy vấn
            dgvResult.DataSource = dtDiem; // Hiển thị dữ liệu lên DataGridView

            // Lấy tên sinh viên
            string queryName = $"SELECT HoTen FROM SinhVien WHERE MaSV = '{maSV}'";
            DataTable dtSV = cn.Execute(queryName);
            lblName.Text = dtSV.Rows[0]["HoTen"].ToString();

            // Tính điểm trung bình, xếp loại học lực
            double gpa10 = CalculateGPA(dgvResult, "DiemTBCHP");
            double gpa4 = CalculateGPA(dgvResult, "DiemThang4");

            lblGPA_10.Text = gpa10.ToString();
            lblGPA_4.Text = gpa4.ToString();

            if (gpa10 >= 8.5) AcaRank_10 = "Giỏi";
            else if (gpa10 >= 6.5) AcaRank_10 = "Khá";
            else if (gpa10 >= 4.0) AcaRank_10 = "Trung bình";
            else AcaRank_10 = "Yếu";

            if (gpa4 >= 3.2) AcaRank_4 = "Giỏi";
            else if (gpa4 >= 2.4) AcaRank_4 = "Khá";
            else if (gpa4 >= 1.6) AcaRank_4 = "Trung bình";
            else AcaRank_4 = "Yếu";

            lblAcademicRank_10.Text = AcaRank_10;
            lblAcademicRank_4.Text = AcaRank_4;

            // Lấy tổng số tín chỉ
            string queryTotalCredits = "SELECT TongTinChi FROM SinhVien WHERE MaSV = '" + maSV + "'";
            DataTable dtCredits = cn.Execute(queryTotalCredits);
            lblTotalCredits.Text = dtCredits.Rows[0]["TongTinChi"].ToString();
        }

        private double CalculateGPA(DataGridView dvg, string columnName)
        {
            double sum = 0;
            int count = 0;

            foreach (DataGridViewRow row in dvg.Rows)
            {
                if (row.Cells[columnName].Value != null && double.TryParse(row.Cells[columnName].Value.ToString(), out double value))
                {
                    sum += value;
                    count++;
                }
            }

            return (count > 0) ? Math.Round(sum / count, 2) : 0;
        }

        private void cbxSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSemester.SelectedIndex > 0 || cbxSchoolYear.SelectedIndex > 0)
            {
                if (cbxSubject.SelectedIndex > 0)
                    cbxSubject.SelectedIndex = 0;  // Chỉ reset nếu đang chọn môn học
            }

            LoadStudentScoresByYearAndSemester();
        }

        private void cbxSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSemester.SelectedIndex > 0 || cbxSchoolYear.SelectedIndex > 0)
            {
                if (cbxSubject.SelectedIndex > 0)
                    cbxSubject.SelectedIndex = 0;  // Chỉ reset nếu đang chọn môn học
            }

            LoadStudentScoresByYearAndSemester();
        }

        private void cbxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSubject.SelectedIndex > 0)
            {
                if (cbxSemester.SelectedIndex > 0 || cbxSchoolYear.SelectedIndex > 0)
                {
                    cbxSemester.SelectedIndex = 0;
                    cbxSchoolYear.SelectedIndex = 0;
                }
                LoadStudentScoresBySubject(); // Gọi ngay khi đổi sang tìm kiếm theo môn học
            }
        }

        private void LoadStudentScoresByYearAndSemester()
        {
            if (cbxSchoolYear.SelectedIndex == 0 || cbxSemester.SelectedIndex == 0)
            {
                return;// Không chọn năm học hoặc học kỳ
            }

            string maSV = txtMSV.Text.Trim();

            string semester = "";

            if (cbxSemester.SelectedItem.ToString() == "Học kỳ 1")
            {
                semester = "1";
            }
            else
            {
                semester = "2";
            }

            string schoolYear = cbxSchoolYear.SelectedItem.ToString();

            string queryAll = @"SELECT d.MaSV AS 'Mã Sinh Viên', mh.MaMon AS 'Mã Môn', mh.TenMon AS 'Tên Môn',
                            d.HeSoDiem AS 'Hệ số điểm', d.DiemThanhPhan AS 'Điểm thành phần', d.DiemThi AS 'Điểm thi',
                            d.DiemTBCHP AS 'Điểm TBCHP', d.DiemThang4 AS 'Điểm thang 4', d.DiemChu AS 'Điểm chữ',
                            d.TrangThai AS 'Trạng thái', mh.KiHoc AS 'Kì học', mh.NamHoc AS 'Năm học'
                            FROM Diem d INNER JOIN MonHoc mh ON d.MaMon = mh.MaMon " +
                            "WHERE mh.NamHoc = '" + schoolYear + "' AND mh.KiHoc = '" + semester + "'"; // Truy vấn SQL tất cả dữ liệu

            string queryOne = @"SELECT d.MaSV AS 'Mã Sinh Viên', mh.MaMon AS 'Mã Môn', mh.TenMon AS 'Tên Môn',
                            d.HeSoDiem AS 'Hệ số điểm', d.DiemThanhPhan AS 'Điểm thành phần', d.DiemThi AS 'Điểm thi',
                            d.DiemTBCHP AS 'Điểm TBCHP', d.DiemThang4 AS 'Điểm thang 4', d.DiemChu AS 'Điểm chữ',
                            d.TrangThai AS 'Trạng thái', mh.KiHoc AS 'Kì học', mh.NamHoc AS 'Năm học'
                            FROM Diem d INNER JOIN MonHoc mh ON d.MaMon = mh.MaMon " +
                            "WHERE MaSV = '" + maSV + "' AND mh.NamHoc = '" + schoolYear + "' AND mh.KiHoc = '" + semester + "'"; 

            if (string.IsNullOrEmpty(txtMSV.Text))
            {
                DataTable dt = cn.Execute(queryAll);
                dgvResult.DataSource = dt;
            }
            else
            {
                DataTable dt = cn.Execute(queryOne);
                dgvResult.DataSource = dt;
            }
        }

        public void LoadStudentScoresBySubject()
        {
            string subject = cbxSubject.SelectedValue.ToString();

            string query = @"SELECT d.MaSV AS 'Mã Sinh Viên', mh.MaMon AS 'Mã Môn', mh.TenMon AS 'Tên Môn',
                            d.HeSoDiem AS 'Hệ số điểm', d.DiemThanhPhan AS 'Điểm thành phần', d.DiemThi AS 'Điểm thi',
                            d.DiemTBCHP AS 'Điểm TBCHP', d.DiemThang4 AS 'Điểm thang 4', d.DiemChu AS 'Điểm chữ',
                            d.TrangThai AS 'Trạng thái', mh.KiHoc AS 'Kì học', mh.NamHoc AS 'Năm học'
                            FROM Diem d
                            INNER JOIN MonHoc mh ON d.MaMon = mh.MaMon
                            WHERE mh.TenMon = '" + subject + "'";

            DataTable dt = cn.Execute(query);
            dgvResult.DataSource = dt;
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSV.Clear();
            txtSearchName.Clear();
            lblName.Text = "";
            lblMSV.Text = "";
            lblAcademicRank_4.Text = "";
            lblAcademicRank_10.Text = "";
            lblGPA_10.Text = "";
            lblGPA_4.Text = "";
            lblTotalCredits.Text = "";
            cbxSchoolYear.SelectedIndex = 0;
            cbxSemester.SelectedIndex = 0;
            dgvResult.DataSource = null;
            txtMSV.Focus();
        }

        private void btnClassList_Click(object sender, EventArgs e)
        {
            frmClassList frm = new frmClassList();
            frm.ShowDialog();
        }

        private void txtMSV_TextChanged(object sender, EventArgs e)
        {
            txtSearchName.Clear();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            txtMSV.Clear();
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            frmAddScore frm = new frmAddScore(this);
            frm.ShowDialog();
        }

        private void btnEditScore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblMSV.Text) && dgvResult.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa điểm!\nNhập mã sinh viên và nhấn 'Xem điểm' hoặc chọn sinh viên trên bảng!", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSV = lblMSV.Text;

            if (dgvResult.SelectedCells.Count > 0) {
                int selectedrowindex = dgvResult.SelectedCells[0].RowIndex;// Lấy chỉ số dòng đang chọn
                DataGridViewRow selectedRow = dgvResult.Rows[selectedrowindex];// Lấy dòng đang chọn
                maSV = Convert.ToString(selectedRow.Cells["Mã Sinh Viên"].Value);// Gán giá trị của ô trong cột "Mã Sinh Viên"
            }

            frmEditScore frmEdit = new frmEditScore(this, maSV);
            frmEdit.ShowDialog();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            //ExportToExcel(dgvResult);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
            sfd.Title = "Chọn nơi lưu file Excel";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                ExportToExcel(dgvResult, path);
            }
        }

        private void ExportToExcel(DataGridView dgv, string filePath)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                //Khởi tạo ứng dụng Excel
                Excel.Application excelApp = new Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("Không thể mở Excel. Kiểm tra xem bạn đã cài Excel chưa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Tạo Workbook và Worksheet
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                //Đặt tiêu đề cột (dòng 1)
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText; // Header
                    ((Excel.Range)worksheet.Cells[1, i + 1]).Font.Bold = true; 
                    ((Excel.Range)worksheet.Cells[1, i + 1]).Interior.Color = System.Drawing.Color.LightGray; 
                }

                //Đổ dữ liệu từ DataGridView vào Excel
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                //Định dạng bảng
                Excel.Range usedRange = worksheet.UsedRange;
                usedRange.Columns.AutoFit(); // Căn chỉnh độ rộng cột tự động
                usedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous; // Viền bảng

                //Lưu file Excel
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
