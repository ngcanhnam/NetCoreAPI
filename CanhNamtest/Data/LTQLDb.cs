using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CanhNamtest;

    public class LTQLDb : DbContext
    {
        public LTQLDb (DbContextOptions<LTQLDb> options)
            : base(options)
        {
        }

        public DbSet<CanhNamtest.Lophoc> Lophoc { get; set; } = default!;

        public DbSet<CanhNamtest.Sinhvien> Sinhvien { get; set; } = default!;
        
    }
