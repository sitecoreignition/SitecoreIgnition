using Ignition.Core.Mvc;

namespace Ignition.Sc.Components.Service
{
    public class ServiceAgent : Agent<ServiceGridViewModel>
    {
        public override void PopulateModel()
        {
            var ds = (IServiceGrid) Datasource;
            if (ds == null) return;

            ViewModel.ServiceCards = ds.ServiceCards;
        }
    }
}