using recap.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recap.Controllers
{
    public class ControllerMasini
    {

        private List<Masina> masini;
        private string _path;

        public ControllerMasini(string path) { 
        
            masini = new List<Masina>();
            this._path = path;
            load();
        }

        public void load()
        {

            string path1 = Directory.GetCurrentDirectory() + _path;

            StreamReader streamReader = new StreamReader(path1);

            string t = "";

            while ((t = streamReader.ReadLine()) != null)
            {
                if (!t.Equals(""))
                {
                    Masina masina = new Masina(t);
                    masini.Add(masina);

                }
                
            }

            streamReader.Close();
        }

        public void afisare()
        {
            for(int i=0;i< masini.Count;i++)
            {
                Console.WriteLine(masini[i].descriere());
            }
        }

        public bool verificare(Masina masina) {
        
            for(int i=0;i<masini.Count;i++)
            {
                if (masini[i].Id == masina.Id)
                {
                    return false;
                }
            }
            return true;
        }

        public void addMasina(Masina masina)
        {
           if(verificare(masina)) masini.Add(masina);
        }

        public Masina findbyId(int id)
        {

            for(int i = 0; i < masini.Count; i++)
            {
                if (masini[i].Id == id) return masini[i];
            }

            return null;
        }

        public List<Masina> getMasini()
        {
            return masini;
        }

        int pozId(int id)
        {

            for(int i = 0; i < masini.Count; i++)
            {
                if (masini[i].Id == id) return i;
            }
            return -1;
        }

        public void stergere(int id)
        {

            masini.RemoveAt(pozId(id));

        }

        public string toSaveFisier()
        {

            string t = "";

            for(int i=0; i < masini.Count; i++)
            {
                t += masini[i].toSave() + "\n";

            }

            return t;
        }

        public void delete(int id)
        {
            if (findbyId(id).Pretul <= 20000)
            {
                this.stergere(id);

                StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + _path);
                streamWriter.WriteLine(toSaveFisier());
                streamWriter.Close();
            }
          
        }


    }
}
