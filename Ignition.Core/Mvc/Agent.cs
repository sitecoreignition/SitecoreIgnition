using System;
using System.ComponentModel.Composition;
using Glass.Mapper.Sc;
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
