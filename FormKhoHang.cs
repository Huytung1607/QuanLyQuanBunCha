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
    public partial class FormKhoHang : Form
    {
        QuanLyQuanBunChaEntities db = new QuanLyQuanBunChaEntities();
        public FormKhoHang()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void trolai_Click(object sender, EventArgs e)
        {
            FormTrangChu a = new FormTrangChu();
            this.Hide();
            a.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Them_Click(object sender, EventArgs e)
        {
            khohang khohang = new khohang
            {
                makho = tb_makho.Text.Trim(),
                manhanvien = tb_manv.Text.Trim(),
                nhacungcap = tb_ncc.Text.Trim(),
                tennguyenlieu = tb_tenngl.Text.Trim(),
                soluong = int.Parse(tb_sl.Text.Trim())
            };
            if (db.khohangs.Any(k => k.makho == khohang.makho))
            {
                MessageBox.Show("Mã kho hàng đã tồn tại, vui lòng nhập mã khác!", "Thông báo");
                return;
            }
            db.khohangs.Add(khohang);
            db.SaveChanges();
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
            MessageBox.Show("Thêm kho hàng thành công!", "Thông báo");
            tb_makho.Clear();
            tb_manv.Clear();
            tb_ncc.Clear();
            tb_tenngl.Clear();
            tb_sl.Clear();
        }

        private void FormKhoHang_Load(object sender, EventArgs e)
        {
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

        private void Sua_Click(object sender, EventArgs e)
        {
            if (dt_KhoHang.CurrentRow != null)
            {
                string ma = dt_KhoHang.CurrentRow.Cells["makho"].Value.ToString();

                var khohang = db.khohangs.FirstOrDefault(s => s.makho == ma);

                if (khohang != null)
                {
                    khohang.makho = tb_makho.Text;
                    khohang.manhanvien = tb_manv.Text;
                    khohang.nhacungcap = tb_ncc.Text;
                    khohang.tennguyenlieu = tb_tenngl.Text;
                    khohang.soluong = int.Parse(tb_sl.Text);
                    db.SaveChanges();
                    MessageBox.Show("Sửa kho hàng thành công!");

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
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa!");
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            string macanxoa = tb_makho.Text;
            if (string.IsNullOrEmpty(macanxoa))
            {
                MessageBox.Show("Vui lòng chọn một kho hàng để xóa.");
                return;
            }

            var khohang = db.khohangs.FirstOrDefault(s => s.makho == macanxoa);
            if (khohang != null)
            {
                db.khohangs.Remove(khohang);
                db.SaveChanges();
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

                MessageBox.Show("Xóa kho hàng thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy kho hàng cần xóa.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dt_KhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dt_KhoHang.Rows[e.RowIndex];


                tb_makho.Text = row.Cells["makho"].Value.ToString();
                tb_manv.Text = row.Cells["manhanvien"].Value.ToString();
                tb_ncc.Text = row.Cells["nhacungcap"].Value.ToString();
                tb_tenngl.Text = row.Cells["tennguyenlieu"].Value.ToString();
                tb_sl.Text = row.Cells["soluong"].Value.ToString();
            }
        }
    }
}
