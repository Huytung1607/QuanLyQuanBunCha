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
    public partial class FormNhanVien : Form
    {
        QuanLyQuanBunChaEntities db = new QuanLyQuanBunChaEntities();
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
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

        private void Them_Click(object sender, EventArgs e)
        {
            nhanvien nhanvien = new nhanvien
            {
                manhanvien = tb_ma.Text.Trim(),
                tennhanvien = tb_ten.Text.Trim(),
                vitrilamviec = tb_vtlv.Text.Trim(),
                sodienthoai = tb_sdt.Text.Trim(),
                diachi = tb_dc.Text.Trim()
            };
            if (db.nhanviens.Any(k => k.manhanvien == nhanvien.manhanvien))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại, vui lòng nhập mã khác!", "Thông báo");
                return;
            }
            db.nhanviens.Add(nhanvien);
            db.SaveChanges();
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
            MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
            tb_ma.Clear();
            tb_ten.Clear();
            tb_vtlv.Clear();
            tb_sdt.Clear();
            tb_dc.Clear();
        }

        private void dt_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dt_NhanVien.Rows[e.RowIndex];


                tb_ma.Text = row.Cells["manhanvien"].Value.ToString();
                tb_ten.Text = row.Cells["tennhanvien"].Value.ToString();
                tb_vtlv.Text = row.Cells["vitrilamviec"].Value.ToString();
                tb_sdt.Text = row.Cells["sodienthoai"].Value.ToString();
                tb_dc.Text = row.Cells["diachi"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            if (dt_NhanVien.CurrentRow != null)
            {
                string ma = dt_NhanVien.CurrentRow.Cells["manhanvien"].Value.ToString();

                var nhanvien = db.nhanviens.FirstOrDefault(s => s.manhanvien == ma);

                if (nhanvien != null)
                {

                    nhanvien.manhanvien = tb_ma.Text;
                    nhanvien.tennhanvien = tb_ten.Text;
                    nhanvien.vitrilamviec = tb_vtlv.Text;
                    nhanvien.sodienthoai = tb_sdt.Text;
                    nhanvien.diachi = tb_dc.Text;
                    db.SaveChanges();
                    MessageBox.Show("Sửa nhân viên thành công!");

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
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!");
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            string macanxoa = tb_ma.Text;
            if (string.IsNullOrEmpty(macanxoa))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.");
                return;
            }

            var nhanvien = db.nhanviens.FirstOrDefault(s => s.manhanvien == macanxoa);
            if (nhanvien != null)
            {
                db.nhanviens.Remove(nhanvien);
                db.SaveChanges();
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

                MessageBox.Show("Xóa nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên cần xóa.");
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
