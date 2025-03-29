using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QL_Diem
{
    public partial class frmEditScore : Form
    {
        private string maSV;
        ConnectData cn = new ConnectData();
        private frmMain parentForm;//Khai báo biến parentForm để lưu form cha


        public frmEditScore(frmMain frmMain, string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
            this.parentForm = frmMain;// Lưu form cha vào biến parentForm
            lblMSV.Text = maSV;
            lblName.Text = getName(maSV);
        }

        private void LoadStudentScores()
        {   
            string maSV = this.maSV;

            string query = @"SELECT MaDiem AS 'Mã điểm', mh.MaMon AS 'Mã Môn',mh.TenMon AS 'Tên môn' , HeSoDiem AS 'Hệ số điểm', 
                            DiemThanhPhan AS 'Điểm thành phần', DiemThi AS 'Điểm thi', DiemThang4 AS 'Điểm thang 4', 
                            DiemChu AS 'Điểm chữ', d.TrangThai AS 'Trạng thái'
                            FROM Diem d
                            JOIN MonHoc mh ON d.MaMon = mh.MaMon
                            WHERE d.MaSV ='" + maSV + "'";

            DataTable dt = cn.Execute(query);
            dgvResult.DataSource = dt;
        }

        private void frmEditScore_Load(object sender, EventArgs e)
        {
            parentForm.LoadSubjects();
            cbxSubject.DataSource = parentForm.SubjectData;
            cbxSubject.DisplayMember = "TenMon"; // Hiển thị tên môn học
            cbxSubject.ValueMember = "TenMon";   // Giá trị của từng item trong ComboBox
            cbxSubject.SelectedIndex = 0;
            DataGridViewHelper.Customize(dgvResult);
            LoadStudentScores();
        }

        private void LoadStudentListBySubject()
        {
            string maSV = this.maSV;
            string subject = cbxSubject.SelectedValue.ToString();

            string query = @"SELECT MaDiem AS 'Mã điểm', mh.MaMon AS 'Mã Môn',mh.TenMon AS 'Tên môn' , HeSoDiem AS 'Hệ số điểm', 
                            DiemThanhPhan AS 'Điểm thành phần', DiemThi AS 'Điểm thi', DiemThang4 AS 'Điểm thang 4', 
                            DiemChu AS 'Điểm chữ', d.TrangThai AS 'Trạng thái'
                            FROM Diem d
                            JOIN MonHoc mh ON d.MaMon = mh.MaMon
                            WHERE MaSV ='" + maSV + "' AND mh.TenMon = '" + subject + "'";

            DataTable dt = cn.Execute(query);
            dgvResult.DataSource = dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSubject.SelectedIndex == 0)
            {
                LoadStudentScores();
            }
            else
            {
                LoadStudentListBySubject();
            }
        }

        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvResult.Rows.Count)
                return; // Tránh lỗi khi nhấn vào header hoặc ngoài phạm vi

            dgvResult.Rows[e.RowIndex].Selected = true;

            string maSV = this.maSV;
            string subject = dgvResult.Rows[e.RowIndex].Cells["Tên Môn"].Value?.ToString() ?? "";
            string weightScore = dgvResult.Rows[e.RowIndex].Cells["Hệ số điểm"].Value?.ToString() ?? "";

            double componentScore = 0, examScore = 0;

            // Kiểm tra dữ liệu trước khi chuyển đổi
            if (dgvResult.Rows[e.RowIndex].Cells["Điểm thành phần"].Value != DBNull.Value)
                double.TryParse(dgvResult.Rows[e.RowIndex].Cells["Điểm thành phần"].Value.ToString(), out componentScore);

            if (dgvResult.Rows[e.RowIndex].Cells["Điểm thi"].Value != DBNull.Value)
                double.TryParse(dgvResult.Rows[e.RowIndex].Cells["Điểm thi"].Value.ToString(), out examScore);

            // Mở form chỉnh sửa điểm
            frmEditScoreTab frmEdit_tab = new frmEditScoreTab(maSV, subject, weightScore, componentScore, examScore);
            if (frmEdit_tab.ShowDialog() == DialogResult.OK)
            {
                LoadStudentScores();
            }
        }

        private string getName(string maSV)
        {
            string query = @"SELECT HoTen FROM SinhVien WHERE MaSV = '" + maSV + "'";
            string name = "";
            return name = cn.Execute(query).Rows[0][0].ToString();
        }
    }
}
