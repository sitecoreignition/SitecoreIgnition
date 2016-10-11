using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Project.IgnitionDemo.Sc.Components.News
{
    [SitecoreType(TemplateId = "{97A78F81-BBBB-423D-857E-69F3270F3DCD}", AutoMap = true)]
    public interface ILatestNewsItem : IDateField1, IHeading, IPrimaryLink, IPlainText
    {     
    }
}