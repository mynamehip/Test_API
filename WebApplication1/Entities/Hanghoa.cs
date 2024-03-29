﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Entities
{
    public class Hanghoa
    {
        [Key]
        public Guid Mahh { get; set; }
        [Required]
        [MaxLength(100)]
        public string Tenhh {  get; set; }
        public string Mota { get; set; }
        [Range(0, Double.MaxValue)]
        public double Dongia { get; set; }
        public byte Giamgia { get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loaihh Loaihh { get; set; }

        public ICollection<Chitietdh> Chitietdh { get; set; }
        public Hanghoa()
        {
            Chitietdh = new List<Chitietdh>();
        }
    }
}
