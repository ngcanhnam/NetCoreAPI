using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NCN_2121050710_2324;

    public class NCN017 : DbContext
    {
        public NCN017 (DbContextOptions<NCN017> options)
            : base(options)
        {
        }

        public DbSet<NCN_2121050710_2324.Person> Person { get; set; } = default!;
    }
