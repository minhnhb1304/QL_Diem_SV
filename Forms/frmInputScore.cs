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
    public partial class frmInputScore : Form
    {
        private string maSV, name, subject;
        ConnectData cn = new ConnectData();

        private void frmInputScore_Load(object sender, EventArgs e)
        {
            cbxWeightScore.Items.Add("---Chọn hệ số---");
            cbxWeightScore.Items.Add("30 - 70 (%)");
            cbxWeightScore.Items.Add("40 - 60 (%)");
            cbxWeightScore.SelectedIndex = 0;
            txtScore_1.Focus();
        }

        public frmInputScore(string maSV, string name, string subject)
        {
            InitializeComponent();
            this.maSV = maSV;
            this.name = name;
            this.subject = subject;
            lblName.Text = $"Sinh viên: {name} - MSV: {maSV}";
            lblSubject.Text = $"Môn học: {subject}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            double componentScore, examScore;
            double finalScore = 0, Score4Scale = 0;
            string weightScore = "";

            if (!double.TryParse(txtScore_1.Text, out componentScore) || !double.TryParse(txtScore_2.Text, out examScore))
            {
                MessageBox.Show("Vui lòng nhập điểm số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (componentScore < 0 || componentScore > 10 || examScore < 0 || examScore > 10)
            {
                MessageBox.Show("Điểm không hợp lệ! Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (cbxWeightScore.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn hệ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbxWeightScore.SelectedIndex == 1)
            {
                finalScore = componentScore * 0.3f + examScore * 0.7f;
                weightScore = "30-70";
            }
            else if (cbxWeightScore.SelectedIndex == 2)
            {
                finalScore = componentScore * 0.4f + examScore * 0.6f;
                weightScore = "40-60";
            }

            string letterScore = (finalScore >= 8.5) ? "A" : (finalScore >= 7) ? "B" : (finalScore >= 5.5) ? "C" : (finalScore >= 4) ? "D" : "F";
            string status = (finalScore >= 4) ? "Qua môn" : "Trượt môn";
            Score4Scale = Math.Round(finalScore / 2.5, 1);

            string nq_AddScore = $@"INSERT INTO Diem (MaSV, MaMon, HeSoDiem, DiemThanhPhan, DiemThi, DiemTBCHP, DiemThang4, DiemChu, TrangThai)  
                                    SELECT '{maSV}', MaMon, '{weightScore}', {componentScore}, {examScore}, {finalScore}, {Score4Scale}, '{letterScore}', N'{status}' 
                                    FROM MonHoc WHERE TenMon = N'{subject}'";
            cn.ExecuteNonQuery(nq_AddScore);

            MessageBox.Show("Thêm điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
