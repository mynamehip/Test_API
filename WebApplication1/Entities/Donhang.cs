namespace WebApplication1.Entities
{
    public enum TinhTrangDonHang
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }

    public class Donhang
    {
        public Guid Madh { get; set; }
        public DateTime Ngaydh { get; set; }
        public DateTime? Ngaygiao { get; set; }
        public TinhTrangDonHang Tinhtrangdh { get; set; }
        public string Nguoimua { get; set; }
        public string Diachi { get; set; }
        public string Sodienthoai {  get; set; }

        public ICollection<Chitietdh> Chitietdh { get; set; }
        public Donhang()
        {
            Chitietdh = new List<Chitietdh>();
        }
    }
}
