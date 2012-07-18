using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Saimoe.Infra;
using Saimoe.Models;
using Saimoe.Core;

namespace Saimoe.Tests
{
    /// <summary>
    /// Summary description for ContestantServiceTest
    /// </summary>
    [TestClass]
    public class ContestantServiceTest
    {
        public ContestantServiceTest()
        {
            //
            // TODO: Add constructor logic here
            //
            ModelMappingUtil.RegisterMapping();
        }

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
        public void TestAddContestant()
        {
            //
            // TODO: Add test logic here
            //
            var gPlusId = "107711263447378891785";
            var contestantRegistration = new ContestantRegistration
            {
                Tagline = "tagline",
                Interest = "interest",
                Characteristic = "chara",
                RegistrationPost = "registrationPost",
                ActingCute = "ActingCute",
            };

            var contestantService = new ContestantService();
            contestantService.AddContestant(gPlusId, contestantRegistration);
            var contestant = contestantService.GetContestant(gPlusId);
            Assert.IsNotNull(contestant);
        }
    }
}
