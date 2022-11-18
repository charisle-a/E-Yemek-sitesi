using AhmetEmirKidik.DatabaseAccessLayer.Concrete;
using AhmetEmirKidik.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmetEmirKidik.DatabaseAccessLayer
{
	public class UnitOfWork:IDisposable
	{
		private readonly MySiteDBContext Context;

		private Repository<Urun> urunRepository;
		private Repository<Kategori> kategoriRepository;
		private RepositoryKullanıcı kullaniciRepository;

		public Repository<Urun>UrunWork
		{
			get
			{
				if(urunRepository==null)
				{
					urunRepository = new Repository<Urun>(Context);
					
				}
return urunRepository;
			}
		}
		public Repository<Kategori> kategWork
		{
			get
			{
				if (kategoriRepository == null)
				{
					kategoriRepository = new Repository<Kategori>(Context);
					
				}
return kategoriRepository;
			}
		}
		public RepositoryKullanıcı kullaniciWork
		{
			get
			{
				if (kullaniciRepository == null)
				{
					kullaniciRepository = new RepositoryKullanıcı(Context);
					
				}
				return kullaniciRepository;
			}
		}
		public UnitOfWork()
		{
			Context = new MySiteDBContext();
		}
		public void Save()
		{
			using (var transaction =Context.Database.BeginTransaction())
			{
				try
				{
					Context.SaveChanges();
					transaction.Commit();
				}
				catch (Exception myEx)
				{
					transaction.Rollback();
					throw myEx;
				}
			}
		}

		public void Dispose()
		{
			urunRepository?.Dispose();
			kategoriRepository?.Dispose();
			kullaniciRepository?.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
