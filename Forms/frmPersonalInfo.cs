using DevExpress.XtraEditors.Mask.Design;
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
    public partial class frmPersonalInfo : Form
    {
        ConnectData cn = new ConnectData();
        private string maSV;

        public frmPersonalInfo (string msv)
        {
            InitializeComponent();
            this.maSV = msv;

            LoadStudentInfo();
        }

        private void LoadStudentInfo()
        {
            string query = $"SELECT * FROM SinhVien WHERE MaSV = '{maSV}'";
            DataTable dt = cn.Execute(query);

            //Hien thi thong tin sinh vien
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblMSV.Text = row["MaSV"].ToString();
                txtName.Text = row["HoTen"].ToString();
                txtDoB.Text = Convert.ToDateTime(row["NgaySinh"]).ToString("dd/MM/yyyy");
                txtGender.Text = row["GioiTinh"].ToString();
                cbxGender.Text = txtGender.Text;
                txtPhone.Text = row["SoDienThoai"].ToString();
                txtHometown.Text = row["QueQuan"].ToString();
                lblEducationType.Text = "Đại học - Chính quy".ToString();
                lblMajor.Text = "Công nghệ thông tin".ToString();
                lblCourseTerm.Text = "2022-2026".ToString();
                //hien thi anh dai dien
                pbProfilePic.SizeMode = PictureBoxSizeMode.Zoom;
                if (row["AnhDaiDien"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])row["AnhDaiDien"];
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pbProfilePic.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbProfilePic.Image = null; // Nếu không có ảnh, để PictureBox trống
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPersonalInfo_Load(object sender, EventArgs e)
        {
            txtDoB.ReadOnly = true;
            txtGender.ReadOnly = true;
            txtHometown.ReadOnly = true;
            txtName.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtPictureAdress.ReadOnly = true;
            btnSave.Visible = false;
            cbxGender.Visible = false;
            cbxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGender.Items.Add("Nam");
            cbxGender.Items.Add("Nữ");
            btnChosePicture.Visible = false;
            txtPictureAdress.Visible = false;
            txtPictureAdress.ReadOnly = true;
        }

        public void btnChange_Click(object sender, EventArgs e)
        {
            txtDoB.ReadOnly = false;
            txtGender.ReadOnly = false;
            txtHometown.ReadOnly = false;
            txtName.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtPictureAdress.ReadOnly = false;
            btnChange.Enabled = false;
            btnSave.Visible = true;
            txtGender.Visible = false;
            cbxGender.Visible = true;
            cbxGender.Text = txtGender.Text;
            btnChosePicture.Visible = true;
            txtPictureAdress.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {   
            // Kiểm tra họ tên không được để trống
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng ngày sinh
            DateTime ngaySinh;
            if (!DateTime.TryParseExact(txtDoB.Text, new[] { "dd/MM/yyyy", "yyyy-MM-dd" },
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng nhập đúng định dạng dd/MM/yyyy hoặc yyyy-MM-dd.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ngày sinh không được lớn hơn ngày hiện tại
            if (ngaySinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Không thể lớn hơn ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra số điện thoại
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^(0\d{9,10})$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập số có 10 hoặc 11 chữ số và bắt đầu bằng số 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra quê quán không được để trống
            if (string.IsNullOrWhiteSpace(txtHometown.Text))
            {
                MessageBox.Show("Quê quán không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Nếu người dùng không nhập ảnh thì không cập nhật ảnh
            byte[] imageData = null;
            string imageHex = "";

            if (!string.IsNullOrEmpty(txtPictureAdress.Text))
            {
                imageData = File.ReadAllBytes(txtPictureAdress.Text); // Chuyển ảnh thành byte[]
                imageHex = $",AnhDaiDien = 0x{BitConverter.ToString(imageData).Replace("-", "")}"; // Chuyển byte[] thành hex
            }

            // Nếu mọi thứ hợp lệ, thực hiện cập nhật vào Database
            string query = $"UPDATE SinhVien SET " +
                           $"HoTen = N'{txtName.Text}', " +
                           $"NgaySinh = '{ngaySinh:yyyy-MM-dd}', " + // Lưu theo định dạng chuẩn SQL
                           $"GioiTinh = N'{cbxGender.Text}', " +
                           $"SoDienThoai = '{txtPhone.Text}', " +
                           $"QueQuan = N'{txtHometown.Text}' " +
                           $"{imageHex}" +
                           $" WHERE MaSV = '{maSV}'";

            cn.ExecuteNonQuery(query);

            // Cập nhật giao diện sau khi lưu
            cbxGender.Visible = false;
            txtGender.Visible = true;
            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadStudentInfo();

            // Khóa lại các ô nhập sau khi cập nhật
            txtDoB.ReadOnly = true;
            txtGender.ReadOnly = true;
            txtHometown.ReadOnly = true;
            txtName.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtPictureAdress.ReadOnly = true;
            btnSave.Visible = false;
            btnChange.Enabled = true;
            btnChosePicture.Visible = false;
            txtPictureAdress.Visible = false;
        }

        private void btnChosePicture_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Chọn ảnh đại diện"
            };

            // Nếu chọn ảnh thành công
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                txtPictureAdress.Text = filePath; // Hiển thị đường dẫn ảnh
                pbProfilePic.Image = Image.FromFile(filePath); // Hiển thị ảnh
            }
        }
    }
}
