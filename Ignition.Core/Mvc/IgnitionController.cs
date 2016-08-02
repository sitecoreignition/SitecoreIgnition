using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Ignition.Core.Factories;
using Ignition.Core.Models.BaseModels;
using Ignition.Core.Models.Page;

namespace Ignition.Core.Mvc
{
    public abstract class IgnitionController : GlassController
    {
        [Import]
        public IAgentFactory AgentFactory { get; set; }

        [Import]
        public ISitecoreServiceFactory SitecoreServiceFactory { get; set; }

        public IgnitionControllerContext IgnitionControllerContext
        {
            get
            {
                var context = (IgnitionControllerContext)ControllerContext;
                context.Context = SitecoreContext;
                return context;
            }
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
            var contextPage = GetContextItem<IPage>(true, true) ?? new NullPage();
            var datasourceItem = GetDataSourceItem();
            var renderingParameters = GetRenderingParameters<TParams>();
            var agentContext = new AgentContext(IgnitionControllerContext, contextPage, datasourceItem)
            {
                AgentParameters = agentParameters,
                RenderingParameters = renderingParameters
            };

            var agent = AgentFactory.CreateAgent<TAgent, TViewModel>(agentContext);
            agent.PopulateModel();

            return View(agent.ViewPath, agent.ViewModel);
        }
        #endregion
        #region Json Overloads
        protected JsonResult Json<TAgent, TViewModel, TRequestData>(Guid itemId, TRequestData agentParameters)
            where TAgent : Agent<TViewModel>
            where TViewModel : BaseViewModel, new()
        {
            var agentContext = new AgentContext(IgnitionControllerContext, new NullPage(), SitecoreContext.GetItem<IModelBase>(itemId))
            {
                AgentParameters = agentParameters,
            };
            var agent = AgentFactory.CreateAgent<TAgent, TViewModel>(agentContext);
            agent.PopulateModel();

            return Json(agent.ViewModel);
        }
        #endregion

        protected IModelBase GetDataSourceItem()
        {
            if (RouteData.Values.ContainsKey(CoreConstants.SitecoreFallThroughRoute))
            {
                return GetLayoutItem<IModelBase>(false, true) ?? new NullModel();
            }
            return new NullModel();
        }
    }
}
