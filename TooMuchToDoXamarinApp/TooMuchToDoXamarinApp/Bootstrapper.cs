using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using System.Linq;
using Xamarin.Forms;
using TooMuchToDoXamarinApp.Views;
using TooMuchToDoXamarinApp.Repositories;
using TooMuchToDoXamarinApp.ViewModels;
using System.Reflection;

namespace TooMuchToDoXamarinApp
{
	//The main Bootstrapper initializes Autofac. It is called at startup. pg.71
	public abstract class Bootstrapper
	{
		protected ContainerBuilder ContainerBuilder { get; private set; }

		public Bootstrapper()
		{
			Initialize();
			FinishInitialization();
		}
		protected virtual void Initialize()
		{
			var currentAssembly = Assembly.GetExecutingAssembly();
			ContainerBuilder = new ContainerBuilder();
			foreach (var type in currentAssembly.DefinedTypes
				.Where(e =>
					   e.IsSubclassOf(typeof(Page)) || e.IsSubclassOf(typeof(ViewModel))))
			{
				ContainerBuilder.RegisterType(type.AsType());
			}

			ContainerBuilder.RegisterType<TodoItemRepository>().SingleInstance();
		}
		private void FinishInitialization()
		{
			var container = ContainerBuilder.Build();
			Resolver.Initialize(container);
		}

	}
}
