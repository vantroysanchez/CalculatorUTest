using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Basic
{    
    public class PersonXUnitTest
    {
        private Person person;
        
        public PersonXUnitTest()
        {
            person = new Person();
        }

        [Theory]
        [InlineData("Vantroy", "Sanchez")]
        public void FullName(string name, string lastName)
        {
            //1. Arrage            
            string fullName = $"{name} {lastName}";

            //2. Act
            string result = person.FullName(name,lastName);

            //3. Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(fullName, result);
                Assert.Contains("troy", fullName);
                Assert.StartsWith("V",fullName);
                Assert.EndsWith("z",fullName);
            });            
        }

        [Fact]
        public void EvaluationDiscount()
        {
            int discount = person.Discount;

            Assert.InRange(discount, 5,24);
        }

        [Fact]
        public void CreateFullName()
        {
            person.FullName("Troy", "");

            Assert.NotNull(person.Name);
            Assert.False(string.IsNullOrEmpty(person.Name));
        }

        [Fact]
        public void PersonNameBlank()
        {
            var exception = Assert.Throws<ArgumentException>(() => person.FullName("", "Sanchez"));

            Assert.Equal("The name is required", exception.Message);

            Assert.Throws<ArgumentException>(() => person.FullName("", "Sanchez"));
        }

        [Fact]
        public void BasicPersonDetails()
        {
            person.OrderTotal = 150;
            var result = person.PersonDetails();

            //Assert.That(result, Is.TypeOf<BasicPerson>());
            Assert.IsType<BasicPerson>(result);
        }

        [Fact]
        public void PremiunPersonDetails()
        {
            person.OrderTotal = 750;
            var result = person.PersonDetails();

            //Assert.That(result, Is.TypeOf<PremiumPerson>());
            Assert.IsType<PremiumPerson>(result);
        }
    }
}
