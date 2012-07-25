using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Saimoe.Models;
using Saimoe.Infra;

namespace Saimoe.Tests
{


    /// <summary>
    ///This is a test class for ContestantGroupingServiceTest and is intended
    ///to contain all ContestantGroupingServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContestantGroupingServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for RandomGrouping
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void RandomGroupingTest()
        {
            var contestants = new List<ContestantRegistration> { }; // TODO: Initialize to an appropriate value
            for (var i = 0; i < 95; i++)
            {
                contestants.Add(new ContestantRegistration { ActingCute = "A " + i });
            }

            int groupQuantity = 10; // TODO: Initialize to an appropriate value
            IEnumerable<IEnumerable<ContestantRegistration>> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<IEnumerable<ContestantRegistration>> actual;
            actual = contestants.RandomGrouping(groupQuantity);

            Assert.IsTrue(!actual.Any(g => g.Count() > 10 || g.Count() < 9));
        }
    }
}
