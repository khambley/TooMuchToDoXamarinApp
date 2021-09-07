using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Xamarin.Forms;

namespace TooMuchToDoXamarinApp.Converters
{
	public class StatusColorConverter : IValueConverter
	{
		//pg.84 Colors fetched from resource file in App.xaml
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ?
				(Color)Application.Current.Resources["CompletedColor"] :
				(Color)Application.Current.Resources["ActiveColor"];
		}
		public object ConvertBack(object value, Type targetType, object paramenter, CultureInfo culture)
		{
			return null,
		}
	}
}
