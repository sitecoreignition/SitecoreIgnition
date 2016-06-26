using System;
using System.ComponentModel.Composition;
using Ignition.Core.Models.BaseModels;
using Ignition.Core.Models.Page;
using Ignition.Core.Repositories;

namespace Ignition.Core.Mvc
{
	public abstract class Agent<TViewModel> where TViewModel : BaseViewModel, new()
	{
		[Import]
		protected IViewModelDataBinder ViewModelDataBinder { get; set; }

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
			ViewModelDataBinder.DataBind(ViewModel, Datasource);

			AgentParameters = Context.AgentParameters;
		}

	    public abstract void PopulateModel();
	}
}
