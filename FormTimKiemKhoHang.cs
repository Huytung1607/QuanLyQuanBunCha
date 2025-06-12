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
    public partial class FormTimKiemKhoHang : Form
    {
        QuanLyQuanBunChaEntities db = new QuanLyQuanBunChaEntities();
        public FormTimKiemKhoHang()
        {
            InitializeComponent();
        }

        private void FormTimKiemKhoHang_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Mã kho");
            comboBox1.Items.Add("Mã nhân viên");
            comboBox1.Items.Add("Nhà cung cấp");
            comboBox1.Items.Add("Tên nguyên liệu");
            comboBox1.Items.Add("Số lượng");
            comboBox1.SelectedIndex = 0;

            dt_KhoHang.AutoGenerateColumns = true;
            dt_KhoHang.DataSource = db.khohangs
                .Select(kh => new
                {
                    kh.makho,
                    kh.manhanvien,
                    kh.nhacungcap,
                    kh.tennguyenlieu,
                    kh.soluong
                })
                .ToList();
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            string tieuChi = comboBox1.SelectedItem?.ToString(); // Tiêu chí tìm kiếm
            string giaTri = textBox1.Text.Trim(); // Giá trị tìm kiếm từ TextBox

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
                    case "Mã kho":
                        ketQua = db.khohangs
                            .Where(kh => kh.makho.Contains(giaTri))
                            .Select(kh => new
                            {
                                kh.makho,
                                kh.manhanvien,
                                kh.nhacungcap,
                                kh.tennguyenlieu,
                                kh.soluong
                            })
                            .ToList<object>();
                        break;

                    case "Mã nhân viên":
                        ketQua = db.khohangs
                            .Where(kh => kh.manhanvien.Contains(giaTri))
                            .Select(kh => new
                            {
                                kh.makho,
                                kh.manhanvien,
                                kh.nhacungcap,
                                kh.tennguyenlieu,
                                kh.soluong
                            })
                            .ToList<object>();
                        break;

                    case "Nhà cung cấp":
                        ketQua = db.khohangs
                            .Where(kh => kh.nhacungcap.Contains(giaTri))
                            .Select(kh => new
                            {
                                kh.makho,
                                kh.manhanvien,
                                kh.nhacungcap,
                                kh.tennguyenlieu,
                                kh.soluong
                            })
                            .ToList<object>();
                        break;

                    case "Tên nguyên liệu":
                        ketQua = db.khohangs
                            .Where(kh => kh.tennguyenlieu.Contains(giaTri))
                            .Select(kh => new
                            {
                                kh.makho,
                                kh.manhanvien,
                                kh.nhacungcap,
                                kh.tennguyenlieu,
                                kh.soluong
                            })
                            .ToList<object>();
                        break;

                    case "Số lượng":
                        if (int.TryParse(giaTri, out int soLuong))
                        {
                            ketQua = db.khohangs
                                .Where(kh => kh.soluong == soLuong)
                                .Select(kh => new
                                {
                                    kh.makho,
                                    kh.manhanvien,
                                    kh.nhacungcap,
                                    kh.tennguyenlieu,
                                    kh.soluong
                                })
                                .ToList<object>();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập một số hợp lệ cho số lượng!", "Lỗi");
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
                    dt_KhoHang.DataSource = ketQua;
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

        private void trolai_Click(object sender, EventArgs e)
        {
            FormTrangChu a = new FormTrangChu();
            this.Hide();
            a.ShowDialog();
        }
    }
}
