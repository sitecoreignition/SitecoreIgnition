using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Data.Fields;

namespace Ignition.Sc.Components.Hero
{
    [SitecoreType(TemplateId = "{97F58184-24C4-4296-979E-288AA210BC69}", AutoMap = true)]
    public interface ILinkedImage : IImage, IPrimaryLink
    {
    }
}
