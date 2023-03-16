//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Basic
//{
//    [TestFixture]
//    public class ProductXUnitTest
//    {
//        [Test]
//        public void GetPricePremium()
//        {
//            Product product = new Product
//            {
//                Price = 50
//            };

//            var result = product.GetPrice(new Person { IsPremium = true });

//            Assert.That(result, Is.EqualTo(product.Price * .8));
//        }

//        [Test]
//        public void GetPricePremiumFake()
//        {
//            Product product = new Product
//            {
//                Price = 50
//            };

//            var personFake = new Mock<IPerson>();
//            personFake.Setup(s => s.IsPremium).Returns(true);

//            var result = product.GetPrice(personFake.Object);

//            Assert.That(result, Is.EqualTo(product.Price * .8));
//        }
//    }
//}
