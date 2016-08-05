using System.Web.Mvc;
using Glass.Mapper.Sc;

namespace Ignition.Core.Mvc
{
    public class IgnitionControllerContext : ControllerContext
    {
        public ISitecoreContext Context { get; set; }
        public IgnitionControllerContext(ISitecoreContext context)
        {
            Context = context;
        }
    }
}
