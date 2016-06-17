using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ignition.Sc.Components.Bases;
using Ignition.Sc.Components.MVC;

namespace Ignition.Sc.Components
{
    public class NewComponentAgent : AbstractViewAgent<AbstractViewModel>
    {
        public NewComponentAgent(IRepository repository, SitecoreData sitecoreData) : base(repository, sitecoreData)
        {
        }

        public override void PopulateModel()
        {

        }
    }
}
