using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Glass.Mapper.Sc.Web.Mvc;
using Ignition.Core.Factories;
using Ignition.Core.Models;
using Ignition.Core.Repositories;

namespace Ignition.Core.Mvc
{
	public abstract class BaseController : GlassController
	{
		public IAgentFactory AgentFactory { get; set; }
		public IParamsBase RenderingParameters { get; set; }
		public IModelBase RenderingItem { get; set; } 
		protected ItemContext Context { get; set; }

		protected BaseController(ItemContext context) : base(context)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));
			Context = context;
		}

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
			SitecoreContext = Context;
			if (RouteData.Values.ContainsKey(Constants.CoreConstants.SitecoreFallThroughRoute))
				Context.DatasourceItem = GetLayoutItem<IModelBase>(false, true) ?? new NullModel();
			else
                Context.DatasourceItem = new NullModel();
			Context.RenderingParameters = new NullParams();
		}

		public override ActionResult Index()
		{
			return null;
		}

		#region GetViewResult Overloads

		protected ActionResult GetViewResult<TViewModel>() where TViewModel : BaseViewModel, new()
		{
			return GetViewResult<SimpleAgent<TViewModel>, TViewModel, NullParams>(new NullParams(), null);
		}

		protected ActionResult GetViewResult<TViewModel>(Dictionary<string, object> data) where TViewModel : BaseViewModel, new()
		{
			return GetViewResult<SimpleAgent<TViewModel>, TViewModel, NullParams>(new NullParams(), data);
		}

		protected ActionResult GetViewResult<TAgent, TViewModel>()
			where TAgent : Agent<TViewModel>
			where TViewModel : BaseViewModel, new()
		{
			return GetViewResult<TAgent, TViewModel, NullParams>(new NullParams(), null);
		}

		protected ActionResult GetViewResult<TAgent, TViewModel, TParams>(TParams param)
			where TAgent : Agent<TViewModel>
			where TViewModel : BaseViewModel, new()
			where TParams : IParamsBase
		{
			return GetViewResult<TAgent, TViewModel, TParams>(param, null);
		}

		protected ActionResult GetViewResult<TAgent, TViewModel>(Dictionary<string, object> data)
			where TAgent : Agent<TViewModel>
			where TViewModel : BaseViewModel, new()
		{
			return GetViewResult<TAgent, TViewModel, NullParams>(new NullParams(), data);
		}

		protected ActionResult GetViewResult<TAgent, TViewModel, TParams>(TParams parameters, Dictionary<string, object> viewdata)
			where TAgent : Agent<TViewModel>
			where TViewModel : BaseViewModel, new()
			where TParams : IParamsBase
		{
			var moduleName = GetType().Name.Replace(GetType().Namespace ?? string.Empty, string.Empty).Replace("Controller", string.Empty);

		    Context.ContextPage = GetContextItem<IPage>(true, true);
		    Context.ModuleWrapperName = moduleName;
		    Context.RenderingParameters = parameters;
		    Context.ViewData = viewdata;
			var agent = AgentFactory.CreateAgent<TAgent, TViewModel>(Context);
			agent.PopulateModel();
			return View(agent.ViewPath, agent.ViewModel);
		}

		#endregion
	}
}
