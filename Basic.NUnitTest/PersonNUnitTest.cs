using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    [TestFixture]
    public class PersonNUnitTest
    {
        [Test]
        [TestCase("Vantroy", "Sanchez")]
        public void FullName(string name, string lastName)
        {
            //1. Arrage
            Person person = new();
            string fullName = $"{name} {lastName}";

            //2. Act
            string result = person.FullName(name,lastName);

            //3. Assert
            Assert.Multiple(() =>
            {
                Assert.That(fullName, Is.EqualTo(result));
                Assert.That(fullName, Does.Contain("troy").IgnoreCase);
                Assert.That(fullName, Does.StartWith("V").IgnoreCase);
            });
            
        }
    }
}
