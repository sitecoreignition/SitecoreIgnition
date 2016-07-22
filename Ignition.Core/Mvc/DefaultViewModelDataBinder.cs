using System;
using System.Linq;
using Ignition.Core.Attributes;
using Ignition.Core.Models.BaseModels;
using Ignition.Core.Models.Page;
using Sitecore.Diagnostics;

namespace Ignition.Core.Mvc
{
	public class DefaultViewModelDataBinder : IViewModelDataBinder
	{
		public void DataBind(BaseViewModel viewModel, IModelBase dataSource)
		{
			if (dataSource.GetType().GetCustomAttributes(typeof(IgnoreAutomapAttribute), true).Any()) return;

			try
			{
				foreach (var prop in viewModel.GetType().GetProperties()
					.Where(
						a => typeof(IModelBase).IsAssignableFrom(a.PropertyType) &&
							 !(typeof(IPage).IsAssignableFrom(a.PropertyType) ||
							  typeof(IParamsBase).IsAssignableFrom(a.PropertyType)
							  || a.GetCustomAttributes(typeof(IgnoreAutomapAttribute), true).Any())))
					prop.SetValue(viewModel, dataSource);
			}
			catch (ArgumentNullException argumentNullException)
			{
				Log.Error("Databind Error", argumentNullException, this);
			}
			catch (Exception ex)
			{
				Log.Error("Databind Error", ex, this);
			}
		}
	}
}
