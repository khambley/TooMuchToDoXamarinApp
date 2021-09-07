using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TooMuchToDoXamarinApp.Repositories;
using System.Windows.Input;
using TooMuchToDoXamarinApp.Views;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using TooMuchToDoXamarinApp.Models;

namespace TooMuchToDoXamarinApp.ViewModels
{
	public class MainViewModel : ViewModel
	{
		private readonly TodoItemRepository repository;

		//This collection can notify listeners about changes in the list, when 
		//items are added or deleted. Used with Listview control, listems to changes
		//in the list and updates itself automatically. pg.80
		public ObservableCollection<TodoItemViewModel> Items { get; set; }
		public MainViewModel(TodoItemRepository repository)
		{
			//If item is added to repository, Mainview will add it to the items list.
			//The list updates via the ObservableCollection. pg. 82
			repository.OnItemAdded += (sender, item) => Items.Add(CreateTodoItemViewModel(item));

			//If an item is updated, the list simply reloads.
			repository.OnItemUpdated += (sender, item) => Task.Run(async () => await LoadData());

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
		
		//The LoadData method calls the repository to fetch all item.
		private async Task LoadData()
		{
			var items = await repository.GetItems();

			//Wraps each to-do list item in TodoItemViewModel
			//(use ViewModel and not Model, best practice pg.81)
			var itemViewModels = items.Select(i => CreateTodoItemViewModel(i));

			Items = new ObservableCollection<TodoItemViewModel>(itemViewModels);
		}

		private TodoItemViewModel CreateTodoItemViewModel(TodoItem item)
		{
			var itemViewModel = new TodoItemViewModel(item);
			itemViewModel.ItemStatusChanged += ItemStatusChanged;
			return itemViewModel;
		}

		private void ItemStatusChanged(object sender, EventArgs e)
		{

		}

		

	}
}
