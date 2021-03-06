﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fajlovi2
{
	[Serializable]
	public class Osoba
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }

		public Osoba() { }
		public Osoba(string i, string p)
		{
			Ime = i;
			Prezime = p;
		}

		public override string ToString()
		{
			return $"{Ime} {Prezime}";
		}
	}
}
