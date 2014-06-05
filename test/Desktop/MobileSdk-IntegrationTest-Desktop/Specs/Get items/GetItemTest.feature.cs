﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace MobileSdk_IntegrationTest_Desktop.Specs.GetItems
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("GetItemTest")]
    public partial class GetItemTestFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetItemTest.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetItemTest", "In order to get data from sitecore to mobile app\r\nAs a daveloper\r\nI want to get i" +
                    "tem using Mobile SDK", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Item by ID")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void GetItemByID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Item by ID", new string[] {
                        "mytag"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I have logged in authenticated instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "Password"});
            table1.AddRow(new string[] {
                        "sitecore\\admin",
                        "b"});
#line 9
 testRunner.And("I have choosed user", ((string)(null)), table1, "And ");
#line 12
 testRunner.When("I send request to get item by id \"HomeItemId\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("I\'ve got 1 items in response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.And("This is Home item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Item by invalid ID")]
        public virtual void GetItemByInvalidID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Item by invalid ID", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given("I have logged in authenticated instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "Password"});
            table2.AddRow(new string[] {
                        "sitecore\\admin",
                        "b"});
#line 18
 testRunner.And("I have choosed user", ((string)(null)), table2, "And ");
#line 21
 testRunner.When("I send request to get item by id \"{/invalid- item &ID}*\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.Then("I\'ve got 0 items in response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Item by not existent ID")]
        public virtual void GetItemByNotExistentID()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Item by not existent ID", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given("I have logged in authenticated instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "Password"});
            table3.AddRow(new string[] {
                        "sitecore\\admin",
                        "b"});
#line 26
 testRunner.And("I have choosed user", ((string)(null)), table3, "And ");
#line 29
 testRunner.When("I send request to get item by id \"{110D559F-QQQQ-QQQQ-QQQQ-8A5DF7E70EF9}\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("I\'ve got 0 items in response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Item by Path")]
        public virtual void GetItemByPath()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Item by Path", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
 testRunner.Given("I have logged in authenticated instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "Password"});
            table4.AddRow(new string[] {
                        "sitecore\\admin",
                        "b"});
#line 34
 testRunner.And("I have choosed user", ((string)(null)), table4, "And ");
#line 37
 testRunner.When("I send request to get item by path \"HomeItemPath\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.Then("I\'ve got 1 items in response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
 testRunner.And("This is Home item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Item by not existent Path")]
        public virtual void GetItemByNotExistentPath()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Item by not existent Path", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line 42
 testRunner.Given("I have logged in authenticated instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "Password"});
            table5.AddRow(new string[] {
                        "sitecore\\admin",
                        "b"});
#line 43
 testRunner.And("I have choosed user", ((string)(null)), table5, "And ");
#line 46
 testRunner.When("I send request to get item by path \"/Not/Existent/Path\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
 testRunner.Then("I\'ve got 0 items in response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Item by Path with spaces")]
        public virtual void GetItemByPathWithSpaces()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Item by Path with spaces", ((string[])(null)));
#line 50
this.ScenarioSetup(scenarioInfo);
#line 51
 testRunner.Given("I have logged in authenticated instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "Password"});
            table6.AddRow(new string[] {
                        "sitecore\\admin",
                        "b"});
#line 52
 testRunner.And("I have choosed user", ((string)(null)), table6, "And ");
#line 55
 testRunner.When("I send request to get item by path \"/sitecore/content/T E S T/i t e m\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.Then("I\'ve got 1 items in response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
    testRunner.And("This is \"i t e m\" item with path \"ItemPathWithSpaces\" and template \"Sample/Sample" +
                    " Item\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get Item by Path for two items with same path exist")]
        public virtual void GetItemByPathForTwoItemsWithSamePathExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Item by Path for two items with same path exist", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
 testRunner.Given("I have logged in authenticated instance", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Username",
                        "Password"});
            table7.AddRow(new string[] {
                        "sitecore\\admin",
                        "b"});
#line 62
 testRunner.And("I have choosed user", ((string)(null)), table7, "And ");
#line 65
 testRunner.When("I send request to get item by path \"/sitecore/content/T E S T/i t e m\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.Then("I\'ve got 1 items in response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
 testRunner.And("This is \"i t e m\" item with path \"ItemPathWithSpaces\" and template \"Sample/Sample" +
                    " Item\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
