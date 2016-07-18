using System;
using System.ComponentModel.Composition;
using Ignition.Core.Factories;
using Ignition.Core.Models.BaseModels;
using Ignition.Core.Models.Page;

namespace Ignition.Core.Mvc
{
	public abstract class Agent<TViewModel> where TViewModel : BaseViewModel, new()
	{
        [Import]
        protected ISitecoreServiceFactory SitecoreServiceFactory { get; set; }

        [Import]
		protected IViewModelDataBinder ViewModelDataBinder { get; set; }

		public string ViewPath => ViewModel.ViewPath;
		public TViewModel ViewModel { get; protected set; }
		public AgentContext AgentContext { get; private set; }
		public IModelBase Datasource { get; set; }
		public IPage ContextPage => ViewModel.ContextPage;
		public IParamsBase RenderingParameters { get; set; }
		protected object AgentParameters { get; set; }

		public virtual void Initialize(AgentContext agentContext)
		{
			if (agentContext == null) throw new ArgumentNullException(nameof(agentContext));
			AgentContext = agentContext;
			RenderingParameters = AgentContext.RenderingParameters;
			Datasource = AgentContext.DatasourceItem;

			ViewModel = new TViewModel
			{
				ContextPage = AgentContext.ContextPage,
				ParentPlaceholderName = AgentContext.PlaceholderName
			};
			ViewModelDataBinder.DataBind(ViewModel, Datasource);

			AgentParameters = AgentContext.AgentParameters;
		}

	    public abstract void PopulateModel();
	}
}
