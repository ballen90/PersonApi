namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

   
    class Program
    {
        class Person
        {
            public string LastName { get; set; }

            public string FirstName { get; set; }

            public string Gender { get; set; }

            public string FavoriteColor { get; set; }

            public DateTime DateOfBirth { get; set; }
        }

        class Utilities
        {
            public DateTime FormatDate(string dateInput)
            {
                DateTime parsedDate = DateTime.Parse(dateInput);
                return parsedDate;
            }

            public void DisplayInformation(List<Person> output)
            {
                for (int i = 0; i < output.Count(); i++)
                {
                   Console.WriteLine($"{output[i].LastName} {output[i].FirstName} {output[i].Gender} {output[i].FavoriteColor} {String.Format("{0:MM/dd/yyyy}", output[i].DateOfBirth)}");
                }
            }
        }

        static void Main(string[] args)
        {
            Utilities utilities = new Utilities();
            
            List<Person> detailList = new List<Person>();

            var query = from line in File.ReadLines(@"C:\Applications\New Text Document.txt")
                        let personDetail = line.Replace("|", "").Replace(",", "").Replace("  ", " ").Split(' ')
                        select new Person
                        {
                            LastName = personDetail[0],
                            FirstName = personDetail[1],
                            Gender = personDetail[2],
                            FavoriteColor = personDetail[3],
                            DateOfBirth = utilities.FormatDate(personDetail[4])
                        };
            
            foreach(var line in query)
            {
                detailList.Add(line);
            }

            Console.WriteLine("Output 1:");

            var output = detailList.OrderBy(x => x.Gender)
                .ThenBy(x => x.LastName)
                .ToList();

            utilities.DisplayInformation(output);

            Console.WriteLine("Output 2:");

            var output3 = detailList.OrderBy(x => x.DateOfBirth).ToList();

            utilities.DisplayInformation(output3);

            Console.WriteLine("Output 3:");

            var output2 = detailList.OrderBy(x => x.LastName)
                .ToList();

            utilities.DisplayInformation(output2);

        }
    }
}
