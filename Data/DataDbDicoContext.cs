using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataDbDicoContext : DbContext
    {
        public DataDbDicoContext (DbContextOptions<DataDbDicoContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Vocabulaire> Vocabulaire { get; set; } = default!;
    }
}
