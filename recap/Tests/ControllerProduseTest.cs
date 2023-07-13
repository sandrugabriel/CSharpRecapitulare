using recap.Controllers;
using recap.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ControllerProduseTest
    {

        private ControllerProduse underProduse;

        private string _path = @"/data/produse_test.txt";

        [Fact]
        public void Add_WhenCalled_DifNume()
        {

            underProduse = new ControllerProduse(_path);

            //Given
            Produs produs1 = new Produs(1, "Paine", 1, 9, DateTime.Parse("07/20/2023"));
            Produs produs2 = new Produs(2, "test2", 0, 20,DateTime.Parse("09/01/2023"));
            Produs produs3 = new Produs(3, "test3", 1, 12, DateTime.Parse("07/17/2023"));
            Produs produs4 = new Produs(4, "test4", 0, 2, DateTime.Parse("07/20/2025"));
            Produs produs5 = new Produs(5, "test5", 1, 5, DateTime.Parse("08/05/2023"));

            //When

            underProduse.addProdus(produs1);
            underProduse.addProdus(produs2);
            underProduse.addProdus(produs3);
            underProduse.addProdus(produs4);
            underProduse.addProdus(produs5);

            Produs produs6 = new Produs(6, "test5", 1, 25, DateTime.Parse("08/08/2023"));

            underProduse.addProdus(produs6);

            //Then

            Assert.Null(underProduse.findById(6));

            Assert.Equal("Paine", underProduse.findById(1).Name);
            Assert.Equal(0, underProduse.findById(4).TipProdus);
            Assert.Equal(DateTime.Parse("08/05/2023"), underProduse.findById(5).DataExpirare);
            Assert.NotEqual(1, underProduse.findById(2).TipProdus);

        }


        [Theory]
        [InlineData(1, "Paine", 1, 9,"07/10/2023")]
        [InlineData(2, "test2", 0, 20, "03/01/2023")]
        [InlineData(3, "test3", 1, 12, "04/10/2023")]
        [InlineData(4, "test4", 0, 2, "06/12/2023")]
        [InlineData(5, "test5", 1, 5, "01/05/2022")]

        public void Delete_WhenCalled_ProdusExpirat(int id, string name, int tipProdus, int pretul, string dataExpirare)
        {
            //Given
            underProduse = new ControllerProduse(_path);
            
            Produs produs = new Produs(id, name, tipProdus, pretul, DateTime.Parse(dataExpirare));

            //When

            underProduse.addProdus(produs);
            underProduse.deleteProdus(id);

            //Then

            Assert.Null(underProduse.findById(id));

        }



    }
}

/*

[Theory]
[InlineData(1, "Paine", 1, 9, "07/10/2023")]
public void Delete_WhenCalled_ProdusExpirat(int id, string name, int quantity, decimal price, string expiryDate)
{
    // Arrange
    underProduse = new ControllerProduse(_path);
    Produs produs = new Produs(id, name, quantity, price, DateTime.Parse(expiryDate));
    Produs produs2 = new Produs(2, "test2", 0, 20, DateTime.Parse("09/01/2023"));
    Produs produs3 = new Produs(3, "test3", 1, 12, DateTime.Parse("07/10/2023"));
    Produs produs4 = new Produs(4, "test4", 0, 2, DateTime.Parse("07/12/2023"));
    Produs produs5 = new Produs(5, "test5", 1, 5, DateTime.Parse("08/05/2023"));

    underProduse.addProdus(produs);
    underProduse.addProdus(produs2);
    underProduse.addProdus(produs3);
    underProduse.addProdus(produs4);
    underProduse.addProdus(produs5);

    // Act
    underProduse.deleteProdus(id);

    // Assert
    Assert.Null(underProduse.findById(id));
}
*/
