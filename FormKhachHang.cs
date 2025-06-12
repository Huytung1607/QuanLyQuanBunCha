using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyQuanBunCha
{
    public partial class FormKhachHang : Form
    {
        QuanLyQuanBunChaEntities db = new QuanLyQuanBunChaEntities();
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void HienThi_Click(object sender, EventArgs e)
        {
            
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
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

        private void Them_Click(object sender, EventArgs e)
        {
            khachhang khachhang = new khachhang
            {
                makhachhang = tb_ma.Text.Trim(),
                tenkhachhang = tb_ten.Text.Trim(),
                sodienthoai = tb_sdt.Text.Trim(),
                diachi = tb_dc.Text.Trim()
            };
            if (db.khachhangs.Any(k => k.makhachhang == khachhang.makhachhang))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại, vui lòng nhập mã khác!", "Thông báo");
                return;
            }
            db.khachhangs.Add(khachhang);
            db.SaveChanges();
            dt_KhachHang.DataSource = db.khachhangs
                .Select(kh => new
                {
                    kh.makhachhang,
                    kh.tenkhachhang,
                    kh.sodienthoai,
                    kh.diachi
                })
                .ToList();
            MessageBox.Show("Thêm khách hàng thành công!", "Thông báo");
            tb_ma.Clear();
            tb_ten.Clear();
            tb_sdt.Clear();
            tb_dc.Clear();
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            if (dt_KhachHang.CurrentRow != null)
            {
                string ma = dt_KhachHang.CurrentRow.Cells["makhachhang"].Value.ToString();

                var khachhang = db.khachhangs.FirstOrDefault(s => s.makhachhang == ma);

                if (khachhang != null)
                {

                    khachhang.makhachhang = tb_ma.Text;
                    khachhang.tenkhachhang = tb_ten.Text;
                    khachhang.sodienthoai = tb_sdt.Text;
                    khachhang.diachi = tb_dc.Text;
                    db.SaveChanges();
                    MessageBox.Show("Sửa khách hàng thành công!");

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
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa!");
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            string macanxoa = tb_ma.Text;
            if (string.IsNullOrEmpty(macanxoa))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa.");
                return;
            }

            var khachhang = db.khachhangs.FirstOrDefault(s => s.makhachhang == macanxoa);
            if (khachhang != null)
            {
                db.khachhangs.Remove(khachhang);
                db.SaveChanges();
                dt_KhachHang.DataSource = db.khachhangs
                .Select(kh => new
                {
                    kh.makhachhang,
                    kh.tenkhachhang,
                    kh.sodienthoai,
                    kh.diachi
                })
                .ToList();

                MessageBox.Show("Xóa khách hàng thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng cần xóa.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dt_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dt_KhachHang.Rows[e.RowIndex];


                tb_ma.Text = row.Cells["makhachhang"].Value.ToString();
                tb_ten.Text = row.Cells["tenkhachhang"].Value.ToString();
                tb_sdt.Text = row.Cells["sodienthoai"].Value.ToString();
                tb_dc.Text = row.Cells["diachi"].Value.ToString();
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
