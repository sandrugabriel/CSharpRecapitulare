using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recap.models
{
    internal class Masina
    {

        private int _id;
        private string _marca;
        private string _model;
        private int _km;
        private int _pretul;

        public Masina(int id, string marca, string model, int km, int pretul)
        {
            _id = id;
            _marca = marca;
            _model = model;
            _km = km;
            _pretul = pretul;
        }

        public Masina(string text)
        {

            string[] prop = text.Split('|');

            this._id = int.Parse(prop[0]);
            this._marca = prop[1];
            this._model = prop[2];
            this._km = int.Parse(prop[3]);
            this._pretul = int.Parse(prop[4]);

        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public int Km
        {
            get { return _km; }
            set { _km = value; }
        }

        public int Pretul
        {
            get { return _pretul; }
            set { _pretul = value; }
        }

        public string descriere()
        {
            string t = "";

            t += "Id-ul: " + _id.ToString() + "\n";
            t += "Marca: " + _marca + "\n";
            t += "Model: " + _model + "\n";
            t += "Km: " + _km + "\n";
            t += "Pretul: " + _pretul + "\n";

            return t;
        }


    }
}
