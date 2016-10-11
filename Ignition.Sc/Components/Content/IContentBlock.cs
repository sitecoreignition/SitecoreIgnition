using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Data.Fields;

namespace Ignition.Project.IgnitionDemo.Sc.Components.Content
{
	[SitecoreType(TemplateId = "{D2C513B3-9CA7-490F-A1ED-58505B7B9CA1}", AutoMap = true)]
	public interface IContentBlock : IHeading, ICopy1
	{
	}
}
