using Glass.Mapper.Sc;
using Ignition.Core.Bases;

namespace Ignition.Core.Factories
{
    public class SitecoreServiceFactory : ISitecoreServiceFactory
    {
        public ISitecoreService GetSitecoreService<T>() where T : IDatabaseType, new()
        {
            var databaseType = new T();
            return new SitecoreService(databaseType.GetDatabaseName());
        }
    }
}
