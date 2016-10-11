using Glass.Mapper.Sc;
using Ignition.Foundation.Core.Bases;

namespace Ignition.Foundation.Core.Factories
{
    public interface ISitecoreServiceFactory
    {
        ISitecoreService GetSitecoreService<T>() where T : IDatabaseType, new();
    }
}
