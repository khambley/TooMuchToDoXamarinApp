using System;
using System.Collections.Generic;
using System.Text;
using TooMuchToDoXamarinApp.Models;
using System.IO;
using System.Threading.Tasks;

namespace TooMuchToDoXamarinApp.Repositories
{
	public class TodoItemRepository : ITodoItemRepository
	{
		public event EventHandler<TodoItem> OnItemAdded;
		public event EventHandler<TodoItem> OnItemUpdated;

		public async Task<List<TodoItem>> GetItems()
		{
			return null; //Just to get it to build for now.
		}

		public async Task AddItem(TodoItem item)
		{

		}

		public async Task UpdateItem(TodoItem item)
		{
		}

		public async Task AddOrUpdate(TodoItem item)
		{
			if (item.Id == 0)
			{
				await AddItem(item);
			}
			else
			{
				await UpdateItem(item);
			}
		}


	}
}
