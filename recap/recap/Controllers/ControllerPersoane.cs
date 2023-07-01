using recap.models;
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

        public ControllerPersoane() { 
        
            persoane = new List<Persoana>();
            load();
        
        }

        public void load()
        {

            string path = Directory.GetCurrentDirectory()+@"/data/persoane.txt";
            
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

    }
}
