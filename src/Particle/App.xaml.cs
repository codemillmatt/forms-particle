using Xamarin.Forms;

namespace Particle
{
	public partial class App : Application
	{
		public static int Height { get; set; }
		public static int Width { get; set; }

		public App()
		{
			InitializeComponent();

			MainPage = new ParticlePage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
