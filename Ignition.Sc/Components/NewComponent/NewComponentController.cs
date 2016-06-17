using System.Web.Mvc;
using Ignition.Sc.Components.Bases;
using Ignition.Sc.Components.MVC;

namespace Ignition.Sc.Components
{
    public class NewComponentController : BaseController
    {
        public NewComponentController(IRepository repository) : base(repository)
        {
        }
    }
}
