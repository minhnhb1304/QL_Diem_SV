using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Diem
{
    public partial class frmAddScore : Form
    {
        ConnectData cn = new ConnectData();
        private frmMain parentForm;//Khai báo biến parentForm để lưu form cha

        public frmAddScore(frmMain frmMain)
        {
            InitializeComponent();
            this.parentForm = frmMain;  // Lưu form cha vào biến parentForm
        }

        private void frmAddScore_Load(object sender, EventArgs e)
        {
            parentForm.LoadSubjects();
            cbxSubject.DataSource = parentForm.SubjectData;
            cbxSubject.DisplayMember = "TenMon"; // Hiển thị tên môn học
            cbxSubject.ValueMember = "TenMon";   // Giá trị của từng item trong ComboBox
            DataGridViewHelper.Customize(dgvResult);
        }

        private void LoadStudentListBySubject()
        {
            string subject = cbxSubject.SelectedValue.ToString();

            // Câu lệnh truy vấn các sinh viên theo môn học và điểm số của họ
            string query = @"SELECT sv.MaSV AS 'Mã Sinh Viên', sv.HoTen AS 'Họ tên', mh.MaMon AS 'Mã Môn', mh.TenMon AS 'Tên Môn',                         mh.SoTinChi AS 'Số tín chỉ', d.HeSoDiem AS 'Hệ số điểm',  
                            COALESCE(d.DiemThanhPhan, NULL) AS 'Điểm thành phần', 
                            COALESCE(d.DiemThi, NULL)  AS 'Điểm thi', 
                            COALESCE(d.DiemTBCHP, NULL) AS 'Điểm TBCHP', 
                            COALESCE(d.DiemThang4, NULL) AS 'Điểm thang 4', 
                            COALESCE(d.DiemChu, NULL) AS 'Điểm chữ', 
                            COALESCE(d.TrangThai, NULL) AS 'Trạng thái', 
                            mh.KiHoc AS 'Kì học', mh.NamHoc AS 'Năm học'
                            FROM SinhVien sv
                            CROSS JOIN MonHoc mh 
                            LEFT JOIN Diem d ON sv.MaSV = d.MaSV AND mh.MaMon = d.MaMon
                            WHERE  mh.TenMon LIKE N'" + subject + "'" +
                            "ORDER BY sv.MaSV;";

            DataTable dt = cn.Execute(query);
            dgvResult.DataSource = dt;
        }

        private void cbxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudentListBySubject();
        }

        private void dgvResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào header hoặc ngoài phạm vi
            if (e.RowIndex < 0 || e.RowIndex >= dgvResult.Rows.Count)
                return;

            // Chọn cả dòng khi double-click vào ô
            dgvResult.Rows[e.RowIndex].Selected = true;

            // Lấy thông tin cần thiết
            string maSV = dgvResult.Rows[e.RowIndex].Cells["Mã Sinh Viên"].Value.ToString();
            string tenSV = dgvResult.Rows[e.RowIndex].Cells["Họ tên"].Value.ToString();
            string tenMon = cbxSubject.SelectedValue.ToString();

            // Hiển thị Form nhập điểm
            frmInputScore frm = new frmInputScore(maSV, tenSV, tenMon);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Load lại dữ liệu sau khi nhập điểm
                LoadStudentListBySubject();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
