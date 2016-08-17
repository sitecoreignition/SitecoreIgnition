using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Data.Fields;


namespace Ignition.Sc.Components.Content
{
	[SitecoreType(TemplateId = "{D2C513B3-9CA7-490F-A1ED-58505B7B9CA1}", AutoMap = true)]
	public interface IContentBlock : IHeading, IRichContent1
	{
	}
}
