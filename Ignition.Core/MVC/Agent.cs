using System;
using System.Linq;
using Ignition.Core.Attributes;
using Ignition.Core.Models;
using Ignition.Core.Repositories;
using Sitecore.Diagnostics;

namespace Ignition.Core.Mvc
{
	public abstract class Agent<TViewModel> where TViewModel : BaseViewModel, new()
	{
		public string ViewPath => ViewModel.ViewPath;
		public TViewModel ViewModel { get; protected set; }
		public ItemContext Context { get; private set; }
		public IModelBase Datasource { get; set; }
		public IPage ContextPage => ViewModel.ContextPage;
		public IParamsBase RenderingParameters { get; set; }
		protected object AgentParameters { get; set; }

		public virtual void Initialize(ItemContext context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));
			Context = context;
			RenderingParameters = Context.RenderingParameters;
			Datasource = Context.DatasourceItem;
			ViewModel = new TViewModel
			{
				ContextPage = Context.ContextPage,
				ParentPlaceholderName = Context.PlaceholderName
			};
			DataBind();
			AgentParameters = Context.AgentParameters;
		}

	    public abstract void PopulateModel();

		private void DataBind()
		{
		    if (Datasource.GetType().CustomAttributes.Any(a => a.AttributeType == typeof (IgnoreAutomapAttribute))) return;
			try
			{
				foreach (var prop in ViewModel.GetType().GetProperties()
                    .Where(a => (typeof(IModelBase).IsAssignableFrom(a.PropertyType)) && !((typeof(IPage).IsAssignableFrom(a.PropertyType)) || (typeof(IParamsBase).IsAssignableFrom(a.PropertyType))
                        || (a.CustomAttributes.Any(b => b.AttributeType != typeof(IgnoreAutomapAttribute))))))
					prop.SetValue(ViewModel, Datasource);
			}
			catch (ArgumentNullException argumentNullException)
			{
				Log.Error("Databind Error", argumentNullException, this);
			}
		}
	}
}