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
    public partial class FormTimKiemThanhToan : Form
    {
        QuanLyQuanBunChaEntities db = new QuanLyQuanBunChaEntities();
        public FormTimKiemThanhToan()
        {
            InitializeComponent();
        }

        private void FormTimKiemThanhToan_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Mã thanh toán");
            comboBox1.Items.Add("Mã đơn hàng");
            comboBox1.Items.Add("Ngày thanh toán");
            comboBox1.Items.Add("Phương thức thanh toán");
            comboBox1.Items.Add("Số tiền");
            comboBox1.SelectedIndex = 0;

            dt_ThanhToan.AutoGenerateColumns = true;
            dt_ThanhToan.DataSource = db.thanhtoans
                .Select(kh => new
                {
                    kh.mathanhtoan,
                    kh.madonhang,
                    kh.ngaythanhtoan,
                    kh.phuongthucthanhtoan,
                    kh.sotien
                })
                .ToList();
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            string tieuChi = comboBox1.SelectedItem?.ToString(); // Lấy tiêu chí tìm kiếm
            string giaTri = textBox1.Text.Trim(); // Lấy giá trị tìm kiếm từ TextBox

            // Kiểm tra nếu giá trị tìm kiếm rỗng
            if (string.IsNullOrWhiteSpace(giaTri))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm!", "Thông báo");
                return;
            }

            try
            {
                // Danh sách chứa kết quả tìm kiếm
                var ketQua = new List<object>();

                // Tìm kiếm theo tiêu chí
                switch (tieuChi)
                {
                    case "Mã thanh toán":
                        ketQua = db.thanhtoans
                            .Where(tt => tt.mathanhtoan.Contains(giaTri))
                            .Select(tt => new
                            {
                                tt.mathanhtoan,
                                tt.madonhang,
                                tt.ngaythanhtoan,
                                tt.phuongthucthanhtoan,
                                tt.sotien
                            })
                            .ToList<object>();
                        break;

                    case "Mã đơn hàng":
                        ketQua = db.thanhtoans
                            .Where(tt => tt.madonhang.Contains(giaTri))
                            .Select(tt => new
                            {
                                tt.mathanhtoan,
                                tt.madonhang,
                                tt.ngaythanhtoan,
                                tt.phuongthucthanhtoan,
                                tt.sotien
                            })
                            .ToList<object>();
                        break;

                    case "Ngày thanh toán":
                        if (DateTime.TryParse(giaTri, out DateTime ngayThanhToan))
                        {
                            ketQua = db.thanhtoans
                                .Where(tt => tt.ngaythanhtoan == ngayThanhToan)
                                .Select(tt => new
                                {
                                    tt.mathanhtoan,
                                    tt.madonhang,
                                    tt.ngaythanhtoan,
                                    tt.phuongthucthanhtoan,
                                    tt.sotien
                                })
                                .ToList<object>();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập ngày hợp lệ (định dạng yyyy-MM-dd)!", "Lỗi");
                            return;
                        }
                        break;

                    case "Phương thức thanh toán":
                        ketQua = db.thanhtoans
                            .Where(tt => tt.phuongthucthanhtoan.Contains(giaTri))
                            .Select(tt => new
                            {
                                tt.mathanhtoan,
                                tt.madonhang,
                                tt.ngaythanhtoan,
                                tt.phuongthucthanhtoan,
                                tt.sotien
                            })
                            .ToList<object>();
                        break;

                    case "Số tiền":
                        if (decimal.TryParse(giaTri, out decimal soTien))
                        {
                            ketQua = db.thanhtoans
                                .Where(tt => tt.sotien == soTien)
                                .Select(tt => new
                                {
                                    tt.mathanhtoan,
                                    tt.madonhang,
                                    tt.ngaythanhtoan,
                                    tt.phuongthucthanhtoan,
                                    tt.sotien
                                })
                                .ToList<object>();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập một số tiền hợp lệ!", "Lỗi");
                            return;
                        }
                        break;

                    default:
                        MessageBox.Show("Tiêu chí tìm kiếm không hợp lệ!", "Lỗi");
                        return;
                }

                // Hiển thị kết quả tìm kiếm
                if (ketQua.Count > 0)
                {
                    dt_ThanhToan.DataSource = ketQua;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tìm kiếm: {ex.Message}", "Lỗi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trolai_Click(object sender, EventArgs e)
        {
            FormTrangChu a = new FormTrangChu();
            this.Hide();
            a.ShowDialog();
        }
    }
}
