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
    public partial class frmEditScoreTab : Form
    {
        ConnectData cn = new ConnectData();
        string maSV, subject, weight;
        double componentScore, examScore;

        public frmEditScoreTab(string maSV, string subject, string weight, double componentScore, double examScore)
        {
            InitializeComponent();
            this.maSV = maSV;
            this.subject = subject;
            this.weight = weight;
            this.componentScore = componentScore;
            this.examScore = examScore;
        }
        private void frmEditScoreTab_Load(object sender, EventArgs e)
        {
            txtComponentScore.Text = componentScore.ToString();
            txtExamScore.Text = examScore.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        { 
            double componentScore, examScore;
            double finalScore = 0, Score4Scale = 0;
            string weight = this.weight;

            if (!double.TryParse(txtComponentScore.Text, out componentScore) || !double.TryParse(txtExamScore.Text, out examScore))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (componentScore < 0 || componentScore > 10 || examScore < 0 || examScore > 10)
            {
                MessageBox.Show("Điểm không hợp lệ! Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (weight == "30-70")
            {
                finalScore = componentScore * 0.3f + examScore * 0.7f;
            }
            else 
            {
                finalScore = componentScore * 0.4f + examScore * 0.6f;
            }

            string letterScore = (finalScore >= 8.5) ? "A" : (finalScore >= 7) ? "B" : (finalScore >= 5.5) ? "C" : (finalScore >= 4) ? "D" : "F";
            string status = (finalScore >= 4) ? "Qua môn" : "Trượt môn";
            Score4Scale = Math.Round(finalScore / 2.5, 1);

            string nq_EditScore = $@"UPDATE Diem
                                    SET DiemThanhPhan = {componentScore},DiemThi = {examScore},
                                        DiemTBCHP = {finalScore},DiemThang4 = {Score4Scale},
                                        DiemChu = '{letterScore}',TrangThai = N'{status}'
                                    WHERE MaSV = '{this.maSV}' 
                                    AND MaMon = (SELECT MaMon FROM MonHoc WHERE TenMon = N'{this.subject}')";
            cn.ExecuteNonQuery(nq_EditScore);

            MessageBox.Show("Sửa điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
