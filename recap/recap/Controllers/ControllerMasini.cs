using recap.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recap.Controllers
{
    internal class ControllerMasini
    {

        private List<Masina> masini;
        private string _path;

        public ControllerMasini(string path) { 
        
            masini = new List<Masina>();
            load();
            this._path = path;
        }

        public void load()
        {

            string path = Directory.GetCurrentDirectory() + _path;

            StreamReader streamReader = new StreamReader(path);

            string t = "";

            while ((t = streamReader.ReadLine()) != null)
            {
                Masina masina = new Masina(t);
                masini.Add(masina);
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

        public void addMasina(Masina masina)
        {
            masini.Add(masina);
        }

    }
}
