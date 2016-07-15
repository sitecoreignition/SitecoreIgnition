using Glass.Mapper.Sc;
using Ignition.Core.Bases;

namespace Ignition.Core.Factories
{
    public interface ISitecoreServiceFactory
    {
        ISitecoreService GetSitecoreService<T>() where T : IDatabaseType, new();
    }
}
