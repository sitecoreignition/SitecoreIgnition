using System.ComponentModel.Composition;
using Glass.Mapper.Sc;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.BaseModels.Concrete;
using Ignition.Foundation.Core.Models.Page;

namespace Ignition.Foundation.Core.Mvc
{
    public class AgentContext : IgnitionControllerContext
    {
        [Import]
        public ISitecoreContext SitecoreContext { get; set; }

        public object AgentParameters { get; set; }
        public IPage ContextPage { get; set; }
        public IModelBase DatasourceItem { get; set; }
        public string PlaceholderName { get; set; }
        public IParamsBase RenderingParameters { get; set; } = new NullParams();

        private IPage _homeItem;
        public IPage HomeItem => _homeItem ?? (_homeItem = SitecoreContext.GetHomeItem<IPage>(false, true));

        public string ModuleWrapperName => Controller?.GetType().Name.Replace("Controller", string.Empty);

        public AgentContext(IgnitionControllerContext controllerContext, ISitecoreContext sitecoreContext, IPage contextPage, IModelBase datasourceItem, object agentParameters = null)
            : base(controllerContext, sitecoreContext)
        {
            DatasourceItem = datasourceItem ?? new NullModel();
            AgentParameters = agentParameters;
            ContextPage = contextPage ?? new NullPage();
        }
    }
}
