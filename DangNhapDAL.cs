using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBunCha
{
    internal class DangNhapDAL
    {
        public bool CheckLogin(string username, string password)
    {
        using (QuanLyQuanBunChaEntities context = new QuanLyQuanBunChaEntities())
        {
            return context.dangnhaps
                .Any(user => user.tendangnhap == username && user.password == password);
        }
    }
    }
}
