using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace Particle
{
	public class WeatherViewModel : INotifyPropertyChanged
	{
		WeatherService WeatherService { get; } = new WeatherService();

		string location = "";// Settings.City;
		public string Location
		{
			get { return location; }
			set
			{
				location = value;
				OnPropertyChanged();
				//Settings.City = value;
			}
		}

		bool useCity = false;
		public bool UseCity
		{
			get { return useCity; }
			set
			{
				useCity = value;
				OnPropertyChanged();
				//Settings.UseCity = value;
			}
		}


		bool isImperial = false;//Settings.IsImperial;
		public bool IsImperial
		{
			get { return isImperial; }
			set
			{
				isImperial = value;
				OnPropertyChanged();
				//Settings.IsImperial = value;
			}
		}



		string temp = string.Empty;
		public string Temp
		{
			get { return temp; }
			set { temp = value; OnPropertyChanged(); }
		}

		string condition = string.Empty;
		public string Condition
		{
			get { return condition; }
			set { condition = value; OnPropertyChanged(); }
		}



		bool isBusy = false;
		public bool IsBusy
		{
			get { return isBusy; }
			set { isBusy = value; OnPropertyChanged(); }
		}

		WeatherForecastRoot forecast;
		public WeatherForecastRoot Forecast
		{
			get { return forecast; }
			set { forecast = value; OnPropertyChanged(); }
		}


		ICommand getWeather;
		public ICommand GetWeatherCommand =>
				getWeather ??
				(getWeather = new Command(async () => await ExecuteGetWeatherCommand()));

		private async Task ExecuteGetWeatherCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			try
			{
				WeatherRoot weatherRoot = null;
				var units = IsImperial ? Units.Imperial : Units.Metric;
				if (UseCity)
				{
					weatherRoot = await WeatherService.GetWeather(Location.Trim(), units);
				}
				else
				{
					var location = await CrossGeolocator.Current.GetPositionAsync(10000);
					weatherRoot = await WeatherService.GetWeather(location.Latitude, location.Longitude, units);
				}

				Forecast = await WeatherService.GetForecast(weatherRoot.CityId, units);

				var unit = IsImperial ? "F" : "C";
				Temp = $"Temp: {weatherRoot?.MainWeather?.Temperature ?? 0}°{unit}";
				Condition = weatherRoot?.Weather?[0]?.Description ?? string.Empty;

			}
			catch (Exception ex)
			{
				Temp = "Unable to get Weather";
			}
			finally
			{
				IsBusy = false;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string name = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
