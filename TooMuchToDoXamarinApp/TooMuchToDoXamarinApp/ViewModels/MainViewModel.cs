using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TooMuchToDoXamarinApp.Repositories;

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

		private async Task LoadData()
		{

		}
	}
}
