using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TooMuchToDoXamarinApp.Models;
using TooMuchToDoXamarinApp.Repositories;
using Xamarin.Forms;

namespace TooMuchToDoXamarinApp.ViewModels
{
	//This represents the list of to-do items.
	public class ItemViewModel : ViewModel
	{
		private readonly TodoItemRepository repository;

		public TodoItem Item { get; set; }

		public ItemViewModel(TodoItemRepository repository)
		{
			this.repository = repository;
			Item = new TodoItem() { DueDate = DateTime.Now.AddDays(1) };
		}

		public ICommand Save => new Command(async () =>
		{
			await repository.AddOrUpdate(Item);

			//"Popping the stack" - removes the topmost item from the stack.
			//"Pushing a page" - adds a page to the navigation stack - PushAsync()
			await Navigation.PopAsync();
		});
	}
}
