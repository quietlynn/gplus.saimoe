using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Saimoe.Infra;
using Saimoe.Models;
using Saimoe.Core;
using Saimoe.Repository;

namespace Saimoe.Tests
{
    /// <summary>
    /// Summary description for ContestantServiceTest
    /// </summary>
    [TestClass]
    public class ContestantRepositoryTest
    {
        public ContestantRepositoryTest()
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
        public void TestUpdateContestant()
        {

            var gPlusId = "107711263447378891785";
            var expect = new Profile
            {
                Id = 2,
                Tagline = "ttt" + DateTime.Now.Minute,
                Interest = "iii" + DateTime.Now.Minute,
                Characteristic = "ccc" + DateTime.Now.Minute,
                RegistrationPost = "rrr" + DateTime.Now.Minute,
                ActingCute = "aaa" + DateTime.Now.Minute,
                JoinedDate = DateTime.Now
            };

            var repository = new ContestantRepository();
            repository.UpdateProfile(expect);

            var actual = repository.GetContestant(gPlusId).Profile;
            Assert.AreEqual(expect.Tagline, actual.Tagline);
            Assert.AreEqual(expect.ActingCute, actual.ActingCute);
            Assert.AreEqual(expect.Interest, actual.Interest);
            Assert.AreEqual(expect.Characteristic, actual.Characteristic);
            Assert.AreEqual(expect.RegistrationPost, actual.RegistrationPost);
            Assert.AreEqual(expect.JoinedDate, actual.JoinedDate);
        }
    }
}
