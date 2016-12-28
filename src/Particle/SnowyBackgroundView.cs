using System;
using System.Collections.Generic;

using Xamarin.Forms;
using CocosSharp;

namespace Particle
{
	public class SnowyBackgroundView : ContentView
	{
		SnowScene overallScene;

		public SnowyBackgroundView()
		{
			var sharpView = new CocosSharpView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			sharpView.ViewCreated += (sender, e) =>
			{
				var ccGView = sender as CCGameView;
				if (ccGView != null)
				{
					ccGView.DesignResolution = new CCSizeI(App.Width, App.Height);

					var contentSearchPaths = new List<string> { "Images" };
					ccGView.ContentManager.SearchPaths = contentSearchPaths;

					overallScene = new SnowScene(ccGView);

					ccGView.RunWithScene(overallScene);
				}
			};

			Content = sharpView;
		}
	}
}

