using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.BaseModels.Concrete;
using Ignition.Foundation.Core.Models.Page;

namespace Ignition.Foundation.Core.Mvc
{
    public abstract class IgnitionController : GlassController
    {
        [Import]
        public IAgentFactory AgentFactory { get; set; }

        [Import]
        public ISitecoreServiceFactory SitecoreServiceFactory { get; set; }

        public IgnitionControllerContext IgnitionControllerContext => new IgnitionControllerContextFactory().GetInstance(ControllerContext, SitecoreContext);

	    #region View Overloads
        protected ViewResult View<TViewModel>() where TViewModel : IgnitionViewModel, new()
        {
            return View<SimpleAgent<TViewModel>, TViewModel, NullParams>(null);
        }

        protected ViewResult View<TAgent, TViewModel>()
          where TAgent : Agent<TViewModel>
          where TViewModel : IgnitionViewModel, new()
        {
            return View<TAgent, TViewModel, NullParams>(null);
        }

        protected ViewResult View<TAgent, TViewModel>(object agentParameters)
          where TAgent : Agent<TViewModel>
          where TViewModel : IgnitionViewModel, new()
        {
            return View<TAgent, TViewModel, NullParams>(agentParameters);
        }

        protected ViewResult View<TAgent, TViewModel, TParams>()
            where TAgent : Agent<TViewModel>
            where TViewModel : IgnitionViewModel, new()
            where TParams : class, IParamsBase
        {
            return View<TAgent, TViewModel, TParams>(null);
        }

        protected ViewResult View<TAgent, TViewModel, TParams>(object agentParameters)
            where TAgent : Agent<TViewModel>
            where TViewModel : IgnitionViewModel, new()
            where TParams : class, IParamsBase
        {
            var contextPage = GetContextItem<IPage>(true, true) ?? new NullPage();
            var datasourceItem = GetDataSourceItem();
            var renderingParameters = GetRenderingParameters<TParams>();
            var agentContext = new AgentContext(IgnitionControllerContext, SitecoreContext, contextPage, datasourceItem)
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
            where TViewModel : IgnitionViewModel, new()
        {
            var agentContext = new AgentContext(IgnitionControllerContext, SitecoreContext, new NullPage(), SitecoreContext.GetItem<IModelBase>(itemId))
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
            if (RouteData.Values.ContainsKey(FoundationCoreConstants.SitecoreFallThroughRoute))
            {
                return GetLayoutItem<IModelBase>(false, true) ?? new NullModel();
            }
            return new NullModel();
        }
    }
}
