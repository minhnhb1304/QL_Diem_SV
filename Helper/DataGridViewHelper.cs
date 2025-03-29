using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_Diem
{
    public static class DataGridViewHelper
    {
        public static void Customize(DataGridView dgv)
        {
            // Viền và màu nền DataGridView
            dgv.BorderStyle = BorderStyle.Fixed3D;
            dgv.BackgroundColor = ColorTranslator.FromHtml("#F8F9FA"); 
            dgv.GridColor = ColorTranslator.FromHtml("#D6D6D6"); 

            // Định dạng tiêu đề cột
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DDEBF7"); 
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#333333"); 

            // Định dạng nội dung 
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Arial", 11);
            dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#2C3E50"); 
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#A4C2F4"); 
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Màu nền xen kẽ giữa các hàng
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F0F8FF"); 

            // Cài đặt cột tự động điều chỉnh theo nội dung
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Không cho thêm dòng mới
            dgv.AllowUserToAddRows = false;

            // Không cho chỉnh sửa dữ liệu trực tiếp trên bảng
            dgv.ReadOnly = true;

            // Chặn chọn nhiều hàng
            dgv.MultiSelect = false;

            // Chọn cả hàng khi click vào ô
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Bỏ viền mặc định
            dgv.EnableHeadersVisualStyles = false;
        }
    }
}
