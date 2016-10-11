using Ignition.Foundation.Core.Bases;

namespace Ignition.Foundation.Core.Repositories
{
    public sealed class WebDatabaseType : IDatabaseType
    {
        public string GetDatabaseName()
        {
            return "web";
        }
    }
}