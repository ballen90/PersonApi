namespace WebApplication2.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using Controllers;
    using BusinessLayer.Interfaces;
    using Moq;
    using Models;
    using System.Net.Http;
    using System.Web.Http.Hosting;
    using System.Web.Http;
    using System.Net;

    [TestClass]
    public class PersonControllerTests
    {
        private PersonController personController;
        private Mock<IPersonBusinessLayer> moq_personBusinessLayer;

        private readonly string DUMMY_RECORD = "Johnson | Brenda | Female | Green | 03/17/1989";

        [TestInitialize]
        public void Initialize()
        {
            moq_personBusinessLayer = new Mock<IPersonBusinessLayer>();

            moq_personBusinessLayer.Setup(bl => bl.CreateRecord(It.IsAny<string>()))
                .Returns("File added successfully.");

            moq_personBusinessLayer.Setup(bl => bl.GetRecordSortedByGender())
                .Returns(new List<Person>
                {
                    new Person
                    {
                        LastName = "Jackson",
                        FirstName = "Michael",
                        Gender = "Male",
                        FavoriteColor = "Maroon",
                        DateOfBirth = new DateTime(1958, 8, 29)
                    },
                    new Person
                    {
                        LastName = "Brown",
                        FirstName = "James",
                        Gender = "Male",
                        FavoriteColor = "Black",
                        DateOfBirth = new DateTime(1933, 12, 25)
                    },
                    new Person
                    {
                        LastName = "Houston",
                        FirstName = "Whitney",
                        Gender = "Female",
                        FavoriteColor = "White",
                        DateOfBirth = new DateTime(1963, 08, 09)
                    }
                });

            personController = new PersonController(moq_personBusinessLayer.Object);
        }

        [TestMethod]
        public void GetRecordsSortedByGenderTest()
        {
            // Arrange
            personController.Request = new HttpRequestMessage(HttpMethod.Get, "");
            personController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            //Act
            HttpResponseMessage result1 = personController.GetRecordSortedByGender();

            // Assert
            Assert.AreNotEqual(result1, null);
            Assert.AreEqual(result1.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void GetRecordSortedByBirthdateTest()
        {
            // Arrange
            personController.Request = new HttpRequestMessage(HttpMethod.Get, "");
            personController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            //Act
            HttpResponseMessage result1 = personController.GetRecordSortedByBirthdate();

            // Assert
            Assert.AreNotEqual(result1, null);
            Assert.AreEqual(result1.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void GetRecordsSortedByLastNameTest()
        {
            // Arrange
            personController.Request = new HttpRequestMessage(HttpMethod.Get, "");
            personController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            //Act
            HttpResponseMessage result1 = personController.GetRecordsSortedByLastName();

            // Assert
            Assert.AreNotEqual(result1, null);
            Assert.AreEqual(result1.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void CreateRecordTest()
        {
            // Arrange
            personController.Request = new HttpRequestMessage(HttpMethod.Post, "");
            personController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            //Act
            HttpResponseMessage result1 = personController.CreateRecord(DUMMY_RECORD);
            HttpResponseMessage result2 = personController.CreateRecord(string.Empty);

            // Assert
            Assert.AreNotEqual(result1, null);
            Assert.AreEqual(result1.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(result2.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}
