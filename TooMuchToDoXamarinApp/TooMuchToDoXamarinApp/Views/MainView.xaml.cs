using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TooMuchToDoXamarinApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TooMuchToDoXamarinApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : ContentPage
	{
		public MainView(MainViewModel viewModel)
		{
			InitializeComponent();
			viewModel.Navigation = Navigation;

			//This tells the Xamarin.Forms binding engine to use our
			//ViewModel object for the bindings.
			BindingContext = viewModel;
		}
	}
}