namespace WebApplication2.BusinessLayer
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApplication2.BusinessLayer.Interfaces;
    using WebApplication2.DataLayerInterfaces;

    public class PersonBusinessLayer : IPersonBusinessLayer
    {
        private readonly IPersonDataLayer personDataLayer;

        public PersonBusinessLayer(IPersonDataLayer personDataLayer)
        {
            this.personDataLayer = personDataLayer;
        }

        /// <summary>
        /// Creates a new record to add to the .txt file.
        /// </summary>
        /// <param name="record">text record</param>
        /// <returns>A string</returns>
        public string CreateRecord(string record)
        {
            var modifiedRecord = this.RemoveDelimiters(record);

            return this.personDataLayer.CreateRecord(record);
        }

        /// <summary>
        /// Gets records sorted by last name, descending.
        /// </summary>
        /// <returns></returns>
        public List<Person> GetRecordsSortedByLastNameDescending()
        {
            var data = this.personDataLayer.GetTextData();

            var modifiedData = this.ModifyTextFileData(data);

            return modifiedData.OrderByDescending(x => x.LastName)
                .ToList();
        }

        /// <summary>
        /// Gets records sorted by birthdate, ascending
        /// </summary>
        /// <returns></returns>
        public List<Person> GetRecordsSortedByBirthdateAscending()
        {
            var data = this.personDataLayer.GetTextData();

            var modifiedData = this.ModifyTextFileData(data);

            return modifiedData.OrderBy(x => x.DateOfBirth).ToList();
        }

        /// <summary>
        /// Gets records sorted by gender (females before males) then by last name ascending.
        /// </summary>
        /// <returns>A list of person object</returns>
        public List<Person> GetRecordSortedByGender()
        {
            var data = this.personDataLayer.GetTextData();

            var modifiedData = this.ModifyTextFileData(data).ToList();

            return modifiedData.OrderBy(x => x.Gender)
                    .ThenBy(x => x.LastName)
                    .ToList();
        }

        private IEnumerable<Person> ModifyTextFileData(IEnumerable<string> data)
        {
            var query = from line in data
                        let personDetail = RemoveDelimiters(line)
                        select new Person
                        {
                            LastName = personDetail[0],
                            FirstName = personDetail[1],
                            Gender = personDetail[2],
                            FavoriteColor = personDetail[3],
                            DateOfBirth = DateTime.Parse(personDetail[4])
                        };
            return query;
        }

        /// <summary>
        /// Removes select delimiters from a string
        /// </summary>
        /// <param name="text">A string</param>
        /// <returns>string array</returns>
        public string[] RemoveDelimiters (string text)
        {
           var modifiedLine = text.Replace("|", "").Replace(",", "").Replace("  ", " ").Split(' ');
            return modifiedLine;
        }
    }
}
