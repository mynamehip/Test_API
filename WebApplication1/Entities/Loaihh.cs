using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Loaihh
    {
        [Key]
        public int MaLoai {  get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }

        public virtual ICollection<Hanghoa> HangHoa { get; set;}
    }
}
