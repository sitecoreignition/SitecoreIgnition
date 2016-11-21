using System;
using System.ComponentModel.Composition;
using Glass.Mapper.Sc;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Page;

namespace Ignition.Foundation.Core.Mvc
{
	public abstract class Agent<TViewModel> where TViewModel : IgnitionViewModel, new()
	{
        [Import]
        protected ISitecoreServiceFactory SitecoreServiceFactory { get; set; }

        [Import]
        protected IViewModelDataBinder ViewModelDataBinder { get; set; }

        public AgentContext AgentContext { get; private set; }
	    public object AgentParameters => AgentContext.AgentParameters;
        public IPage ContextPage => AgentContext.ContextPage;
        public IModelBase Datasource => AgentContext.DatasourceItem;
	    public IParamsBase RenderingParameters => AgentContext.RenderingParameters;
	    public ISitecoreContext SitecoreContext => AgentContext.SitecoreContext;
        
		public TViewModel ViewModel { get; protected set; }
        public string ViewPath => ViewModel.ViewPath;

		public virtual void Initialize(AgentContext agentContext)
		{
			if (agentContext == null) throw new ArgumentNullException(nameof(agentContext));
			AgentContext = agentContext;

			ViewModel = new TViewModel
			{
				ContextPage = AgentContext.ContextPage,
				ParentPlaceholderName = AgentContext.PlaceholderName
			};
			ViewModelDataBinder.DataBind(ViewModel, Datasource);
		}

	    public abstract void PopulateModel();
	}
}
