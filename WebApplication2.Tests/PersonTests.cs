using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.BusinessLayer;
using WebApplication2.BusinessLayer.Interfaces;
using WebApplication2.DataLayerInterfaces;
using WebApplication2.Models;

namespace WebApplication2.BusinessLayer.Tests
{
    
    [TestClass()]
    public class PersonTests
    {
        private IPersonBusinessLayer personBusinessLayer;
        private Mock<IPersonDataLayer> moq_personDataLayer;

        private readonly string DUMMY_RECORD1 = "Johnson | Brenda | Female | Green | 03/17/1989";

        [TestInitialize]
        public void Initialize()
        {
            moq_personDataLayer = new Mock<IPersonDataLayer>();

            moq_personDataLayer.Setup(dl => dl.CreateRecord(It.IsAny<string>()))
                .Returns("Record created successfully");

            moq_personDataLayer.Setup(m => m.GetTextData())
                .Returns(new string[] { "Allen, Michael, Male, Blue, 08/21/1991",
                    "Allen | Brandon | Male | Red | 03/17/1990",
                    "Rosier Lori Female Pink 12/10/1968"
                });

            personBusinessLayer = new PersonBusinessLayer(moq_personDataLayer.Object); 
        }

        [TestMethod()]
        public void CreateRecordTest()
        {
            var result1 = personBusinessLayer.CreateRecord(DUMMY_RECORD1);

            Assert.AreNotEqual(result1, null);
        }

        [TestMethod()]
        public void GetRecordsSortedByLastNameDescending()
        {
            var result = personBusinessLayer.GetRecordsSortedByLastNameDescending();

            Assert.AreNotEqual(result.Count, null);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.Count == 3);
            Assert.AreEqual(result[0].FavoriteColor, "Blue");
        }

        [TestMethod()]
        public void GetRecordsSortedByBirthdateAscending()
        {
            var result = personBusinessLayer.GetRecordsSortedByBirthdateAscending();

            Assert.AreNotEqual(result.Count, null);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.Count == 3);
            Assert.AreEqual(result[1].FavoriteColor, "Red");
        }

        [TestMethod()]
        public void GetRecordSortedByGender()
        {
            var result = personBusinessLayer.GetRecordSortedByGender();

            Assert.AreNotEqual(result.Count, null);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.Count == 3);
            Assert.AreEqual(result[2].FavoriteColor, "Pink");
        }


    }
}