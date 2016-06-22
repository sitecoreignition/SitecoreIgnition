using Ignition.Core.Bases;

namespace Ignition.Core
{
    public sealed class MasterDatabaseType : IDatabaseType
    {
        public string GetDatabaseName()
        {
            return CoreConstants.Master;
        }
    }
}