using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace ScottsMyLawn
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			app.Tap("btn_create_lawn_care");
			app.Screenshot("Tapped on Create my Lawn");

			app.Tap("action_continue_as_guest");
			app.Screenshot("Tapped'Continue as Guest' Button");
			Thread.Sleep(8000);

			app.EnterText("94111");
			app.Screenshot("Typed in my Zip-Code");

			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap("action_next");
			app.Screenshot("Tapped on Next Button");

			app.Tap(x => x.Class("android.widget.ImageView").Index(7));
			app.Screenshot("Changed 'Thickness' of my lawn");

			app.Tap(x => x.Class("android.widget.ImageView").Index(22));
			app.Screenshot("Changed the 'Color' of my lawn");

			app.Tap(x => x.Class("android.widget.ImageView").Index(30));
			app.Screenshot("Changed the 'Weeds' of my lawn");

			app.Tap("action_next");
			app.Screenshot("Tapped on Next Button");

			app.Tap("Bermuda");
			app.Screenshot("Tapped on 'Bermuda'");

			app.Back();
			app.Screenshot("Tapped on 'Back' Button");

			app.Tap(x => x.Id("backdrop").Index(0));
			app.Screenshot("Tapped on my grass type, 'Bermuda'");

			app.Tap("action_next");
			app.Screenshot("Tapped on Next Button");

			app.Tap("Drop");
			app.Screenshot("Tapped on 'Drop'");

			app.Tap("action_done");
			app.Screenshot("Tapped on Done Button");

			//app.WaitForElement(x => x.Id("progress"), timeout: TimeSpan.FromSeconds(80));
			//app.Screenshot("Shows my lawn selections");
		}

	}
}
