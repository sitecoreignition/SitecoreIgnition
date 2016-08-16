using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Breadcrumb
{
    [SitecoreType(TemplateId = "{01C8C273-8BA6-44EB-9947-BEB3D2C29B4A}", AutoMap = true)]
    public interface IBreadcrumb : IHeading
    {
    }
}
