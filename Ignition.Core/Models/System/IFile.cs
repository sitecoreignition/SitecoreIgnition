using System.IO;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Models.System
{
    [SitecoreType(TemplateId = "{962B53C4-F93B-4DF9-9821-415C867B8903}", AutoMap = true)]
    public interface IFile : IModelBase
    {
        [SitecoreField("Mime Type")]
        string MimeType { get; set; }

        [SitecoreField("__Icon")]
        string Icon { get; set; }

        Stream Blob { get; set; }
        string Extension { get; set; }
        int Size { get; set; }
    }
}
