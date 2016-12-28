using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Particle.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			App.Height = (int)UIScreen.MainScreen.Bounds.Height;
			App.Width = (int)UIScreen.MainScreen.Bounds.Width;

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
