using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recap.models
{
    public class Produs
    {

        private int _id;
        private string _name;
        private int _tipProdus;//1- alimente; 2-altele
        private int _pretul;
        private DateTime _dataExpirare;

        public Produs(int id, string name, int tipProdus, int pretul, DateTime dataExpirare)
        {
            _id = id;
            _name = name;
            _tipProdus = tipProdus;
            _pretul = pretul;
            _dataExpirare = dataExpirare;
        }

        public Produs(string text)
        {

            string[] prop = text.Split('|');

            this._id = int.Parse(prop[0]);
            this._name = prop[1];
            this._tipProdus = int.Parse(prop[2]);
            this._pretul = int.Parse(prop[3]);
            if(_tipProdus == 1) this._dataExpirare = DateTime.Parse(prop[4]);

        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int TipProdus
        {
            get { return _tipProdus; }
            set { _tipProdus = value; }
        }

        public int Pret
        {
            get { return _pretul; }
            set { _pretul = value; }
        }

        public DateTime DataExpirare
        {
            get { return _dataExpirare;}
            set { _dataExpirare = value;}
        }

        public string toSave()
        {
            return Id.ToString() + "|" +Name + "|" +TipProdus.ToString() + "|" + Pret.ToString() + "|" + DataExpirare.ToString();
        }

    }
}
