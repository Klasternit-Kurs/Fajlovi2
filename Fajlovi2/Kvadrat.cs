using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fajlovi2
{
	class Kvadrat
	{
		public int DuzinaA;

		public virtual int RacunajPovrsinu()
		{
			return DuzinaA * DuzinaA;
		}
	}

	class Pravougaonik : Kvadrat
	{
		public int DuzinaB;

		public override int RacunajPovrsinu()
		{
			return DuzinaA*DuzinaB;
		}

	}
}
