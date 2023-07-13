using recap.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recap.Controllers
{
    public class ControllerPersoane
    {


        private List<Persoana> persoane;
        private string _path;
        public ControllerPersoane(string path) { 
        
            persoane = new List<Persoana>();
            this._path = path;
            load();
        }

        public void load()
        {

            string path = Directory.GetCurrentDirectory() + _path;

            StreamReader streamReader = new StreamReader(path);

            string t;

            while ((t = streamReader.ReadLine()) != null)
            {
                if (!t.Equals(""))
                {
                    Persoana persoana = new Persoana(t);
                    persoane.Add(persoana);
                }
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
           if(verificare(persoana)) persoane.Add(persoana);
        }

        public List<Persoana> getPersoane()
        {
            return persoane;
        }

        public Persoana findById(int id)
        {

            for(int i=0;i< persoane.Count;i++)
            {
                if(id == persoane[i].IdPersoana) return persoane[i];
            }

            return null;
        }

        public Persoana findbyId(int id)
        {

            for (int i = 0; i < persoane.Count; i++)
            {
                if (persoane[i].IdPersoana == id) return persoane[i];
            }

            return null;
        }


        public int pozId(int id)
        {

            for(int i=0;i< persoane.Count; i++)
            {
                if (id == persoane[i].IdPersoana) return i;
            }

            return -1;
        }

        public void stergere(int id)
        {
            persoane.RemoveAt(pozId(id));
        }

        public string toSaveFisier()
        {

            string t = "";

            for (int i = 0; i < persoane.Count; i++)
            {
                t += persoane[i].toSave() + "\n";

            }

            return t;
        }

        public void delete(int id)
        {

            if(findById(id).Varsta >= 18)
            {

                this.stergere(id);

                StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + _path);
                streamWriter.WriteLine(toSaveFisier());
                streamWriter.Close();

            }

        }

    }
}
