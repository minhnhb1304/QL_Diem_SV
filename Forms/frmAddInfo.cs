using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Diem
{
    public partial class frmAddInfo : Form
    {
        ConnectData cn = new ConnectData();

        public frmAddInfo()
        {
            InitializeComponent();
        }

        private void frmAddInfo_Load(object sender, EventArgs e)
        {
            cbxGender.Items.Add("---Giới tính----");
            cbxGender.Items.Add("Nam");
            cbxGender.Items.Add("Nữ");
            cbxGender.SelectedIndex = 0;
            cbxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            pbxProfilePicure.SizeMode = PictureBoxSizeMode.Zoom; // Giữ tỷ lệ ảnh và vừa PictureBox
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn ảnh đại diện",
                Filter = "Ảnh (*.jpg;*.png)|*.jpg;*.png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbxProfilePicure.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnAddInfo_Click(object sender, EventArgs e)
        {
            string maSV = txtMSV.Text;
            string hoTen = txtName.Text;
            string ngaySinh = dtpDoB.Value.ToString("yyyy-MM-dd");
            string gioiTinh = cbxGender.Text;
            string sdt = txtPhone.Text;
            string queQuan = txtHomeTown.Text;

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(maSV)) // Kiểm tra mã sinh viên
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(hoTen)) // Kiểm tra họ tên
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^(0\d{9,11})$")) // Kiểm tra số điện thoại
            {
                MessageBox.Show("Số điện thoại không hợp lệ!\n\nSố điện thoại bắt đầu bằng số 0 và có độ dài 9 - 11 số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbxGender.SelectedIndex == 0) // Kiểm tra giới tính
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] imageData = null;
            if (pbxProfilePicure.Image != null) // Kiểm tra nếu đã chọn ảnh
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbxProfilePicure.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }
            }

            // Chuyển mảng byte ảnh thành chuỗi hex để lưu vào CSDL nếu chưa chọn ảnh thì lưu NULL
            string imageHex = (imageData != null) ? "0x" + BitConverter.ToString(imageData).Replace("-", "") : "NULL";


            // Câu lệnh SQL INSERT
            string queryAdd = "INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, SoDienThoai, QueQuan, AnhDaiDien) " +
                             $"VALUES ('{maSV}', N'{hoTen}', '{ngaySinh}', N'{gioiTinh}', '{sdt}', N'{queQuan}', {imageHex})";

            // Thực thi câu lệnh
            try
            {
                cn.ExecuteNonQuery(queryAdd);
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
