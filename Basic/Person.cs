using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public class Person: IPerson
    {
        public string Name { get; set; }
        public int Discount { get; set; }
        public int OrderTotal { get; set; }

        public bool IsPremium { get; set; }

        public Person()
        {
            IsPremium = false;
            Discount = 10;
        }

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
            return new PremiumPerson();

        }
    }

    public class PersonType { }
    public class PremiumPerson : PersonType { }
    public class BasicPerson: PersonType { }

}
