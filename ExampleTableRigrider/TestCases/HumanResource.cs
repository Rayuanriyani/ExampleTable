using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleTableRIgrider.ShareSteps;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static ExampleTableRIgrider.ShareSteps.MyShareThings;

namespace ExampleTableRIgrider.TestCases
{
	[Binding]
	public sealed class HR_Maintenance : BaseSteps
	{
		public HR_Maintenance(MyShareThings sharedThings) : base(sharedThings)
		{
		}
		[Given(@"Access the rigrider web portal")]
		public void GivenAccessTheRigriderWebPortal()
		{
			things.GoToRigRiderPortal();
		}

		[Given(@"Login as rigrider administrator")]
		public void GivenLoginAsRigriderAdministrator()
		{
			things.driver.FindElement(By.Id("UserName")).SendKeys("ridersetup");
			things.driver.FindElement(By.Id("Password")).SendKeys("P@ssw0rd");
			things.WaitingForElement("//INPUT[@type='submit']");
			things.driver.FindElement(By.XPath("//INPUT[@type='submit']")).Click();

			things.WaitForElementText("//H1[@ng-show='licenseHolder'][text()='Rider - Internal Development']", "Rider - Internal Development");
		}

		[When(@"Navigate to the HR Maintenance Page")]
		public void WhenNavigateToTheHRMaintenancePage()
		{
			things.driver.FindElement(By.XPath("//a[@id='fa-users']//span[.='Human Resources']")).Click();
			things.WaitForElementText("//H2[@class='ng-binding'][text()='HR Maintenance']", "HR Maintenance");
		}

		[Then(@"The HR Maintenance Page should be displayed")]
		public void ThenTheHRMaintenancePageShouldBeDisplayed()
		{
			things.driver.FindElement(By.XPath("//H2[@class='ng-binding'][text()='HR Maintenance']"));
		}

		[Given(@"Navigate to the HR Maintenance page")]
		public void GivenNavigateToTheHRMaintenancepage()
		{

			var capabilities = new DesiredCapabilities();

			var switches = new List<string>
							   {
								   "--start-fullscreen"
							   };

			capabilities.SetCapability("chrome.switches", switches);

			things.LoginAsAdmin();
			things.WaitForElementText("//H1[@ng-show='licenseHolder'][text()='Rider - Internal Development']", "Rider - Internal Development");
			things.driver.FindElement(By.XPath("//a[@id='fa-users']//span[.='Human Resources']")).Click();
			things.WaitForElementText("//H2[@class='ng-binding'][text()='HR Maintenance']", "HR Maintenance");
		}

		[Given(@"Navigate to the HR Maintenance Page")]
		public void GivenNavigateToTheHRMaintenancePage()
		{
			things.LoginAsAdmin();
			things.WaitForElementText("//H1[@ng-show='licenseHolder'][text()='Rider - Internal Development']", "Rider - Internal Development");
			things.driver.FindElement(By.XPath("//a[@id='fa-users']//span[.='Human Resources']")).Click();
			things.WaitForElementText("//H2[@class='ng-binding'][text()='HR Maintenance']", "HR Maintenance");
		}
	
		[Given(@"Click on the Tab People")]
		public void GivenClickOnTheTabPeople()
		{
			things.driver.FindElement(By.XPath("//A[@href=''][text()='\n                People\n            ']")).Click();
			things.WaitForElementText("//SPAN[@class='action ng-binding']", "PEOPLE");
		}

		[When(@"Click on the Tab Designation")]
		public void WhenClickOnTheTabDesignation()
		{
			things.driver.FindElement(By.XPath("//A[@href=''][text()='\n                Designation\n            ']")).Click();
			things.WaitForElementText("//SPAN[@class='action ng-binding']", "DESIGNATIONS");
		}

		[When(@"Click on the Tab Location")]
		public void WhenClickOnTheTabLocation()
		{
			things.driver.FindElement(By.XPath("//A[@href=''][text()='\n                Locations\n            ']")).Click();
			things.WaitForElementText("//SPAN[@class='action ng-binding']", "LOCATIONS");
		}

		[Then(@"All Tabs can be clicked and displayed")]
		public void ThenAllTabsCanBeClickedAndDisplayed()
		{
			things.driver.FindElement(By.XPath("//A[@href=''][text()='\n                People\n            ']")).Click();
			things.WaitForElementText("//SPAN[@class='action ng-binding']", "PEOPLE");
			things.driver.FindElement(By.XPath("//A[@href=''][text()='\n                Designation\n            ']")).Click();
			things.WaitForElementText("//SPAN[@class='action ng-binding']", "DESIGNATIONS");
			things.driver.FindElement(By.XPath("//A[@href=''][text()='\n                Locations\n            ']")).Click();
			things.WaitForElementText("//SPAN[@class='action ng-binding']", "LOCATIONS");

		}

		[When(@"Click on the Create People Button")]
		public void WhenClickOnTheCreatePeopleButton()
		{
			things.WaitingForElement("//I[@class='fa fa-plus']");
			things.driver.FindElement(By.XPath("//BUTTON[@tooltip='Create']")).Click();
			things.WaitForElementText("//H4[@class='modal-title ng-binding'][text()='\n            Create Person\n        ']", "Create Person");
		}

		[When(@"Create name on the people for Dictionary")]
		public void WhenCreateNameOnThePeopleforDictionary(Table Person)
		{
			things.CreatePerson(Person);
		}


		[When(@"Create name on the people for CreateSet in SpecFlow Table")]
		public void WhenCreateNameOnThePeopleForCreateSetInSpecFlowTable(Table People)
		{
			things.CreatePeople(People);
		}


		[When(@"Click on the save button for people")]
		public void WhenClickOnTheSaveButtonForPeople()
		{
			things.WaitingForElement("//BUTTON[@type='submit'][@class='btn btn-primary ng-binding']");
			things.driver.FindElement(By.XPath("//BUTTON[@type='submit'][text()='\n                Save\n            ']")).Click();
		}

		[Then(@"the Name People is ""(.*)"" can be added and shown in overview list")]
		public void ThenTheNamePeopleIsCanBeAddedAndShownInOverviewList(string person)
		{
			var result = things.CheckDataOnTheList(person, "Exist");

			things.WaitingForElement(result.Item2);
			things.driver.FindElement(By.XPath(result.Item2)).Click();
		}


		[Given(@"Click on the Designation Tab")]
		public void GivenClickOnTheDesignationTab()
		{
			ScenarioContext.Current.Pending();
		}

		[When(@"Click on the Create Designation Button")]
		public void WhenClickOnTheCreateDesignationButton()
		{
			things.WaitingForElement("(//I[@class='fa fa-plus'])");
			things.driver.FindElement(By.XPath("(//BUTTON[@tooltip='Create'])")).Click();
			things.WaitForElementText("//H4[@class='modal-title ng-binding'][text()='\n            Create Designation\n        ']", "Create Designation");
		}

		[When(@"Fill in the name Designation with ""(.*)""")]
		public void WhenFillInTheNameDesignationWith(string designation)
		{
			things.WaitingForElement("(//INPUT[@type='text'])[1]");
			things.driver.FindElement(By.XPath("(//INPUT[@type='text'])[1]")).SendKeys(designation);
		}

		[When(@"Click on the save button")]
		public void WhenClickOnTheSaveButton()
		{
			things.WaitingForElement("//BUTTON[@type='submit'][text()='\n                Save\n            ']");
			things.driver.FindElement(By.XPath("//BUTTON[@type='submit'][text()='\n                Save\n            ']")).Click();
		}


		[Then(@"the Name Designation is ""(.*)"" can be added and shown in overview list")]
		public void ThenTheNameDesignationIsCanBeAddedAndShownInOverviewList(string designation)
		{
			things.VerifyExistDataOnTheList(designation);
		}






	}
}
