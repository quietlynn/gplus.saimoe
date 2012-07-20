﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Saimoe.Infra;
using Saimoe.Models;
using Saimoe.Models.EF;
using AutoMapper;

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
            };

            var profile = Mapper.Map<ContestantRegistration, Saimoe.Models.EF.Profile>(contestantRegistration);
            Assert.AreEqual(contestantRegistration.ActingCute, profile.ActingCute);
        }
    }
}