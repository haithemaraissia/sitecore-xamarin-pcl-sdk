﻿namespace MobileSDK_UnitTest_Desktop
{
    using System;
    using NUnit.Framework;

    using MobileSDKUnitTest.Mock;

    using Sitecore.MobileSDK;
    using Sitecore.MobileSDK.Items;
    using Sitecore.MobileSDK.SessionSettings;
    using Sitecore.MobileSDK.UrlBuilder;

    [TestFixture]
    public class ItemByIdUrlBuilderTests
    {
        private ItemByIdUrlBuilder builder;
        private ISessionConfig sessionConfig;

        [SetUp]
        public void SetUp()
        {
            IRestServiceGrammar restGrammar = RestServiceGrammar.ItemWebApiV2Grammar();
            IWebApiUrlParameters webApiGrammar = WebApiUrlParameters.ItemWebApiV2UrlParameters();

            this.builder = new ItemByIdUrlBuilder(restGrammar, webApiGrammar);

            SessionConfigPOD mutableSessionConfig = new SessionConfigPOD();
            mutableSessionConfig.ItemWebApiVersion = "v1";
            mutableSessionConfig.InstanceUrl = "sitecore.net";
            mutableSessionConfig.Site = null;

            this.sessionConfig = mutableSessionConfig;
        }

        [TearDown]
        public void TearDown()
        {
            this.builder = null;
            this.sessionConfig = null;
        }

        [Test]
        public void TestInvalidItemId()
        {
            MockGetItemsByIdParameters mutableParameters = new MockGetItemsByIdParameters();
            mutableParameters.SessionSettings = this.sessionConfig;
            mutableParameters.ItemSource = ItemSource.DefaultSource();
            mutableParameters.ItemId = "someInvalidItemId";

            IGetItemByIdRequest parameters = mutableParameters;

            TestDelegate action = () => this.builder.GetUrlForRequest(parameters);
            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void TestUrlBuilderExcapesArgs()
        {
            MockGetItemsByIdParameters mutableParameters = new MockGetItemsByIdParameters();
            mutableParameters.SessionSettings = this.sessionConfig;
            mutableParameters.ItemSource = null;
            mutableParameters.ItemId = "{   xxx   }";

            IGetItemByIdRequest parameters = mutableParameters;

            string result = this.builder.GetUrlForRequest(parameters);
            string expected = "http://sitecore.net/-/item/v1?sc_itemid=%7b%20%20%20xxx%20%20%20%7d";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestUrlBuilderHandlesNullItemId()
        {
            MockGetItemsByIdParameters mutableParameters = new MockGetItemsByIdParameters();
            mutableParameters.SessionSettings = this.sessionConfig;
            mutableParameters.ItemSource = null;
            mutableParameters.ItemId = null;

            IGetItemByIdRequest parameters = mutableParameters;

            TestDelegate action = () =>
            {
                string result = this.builder.GetUrlForRequest(parameters);
            };

            Assert.Throws<ArgumentNullException>(action);
        }
    }
}