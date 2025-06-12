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
    public partial class FormDangNhap : Form
    {
        QuanLyQuanBunChaEntities a = new QuanLyQuanBunChaEntities();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tb_pass.UseSystemPasswordChar = false;
            }
            else
            {
                tb_pass.UseSystemPasswordChar = true;
            }
        }

        private void btn_Dky_Click(object sender, EventArgs e)
        {
            FormDangKy c = new FormDangKy();
            this.Hide();
            c.ShowDialog();
        }

        private void btn_Nhaplai_Click(object sender, EventArgs e)
        {
            tb_tendnhap.Text = "";
            tb_pass.Text = "";
            tb_tendnhap.Focus();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Dangnhap_Click(object sender, EventArgs e)
        {
            string username = tb_tendnhap.Text.Trim();
            string password = tb_pass.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Cảnh báo");
                return;
            }

            DangNhapDAL dangnhap = new DangNhapDAL();
            if (dangnhap.CheckLogin(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                FormTrangChu main = new FormTrangChu();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Lỗi");
            }
        }
    }
}
