using BlomstViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomsterbutik
{
    public class BlomstViewModel
    {
         public ObservableCollection<OrdreBlomst> Blomster { get; }
        = new ObservableCollection<OrdreBlomst>();

        public string NavnBlomst { get; set; }
        public int AntalBlomst { get; set; }
        public string FarveBlomst {get; set; }

        public RelayCommand AddNyBlomst { get; set; }
        public OrdreBlomst SelectedOrdreBlomst { get; set; }
        public RelayCommand SletSelectedBlomst { get; set; }


        public BlomstViewModel()
        {
            
            Blomster.Add(new OrdreBlomst() { Navn = "Rose", Farve = "Rød", Antal = 4 });
            Blomster.Add(new OrdreBlomst() { Navn = "Tulipan", Farve = "Gul", Antal = 6 });
            Blomster.Add(new OrdreBlomst() { Navn = "Rose", Farve = "Lilla", Antal = 3 });

            AddNyBlomst = new RelayCommand(AddBlomst);
            SelectedOrdreBlomst = new OrdreBlomst();
            SletSelectedBlomst = new RelayCommand(SletBlomst);

        }

        public void AddBlomst()
        {
            OrdreBlomst oBlomst = new OrdreBlomst(NavnBlomst, FarveBlomst, AntalBlomst);

            Blomster.Add(oBlomst);
        }

        public void SletBlomst()
        {
            Blomster.Remove(SelectedOrdreBlomst);
        }
    }
}
