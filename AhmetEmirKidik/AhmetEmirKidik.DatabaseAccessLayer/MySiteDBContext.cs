using AhmetEmirKidik.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmetEmirKidik.DatabaseAccessLayer
{
	public class MySiteDBContext : DbContext
	{
		public DbSet<Urun> Urunler { get; set; }
		public DbSet<Kategori> Kategoriler { get; set; }
		public DbSet<Kullanıcı> Kullanicilar { get; set; }
		public MySiteDBContext():base("name=SiteDBConString")
		{
			Database.SetInitializer(new MyInitializer());
		}
	}
	public class MyInitializer:CreateDatabaseIfNotExists<MySiteDBContext>
		{
		protected override void Seed(MySiteDBContext context)
		{

			base.Seed(context);
		}
	}
}
