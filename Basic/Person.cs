using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public class Person
    {
        public string Name { get; set; }
        public int Discount = 10;
        public int OrderTotal { get; set; }
        public string FullName(string name, string lastName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name is required");
            }

            Discount = 30;
            Name = $"{name} {lastName}";
            
            return Name;
        }

        public PersonType PersonDetails()
        {
            if (OrderTotal < 500)
            {
                return new BasicPerson();
            }
            return new PremiunPerson();

        }
    }

    public class PersonType { }
    public class PremiunPerson : PersonType { }
    public class BasicPerson: PersonType { }

}
