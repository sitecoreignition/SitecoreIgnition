using System.Collections.Generic;
using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.Service
{
    public class ServiceGridViewModel : BaseViewModel
    {
        public IEnumerable<IServiceCard> ServiceCards { get; set; } 

        public IServiceGrid EditFrameItem { get; set; }
    }
}