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
    public partial class FormThanhToan : Form
    {
        QuanLyQuanBunChaEntities db = new QuanLyQuanBunChaEntities();
        public FormThanhToan()
        {
            InitializeComponent();
        }

        private void trolai_Click(object sender, EventArgs e)
        {
            FormTrangChu a = new FormTrangChu();
            this.Hide();
            a.ShowDialog();
        }

        private void Them_Click(object sender, EventArgs e)
        {
            thanhtoan thanhtoan = new thanhtoan
            {
                mathanhtoan = tb_matt.Text.Trim(),
                madonhang = tb_madh.Text.Trim(),
                ngaythanhtoan = DateTime.Parse(tb_ngtt.Text.Trim()),
                phuongthucthanhtoan = tb_pttt.Text.Trim(),
                sotien = decimal.Parse(tb_st.Text.Trim()),
            };
            if (db.thanhtoans.Any(k => k.mathanhtoan == thanhtoan.mathanhtoan))
            {
                MessageBox.Show("Mã thanh toán đã tồn tại, vui lòng nhập mã khác!", "Thông báo");
                return;
            }
            db.thanhtoans.Add(thanhtoan);
            db.SaveChanges();
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
            MessageBox.Show("Thêm thanh toán thành công!", "Thông báo");
            tb_matt.Clear();
            tb_madh.Clear();
            tb_pttt.Clear();
            tb_st.Clear();
        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            if (dt_ThanhToan.CurrentRow != null)
            {
                string ma = dt_ThanhToan.CurrentRow.Cells["mathanhtoan"].Value.ToString();

                var thanhtoan = db.thanhtoans.FirstOrDefault(s => s.mathanhtoan == ma);

                if (thanhtoan != null)
                {

                    thanhtoan.mathanhtoan = tb_matt.Text;
                    thanhtoan.madonhang = tb_madh.Text;
                    thanhtoan.ngaythanhtoan = DateTime.Parse(tb_ngtt.Text);
                    thanhtoan.phuongthucthanhtoan = tb_pttt.Text;
                    thanhtoan.sotien = decimal.Parse(tb_st.Text);
                    db.SaveChanges();
                    MessageBox.Show("Sửa bill thanh toán thành công!");

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
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bill thanh toán để sửa!");
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            string macanxoa = tb_matt.Text;
            if (string.IsNullOrEmpty(macanxoa))
            {
                MessageBox.Show("Vui lòng chọn một bill thanh toán để xóa.");
                return;
            }

            var thanhtoan = db.thanhtoans.FirstOrDefault(s => s.mathanhtoan == macanxoa);
            if (thanhtoan != null)
            {
                db.thanhtoans.Remove(thanhtoan);
                db.SaveChanges();
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

                MessageBox.Show("Xóa bill thanh toán thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy bill thanh toán cần xóa.");
            }
        }

        private void dt_ThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dt_ThanhToan.Rows[e.RowIndex];


                tb_matt.Text = row.Cells["mathanhtoan"].Value.ToString();
                tb_madh.Text = row.Cells["madonhang"].Value.ToString();
                tb_ngtt.Text = row.Cells["ngaythanhtoan"].Value.ToString();
                tb_pttt.Text = row.Cells["phuongthucthanhtoan"].Value.ToString();
                tb_st.Text = row.Cells["sotien"].Value.ToString();
            }
        }
    }
}
