using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using System.Web.Routing;
using Glass.Mapper.Sc.Web.Mvc;
using Ignition.Core.Factories;
using Ignition.Core.Models.BaseModels;
using Ignition.Core.Models.Page;
using Ignition.Core.Repositories;

namespace Ignition.Core.Mvc
{
	public abstract class IgnitionController : GlassController
	{
		[Import]
		public IAgentFactory AgentFactory { get; set; }
		public IParamsBase RenderingParameters { get; set; }
		public IModelBase RenderingItem { get; set; }
		protected AgentContext AgentContext { get; set; }

		protected IgnitionController(AgentContext agentContext) : base(agentContext)
		{
			if (agentContext == null) throw new ArgumentNullException(nameof(agentContext));
			AgentContext = agentContext;
		}

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
			SitecoreContext = AgentContext;
			if (RouteData.Values.ContainsKey(CoreConstants.SitecoreFallThroughRoute))
				AgentContext.DatasourceItem = GetLayoutItem<IModelBase>(false, true) ?? new NullModel();
			else
				AgentContext.DatasourceItem = new NullModel();
			AgentContext.RenderingParameters = new NullParams();
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

			AgentContext.ContextPage = GetContextItem<IPage>(true, true);
			AgentContext.ModuleWrapperName = moduleName;
			AgentContext.RenderingParameters = GetRenderingParameters<TParams>();
			AgentContext.AgentParameters = agentParameters;
			var agent = AgentFactory.CreateAgent<TAgent, TViewModel>(AgentContext);
			agent.PopulateModel();
			return View(agent.ViewPath, agent.ViewModel);
		}
		#endregion

	}
}
