namespace WebApplication2.BusinessLayer.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IPersonBusinessLayer
    {
        /// <summary>
        /// Creates a new record to be saved to txt file.
        /// </summary>
        /// <param name="record">A text record</param>
        /// <returns>string</returns>
        string CreateRecord(string record);

        /// <summary>
        /// Gets records sorted by last name, descending.
        /// </summary>
        /// <returns>List of person object</returns>
        List<Person> GetRecordsSortedByLastNameDescending();

        /// <summary>
        /// Gets recorts sorted by birt date, ascending.
        /// </summary>
        /// <returns>List of person object</returns>
        List<Person> GetRecordsSortedByBirthdateAscending();

        /// <summary>
        /// Gets records sorted by gender (females before males) then by last name ascending.
        /// </summary>
        /// <returns>List of person object</returns>
        List<Person> GetRecordSortedByGender();

        /// <summary>
        /// Removes select delimiters from a string
        /// </summary>
        /// <param name="text">A string</param>
        /// <returns>string array</returns>
        string[] RemoveDelimiters(string line);
    }
}
