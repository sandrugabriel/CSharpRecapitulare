using recap.Controllers;
using recap.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ControllerMasiniTest
    {

        private ControllerMasini underMasini;

        public ControllerMasiniTest()
        {

        }

        private string path2 = @"/data/masini_test.txt";

        [Fact]
        public void Add_WhenCalled_DifCars()
        {

            //Given

            underMasini = new ControllerMasini(path2);

            Masina masina1 = new Masina(1, "test1", "model1", 10000, 90000);
            Masina masina2 = new Masina(2, "test2", "model2", 1, 150000);
            Masina masina3 = new Masina(3, "test3", "model3", 50000, 90000);
            Masina masina4 = new Masina(4, "test4", "model4", 1, 150000);
            Masina masina5 = new Masina(5, "test5", "model5", 250000, 6000);

            //When

            underMasini.addMasina(masina1);
            underMasini.addMasina(masina2);
            underMasini.addMasina(masina3);
            underMasini.addMasina(masina4);
            underMasini.addMasina(masina5);
            int dim = 5;
            //Then
            Masina masina6 = new Masina(5, "test6", "model6", 250000, 6000);

            underMasini.addMasina(masina6);
            dim++;

            Assert.NotNull(underMasini.findbyId(5));
            Assert.Equal("test1", underMasini.findbyId(1).Marca);
            Assert.NotEqual(dim,underMasini.getMasini().Count-1);
            Assert.Null(underMasini.findbyId(6));
            Assert.False(underMasini.verificare(masina6));  
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        public void Delete_WhenCalled_LessThan20000(int id)
        {
            //Given
            underMasini = new ControllerMasini(path2);

            Masina masina1 = new Masina(1, "test1", "model1", 10000, 9000);
            Masina masina2 = new Masina(2, "test2", "model2", 1, 150000);
            Masina masina3 = new Masina(3, "test3", "model3", 50000, 90000);
            Masina masina4 = new Masina(4, "test4", "model4", 1, 150000);
            Masina masina5 = new Masina(5, "test5", "model5", 250000, 6000);

            //When

            underMasini.addMasina(masina1);
            underMasini.addMasina(masina2);
            underMasini.addMasina(masina3);
            underMasini.addMasina(masina4);
            underMasini.addMasina(masina5);

            underMasini.delete(id);

            //Then

            Assert.Null(underMasini.findbyId(id));

        }

        

    }
}
