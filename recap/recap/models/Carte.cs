using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recap.models
{
    internal class Carte
    {

        private int _id;
        private string _name;
        private string _autorul;
        private int _anul;

        public Carte(int id, string name, string autorul, int anul)
        {
            _id = id;
            _name = name;
            _autorul = autorul;
            _anul = anul;
        }

        public Carte(string text)
        {

            string[] prop = text.Split('|');

            this._id = int.Parse(prop[0]);
            this._name = prop[1];
            this._autorul = prop[2];
            this._anul = int.Parse(prop[3]);

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

        public string Autorul
        {
            get { return _autorul; }
            set { _autorul = value; }
        }

        public int Anul
        {
            get { return _anul; }
            set { _anul = value; }
        }

        public string descriere()
        {

            string t = "";

            t += "Id-ul: " + _id.ToString() + "\n";
            t+="Numele carti: "+_name +"\n";
            t += "Autorul: " + _autorul + "\n";
            t += "Anul: " + _anul.ToString() + "\n";

            return t;
        }

    }
}
