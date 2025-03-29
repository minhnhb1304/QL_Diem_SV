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
    public partial class frmClassList : Form
    {
        ConnectData cn = new ConnectData();
        public frmClassList()
        {
            InitializeComponent();
        }

        private void frmClassList_Load(object sender, EventArgs e)
        {
            DataGridViewHelper.Customize(dgvClassList);
            LoadStudentList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddInfo_Click(object sender, EventArgs e)
        {
            Form frmAddInfo = new frmAddInfo();
            frmAddInfo.ShowDialog();

            LoadStudentList();//Load lại danh sách sinh viên sau khi thêm
        }
        private void LoadStudentList()
        {
            string query = @"SELECT MaSV AS 'Mã Sinh Viên', HoTen AS 'Họ và tên', NgaySinh AS 'Ngày sinh', GioiTinh AS 'Giới tính', 
                            QueQuan AS 'Quê quán', SoDienThoai AS 'Số điện thoại', AnhDaiDien AS 'Ảnh đại diện'
                            FROM SinhVien";

            DataTable dt = cn.Execute(query);
            dgvClassList.DataSource = dt;
        }

        private void btnChangeInfo_Click(object sender, EventArgs e)
        {
            if (dgvClassList.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int rowIndex = dgvClassList.SelectedCells[0].RowIndex; // Lấy chỉ số hàng từ ô đang chọn
                string maSV = dgvClassList.Rows[rowIndex].Cells["Mã Sinh Viên"].Value.ToString(); // Lấy Mã SV từ hàng đó

                Form frmChangeInfo = new frmPersonalInfo(maSV);
                frmChangeInfo.ShowDialog();//Hiển thị form sửa thông tin sinh viên

                LoadStudentList();//Load lại danh sách sinh viên sau khi sửa
            }
        }

        private void btnDeleteInfo_Click(object sender, EventArgs e)
        {
            if (dgvClassList.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Xóa thông tin sinh viên này (không thể hoàn tác)", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    int rowIndex = dgvClassList.SelectedCells[0].RowIndex; // Lấy chỉ số hàng từ ô đang chọn
                    string maSV = dgvClassList.Rows[rowIndex].Cells["Mã Sinh Viên"].Value.ToString(); // Lấy Mã SV từ hàng đó

                    string query = $"DELETE FROM Diem WHERE MaSV = '{maSV}'" +
                                   $"DELETE FROM SinhVien WHERE MaSV = '{maSV}'";//Xóa thông tin điểm trước khi xóa TTCN sinh viên

                    cn.ExecuteNonQuery(query);
                    LoadStudentList();//Load lại danh sách sinh viên sau khi xóa
                }
            }
        }
    }
}
