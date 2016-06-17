using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ignition.Sc.Components.Bases;
using Ignition.Sc.Components.MVC;

namespace Ignition.Sc.Components
{
    public class NewComponentViewModel : AbstractViewModel
    {
        public NewComponentViewModel(IRepository repository) : base(repository)
        {
        }

        public override string ViewPath { get; set; }
    }
}
