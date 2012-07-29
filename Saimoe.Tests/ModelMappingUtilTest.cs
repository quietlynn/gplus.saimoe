using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Saimoe.Infra;
using Saimoe.Models;
using Saimoe.Models.EF;
using AutoMapper;
using Omu.ValueInjecter;

namespace Saimoe.Tests
{
    /// <summary>
    /// Summary description for ModelMappingUtilTest
    /// </summary>
    [TestClass]
    public class ModelMappingUtilTest
    {
        public ModelMappingUtilTest()
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
        public void TestContestantRegister()
        {
            //
            // TODO: Add test logic here
            //
            var contestantRegistration = new ContestantRegistration
            {
                Tagline = "tagline",
                Interest = "interest",
                Characteristic = "chara",
                RegistrationPost = "registrationPost",
                ActingCute = "ActingCute",
                JoiningDateYear=2011,
                JoiningDateMonth=7
            };
            //var profile = new Saimoe.Models.EF.Profile();
            //profile.InjectFrom(contestantRegistration);

            var profile = Mapper.Map<ContestantRegistration, Saimoe.Models.EF.Profile>(contestantRegistration);

            var registration = Mapper.Map<Saimoe.Models.EF.Profile, ContestantRegistration>(profile);
  
            Assert.AreEqual(contestantRegistration.ActingCute, profile.ActingCute);
           Assert.AreEqual(contestantRegistration.JoiningDateYear, profile.JoinedDate.Year);
           Assert.AreEqual(contestantRegistration.JoiningDateMonth, profile.JoinedDate.Month);
        }
    }
}
