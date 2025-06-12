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
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Dangnhap_Click(object sender, EventArgs e)
        {
            FormDangNhap c = new FormDangNhap();
            this.Hide();
            c.ShowDialog();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Nhaplai_Click(object sender, EventArgs e)
        {
            tb_tentk.Text = "";
            tb_tendnhap.Text = "";
            tb_pass.Text = "";
            tb_confirmPass.Text = "";
            tb_sdt.Text = "";
            tb_dc.Text = "";
            tb_tentk.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tb_pass.UseSystemPasswordChar = false;
                tb_confirmPass.UseSystemPasswordChar = false;
            }
            else
            {
                tb_pass.UseSystemPasswordChar = true;
                tb_confirmPass.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tentk = tb_tentk.Text.Trim();
            string tendnhap = tb_tendnhap.Text.Trim();
            string pass = tb_pass.Text.Trim();
            string confirmPass = tb_confirmPass.Text.Trim();
            string sdt = tb_sdt.Text.Trim();
            string dc = tb_dc.Text.Trim();

            // Kiểm tra thông tin đầu vào
            if (string.IsNullOrWhiteSpace(tentk) || string.IsNullOrWhiteSpace(tendnhap) ||
                string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(confirmPass))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
                return;
            }

            if (pass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo");
                return;
            }

            try
            {
                using (QuanLyQuanBunChaEntities context = new QuanLyQuanBunChaEntities())
                {
                    // Kiểm tra tên đăng nhập đã tồn tại
                    if (context.dangnhaps.Any(user => user.tendangnhap == tendnhap))
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác!", "Thông báo");
                        return;
                    }

                    // Tạo đối tượng mới cho bảng dangnhap
                    dangnhap acc = new dangnhap
                    {
                        tendangnhap = tendnhap,
                        password = pass
                    };

                    // Thêm thông tin vào bảng dangky
                    dangky userDetails = new dangky
                    {
                        tentaikhoan = tentk,
                        sodienthoai = sdt,
                        diachi = dc
                    };

                    // Thêm dữ liệu vào CSDL
                    acc.dangkies.Add(userDetails); // Thêm liên kết giữa 2 bảng
                    context.dangnhaps.Add(acc);
                    context.SaveChanges();

                    // Thông báo thành công
                    MessageBox.Show("Đăng ký thành công!", "Thông báo");

                    // Chuyển về form đăng nhập
                    FormDangNhap a = new FormDangNhap();
                    this.Hide();
                    a.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi cụ thể
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message, "Lỗi");
            }
        }
    }
}
