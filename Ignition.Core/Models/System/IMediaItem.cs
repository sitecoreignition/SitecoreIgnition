using Glass.Mapper.Sc.Configuration.Attributes;

namespace Ignition.Foundation.Core.Models.System
{
    [SitecoreType(TemplateId = "{F1828A2C-7E5D-4BBD-98CA-320474871548}", AutoMap = true)]
    public interface IMediaItem : IFile
    {
        string Alt { get; set; }
        string Width { get; set; }
        string Height { get; set; }
        string Dimensions { get; set; }
    }
}
