using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace TooMuchToDoXamarinApp
{
	//The resolver is responsible for creating objects based on the type requested. pg 70
	public class Resolver
	{
		private static IContainer container;

		public static void Initialize(IContainer container)
		{
			Resolver.container = container;
		}

		public static T Resolve<T>()
		{
			return container.Resolve<T>();
		}
	}
}
