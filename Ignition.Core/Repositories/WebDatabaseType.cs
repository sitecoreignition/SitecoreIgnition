using Ignition.Core.Bases;

namespace Ignition.Core.Repositories
{
    public sealed class WebDatabaseType : IDatabaseType
    {
        public string GetDatabaseName()
        {
            return "web";
        }
    }
}