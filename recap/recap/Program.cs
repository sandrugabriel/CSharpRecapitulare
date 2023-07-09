using recap.Controllers;
using recap.models;

internal class Program
{
    private static void Main(string[] args)
    {

        Persoana persoana1 = new Persoana("1|Sandru|Gabi|17|1,80");
        Persoana persoana2 = new Persoana("2|Ana|Maria|15|1,70");
        Persoana persoana3 = new Persoana("3|Dan|Alex|14|1,69");

        Persoana persoana4 = persoana1;

        persoana1 = persoana2;

        persoana1.Varsta = 23;

        //  Console.WriteLine("Persoana1: " + persoana1.descriere() + "\nPersoana2: " + persoana2.descriere() + "\nPersoana3: " + persoana3.descriere() + "\nPersoana4: " + persoana4.descriere());
/*
        ControllerPersoane controllerPersoane = new ControllerPersoane();
        if (controllerPersoane.verificare(persoana1))
        {
            controllerPersoane.addPersoana(persoana1);
        }
        else
        {
            Console.WriteLine("Introduceti alt nume si prenume");
        }*/

      //  ControllerMasini controllerMasini = new ControllerMasini();
       // controllerMasini.afisare();

     //   ControllerCarte controllerCarte = new ControllerCarte();
       // controllerCarte.afisare();


    }
}