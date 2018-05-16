namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person
    {
        /// <summary>
        /// Gets or sets a value indicating the last name of a person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the first name of a person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the gender of a person.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the favorite color of a person.
        /// </summary>
        public string FavoriteColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the date of birth of a person.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
