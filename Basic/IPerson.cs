using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public interface IPerson
    {
        string Name { get; }
        int Discount { get; set; }
        int OrderTotal { get; set; }
        bool IsPremium { get; set; }
        string FullName(string name, string lastName);
        PersonType PersonDetails();
    }
}
