//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyQuanBunCha
{
    using System;
    using System.Collections.Generic;
    
    public partial class donhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public donhang()
        {
            this.thanhtoans = new HashSet<thanhtoan>();
        }
    
        public string madonhang { get; set; }
        public string makhachhang { get; set; }
        public string manhanvien { get; set; }
        public Nullable<System.DateTime> ngaytao { get; set; }
        public Nullable<decimal> tonggiatri { get; set; }
        public string trangthai { get; set; }
    
        public virtual khachhang khachhang { get; set; }
        public virtual nhanvien nhanvien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<thanhtoan> thanhtoans { get; set; }
    }
}
