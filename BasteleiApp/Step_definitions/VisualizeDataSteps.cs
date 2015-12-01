using System;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WPFUIItems;
using NUnit.Framework;

namespace BasteleiApp.Step_definitions
{
    [Binding]
    public class VisualizeDataSteps
    {
        private static Application app;
        private static Window window;
        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            app = Application.Launch(@"C:\Users\Robin\Documents\Visual Studio 2015\Projects\BasteleiApp\BasteleiApp\bin\Debug\BasteleiApp.exe");
            window = app.GetWindow("MainWindow");

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            window.Close();
        }

        [Given(@"I see the location selection menu")]
        public void GivenISeeTheLocationSelectionMenu()
        {
            ListBox locbox = window.Get<ListBox>("loclist");
            Assert.IsTrue(locbox.Visible);
        }
        
        [Given(@"I see the timeframe selection menu")]
        public void GivenISeeTheTimeframeSelectionMenu()
        {
            ComboBox combo = window.Get<ComboBox>("comboBox");
            Assert.IsTrue(combo.Visible);
        }
        
        [Given(@"I have selected the location ""(.*)""")]
        public void GivenIHaveSelectedTheLocation(string p0)
        {
            ListBox locbox = window.Get<ListBox>("loclist");

            Assert.IsTrue(locbox.IsSelected(p0));
        }
        
        [Given(@"I have selected the timeframe ""(.*)""")]
        public void GivenIHaveSelectedTheTimeframe(string p0)
        {
            ComboBox combo = window.Get<ComboBox>("comboBox");
            Assert.AreEqual(p0, combo.SelectedItemText);
        }
        
        [When(@"I select the timeframe ""(.*)""")]
        public void WhenISelectTheTimeframe(string p0)
        {
            ComboBox combo = window.Get<ComboBox>("comboBox");
            combo.Select(p0);
            Assert.AreEqual(p0, combo.SelectedItemText);
        }
        
        [When(@"I click on the location ""(.*)""")]
        public void WhenIClickOnTheLocation(string p0)
        {
            ListBox locbox = window.Get<ListBox>("loclist");
            locbox.Select(p0);
            Assert.IsTrue(locbox.IsSelected(p0));
        }
        
        
        [When(@"I click on the button ""(.*)""")]
        public void WhenIClickOnTheButton(string p0)
        {
            Button button = window.Get<Button>("loadloc");
            button.Click();
        }
        
        
        [Then(@"the data of ""(.*)"" should be shown")]
        public void ThenTheDataOfShouldBeShown(string p0)
        {
            ;
        }
        
        [Then(@"the data of the last week is shown")]
        public void ThenTheDataOfTheLastWeekIsShown()
        {
            ; 
        }
    }
}
