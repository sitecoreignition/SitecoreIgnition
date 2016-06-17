using Ignition.Core.Bases;
using Ignition.Core.Constants;

namespace Ignition.Core
{
    public sealed class WebDatabaseType : IDatabaseType
    {
        public string GetDatabaseName()
        {
            return CoreConstants.Web;
        }
    }
}