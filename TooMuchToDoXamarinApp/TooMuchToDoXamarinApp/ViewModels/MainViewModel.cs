using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TooMuchToDoXamarinApp.Repositories;
using System.Windows.Input;
using TooMuchToDoXamarinApp.Views;
using Xamarin.Forms;

namespace TooMuchToDoXamarinApp.ViewModels
{
	public class MainViewModel : ViewModel
	{
		private readonly TodoItemRepository repository;

		public MainViewModel(TodoItemRepository repository)
		{
			this.repository = repository;
			Task.Run(async () => await LoadData());
		}

		// All commands should be exposed as a generic ICommand type,
		// and let the Resolver resolve the instance.
		public ICommand AddItem => new Command(async () =>
		{
			//This line creates a new ItemView view through Resolver, and Autofac
			//builds the necessary dependencies.
			var itemView = Resolver.Resolve<ItemView>();
			await Navigation.PushAsync(itemView);
		});

		private async Task LoadData() { }

		

	}
}
