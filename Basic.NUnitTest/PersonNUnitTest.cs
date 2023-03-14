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
        private Person person;
        [SetUp]
        public void Setup()
        {
            person = new Person();
        }

        [Test]
        [TestCase("Vantroy", "Sanchez")]
        public void FullName(string name, string lastName)
        {
            //1. Arrage            
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

        [Test]
        public void EvaluationDiscount()
        {
            int discount = person.Discount;

            Assert.That(discount, Is.InRange(5,24));
        }

        [Test]
        public void CreateFullName()
        {
            person.FullName("Troy", "");

            Assert.IsNotNull(person.Name);
            Assert.IsFalse(string.IsNullOrEmpty(person.Name));
        }

        [Test]
        public void PersonNameBlank()
        {
            var exception = Assert.Throws<ArgumentException>(() => person.FullName("", "Sanchez"));

            Assert.AreEqual("The name is required", exception.Message);

            Assert.That(() => person.FullName("", "Sanchez"), Throws.ArgumentException);
        }

        [Test]
        public void BasicPersonDetails()
        {
            person.OrderTotal = 150;
            var result = person.PersonDetails();

            Assert.That(result, Is.TypeOf<BasicPerson>());
        }

        [Test]
        public void PremiunPersonDetails()
        {
            person.OrderTotal = 750;
            var result = person.PersonDetails();

            Assert.That(result, Is.TypeOf<PremiunPerson>());
        }
    }
}
