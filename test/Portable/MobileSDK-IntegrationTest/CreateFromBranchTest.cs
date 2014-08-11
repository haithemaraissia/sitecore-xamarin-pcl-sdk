﻿namespace MobileSDKIntegrationTest
{
  using System;
  using System.Threading.Tasks;

  using NUnit.Framework;

  using MobileSDKUnitTest.Mock;

  using Sitecore.MobileSDK.API;
  using Sitecore.MobileSDK.API.Items;
  using Sitecore.MobileSDK.API.Session;
  using Sitecore.MobileSDK.API.Request.Parameters;


  [TestFixture]
  public class CreateFromBranchTest
  {
    private MobileSDKIntegrationTest.TestEnvironment testData;
    private ISitecoreWebApiSession session;
    private ISitecoreWebApiSession noThrowCleanupSession;


    #region Setup
    [SetUp]
    public void Setup()
    {
      this.testData = TestEnvironment.DefaultTestEnvironment();
      this.session = this.CreateSession();


      // Same as this.session
      var cleanupSession = this.CreateSession();
      this.noThrowCleanupSession = new NoThrowWebApiSession(cleanupSession);
    }

    private ISitecoreWebApiSession CreateSession()
    {
      var result = SitecoreWebApiSessionBuilder.AuthenticatedSessionWithHost(testData.InstanceUrl)
        .Credentials(testData.Users.Admin)
        .Site(testData.ShellSite)
        .BuildSession();

      return result;
    }

    private TestEnvironment.Item CreateTestItem(string name)
    {
      return new TestEnvironment.Item
      {
        DisplayName = name,
        Path = testData.Items.CreateItemsHere.Path + "/" + name,
        Template = this.testData.Items.Home.Template
      };
    }
    #endregion Setup

    #region TearDown
    [TearDown]
    public void TearDown()
    {
      this.testData = null;

      this.session.Dispose();
      this.session = null;

      this.noThrowCleanupSession.Dispose();
      this.noThrowCleanupSession = null;
    }

    public async Task<ScDeleteItemsResponse> RemoveTestItemsFromMasterAndWebAsync()
    {
      await this.DeleteAllItems("master");
      return await this.DeleteAllItems("web");
    }

    private async Task<ScDeleteItemsResponse> DeleteAllItems(string database)
    {
      var deleteFromMaster = ItemWebApiRequestBuilder.DeleteItemRequestWithSitecoreQuery(this.testData.Items.CreateItemsHere.Path)
        .AddScope(ScopeType.Children)
        .Database(database)
        .Build();
      return await this.noThrowCleanupSession.DeleteItemAsync(deleteFromMaster);
    }
    #endregion TearDown


    #region RequestsToServer
    [Test]
    public async void TestCreateItemByPathFromBranch()
    {
      await this.RemoveTestItemsFromMasterAndWebAsync();

      const string itemFromBranchName = "ITEM PATH   A default name of the branch should be used";
//      const string itemFromBranchName = "Multiple item brunch";
      TestEnvironment.Item expectedItem = this.CreateTestItem(itemFromBranchName);

      var request = ItemWebApiRequestBuilder.CreateItemRequestWithPath(this.testData.Items.CreateItemsHere.Path)
        .BranchId("{14416817-CDED-45AF-99BF-2DE9883B7AC3}")
        .ItemName(itemFromBranchName)
        .Database("master")
        .Language("en")
        .AddScope(ScopeType.Self)
        .Payload(PayloadType.Content)
        .Build();

      var createResponse = await session.CreateItemAsync(request);
      this.testData.AssertItemsCount(1, createResponse);

      ISitecoreItem resultItem = createResponse.Items[0];
      this.testData.AssertItemsAreEqual(expectedItem, resultItem);


      var readJustCreatedItemRequest = ItemWebApiRequestBuilder.ReadItemsRequestWithId(resultItem.Id)
        .Database("master")
        .Build();
      var readJustCreatedItemResponse = await this.session.ReadItemAsync(readJustCreatedItemRequest);

      this.testData.AssertItemsCount(1, readJustCreatedItemResponse);
      this.testData.AssertItemsAreEqual(expectedItem, readJustCreatedItemResponse.Items[0]);
    }

    [Test]
    public async void TestCreateItemByIdFromBranch()
    {
      await this.RemoveTestItemsFromMasterAndWebAsync();

      const string itemFromBranchName = "ITEM ID   A default name of the branch should be used";
      //      const string itemFromBranchName = "Multiple item brunch";
      TestEnvironment.Item expectedItem = this.CreateTestItem(itemFromBranchName);

      var request = ItemWebApiRequestBuilder.CreateItemRequestWithId(this.testData.Items.CreateItemsHere.Id)
        .BranchId("{14416817-CDED-45AF-99BF-2DE9883B7AC3}")
        .ItemName(itemFromBranchName)
        .Database("master")
        .Language("en")
        .AddScope(ScopeType.Self)
        .Payload(PayloadType.Content)
        .Build();

      var createResponse = await session.CreateItemAsync(request);
      this.testData.AssertItemsCount(1, createResponse);

      ISitecoreItem resultItem = createResponse.Items[0];
      this.testData.AssertItemsAreEqual(expectedItem, resultItem);


      var readJustCreatedItemRequest = ItemWebApiRequestBuilder.ReadItemsRequestWithId(resultItem.Id)
        .Database("master")
        .Build();
      var readJustCreatedItemResponse = await this.session.ReadItemAsync(readJustCreatedItemRequest);

      this.testData.AssertItemsCount(1, readJustCreatedItemResponse);
      this.testData.AssertItemsAreEqual(expectedItem, readJustCreatedItemResponse.Items[0]);
    }
    #endregion RequestsToServer

    #region Validations
    [Test]
    public void TestNullBranchIdCausesNullPointerException()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        ItemWebApiRequestBuilder.CreateItemRequestWithPath("/some/valid/path")
                                .BranchId(null);
      });
    }

    [Test]
    public void TestEmptyBranchIdCausesArgumentException()
    {
      Assert.Throws<ArgumentException>(() =>
      {
        ItemWebApiRequestBuilder.CreateItemRequestWithPath("/some/valid/path")
                                .BranchId("");
      });
    }

    [Test]
    public void TestWhitespaceBranchIdCausesArgumentException()
    {
      Assert.Throws<ArgumentException>(() =>
      {
        ItemWebApiRequestBuilder.CreateItemRequestWithPath("/some/valid/path")
          .BranchId("  \n   \r  \t \t\n\r");
      });
    }

    [Test]
    public void TestOpeningBraceOnlyBranchIdCausesArgumentException()
    {
      Assert.Throws<ArgumentException>(() =>
      {
        ItemWebApiRequestBuilder.CreateItemRequestWithPath("/some/valid/path")
          .BranchId("{");
      });
    }

    [Test]
    public void TestClosingBraceOnlyBranchIdCausesArgumentException()
    {
      Assert.Throws<ArgumentException>(() =>
      {
        ItemWebApiRequestBuilder.CreateItemRequestWithPath("/some/valid/path")
          .BranchId("}");
      });
    }

    [Test]
    public void TestBracesOnlyBranchIdCausesArgumentException()
    {
      Assert.Throws<ArgumentException>(() =>
      {
        ItemWebApiRequestBuilder.CreateItemRequestWithPath("/some/valid/path")
          .BranchId("{}");
      });
    }
    #endregion Validations
  }
}

