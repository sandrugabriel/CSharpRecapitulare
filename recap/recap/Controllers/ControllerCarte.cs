using recap.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recap.Controllers
{
    public class ControllerCarte
    {

        private List<Carte> carti;

        private string path;

        public ControllerCarte(string path)
        {

            carti = new List<Carte>();
            this.path = path;
            load();
           
        }

        public void load()
        {
          //  Console.WriteLine(Directory.GetCurrentDirectory() + path);
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + path);
            
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

        public bool verificare(Carte carte)
        {

            for (int i = 0; i < carti.Count; i++)
            {

                if (carti[i].Name.Equals(carte.Name) && carti[i].Autorul.Equals(carte.Autorul))
                {
                    return false;

                }

            }

            return true;
        }

        public void addCarte(Carte carte)
        {
          if(verificare(carte)) carti.Add(carte);
        }

        public List<Carte> getCarti()
        {
            return carti;
        }

        public Carte findById(int  id)
        {

            for(int i=0;i<carti.Count;i++) {

                if (carti[i].Id == id) return carti[i];
            }

            return null;
        }

        public int pozId(int id)
        {
            for(int i = 0; i < carti.Count;i++) {
                if (carti[i].Id == id) { return i; }
            }
            return -1;
        }

        public void stergere(int id)
        {
            int p = pozId(id);
            carti.RemoveAt(p);

        }

        public string toSaveFisier()
        {

            string t = "";

            for(int i = 0; i < carti.Count; i++)
            {
                t += carti[i].toSave() + "\n";
            }

            return t;
        }

        public bool verificareAn(Carte carte)
        {

            if (carte.Anul < 2000) return true;
            return false;
        }

        public void deleteCarte(int id)
        {
            Carte carte = findById(id);
            if(verificareAn(carte))
            {
                this.stergere(id);

                StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + path);
                streamWriter.Write(this.toSaveFisier());
                streamWriter.Close();

            }
          
        }

        public void setCarte(int id, string nume, string autor)
        {

            for(int i = 0; i < carti.Count; i++)
            {
                if(id == carti[i].Id)
                {
                    carti[i].Name = nume;
                    carti[i].Autorul = autor;
                    return;
                }
            }

        }

        public void update()
        {

            StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + path);
            streamWriter.Write(this.toSaveFisier());

            streamWriter.Close();

        }

    }
}
