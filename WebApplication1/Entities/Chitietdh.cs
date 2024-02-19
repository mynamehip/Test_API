using WebApplication1.Entities;

namespace WebApplication1.Entities
{
    public class Chitietdh
    {
        public Guid Mahh { get; set; }
        public Guid Madh { get; set; }
        public int Soluong { get; set; }
        public double Dongia { get; set; }
        public byte Giamgia { get; set; }

        //relationship
        public Donhang Donhang { get; set; }
        public Hanghoa Hanghoa { get; set; }
    }
}
