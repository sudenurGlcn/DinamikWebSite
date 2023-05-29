using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.Model;

namespace WebApplication1.Models.DataContext
{
    public class ProjeDBContext:DbContext
    {
        public ProjeDBContext():base("ProjeWebDB")
        {
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Kimlik> Kimlik { get; set; }
        public DbSet<Urunler> Urunler { get; set; }
        public DbSet<Slider> Slider { get; set; }
    }
}