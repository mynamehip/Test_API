using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data
{
    public class Loaihh
    {
        [Key]
        public int MaLoai {  get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }

        public virtual ICollection<HangHoa> HangHoa { get; set;}
    }
}
