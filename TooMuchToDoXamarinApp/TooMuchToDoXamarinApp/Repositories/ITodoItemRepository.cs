using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TooMuchToDoXamarinApp.Models;

namespace TooMuchToDoXamarinApp.Repositories
{
	public interface ITodoItemRepository
	{
		event EventHandler<TodoItem> OnItemAdded;
		event EventHandler<TodoItem> OnItemUpdated;

		Task<List<TodoItem>> GetItems();
		Task AddItem(TodoItem item);
		Task UpdateItem(TodoItem item);
		Task AddOrUpdate(TodoItem item);

		//TODO: Add Delete method pg.51
	}
}
