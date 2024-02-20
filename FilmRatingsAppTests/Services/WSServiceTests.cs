using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmRatingsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRatingsApp.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void WSServiceTest()
        {
            //Arrange
            WSService service = new WSService("https://localhost:7164/api/");

            Assert.IsNotNull(service);
        }

        [TestMethod()]
        public void GetUtilisateursTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUtlisateurByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUtlisateurByEmailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostUtilisateurTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutUtilisateurTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteUtilisateurTest()
        {
            Assert.Fail();
        }
    }
}