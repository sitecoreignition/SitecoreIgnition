using Glass.Mapper.Sc;
using Ignition.Foundation.Core.Bases;

namespace Ignition.Foundation.Core.Contracts
{
    public interface ISitecoreServiceFactory
    {
        ISitecoreService GetSitecoreService<T>() where T : IDatabaseType, new();
    }
}
