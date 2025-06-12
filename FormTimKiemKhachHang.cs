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
    public partial class FormTimKiemKhachHang : Form
    {
        QuanLyQuanBunChaEntities db = new QuanLyQuanBunChaEntities();
        public FormTimKiemKhachHang()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            string tieuChi = comboBox1.SelectedItem?.ToString();
            // Lấy giá trị tìm kiếm từ TextBox
            string giaTri = textBox1.Text.Trim();

            // Kiểm tra giá trị đầu vào
            if (string.IsNullOrWhiteSpace(giaTri))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm!", "Thông báo");
                return;
            }

            // Danh sách chứa kết quả tìm kiếm
            var ketQua = new List<object>();

            // Tìm kiếm theo tiêu chí
            try
            {
                switch (tieuChi)
                {
                    case "Mã khách hàng":
                        ketQua = db.khachhangs
                            .Where(kh => kh.makhachhang.Contains(giaTri))
                            .Select(kh => new
                            {
                                kh.makhachhang,
                                kh.tenkhachhang,
                                kh.sodienthoai,
                                kh.diachi
                            })
                            .ToList<object>();
                        break;

                    case "Tên khách hàng":
                        ketQua = db.khachhangs
                            .Where(kh => kh.tenkhachhang.Contains(giaTri))
                            .Select(kh => new
                            {
                                kh.makhachhang,
                                kh.tenkhachhang,
                                kh.sodienthoai,
                                kh.diachi
                            })
                            .ToList<object>();
                        break;

                    case "Số điện thoại":
                        ketQua = db.khachhangs
                            .Where(kh => kh.sodienthoai.Contains(giaTri))
                            .Select(kh => new
                            {
                                kh.makhachhang,
                                kh.tenkhachhang,
                                kh.sodienthoai,
                                kh.diachi
                            })
                            .ToList<object>();
                        break;

                    case "Địa chỉ":
                        ketQua = db.khachhangs
                            .Where(kh => kh.diachi.Contains(giaTri))
                            .Select(kh => new
                            {
                                kh.makhachhang,
                                kh.tenkhachhang,
                                kh.sodienthoai,
                                kh.diachi
                            })
                            .ToList<object>();
                        break;

                    default:
                        MessageBox.Show("Tiêu chí tìm kiếm không hợp lệ!", "Lỗi");
                        return;
                }

                // Hiển thị kết quả tìm kiếm
                if (ketQua.Count > 0)
                {
                    dt_KhachHang.DataSource = ketQua;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào phù hợp!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tìm kiếm: {ex.Message}", "Lỗi");
            }
        }
        private void FormTimKiemKhachHang_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Mã khách hàng");
            comboBox1.Items.Add("Tên khách hàng");
            comboBox1.Items.Add("Số điện thoại");
            comboBox1.Items.Add("Địa chỉ");
            comboBox1.SelectedIndex = 0;

            dt_KhachHang.AutoGenerateColumns = true;
            dt_KhachHang.DataSource = db.khachhangs
                .Select(kh => new
                {
                    kh.makhachhang,
                    kh.tenkhachhang,
                    kh.sodienthoai,
                    kh.diachi
                })
                .ToList();
        }

        private void dt_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trolai_Click(object sender, EventArgs e)
        {
            FormTrangChu a = new FormTrangChu();
            this.Hide();
            a.ShowDialog();
        }
    }
}
