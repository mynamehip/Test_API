﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options):base(options) { }

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loaihh> Loaihhs { get; set; }
        #endregion
    }
}