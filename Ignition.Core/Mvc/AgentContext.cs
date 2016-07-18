using System;
using System.Web.Routing;
using Glass.Mapper.Sc;
using Ignition.Core.Models.BaseModels;
using Ignition.Core.Models.Page;

namespace Ignition.Core.Mvc
{
    public class AgentContext : RequestContext
    {
        public ISitecoreContext SitecoreContext { get; set; }

        public AgentContext(ISitecoreContext sitecoreContext)
        {
            if (sitecoreContext == null) throw new ArgumentNullException(nameof(sitecoreContext));
            SitecoreContext = sitecoreContext;
        }

        private IPage _homeItem;
        public IPage HomeItem => _homeItem ?? (_homeItem = SitecoreContext.GetHomeItem<IPage>(false, true));
        public string ModuleWrapperName { get; set; }
        public IPage ContextPage { get; set; }
        public IModelBase DatasourceItem { get; set; }
        public IParamsBase RenderingParameters { get; set; }
        public string PlaceholderName { get; set; }
        public object AgentParameters { get; set; }
    }
}
