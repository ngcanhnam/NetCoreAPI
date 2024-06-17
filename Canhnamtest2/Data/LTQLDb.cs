using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Canhnamtest2.Models;

    public class LTQLDb : DbContext
    {
        public LTQLDb (DbContextOptions<LTQLDb> options)
            : base(options)
        {
        }

        public DbSet<Canhnamtest2.Models.LopHoc> LopHoc { get; set; } = default!;

        public DbSet<Canhnamtest2.Models.SinhVien> SinhVien { get; set; } = default!;
    }
