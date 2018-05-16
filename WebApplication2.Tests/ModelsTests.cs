namespace WebApplication2.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class ModelsTests
    {
        private readonly string FIRST_NAME = "Michael";
        private readonly string LAST_NAME = "Jackson";
        private readonly string GENDER = "Michael Jackson";
        private readonly string FAVORITE_COLOR = "Maroon";
        private readonly DateTime DATE_OF_BIRTH = new DateTime(1958, 08, 29);

        [TestMethod]
        public void TestPersonGetterAndSetterValuesNull()
        {
            // Arrange
            var result1 = new Person();

            // Assert
            Assert.IsNull(result1.FirstName, string.Empty);
            Assert.IsNull(result1.LastName, string.Empty);
            Assert.IsNull(result1.Gender, string.Empty);
            Assert.IsNull(result1.FavoriteColor, string.Empty);
            Assert.AreEqual(result1.DateOfBirth, DateTime.MinValue);
        }

        [TestMethod]
        public void TestPersonGetterAndSetterValuesNotNull()
        {
            // Arrange
            var result1 = new Person()
            {
                FirstName = FIRST_NAME,
                LastName = LAST_NAME,
                Gender = GENDER,
                FavoriteColor = FAVORITE_COLOR,
                DateOfBirth = DATE_OF_BIRTH
            };

            // Assert
            Assert.AreEqual(result1.FirstName, FIRST_NAME);
            Assert.AreEqual(result1.LastName, LAST_NAME);
            Assert.AreEqual(result1.Gender, GENDER);
            Assert.AreEqual(result1.FavoriteColor, FAVORITE_COLOR);
            Assert.AreEqual(result1.DateOfBirth, DATE_OF_BIRTH);
        }
    }
}
