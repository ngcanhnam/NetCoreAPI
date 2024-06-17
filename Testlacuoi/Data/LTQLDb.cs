using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testlacuoi.Models;

    public class LTQLDb : DbContext
    {
        public LTQLDb (DbContextOptions<LTQLDb> options)
            : base(options)
        {
        }

        public DbSet<Testlacuoi.Models.LopHoc> LopHoc { get; set; } = default!;

public DbSet<Testlacuoi.Models.SinhVien> SinhVien { get; set; } = default!;
    }
