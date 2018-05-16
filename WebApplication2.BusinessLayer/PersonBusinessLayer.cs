namespace WebApplication2.BusinessLayer
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WebApplication2;
    using WebApplication2.BusinessLayer.Interfaces;
    using WebApplication2.DataLayerInterfaces;

    public class PersonBusinessLayer : IPersonBusinessLayer
    {
        private readonly IPersonDataLayer personDataLayer;

        public PersonBusinessLayer(IPersonDataLayer personDataLayer)
        {
            this.personDataLayer = personDataLayer;
        }

        public string CreateRecord(string record)
        {
            var modifiedRecord = this.removeDelimiters(record).ToString();

            return this.personDataLayer.CreateRecord(record);
        }

        public List<Person> GetRecordsSortedByName()
        {
            var data = this.personDataLayer.GetTextData();

            var modifiedData = this.ModifyTextFileData(data);

            return modifiedData.OrderByDescending(x => x.LastName)
                .ToList();
        }

        public List<Person> GetRecordSortedByBirthdate()
        {
            var data = this.personDataLayer.GetTextData();

            var modifiedData = this.ModifyTextFileData(data);

            return modifiedData.OrderBy(x => x.DateOfBirth).ToList();
        }

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
                            //let personDetail = utilities.RemoveSpecialCharacters(line).Replace("  ", " ").Split(' ')
                        let personDetail = removeDelimiters(line)
                        //line.Replace("|", "").Replace(",", "").Replace("  ", " ").Split(' ')
                        select new Person
                        {
                            LastName = personDetail[0],
                            FirstName = personDetail[1],
                            Gender = personDetail[2],
                            FavoriteColor = personDetail[3],
                            DateOfBirth = this.FormatDate(personDetail[4])
                        };
            return query;
        }

        public DateTime FormatDate(string dateInput)
        {
            DateTime parsedDate = DateTime.Parse(dateInput);
            return parsedDate;
        }

        public string[] removeDelimiters (string text)
        {
           var modifiedLine = text.Replace("|", "").Replace(",", "").Replace("  ", " ").Split(' ');
            return modifiedLine;
        }
    }
}
