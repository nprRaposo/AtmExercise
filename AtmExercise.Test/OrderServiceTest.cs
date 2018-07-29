using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AtmExercise.Data;
using AtmExercise.Model;
using AtmExercise.Model.Exception;
using AtmExercise.Service;
using System.Collections.Generic;

namespace AtmExercise.Test
{
    [TestClass]
    public class OrderServiceTest
    {
        private Mock<IService<CreditCard>> _ccService;

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void TestMethod()
        {
        }
    }
}
