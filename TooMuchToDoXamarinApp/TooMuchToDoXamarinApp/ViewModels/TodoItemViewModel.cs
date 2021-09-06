using System;
using System.Collections.Generic;
using System.Text;
using TooMuchToDoXamarinApp.Models;

namespace TooMuchToDoXamarinApp.ViewModels
{
	public class TodoItemViewModel : ViewModel
	{
		public TodoItemViewModel(TodoItem item)
		{
			Item = item;
		}
		public event EventHandler ItemStatusChanged;
		public TodoItem Item { get; private set; }

		public string StatusText => Item.Completed ? "Reactivate" : "Completed";
	}
}
