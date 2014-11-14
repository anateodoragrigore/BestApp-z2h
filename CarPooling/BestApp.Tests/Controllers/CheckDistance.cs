using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Spatial;
//using System.Data.Entity.Spatial;

namespace BestApp.Tests.Controllers
{
    /// <summary>
    /// Summary description for CheckDistance
    /// </summary>
    [TestClass]
    public class CheckDistance
    {
        public CheckDistance()
        {
            // TODO: Add constructor logic here
        }
        private TestContext testContextInstance;
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

       
        [TestMethod]
        public void TestMethod2()
        {
            var a = DbGeography.PointFromText(string.Format("POINT(44.413828 26.15589)"), 4326);
            var b = DbGeography.PointFromText(string.Format("POINT(44.415838 26.156795)"), 4326);

            var result = a.Distance(b);
            Assert.AreEqual(2, result);
        }

    }
}
