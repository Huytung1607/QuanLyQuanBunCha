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
    public partial class FormTimKiemNhanVien : Form
    {
        QuanLyQuanBunChaEntities db = new QuanLyQuanBunChaEntities();
        public FormTimKiemNhanVien()
        {
            InitializeComponent();
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            string tieuChi = comboBox1.SelectedItem?.ToString(); // Tiêu chí được chọn
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

                // Tìm kiếm dựa trên tiêu chí
                switch (tieuChi)
                {
                    case "Mã nhân viên":
                        ketQua = db.nhanviens
                            .Where(nv => nv.manhanvien.Contains(giaTri))
                            .Select(nv => new
                            {
                                nv.manhanvien,
                                nv.tennhanvien,
                                nv.vitrilamviec,
                                nv.sodienthoai,
                                nv.diachi
                            })
                            .ToList<object>();
                        break;

                    case "Tên nhân viên":
                        ketQua = db.nhanviens
                            .Where(nv => nv.tennhanvien.Contains(giaTri))
                            .Select(nv => new
                            {
                                nv.manhanvien,
                                nv.tennhanvien,
                                nv.vitrilamviec,
                                nv.sodienthoai,
                                nv.diachi
                            })
                            .ToList<object>();
                        break;

                    case "Vị trí làm việc":
                        ketQua = db.nhanviens
                            .Where(nv => nv.vitrilamviec.Contains(giaTri))
                            .Select(nv => new
                            {
                                nv.manhanvien,
                                nv.tennhanvien,
                                nv.vitrilamviec,
                                nv.sodienthoai,
                                nv.diachi
                            })
                            .ToList<object>();
                        break;

                    case "Số điện thoại":
                        ketQua = db.nhanviens
                            .Where(nv => nv.sodienthoai.Contains(giaTri))
                            .Select(nv => new
                            {
                                nv.manhanvien,
                                nv.tennhanvien,
                                nv.vitrilamviec,
                                nv.sodienthoai,
                                nv.diachi
                            })
                            .ToList<object>();
                        break;

                    case "Địa chỉ":
                        ketQua = db.nhanviens
                            .Where(nv => nv.diachi.Contains(giaTri))
                            .Select(nv => new
                            {
                                nv.manhanvien,
                                nv.tennhanvien,
                                nv.vitrilamviec,
                                nv.sodienthoai,
                                nv.diachi
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
                    dt_NhanVien.DataSource = ketQua;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tìm kiếm: {ex.Message}", "Lỗi");
            }
        }

        private void FormTimKiemNhanVien_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Mã nhân viên");
            comboBox1.Items.Add("Tên nhân viên");
            comboBox1.Items.Add("Vị trí làm việc");
            comboBox1.Items.Add("Số điện thoại");
            comboBox1.Items.Add("Địa chỉ");
            comboBox1.SelectedIndex = 0;

            dt_NhanVien.AutoGenerateColumns = true;
            dt_NhanVien.DataSource = db.nhanviens
                .Select(kh => new
                {
                    kh.manhanvien,
                    kh.tennhanvien,
                    kh.vitrilamviec,
                    kh.sodienthoai,
                    kh.diachi
                })
                .ToList();
        }

        private void trolai_Click(object sender, EventArgs e)
        {
            FormTrangChu a = new FormTrangChu();
            this.Hide();
            a.ShowDialog();
        }
    }
}
