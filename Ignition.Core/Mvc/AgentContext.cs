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

        public AgentContext(ControllerContext controllerContext, ISitecoreContext sitecoreContext)
            : base(controllerContext)
        {
            if (sitecoreContext == null) throw new ArgumentNullException(nameof(sitecoreContext));
            SitecoreContext = sitecoreContext;
        }
    }
}
