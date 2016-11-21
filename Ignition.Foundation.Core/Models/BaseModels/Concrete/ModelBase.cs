using System;
using Sitecore.Data;
using Sitecore.Globalization;

namespace Ignition.Foundation.Core.Models.BaseModels.Concrete
{
    public class ModelBase : IModelBase
    {
        public virtual Guid Id { get; set; }
        public virtual Language Language { get; set; }
        public virtual ItemUri Uri { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual int Version { get; set; }
        public virtual string Path { get; set; }
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
    }
}
