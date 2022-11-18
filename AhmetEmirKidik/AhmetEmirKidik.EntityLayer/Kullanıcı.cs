﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmetEmirKidik.EntityLayer
{
	[Table("tblKullanici")]
	public class Kullanıcı
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string EPosta { get; set; }
		public string Parola { get; set; }
	}
}
