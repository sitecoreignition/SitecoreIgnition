using System;
using System.Web.Mvc;
using Glass.Mapper.Sc;
using Ignition.Core.Models.BaseModels;
using Ignition.Core.Models.Page;

namespace Ignition.Core.Mvc
{
    public class AgentContext : ControllerContext
    {
        public ISitecoreContext SitecoreContext { get; set; }

        public object AgentParameters { get; set; }
        public IPage ContextPage { get; set; }
        public IModelBase DatasourceItem { get; set; }
        public string PlaceholderName { get; set; }
        public IParamsBase RenderingParameters { get; set; }

        private IPage _homeItem;
        public IPage HomeItem => _homeItem ?? (_homeItem = SitecoreContext.GetHomeItem<IPage>(false, true));

        public string ModuleWrapperName => Controller?.GetType().Name.Replace("Controller", string.Empty);

        public AgentContext(ControllerContext controllerContext, ISitecoreContext sitecoreContext, IPage contextPage, IModelBase datasourceItem)
            : base(controllerContext)
        {
            if (sitecoreContext == null) throw new ArgumentNullException(nameof(sitecoreContext));
            if (contextPage == null) throw new ArgumentNullException(nameof(contextPage));
            if (datasourceItem == null) throw new ArgumentNullException(nameof(datasourceItem));
            SitecoreContext = sitecoreContext;
            ContextPage = contextPage;
            DatasourceItem = datasourceItem;
        }

        public AgentContext(AgentContext agentContext, IModelBase datasource = null)
            : base(agentContext)
        {
            SitecoreContext = agentContext.SitecoreContext;
            AgentParameters = agentContext.AgentParameters;
            ContextPage = agentContext.ContextPage;
            DatasourceItem = datasource ?? agentContext.DatasourceItem;
            PlaceholderName = agentContext.PlaceholderName;
            RenderingParameters = agentContext.RenderingParameters;
        }
    }
}
