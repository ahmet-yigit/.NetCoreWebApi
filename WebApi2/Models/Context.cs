using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context>options):base(options)
        {

        }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<SepetUrun> SepetUruns { get; set; }
    }
}
