using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace ExampleTableRIgrider.ShareSteps
{
	[Binding]
	public class MyShareThings
	{
		public IWebDriver driver;
		public string xpath;
		


		public void GoToRigRiderPortal()
		{
			driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://autodeploy-core-corp.cd.rider.local/ui/home.html");

			WaitForElementText("//SPAN[@class='text-primary'][text()='Rider Login']", "Rider Login");
		}
		public void LoginAsAdmin()
		{
			GoToRigRiderPortal();
			driver.FindElement(By.Id("UserName")).SendKeys("ridersetup");
			driver.FindElement(By.Id("Password")).SendKeys("P@ssw0rd");
			driver.FindElement(By.XPath("//INPUT[@type='submit']")).Click();
		}
		public void WaitForElementText(string param, string value)
		{
			WaitingForElement(param);
			Assert.IsTrue(driver.FindElement(By.XPath(param)).Displayed);
			Assert.AreEqual(driver.FindElement(By.XPath(param)).Text, value);
		}
		public void WaitingForElement(string param)
		{
			TimeSpan time = TimeSpan.FromSeconds(50);
			WebDriverWait waitHome = new WebDriverWait(driver, time);

			IWebElement elementHome = waitHome.Until(ExpectedConditions.ElementIsVisible(By.XPath(param)));
		}

		public class TableExtensions
		{
			public static Dictionary<string, string> ToDictionary(Table Person)
			{
				var dictionary = new Dictionary<string, string>();
				foreach (var row in Person.Rows)
				{
					dictionary.Add(row[0], row[1]);
				}
				return dictionary;
			}
		}

		public class People
		{
			public string Identifier { get; set; }
			public string Firstname { get; set; }
			public string Lastname { get; set; }

		}

		public void CreatePerson(Table Person)
		{

			var dictionary = TableExtensions.ToDictionary(Person);
			var test = dictionary["Identifier"];

			WaitForElementText("//div[@class='modal-header']/h4", "Create Person");
			driver.FindElement(By.Name("identifiername")).SendKeys(dictionary["Identifier"]);
			driver.FindElement(By.Name("firstname")).SendKeys(dictionary["Firstname"]);
			driver.FindElement(By.Name("lastname")).SendKeys(dictionary["Lastname"]);

			SelectElement Organization = new SelectElement(driver.FindElement(By.XPath("//SELECT[@data-ng-options='organization.ID as organization.Description for organization in ctrl.organizations']['Operator Machine']")));
			Organization.SelectByValue("0");

			WaitingForElement("//div[@class='modal-body']/div[1]/div[12]/div/input");
			driver.FindElement(By.XPath("//div[@class='modal-body']/div[1]/div[12]/div/input")).Click();
		}

		public void CreatePeople(Table People)
		{
			var oPeople = People.CreateSet<People>();
			foreach (var userData in oPeople)
			{
				WaitForElementText("//div[@class='modal-header']/h4", "Create Person");
				driver.FindElement(By.Name("identifiername")).SendKeys(userData.Identifier);
				driver.FindElement(By.Name("firstname")).SendKeys(userData.Firstname);
				driver.FindElement(By.Name("lastname")).SendKeys(userData.Lastname);

				SelectElement Organization = new SelectElement(driver.FindElement(By.XPath("//SELECT[@data-ng-options='organization.ID as organization.Description for organization in ctrl.organizations']['Operator Machine']")));
				Organization.SelectByValue("0");

				WaitingForElement("//div[@class='modal-body']/div[1]/div[12]/div/input");
				driver.FindElement(By.XPath("//div[@class='modal-body']/div[1]/div[12]/div/input")).Click();
			}
		}



		public Tuple<bool, string> CheckDataOnTheList(string HR, string status)
		{
			int count = 1;
			string value;
			bool paramStatus = status == "Exist" ? false : true;
			bool result = paramStatus;

			while (result == paramStatus && count > 0)
			{
				Thread.Sleep(3000);
				if (IsElementPresent(By.XPath("(//SPAN[@class='ng-binding'])[" + count + "]")))
				{
					value = driver.FindElement(By.XPath("(//SPAN[@class='ng-binding'])[" + count + "]")).Text;
					if (value == HR)
					{
						xpath = "(//SPAN[@class='ng-binding'])[" + count + "]";
						result = status == "Exist" ? true : false;
						count = 0;
					}
					else
					{
						result = status == "Exist" ? false : true;
						count++;
					}
				}
				else
				{
					result = status == "Exist" ? false : true;
					count = 0;
				}
			}
			return Tuple.Create(result, xpath);
		}

		private bool IsElementPresent(By by)
		{
			try
			{
				driver.FindElement(by);
				return true;
			}
			catch (NoSuchElementException)
			{
				return false;
			}

		}

		public void VerifyExistDataOnTheList(string HR)
		{
			var result = CheckDataOnTheList(HR, "Exist");
			Assert.IsTrue(result.Item1);
		}
		public void VerifyNotExistDataOnTheList(string HR)
		{
			var result = CheckDataOnTheList(HR, "NotExist");
			Assert.IsTrue(result.Item1);
		}

	}
}
