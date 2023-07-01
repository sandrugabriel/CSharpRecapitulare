using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recap.models
{
    internal class Persoana
    {

        private int _idPersoana;
        private string _nume;
        private string _prenume;
        private int _varsta;
        private double _inaltimea;

        public Persoana(int idPersoana, string nume, string prenume, int varsta, double inaltimea)
        {
            this._idPersoana = idPersoana;
            this._nume = nume;
            this._prenume = prenume;
            this._varsta = varsta;
            this._inaltimea = inaltimea;
        }

        public Persoana(string text) {

            string[] prop = text.Split('|');

            this._idPersoana = int.Parse(prop[0]);
            this._nume = prop[1];
            this._prenume = prop[2];
            this._varsta = int.Parse(prop[3]);
            this._inaltimea = double.Parse(prop[4]);
        
        }


        public int IdPersoana
        {
            get { return _idPersoana; }
            set { _idPersoana = value; }
        }

        public string Nume
        {
            get { return _nume; }
            set { _nume = value; }

        }

        public string Prenume
        {
            get { return _prenume; }
            set { _prenume = value; }
        }

        public int Varsta
        {
            get { return _varsta; }
            set {  _varsta = value; }
        }

        public double Inaltime
        {
            get { return _inaltimea; }
            set { _inaltimea = value; }
        }

        public string descriere()
        {
            string t = "";

            t += "Id-ul: " + _idPersoana.ToString() + "\n";
            t += "Numele: " + _nume + "\n";
            t += "Prenumele: " + _prenume + "\n";
            t += "Varsta: " + _varsta + "\n";
            t += "Inaltimea: " + _inaltimea.ToString() + "\n";

            return t;
        }

    }
}
