using System;
using System.Web.Mvc;
using System.Web.Routing;
using Glass.Mapper.Sc.Web.Mvc;
using Ignition.Core.Factories;
using Ignition.Core.Models;
using Ignition.Core.Models.BaseModels;
using Ignition.Core.Models.Page;
using Ignition.Core.Repositories;

namespace Ignition.Core.Mvc
{
	public abstract class IgnitionController : GlassController
	{
		public IAgentFactory AgentFactory { get; set; }
		public IParamsBase RenderingParameters { get; set; }
		public IModelBase RenderingItem { get; set; } 
		protected ItemContext Context { get; set; }

		protected IgnitionController(ItemContext context) : base(context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));
			Context = context;
		}

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
			SitecoreContext = Context;
			if (RouteData.Values.ContainsKey(CoreConstants.SitecoreFallThroughRoute))
				Context.DatasourceItem = GetLayoutItem<IModelBase>(false, true) ?? new NullModel();
			else
                Context.DatasourceItem = new NullModel();
			Context.RenderingParameters = new NullParams();
		}

		#region View Overloads

		protected ViewResult View<TViewModel>() where TViewModel : BaseViewModel, new()
		{
			return View<SimpleAgent<TViewModel>, TViewModel, NullParams>(null);
		}

		protected ViewResult View<TAgent, TViewModel>()
			where TAgent : Agent<TViewModel>
			where TViewModel : BaseViewModel, new()
		{
			return View<TAgent, TViewModel, NullParams>(null);
		}

		protected ViewResult View<TAgent, TViewModel>(object agentParameters)
			where TAgent : Agent<TViewModel>
			where TViewModel : BaseViewModel, new()
		{
			return View<TAgent, TViewModel, NullParams>(agentParameters);
		}

	    protected ViewResult View<TAgent, TViewModel, TParams>()
	        where TAgent : Agent<TViewModel>
	        where TViewModel : BaseViewModel, new()
	        where TParams : class, IParamsBase
	    {
            return View<TAgent, TViewModel, TParams>(null);
        }

	    protected ViewResult View<TAgent, TViewModel, TParams>(object agentParameters)
			where TAgent : Agent<TViewModel>
			where TViewModel : BaseViewModel, new()
			where TParams : class, IParamsBase 
		{
			var moduleName = GetType().Name.Replace(GetType().Namespace ?? string.Empty, string.Empty).Replace("Controller", string.Empty);

		    Context.ContextPage = GetContextItem<IPage>(true, true);
		    Context.ModuleWrapperName = moduleName;
		    Context.RenderingParameters = GetRenderingParameters<TParams>();
		    Context.AgentParameters = agentParameters;
			var agent = AgentFactory.CreateAgent<TAgent, TViewModel>(Context);
			agent.PopulateModel();
			return View(agent.ViewPath, agent.ViewModel);
		}
		#endregion

	}
}
