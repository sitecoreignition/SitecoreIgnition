using Ignition.Core.Bases;

namespace Ignition.Core.Repositories
{
    public sealed class MasterDatabaseType : IDatabaseType
    {
        public string GetDatabaseName()
        {
            return "master";
        }
    }
}