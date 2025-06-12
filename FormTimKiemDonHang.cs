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
    public partial class FormTimKiemDonHang : Form
    {
        QuanLyQuanBunChaEntities db = new QuanLyQuanBunChaEntities();
        public FormTimKiemDonHang()
        {
            InitializeComponent();
        }

        private void FormTimKiemDonHang_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Mã đơn hàng");
            comboBox1.Items.Add("Mã khách hàng");
            comboBox1.Items.Add("Mã nhân viên");
            comboBox1.Items.Add("Ngày tạo");
            comboBox1.Items.Add("Tổng giá trị");
            comboBox1.SelectedIndex = 0;

            dt_DonHang.AutoGenerateColumns = true;
            dt_DonHang.DataSource = db.donhangs
                .Select(kh => new
                {
                    kh.madonhang,
                    kh.makhachhang,
                    kh.manhanvien,
                    kh.ngaytao,
                    kh.tonggiatri,
                    kh.trangthai
                })
                .ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            string tieuChi = comboBox1.SelectedItem?.ToString();
            string giaTri = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(giaTri))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm!", "Thông báo");
                return;
            }

            try
            {
                var ketQua = new List<object>();

                // Xử lý tìm kiếm theo tiêu chí
                switch (tieuChi)
                {
                    case "Mã đơn hàng":
                        ketQua = db.donhangs
                            .Where(dh => dh.madonhang.Contains(giaTri))
                            .Select(dh => new
                            {
                                dh.madonhang,
                                dh.makhachhang,
                                dh.manhanvien,
                                dh.ngaytao,
                                dh.tonggiatri,
                                dh.trangthai
                            })
                            .ToList<object>();
                        break;

                    case "Mã khách hàng":
                        ketQua = db.donhangs
                            .Where(dh => dh.makhachhang.Contains(giaTri))
                            .Select(dh => new
                            {
                                dh.madonhang,
                                dh.makhachhang,
                                dh.manhanvien,
                                dh.ngaytao,
                                dh.tonggiatri,
                                dh.trangthai
                            })
                            .ToList<object>();
                        break;

                    case "Mã nhân viên":
                        ketQua = db.donhangs
                            .Where(dh => dh.manhanvien.Contains(giaTri))
                            .Select(dh => new
                            {
                                dh.madonhang,
                                dh.makhachhang,
                                dh.manhanvien,
                                dh.ngaytao,
                                dh.tonggiatri,
                                dh.trangthai
                            })
                            .ToList<object>();
                        break;

                    case "Ngày tạo":
                        if (DateTime.TryParse(giaTri, out DateTime ngayTao))
                        {
                            ketQua = db.donhangs
                                .Where(dh => dh.ngaytao == ngayTao)
                                .Select(dh => new
                                {
                                    dh.madonhang,
                                    dh.makhachhang,
                                    dh.manhanvien,
                                    dh.ngaytao,
                                    dh.tonggiatri,
                                    dh.trangthai
                                })
                                .ToList<object>();
                        }
                        else
                        {
                            MessageBox.Show("Ngày tạo không hợp lệ!", "Lỗi");
                            return;
                        }
                        break;

                    case "Tổng giá trị":
                        if (decimal.TryParse(giaTri, out decimal tongGiaTri))
                        {
                            ketQua = db.donhangs
                                .Where(dh => dh.tonggiatri == tongGiaTri)
                                .Select(dh => new
                                {
                                    dh.madonhang,
                                    dh.makhachhang,
                                    dh.manhanvien,
                                    dh.ngaytao,
                                    dh.tonggiatri,
                                    dh.trangthai
                                })
                                .ToList<object>();
                        }
                        else
                        {
                            MessageBox.Show("Tổng giá trị không hợp lệ!", "Lỗi");
                            return;
                        }
                        break;

                    default:
                        MessageBox.Show("Tiêu chí tìm kiếm không hợp lệ!", "Lỗi");
                        return;
                }

                // Hiển thị kết quả
                if (ketQua.Count > 0)
                {
                    dt_DonHang.DataSource = ketQua;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng nào phù hợp!", "Thông báo");
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
