using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class LoaihhModel
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
