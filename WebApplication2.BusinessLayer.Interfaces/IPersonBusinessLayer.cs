namespace WebApplication2.BusinessLayer.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IPersonBusinessLayer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        string CreateRecord(string record);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        List<Person> GetRecordsSortedByName(string order);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        List<Person> GetRecordSortedByBirthdate(string order);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        List<Person> GetRecordSortedByGender(string order);
    }
}
