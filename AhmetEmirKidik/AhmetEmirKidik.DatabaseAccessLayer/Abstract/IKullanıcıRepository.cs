using AhmetEmirKidik.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmetEmirKidik.DatabaseAccessLayer.Abstract
{
	public interface IKullanıcıRepository:IRepository<Kullanıcı>
	{
		bool Login(string EPosta, string Parola);

	}
}
