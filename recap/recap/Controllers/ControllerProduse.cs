using recap.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recap.Controllers
{
    public class ControllerProduse
    {

        private List<Produs> produse;
        private string path;
        public ControllerProduse(string _path)
        {

            produse = new List<Produs>();
            path = _path;
            load();

        }

        public void load() {
        
        
            StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + path);
            string t;

            while((t = streamReader.ReadLine()) != null)
            {
                if (!t.Equals(""))
                {
                    Produs produs = new Produs(t);
                    produse.Add(produs);
                }
            }

            streamReader.Close();
        }

        public Produs findById(int id)
        {

            for(int i=0;i<produse.Count;i++)
            {
                if (produse[i].Id == id) return produse[i];
            }

            return null;
        }

        public bool verificare(Produs produs)
        {

            for(int i = 0; i < produse.Count; i++)
            {
                if (produse[i].Name.Equals(produs.Name)) return false;
            }

            return true;
        }

        public void addProdus(Produs produs)
        {
           if(verificare(produs)) produse.Add(produs);
        }

        public string toSaveFisier()
        {

            string t="";

            for(int i = 0;i<produse.Count;i++)
            {
                t += produse[i].toSave() + "\n";
            }

            return t;
        }

        public int pozId(int id)
        {
            for(int i = 0; i < produse.Count; i++)
            {
                if (produse[i].Id == id) return i;
            }

            return -1;
        }

        public void stergere(int id)
        {
            produse.RemoveAt(pozId(id));
        }

        public void deleteProdus(int id)
        {

            if(DateTime.Now >= findById(id).DataExpirare)
            {

                this.stergere(id);

                StreamWriter streamWriter = new StreamWriter(Directory.GetCurrentDirectory() + path);
                streamWriter.Write(this.toSaveFisier());
                streamWriter.Close();
            }


        }
    }
}
