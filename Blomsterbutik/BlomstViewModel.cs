using BlomstViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Blomsterbutik
{
    public class BlomstViewModel
    {
         public ObservableCollection<OrdreBlomst> Blomster { get; }
        = new ObservableCollection<OrdreBlomst>();

        public string NavnBlomst { get; set; }
        public int AntalBlomst { get; set; }
        public string FarveBlomst {get; set; }



        public string Jsonblomster { get; set; }

        StorageFolder localfolder = null;

        private readonly string filnavn = "blomster.json";

        public RelayCommand AddNyBlomst { get; set; }
        public OrdreBlomst SelectedOrdreBlomst { get; set; }
        public RelayCommand SletSelectedBlomst { get; set; }
        public RelayCommand GemData { get; set; }
        public RelayCommand HentData  { get; set; }


        public BlomstViewModel()
        {
            
            Blomster.Add(new OrdreBlomst() { Navn = "Rose", Farve = "Rød", Antal = 4 });
            Blomster.Add(new OrdreBlomst() { Navn = "Tulipan", Farve = "Gul", Antal = 6 });
            Blomster.Add(new OrdreBlomst() { Navn = "Rose", Farve = "Lilla", Antal = 3 });

            AddNyBlomst = new RelayCommand(AddBlomst);
            SelectedOrdreBlomst = new OrdreBlomst();
            SletSelectedBlomst = new RelayCommand(SletBlomst, canDeleteBlomsterListe);
            GemData = new RelayCommand(GemDataTilDiskAsync);
            HentData = new RelayCommand(HentDataFraDiskAsync);

            localfolder = ApplicationData.Current.LocalFolder;

        }

        public void AddBlomst()
        {
            OrdreBlomst oBlomst = new OrdreBlomst(NavnBlomst, FarveBlomst, AntalBlomst);

            Blomster.Add(oBlomst);

            SletSelectedBlomst.RaiseCanExecuteChanged();
        }

        public void SletBlomst()
        {
            Blomster.Remove(SelectedOrdreBlomst);
            SletSelectedBlomst.RaiseCanExecuteChanged();
        }

        private bool canDeleteBlomsterListe()
        {
            return Blomster.Count > 0;
        }

        private string GetJson()
        {
            string json = JsonConvert.SerializeObject(Blomster);
            return json;

        }

        private void IndsætJson(string jsonText)
        {
            List<OrdreBlomst> nyliste = JsonConvert.DeserializeObject<List<OrdreBlomst>>(jsonText);
                
            foreach (var blomst in nyliste)
            {
                this.Blomster.Add(blomst);
            }
            SletSelectedBlomst.RaiseCanExecuteChanged();
        }

        private async void GemDataTilDiskAsync()
        {

            this.Jsonblomster = GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filnavn,CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(file, this.Jsonblomster);

        }

        private async void HentDataFraDiskAsync()
        {
            StorageFile file = await localfolder.GetFileAsync(filnavn);
            string jsontext = await FileIO.ReadTextAsync(file);
            this.Blomster.Clear();
            IndsætJson(jsontext);

            SletSelectedBlomst.RaiseCanExecuteChanged();

        }

    }
}
