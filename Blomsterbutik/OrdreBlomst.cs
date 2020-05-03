using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomsterbutik
{
    public class OrdreBlomst
    {
		private int _antal;
		private string _navn;
		private string _farve;

		public string Farve
		{
			get { return _farve; }
			set { _farve = value; }
		}


		public int Antal
		{
			get { return _antal; }
			set { _antal = value; }
		}


		public string Navn
		{
			get { return _navn; }
			set { _navn = value; }
		}

		public OrdreBlomst(string navn, string farve, int antal)
		{
			Navn = navn;
			Antal = antal;
			Farve = farve;




		}

		public OrdreBlomst()
		{

		}

	}
}
