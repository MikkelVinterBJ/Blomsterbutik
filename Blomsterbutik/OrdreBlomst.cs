using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Blomsterbutik 
{
    public class OrdreBlomst : INotifyPropertyChanged
	{
		private int _antal;
		private string _navn;
		private string _farve;

		public event PropertyChangedEventHandler PropertyChanged;

		public string Farve
		{
			get { return _farve; }
			set { _farve = value;
				OnPropertyChanged();
			}

		}


		public int Antal
		{
			get { return _antal; }
			set { _antal = value;
				OnPropertyChanged();
			}
		}


		public string Navn
		{
			get { return _navn; }
			set { _navn = value;
				OnPropertyChanged();
			}
		}

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
