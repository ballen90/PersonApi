namespace WebApplication2.DataLayer
{
    using System;
    using System.Collections.Generic;
    using DataLayerInterfaces;
    using System.IO;

    public class PersonDataLayer : IPersonDataLayer
    {
        /// <summary>
        /// Creates a new record to add to the .txt file.
        /// </summary>
        /// <param name="record">text record</param>
        /// <returns>A string</returns>
        public string CreateRecord(string record)
        {
            try
            {
                File.WriteAllText(@"C:\Applications\New Text Document.txt", record);

                return "File added successfully";
            }
            catch(Exception e)
            {
                throw new Exception("Unable to add file.", e); 
            }
        }

        /// <summary>
        /// Reads data from the .txt file.
        /// </summary>
        /// <returns>IEnumerable string</returns>
        public IEnumerable<string> GetTextData()
        {
            try
            {
                var data = File.ReadLines(@"C:\Applications\New Text Document.txt");
                return data;
            }
            catch (Exception e)
            {
                throw new Exception("Unable to read file.", e);
            }
        }
    }
}
