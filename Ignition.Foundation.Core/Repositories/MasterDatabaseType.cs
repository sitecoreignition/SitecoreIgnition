using Ignition.Foundation.Core.Bases;

namespace Ignition.Foundation.Core.Repositories
{
    public sealed class MasterDatabaseType : IDatabaseType
    {
        public string GetDatabaseName()
        {
            return "master";
        }
    }
}