using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanBunCha
{
    public partial class FormTrangChu : Form
    {
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void DangXuat_Click(object sender, EventArgs e)
        {
            FormDangNhap a = new FormDangNhap();
            a.ShowDialog();
            this.Hide();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhachHang a = new FormKhachHang();
            this.Hide();
            a.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhanVien a = new FormNhanVien();
            this.Hide();
            a.ShowDialog();
        }

        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDonHang a = new FormDonHang();
            this.Hide();
            a.ShowDialog();
        }

        private void khoHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormKhoHang a = new FormKhoHang();
            this.Hide();
            a.ShowDialog();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThanhToan a = new FormThanhToan();
            this.Hide();
            a.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FormTrangChu_Load(object sender, EventArgs e)
        {

        }

        private void tìmKiếmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTimKiemKhachHang a = new FormTimKiemKhachHang();
            this.Hide();
            a.ShowDialog();
        }

        private void tìmKiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTimKiemNhanVien a = new FormTimKiemNhanVien();
            this.Hide();
            a.ShowDialog();
        }

        private void tìmKiếmĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTimKiemDonHang a = new FormTimKiemDonHang();
            this.Hide();
            a.ShowDialog();
        }

        private void tìmKiếmKhoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTimKiemKhoHang a = new FormTimKiemKhoHang();
            this.Hide();
            a.ShowDialog();
        }

        private void tìmKiếmThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTimKiemThanhToan a = new FormTimKiemThanhToan();
            this.Hide();
            a.ShowDialog();
        }
    }
}
