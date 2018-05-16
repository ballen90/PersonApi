namespace WebApplication2.BusinessLayer
{
    using Models;
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
            var modifiedRecord = Utilities.RemoveSpecialCharacters(record);

            return this.personDataLayer.CreateRecord(record);
        }

        public List<Person> GetRecordsSortedByName(string record)
        {
            var data = this.personDataLayer.GetTextData();

            var modifiedData = this.ModifyTextFileData(data);

            return modifiedData.OrderBy(x => x.LastName)
                .ToList();
        }

        public List<Person> GetRecordSortedByBirthdate(string record)
        {
            var data = this.personDataLayer.GetTextData();

            var modifiedData = this.ModifyTextFileData(data);

            return modifiedData.OrderBy(x => x.DateOfBirth).ToList();
        }

        public List<Person> GetRecordSortedByGender(string record)
        {
            var data = this.personDataLayer.GetTextData();

            var modifiedData = this.ModifyTextFileData(data);

            return modifiedData.OrderBy(x => x.Gender)
                .ThenBy(x => x.LastName)
                .ToList();
        }

        private IEnumerable<Person> ModifyTextFileData(IEnumerable<string> data)
        {
            var query = from line in data
                            //let personDetail = utilities.RemoveSpecialCharacters(line).Replace("  ", " ").Split(' ')
                        let personDetail = line.Replace("|", "").Replace(",", "").Replace("  ", " ").Split(' ')
                        select new Person
                        {
                            LastName = personDetail[0],
                            FirstName = personDetail[1],
                            Gender = personDetail[2],
                            FavoriteColor = personDetail[3],
                            DateOfBirth = Utilities.FormatDate(personDetail[4])
                        };
            return query;
        }
    }
}
