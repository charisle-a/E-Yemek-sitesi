using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmetEmirKidik.EntityLayer
{
	[Table("tblUrunler")]
	public class Urun
	{
		[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Ad { get; set; }
		public string Aciklama { get; set; }
		public string FotoUrl { get; set; }
		public string Kategori { get; set; }
		public decimal Fiyat { get; set; }
	}
}
