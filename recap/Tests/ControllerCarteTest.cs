using recap.Controllers;
using recap.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ControllerCarteTest
    {

        private ControllerCarte underTest;


        private string path = @"/data/carti_test.txt";

        [Fact]
        public void Add_WhenCalled_ReturnsCorrectSum()
        {
            // Given

            underTest = new ControllerCarte(path);

            Carte carte1 = new Carte(1,"test1","autor1",1890);
            Carte carte2 = new Carte(2,"test2","autor2",1900);
            Carte carte3 = new Carte(3,"test3","autor3",1930);
            Carte carte4 = new Carte(4, "test4", "autor4", 2000);
            Carte carte5 = new Carte(5, "test5", "autor5", 2001);


            underTest.addCarte(carte1);
            underTest.addCarte(carte2);
            underTest.addCarte(carte3);
            underTest.addCarte(carte4);
            underTest.addCarte(carte5);

            //  When
            Carte carte6 = new Carte(6, "test5", "autor5", 2002);

            underTest.addCarte(carte6);

            // Then

            Carte carte7 = new Carte(7, "test7", "autor7", 2000);

            List<Carte> carti = underTest.getCarti();

            // Assert.True(underTest.verificare(carte6));


            Assert.Equal("test1", underTest.findById(1).Name);

            Assert.Null(underTest.findById(6));

            Assert.Equal("test2",underTest.findById(2).Name);

            Assert.Equal("autor3", underTest.findById(3).Autorul);

            Assert.Equal(2000,underTest.findById(4).Anul);

            Assert.NotEqual(carte6.Anul, carte5.Anul);

        }

        [Fact]
        public void Delete_WhenCalled_LessThan2000()
        {
            //Given
            underTest = new ControllerCarte(path);

            Carte carte1 = new Carte(1, "test1", "autor1", 1890);
            Carte carte2 = new Carte(2, "test2", "autor2", 1900);
            Carte carte3 = new Carte(3, "test3", "autor3", 1930);
            Carte carte4 = new Carte(4, "test4", "autor4", 2005);
            Carte carte5 = new Carte(5, "test5", "autor5", 2001);

            underTest.addCarte(carte1);
            underTest.addCarte(carte2);
            underTest.addCarte(carte3);
            underTest.addCarte(carte4);
            underTest.addCarte(carte5);

            //When
            underTest.deleteCarte(3);
            underTest.deleteCarte(1);

            //Then
            Assert.Null(underTest.findById(3));

            Assert.Null(underTest.findById(1));

            Assert.False(underTest.verificareAn(carte4));

        }

        [Theory]
        [InlineData(1,"test1","Mihai")]
        [InlineData(4,"Ion","autor4")]
        [InlineData(3,"Harap-Alb","Ion")]
        public void Update_WhenCalled_GreaterThan2000(int id,string nume,string autor)
        {

            //Given
            underTest = new ControllerCarte(path);

            Carte carte1 = new Carte(1, "test1", "autor1", 2001);
            Carte carte2 = new Carte(2, "test2", "autor2", 2010);
            Carte carte3 = new Carte(3, "test3", "autor3", 2020);
            Carte carte4 = new Carte(4, "test4", "autor4", 2005);
            Carte carte5 = new Carte(5, "test5", "autor5", 2001);

            underTest.addCarte(carte1);
            underTest.addCarte(carte2);
            underTest.addCarte(carte3);
            underTest.addCarte(carte4);
            underTest.addCarte(carte5);

            int peste = 1;

            //When

            int semn = 0;
            if (underTest.findById(id).Anul >= 2000)
            {
                semn = 1;
            }

            Carte oldCarte = new Carte(underTest.findById(id).toSave());

            underTest.setCarte(id, nume, autor);
            underTest.update();

            //Then

            Assert.NotEqual(oldCarte, underTest.findById(id));
            Assert.Equal(semn, peste);


        }

    }
}
