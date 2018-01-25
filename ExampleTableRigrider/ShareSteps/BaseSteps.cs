using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ExampleTableRIgrider.ShareSteps
{
	[Binding]
	public class BaseSteps
	{
		protected MyShareThings things;

		public BaseSteps(MyShareThings sharedThings)
		{
			this.things = sharedThings;
		}

		[AfterScenario("HumanResource")]
		public void Teardown()
		{
			things.driver.Quit();
		}
	}


}
