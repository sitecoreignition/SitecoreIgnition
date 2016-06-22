using Ignition.Core.Bases;

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