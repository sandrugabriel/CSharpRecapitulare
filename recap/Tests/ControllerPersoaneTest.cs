using recap.Controllers;
using recap.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ControllerPersoaneTest
    {

        private ControllerPersoane underPersoane;
        private string path = @"/data/persoane_test.txt";

        [Fact]
        public void Add_WhenCalled_DifName()
        {

            //Given
            underPersoane = new ControllerPersoane(path);

            Persoana persoana1 = new Persoana(1, "test1", "pre1", 10, 1.60);
            Persoana persoana2 = new Persoana(2, "test2", "pre2", 25, 2.00);
            Persoana persoana3 = new Persoana(3, "test3", "pre3", 18, 1.80);
            Persoana persoana4 = new Persoana(4, "test4", "pre4", 20, 1.90);

            //When
         
            underPersoane.addPersoana(persoana1);
            underPersoane.addPersoana(persoana2);
            underPersoane.addPersoana(persoana3);
            underPersoane.addPersoana(persoana4);

            int dim = 4;

            //Then

            Persoana persoana5 = new Persoana(5, "test4", "pre4", 20, 1.90);
            dim++;

            Assert.NotEqual(dim, underPersoane.getPersoane().Count);
            Assert.Null(underPersoane.findById(5));
            Assert.Equal("test1", underPersoane.findById(1).Nume);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Delete_WhenCalled_LessThan18(int id)
        {

            //Given
            underPersoane = new ControllerPersoane(path);

            Persoana persoana1 = new Persoana(1, "test1", "pre1", 10, 1.60);
            Persoana persoana2 = new Persoana(2, "test2", "pre2", 25, 2.00);
            Persoana persoana3 = new Persoana(3, "test3", "pre3", 18, 1.80);
            Persoana persoana4 = new Persoana(4, "test4", "pre4", 20, 1.90);

            //When

            underPersoane.addPersoana(persoana1);
            underPersoane.addPersoana(persoana2);
            underPersoane.addPersoana(persoana3);
            underPersoane.addPersoana(persoana4);

            underPersoane.delete(id);

            //Then

            Assert.Null(underPersoane.findbyId(id));



        }


    }
}
