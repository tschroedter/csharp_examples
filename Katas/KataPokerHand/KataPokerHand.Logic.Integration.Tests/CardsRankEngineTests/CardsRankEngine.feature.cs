﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

#region Designer generated code

using TechTalk.SpecFlow;

#pragma warning disable
namespace KataPokerHand.Logic.Integration.Tests.CardsRankEngineTests
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow",
        "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CardsRankEngine")]
    public partial class CardsRankEngineFeature
    {
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }

        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }

        private TechTalk.SpecFlow.ITestRunner testRunner;

        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            var featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"),
                                                                "CardsRankEngine",
                                                                "         The engine is used to rank a set of 5 cards.",
                                                                ProgrammingLanguage.CSharp,
                                                                ( ( string[] ) ( null ) ));
            testRunner.OnFeatureStart(featureInfo);
        }

        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
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
        [NUnit.Framework.DescriptionAttribute("Engine detects four of a kind")]
        [NUnit.Framework.CategoryAttribute("fourOfAKind")]
        public virtual void EngineDetectsFourOfAKind()
        {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Engine detects four of a kind",
                                                                  new string[]
                                                                  {
                                                                      "fourOfAKind"
                                                                  });
#line 16
            this.ScenarioSetup(scenarioInfo);
#line 17
            testRunner.Given("I added a card \'two of clubs\' to player cards",
                             ( ( string ) ( null ) ),
                             ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                             "Given ");
#line 18
            testRunner.And("I added a card \'two of spades\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 19
            testRunner.And("I added a card \'two of hearts\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 20
            testRunner.And("I added a card \'two of diamonds\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 21
            testRunner.And("I added a card \'six of clubs\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 22
            testRunner.When("I apply the rules",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "When ");
#line 23
            testRunner.Then("the status should be \'FourOfAKind\'",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "Then ");
#line 24
            testRunner.And("the HighestCard should be \'six of Clubs\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 25
            testRunner.And("the FourOfAKind should be \'two of clubs, two of spades, two of hearts, two of dia" +
                           "monds\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 26
            testRunner.And("the Rank should be \'two\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line hidden
            this.ScenarioCleanup();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Engine detects full house")]
        [NUnit.Framework.CategoryAttribute("fullHouse")]
        public virtual void EngineDetectsFullHouse()
        {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Engine detects full house",
                                                                  new string[]
                                                                  {
                                                                      "fullHouse"
                                                                  });
#line 29
            this.ScenarioSetup(scenarioInfo);
#line 30
            testRunner.Given("I added a card \'two of clubs\' to player cards",
                             ( ( string ) ( null ) ),
                             ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                             "Given ");
#line 31
            testRunner.And("I added a card \'two of spades\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 32
            testRunner.And("I added a card \'two of hearts\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 33
            testRunner.And("I added a card \'three of diamonds\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 34
            testRunner.And("I added a card \'three of clubs\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 35
            testRunner.When("I apply the rules",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "When ");
#line 36
            testRunner.Then("the status should be \'FullHouse\'",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "Then ");
#line 37
            testRunner.And("the TwoOfAkind should be \'three of diamonds, three of clubs\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 38
            testRunner.And("the ThreeOfAkind should be \'two of clubs, two of spades, two of hearts\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line hidden
            this.ScenarioCleanup();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Engine detects highest card")]
        [NUnit.Framework.CategoryAttribute("highestCard")]
        public virtual void EngineDetectsHighestCard()
        {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Engine detects highest card",
                                                                  new string[]
                                                                  {
                                                                      "highestCard"
                                                                  });
#line 91
            this.ScenarioSetup(scenarioInfo);
#line 92
            testRunner.Given("I added a card \'two of clubs\' to player cards",
                             ( ( string ) ( null ) ),
                             ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                             "Given ");
#line 93
            testRunner.And("I added a card \'four of spades\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 94
            testRunner.And("I added a card \'six of hearts\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 95
            testRunner.And("I added a card \'eight of diamonds\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 96
            testRunner.And("I added a card \'jack of clubs\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 97
            testRunner.When("I apply the rules",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "When ");
#line 98
            testRunner.Then("the status should be \'HighCard\'",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "Then ");
#line 99
            testRunner.And("the HighestCard should be \'jack of clubs\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 100
            testRunner.And("the OtherCards should be \'two of clubs, four of spades, six of hearts, eight of d" +
                           "iamonds\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line hidden
            this.ScenarioCleanup();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Engine detects one pair")]
        [NUnit.Framework.CategoryAttribute("onePair")]
        public virtual void EngineDetectsOnePair()
        {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Engine detects one pair",
                                                                  new string[]
                                                                  {
                                                                      "onePair"
                                                                  });
#line 79
            this.ScenarioSetup(scenarioInfo);
#line 80
            testRunner.Given("I added a card \'two of clubs\' to player cards",
                             ( ( string ) ( null ) ),
                             ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                             "Given ");
#line 81
            testRunner.And("I added a card \'two of spades\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 82
            testRunner.And("I added a card \'three of hearts\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 83
            testRunner.And("I added a card \'four of diamonds\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 84
            testRunner.And("I added a card \'five of clubs\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 85
            testRunner.When("I apply the rules",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "When ");
#line 86
            testRunner.Then("the status should be \'OnePair\'",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "Then ");
#line 87
            testRunner.And("the PairOfCards should be \'two of clubs, two of spades\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 88
            testRunner.And("the OtherCards should be \'three of hearts, four of diamonds, five of clubs\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line hidden
            this.ScenarioCleanup();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Engine detects straight")]
        [NUnit.Framework.CategoryAttribute("straight")]
        public virtual void EngineDetectsStraight()
        {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Engine detects straight",
                                                                  new string[]
                                                                  {
                                                                      "straight"
                                                                  });
#line 41
            this.ScenarioSetup(scenarioInfo);
#line 42
            testRunner.Given("I added a card \'two of clubs\' to player cards",
                             ( ( string ) ( null ) ),
                             ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                             "Given ");
#line 43
            testRunner.And("I added a card \'three of spades\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 44
            testRunner.And("I added a card \'four of hearts\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 45
            testRunner.And("I added a card \'five of diamonds\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 46
            testRunner.And("I added a card \'six of clubs\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 47
            testRunner.When("I apply the rules",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "When ");
#line 48
            testRunner.Then("the status should be \'Straight\'",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "Then ");
#line 49
            testRunner.And("the HighestCard should be \'six of Clubs\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line hidden
            this.ScenarioCleanup();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Engine detects straight flush")]
        [NUnit.Framework.CategoryAttribute("straightFlush")]
        public virtual void EngineDetectsStraightFlush()
        {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Engine detects straight flush",
                                                                  new string[]
                                                                  {
                                                                      "straightFlush"
                                                                  });
#line 5
            this.ScenarioSetup(scenarioInfo);
#line 6
            testRunner.Given("I added a card \'two of clubs\' to player cards",
                             ( ( string ) ( null ) ),
                             ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                             "Given ");
#line 7
            testRunner.And("I added a card \'three of clubs\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 8
            testRunner.And("I added a card \'four of clubs\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 9
            testRunner.And("I added a card \'five of clubs\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 10
            testRunner.And("I added a card \'six of clubs\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 11
            testRunner.When("I apply the rules",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "When ");
#line 12
            testRunner.Then("the status should be \'StraightFlush\'",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "Then ");
#line 13
            testRunner.And("the HighestCard should be \'six of Clubs\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line hidden
            this.ScenarioCleanup();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Engine detects three of a kind")]
        [NUnit.Framework.CategoryAttribute("threeOfAKind")]
        public virtual void EngineDetectsThreeOfAKind()
        {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Engine detects three of a kind",
                                                                  new string[]
                                                                  {
                                                                      "threeOfAKind"
                                                                  });
#line 52
            this.ScenarioSetup(scenarioInfo);
#line 53
            testRunner.Given("I added a card \'two of clubs\' to player cards",
                             ( ( string ) ( null ) ),
                             ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                             "Given ");
#line 54
            testRunner.And("I added a card \'two of spades\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 55
            testRunner.And("I added a card \'two of hearts\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 56
            testRunner.And("I added a card \'three of diamonds\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 57
            testRunner.And("I added a card \'four of clubs\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 58
            testRunner.When("I apply the rules",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "When ");
#line 59
            testRunner.Then("the status should be \'ThreeOfAKind\'",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "Then ");
#line 60
            testRunner.And("the ThreeOfAkind should be \'two of clubs, two of spades, two of hearts\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 61
            testRunner.And("the Rank should be \'two\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 62
            testRunner.And("the OtherCards should be \'three of diamonds, four of clubs\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 63
            testRunner.And("the HighestCard should be \'four of Clubs\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line hidden
            this.ScenarioCleanup();
        }

        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Engine detects two pairs")]
        [NUnit.Framework.CategoryAttribute("twoPairs")]
        public virtual void EngineDetectsTwoPairs()
        {
            var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Engine detects two pairs",
                                                                  new string[]
                                                                  {
                                                                      "twoPairs"
                                                                  });
#line 66
            this.ScenarioSetup(scenarioInfo);
#line 67
            testRunner.Given("I added a card \'two of clubs\' to player cards",
                             ( ( string ) ( null ) ),
                             ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                             "Given ");
#line 68
            testRunner.And("I added a card \'two of spades\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 69
            testRunner.And("I added a card \'three of hearts\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 70
            testRunner.And("I added a card \'three of diamonds\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 71
            testRunner.And("I added a card \'four of clubs\' to player cards",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 72
            testRunner.When("I apply the rules",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "When ");
#line 73
            testRunner.Then("the status should be \'TwoPairs\'",
                            ( ( string ) ( null ) ),
                            ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                            "Then ");
#line 74
            testRunner.And("the FirstPairOfCards should be \'two of clubs, two of spades\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 75
            testRunner.And("the SecondPairOfCards should be \'three of hearts, three of diamonds\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line 76
            testRunner.And("the HighestCard should be \'four of clubs\'",
                           ( ( string ) ( null ) ),
                           ( ( TechTalk.SpecFlow.Table ) ( null ) ),
                           "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore

#endregion