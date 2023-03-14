using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    [TestFixture]
    public class OperationNUnitTest
    {
        /// <summary>
        /// Este metodo se encarga de probar la sumatoria de dos numeros enteros.
        /// </summary>
        [Test]
        public void Add()
        {
            //1. Arrange
            //Es la introducción de la prueba. En esta parte declaramos todos los elementos que necesitamos.
            Operation operation = new();
            int number1 = 2;
            int number2 = 3;
            int total = number1 + number2;

            //2. Act
            //Es el desarrollo de la prueba. En esta parte probamos los metodos y funciones simulando el comportamiento real.

            int result = operation.Add(number1, number2);

            //3. Assert
            //Es la conclusión de la prueba. En esta parte obtenemos el resultado y validamos si es el esperado.
            Assert.AreEqual(total, result);

        }

        /// <summary>
        /// Este metodo valida si al ingresar un numero es impar.
        /// </summary>
        [Test]
        [TestCase(7, ExpectedResult = false)]
        [TestCase(13, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        public bool ValidateOddNumber(int number)
        {
            //1. Arrange
            Operation operation = new();            

            //2. Act
            return operation.Even(number);
        }

        /// <summary>
        /// Este metodo valida si al ingresar un numero es par.
        /// </summary>
        [Test]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(10)]
        public void ValidateEvenNumber(int number)
        {
            //1. Arrange
            Operation operation = new();

            //2. Act
            bool isEven = operation.Even(number);

            //3. Assert
            //Assert.IsTrue(isEven);
            Assert.That(isEven, Is.EqualTo(true));
        }

        /// <summary>
        /// Este metodo se encarga de probar la sumatoria de dos numeros decimales.
        /// </summary>
        [Test]
        [TestCase(24.7, 25.2)]
        public void AddDecimals(double number1, double number2)
        {
            //1. Arrange
            //Es la introducción de la prueba. En esta parte declaramos todos los elementos que necesitamos.
            Operation operation = new();            
            double total = number1 + number2;

            //2. Act
            //Es el desarrollo de la prueba. En esta parte probamos los metodos y funciones simulando el comportamiento real.

            double result = operation.AddDecimals(number1, number2);

            //3. Assert
            //Es la conclusión de la prueba. En esta parte obtenemos el resultado y validamos si es el esperado.
            Assert.AreEqual(total, result);

        }

        [Test]        
        public void OddNumbers()
        {
            Operation operation = new();

            List<int> oddNumbersExpect = new() { 5, 7, 9 };

            List<int> result = operation.OddNumbers(5, 10);

            Assert.Multiple(() =>
            {
                Assert.That(oddNumbersExpect, Is.EquivalentTo(result));
                Assert.AreEqual(oddNumbersExpect, result);
                Assert.That(result, Does.Contain(5));
                Assert.Contains(5, result);
                Assert.That(result, Is.Not.Empty);
                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result, Has.No.Member(70));
                Assert.That(result, Is.Ordered.Ascending);
                Assert.That(result, Is.Unique);
            });         

        }
    }
}
