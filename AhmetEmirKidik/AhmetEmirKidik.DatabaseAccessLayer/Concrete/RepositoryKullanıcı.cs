using AhmetEmirKidik.DatabaseAccessLayer.Abstract;
using AhmetEmirKidik.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmetEmirKidik.DatabaseAccessLayer.Concrete
{
	public class RepositoryKullanıcı : Repository<Kullanıcı>, IKullanıcıRepository
	{
		public RepositoryKullanıcı(DbContext context) : base(context)
		{
		}

		public bool Login(string EPosta, string Parola)
		{
			if(context.Set<Kullanıcı>().FirstOrDefault(x => 
			x.EPosta.ToLower().Equals(EPosta.ToLower())&&
			x.Parola.Equals(Parola))!=null)
			return true;
			else
				return false;
		}
	}
}
