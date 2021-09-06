using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TooMuchToDoXamarinApp.Repositories;

namespace TooMuchToDoXamarinApp.ViewModels
{
	//This represents the list of to-do items.
	public class ItemViewModel : ViewModel
	{
		private readonly TodoItemRepository repository;

		public ItemViewModel(TodoItemRepository repository)
		{
			this.repository = repository;
		}
	}
}
