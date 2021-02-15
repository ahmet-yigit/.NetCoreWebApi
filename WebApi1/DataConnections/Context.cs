using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi1.Models;

namespace WebApi1.DataConnections
{
    public class Context:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-TREGG5A;Initial Catalog=ProjectWebApi;Integrated Security=true");
        //}
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<SepetUrun> SepetUruns { get; set; }
    }
}
