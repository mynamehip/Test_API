namespace WebApplication1.Models
{
    public class HangHoaVM
    {
        public string Tenhh { get; set; }
        public double Dongia { get; set; }
    }

    public class HangHoa : HangHoaVM
    {
        public Guid Mahh { get; set; }
    }

    public class HangHoaModel
    {
        public Guid Mahh { get; set; }
        public string Tenhh { get; set; }
        public double Dongia { get; set; }
        public string TenLoai { get; set; }
    }
}
