﻿using recap.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recap.Controllers
{
    internal class ControllerPersoane
    {


        private List<Persoana> persoane;
        private string _path;
        public ControllerPersoane(string path) { 
        
            persoane = new List<Persoana>();
            load();
            this._path = path;
        }

        public void load()
        {

            string path = Directory.GetCurrentDirectory() + _path;
            
            StreamReader streamReader = new StreamReader(path);

            string t;

            while((t = streamReader.ReadLine()) != null)
            {
                Persoana persoana = new Persoana(t);
                persoane.Add(persoana);
            }

            streamReader.Close();
        }

        public void afisarePersoane()
        {

           foreach(Persoana persoana in persoane)
            { 
                Console.WriteLine(persoana.descriere());
            }
        }

        public bool verificare(Persoana persoana)
        {

            for(int i=0;i<persoane.Count;i++)
            {
                if (persoana.Nume.Equals(persoane[i].Nume) && persoana.Prenume.Equals(persoane[i].Prenume))
                {
                    return false;
                }
            }

            return true;
        }

        public void addPersoana(Persoana persoana)
        {
            persoane.Add(persoana);
        }

    }
}
