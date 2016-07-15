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
            var agentContext = new AgentContext(ControllerContext, SitecoreContext)
            {
                ModuleWrapperName = GetType().Name.Replace(GetType().Namespace ?? string.Empty, string.Empty).Replace("Controller", string.Empty),
                ContextPage = GetContextItem<IPage>(true, true),
                RenderingParameters = GetRenderingParameters<TParams>(),
                AgentParameters = agentParameters
            };
            if (RouteData.Values.ContainsKey(CoreConstants.SitecoreFallThroughRoute))
                agentContext.DatasourceItem = GetLayoutItem<IModelBase>(false, true) ?? new NullModel();
            else
                agentContext.DatasourceItem = new NullModel();

            var agent = AgentFactory.CreateAgent<TAgent, TViewModel>(agentContext);
            agent.PopulateModel();

            return View(agent.ViewPath, agent.ViewModel);
        }

        #endregion
    }
}
