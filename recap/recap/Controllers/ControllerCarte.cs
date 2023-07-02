using recap.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recap.Controllers
{
    internal class ControllerCarte
    {

        private List<Carte> carti;

        public ControllerCarte()
        {

            carti = new List<Carte>();
            load();

        }

        public void load()
        {

            string path = Directory.GetCurrentDirectory() + @"/data/carti.txt";

            StreamReader sr = new StreamReader(path);

            string t = "";

            while((t = sr.ReadLine()) != null) {

                Carte carte = new Carte(t);
                carti.Add(carte);
            }

            sr.Close();
        }

        public void afisare()
        {
            for(int i=0;i<carti.Count;i++)
            {
                Console.WriteLine(carti[i].descriere());
            }
        }

        public void addCarte(Carte carte)
        {
            carti.Add(carte);
        }

    }
}
