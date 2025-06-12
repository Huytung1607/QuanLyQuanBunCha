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
    public partial class FormDonHang : Form
    {
        QuanLyQuanBunChaEntities db = new QuanLyQuanBunChaEntities();
        public FormDonHang()
        {
            InitializeComponent();
        }

        private void FormDonHang_Load(object sender, EventArgs e)
        {
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

        private void Them_Click(object sender, EventArgs e)
        {
            donhang donhang = new donhang
            {
                madonhang = tb_madh.Text.Trim(),
                makhachhang = tb_makh.Text.Trim(),
                manhanvien = tb_manv.Text.Trim(),
                ngaytao = DateTime.Parse(tb_ngtao.Text.Trim()), 
                tonggiatri = decimal.Parse(tb_tonggt.Text.Trim()),
                trangthai = tb_tt.Text.Trim()
            };
            if (db.donhangs.Any(k => k.madonhang == donhang.madonhang))
            {
                MessageBox.Show("Mã đơn hàng đã tồn tại, vui lòng nhập mã khác!", "Thông báo");
                return;
            }
            db.donhangs.Add(donhang);
            db.SaveChanges();
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
            MessageBox.Show("Thêm khách hàng thành công!", "Thông báo");
            tb_madh.Clear();
            tb_makh.Clear();
            tb_manv.Clear();
            tb_tonggt.Clear();
            tb_tt.Clear();
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            if (dt_DonHang.CurrentRow != null)
            {
                string ma = dt_DonHang.CurrentRow.Cells["madonhang"].Value.ToString();

                var donhang = db.donhangs.FirstOrDefault(s => s.madonhang == ma);

                if (donhang != null)
                {

                    donhang.madonhang = tb_madh.Text;
                    donhang.makhachhang = tb_makh.Text;
                    donhang.manhanvien = tb_manv.Text;
                    donhang.ngaytao = DateTime.Parse(tb_ngtao.Text);
                    donhang.tonggiatri = decimal.Parse(tb_tonggt.Text);
                    donhang.trangthai = tb_tt.Text;
                    db.SaveChanges();
                    MessageBox.Show("Sửa đơn hàng thành công!");

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
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để sửa!");
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            string macanxoa = tb_madh.Text;
            if (string.IsNullOrEmpty(macanxoa))
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng để xóa.");
                return;
            }

            var donhang = db.donhangs.FirstOrDefault(s => s.madonhang == macanxoa);
            if (donhang != null)
            {
                db.donhangs.Remove(donhang);
                db.SaveChanges();
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

                MessageBox.Show("Xóa đơn hàng thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy đơn hàng cần xóa.");
            }
        }

        private void dt_DonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dt_DonHang.Rows[e.RowIndex];


                tb_madh.Text = row.Cells["madonhang"].Value.ToString();
                tb_makh.Text = row.Cells["makhachhang"].Value.ToString();
                tb_manv.Text = row.Cells["manhanvien"].Value.ToString();
                tb_ngtao.Text = row.Cells["ngaytao"].Value.ToString();
                tb_tonggt.Text = row.Cells["tonggiatri"].Value.ToString();
                tb_tt.Text = row.Cells["trangthai"].Value.ToString();
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
