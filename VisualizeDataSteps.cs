using System;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public class VisualizeDataSteps
    {
        [Given(@"I see the location selection menu")]
        public void GivenISeeTheLocationSelectionMenu()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have selected the location ""(.*)""")]
        public void GivenIHaveSelectedTheLocation(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on the location ""(.*)""")]
        public void WhenIClickOnTheLocation(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on the ComboBox arrow")]
        public void WhenIClickOnTheComboBoxArrow()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on the timeframe ""(.*)""")]
        public void WhenIClickOnTheTimeframe(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the data of ""(.*)"" should be shown")]
        public void ThenTheDataOfShouldBeShown(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the data of the last week is shown")]
        public void ThenTheDataOfTheLastWeekIsShown()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
