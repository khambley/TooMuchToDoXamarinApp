﻿using System;
using System.Collections.Generic;
using System.Text;
using TooMuchToDoXamarinApp.Models;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace TooMuchToDoXamarinApp.Repositories
{
	public class TodoItemRepository : ITodoItemRepository
	{
		private SQLiteAsyncConnection connection;

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
		private async Task CreateConnection()
		{
			if(connection != null)
			{
				return;
			}
			var documentPath = Environment.GetFolderPath(
								Environment.SpecialFolder.MyDocuments);
			var databasePath = Path.Combine(documentPath, "TodoItems.db");

			connection = new SQLiteAsyncConnection(databasePath);
			await connection.CreateTableAsync<TodoItem>();

			if(await connection.Table<TodoItem>().CountAsync() == 0)
			{
				await connection.InsertAsync(new TodoItem()
				{
					Title = "Welcome to TooMuchToDo",
					DueDate = DateTime.Now
				});
			}
		}


	}
}
