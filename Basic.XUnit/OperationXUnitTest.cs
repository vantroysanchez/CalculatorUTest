using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Basic
{    
    public class OperationXUnitTest
    {
        /// <summary>
        /// Este metodo se encarga de probar la sumatoria de dos numeros enteros.
        /// </summary>
        [Fact]
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
            Assert.Equal(total, result);

        }

        /// <summary>
        /// Este metodo valida si al ingresar un numero es impar.
        /// </summary>
        [Theory]
        [InlineData(7, false)]
        [InlineData(13, false)]
        [InlineData(5, false)]
        public void ValidateOddNumber(int number, bool expectedResult)
        {
            //1. Arrange
            Operation operation = new();

            //2. Act
            var result = operation.Even(number);

            //3. Assert
            Assert.Equal(expectedResult, result);            
        }

        /// <summary>
        /// Este metodo valida si al ingresar un numero es par.
        /// </summary>
        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(10)]
        public void ValidateEvenNumber(int number)
        {
            //1. Arrange
            Operation operation = new();

            //2. Act
            bool isEven = operation.Even(number);

            //3. Assert
            Assert.True(isEven);            
        }

        /// <summary>
        /// Este metodo se encarga de probar la sumatoria de dos numeros decimales.
        /// </summary>
        [Theory]
        [InlineData(24.7, 25.2)]
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
            Assert.Equal(total, result);

        }

        [Fact]        
        public void OddNumbers()
        {
            Operation operation = new();

            List<int> oddNumbersExpect = new() { 5, 7, 9 };

            List<int> result = operation.OddNumbers(5, 10);

            Assert.Multiple(() =>
            {
                Assert.Equal(oddNumbersExpect, result);                
                Assert.Contains(5, result);                
                Assert.NotEmpty(result);
                Assert.Equal(3, result.Count);
                Assert.DoesNotContain(100, result);
                Assert.Equal(result.OrderBy(x => x), result);                
            });         

        }
    }
}
