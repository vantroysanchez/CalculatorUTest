namespace Basic.MSTest
{
    [TestClass]
    public class OperationMSTest
    {
        /// <summary>
        /// Este metodo se encarga de probar la sumatoria de dos numeros enteros.
        /// </summary>
        [TestMethod]
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
    }
}