namespace WebApplication2.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataLayerInterfaces;
    using System.IO;

    public class PersonDataLayer : IPersonDataLayer
    {
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
