using Ignition.Core.Bases;
using Ignition.Core.Constants;

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