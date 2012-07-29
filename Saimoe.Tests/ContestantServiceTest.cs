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
            var contestantRegistration = new Contestant(
                gPlusId,
                new Profile
                {
                    Tagline = "tagline",
                    Interest = "interest",
                    Characteristic = "chara",
                    RegistrationPost = "registrationPost",
                    ActingCute = "ActingCute",
                    JoinedDate = new DateTime(2011, 7, 1),
                }
            );

            var contestantService = new ContestantService();
            contestantService.AddContestant(contestantRegistration);
            var contestant = contestantService.GetContestant(gPlusId);
            Assert.IsNotNull(contestant);
        }

        [TestMethod]
        public void TestUpdateContestant()
        {
            var gPlusId = "107711263447378891785";
            var contestantService = new ContestantService();
            var expect = contestantService.GetContestant(gPlusId);

            expect.Profile.Tagline = expect.Profile.Tagline + DateTime.Now.Minute;
            expect.Profile.Interest = expect.Profile.Interest + DateTime.Now.Minute;
            expect.Profile.Characteristic = expect.Profile.Characteristic + DateTime.Now.Minute;
            expect.Profile.RegistrationPost = expect.Profile.RegistrationPost + DateTime.Now.Minute;
            expect.Profile.ActingCute = expect.Profile.ActingCute + DateTime.Now.Minute;
            expect.Profile.JoinedDate = DateTime.Now;
            var contestantService1 = new ContestantService();
            contestantService1.UpdateContestantProfile(gPlusId, expect.Profile);

            var actual = contestantService1.GetContestant(gPlusId);
            Assert.AreEqual(expect.Profile.Tagline, actual.Profile.Tagline);
            Assert.AreEqual(expect.Profile.ActingCute, actual.Profile.ActingCute);
            Assert.AreEqual(expect.Profile.Interest, actual.Profile.Interest);
            Assert.AreEqual(expect.Profile.Characteristic, actual.Profile.Characteristic);
            Assert.AreEqual(expect.Profile.RegistrationPost, actual.Profile.RegistrationPost);
            Assert.AreEqual(expect.Profile.JoinedDate, actual.Profile.JoinedDate);
        }
    }
}
