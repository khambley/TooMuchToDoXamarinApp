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

namespace TooMuchToDoXamarinApp.iOS
{
	
	public class Bootstrapper : TooMuchToDoXamarinApp.Bootstrapper
	{
		public static void Init()
		{
			var instance = new Bootstrapper();
		}

	}
}
