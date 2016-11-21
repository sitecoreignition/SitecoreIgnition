using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Globalization;

namespace Ignition.Foundation.Core.Models.BaseModels.Concrete
{
    public class NullModel : IModelBase
    {
        public string FullPath
        {
            get { return "/"; }
            set { throw new NotImplementedException(); }
        }

        public string FullUrl
        {
            get { return string.Empty; }
            set { throw new NotImplementedException(); }
        }

        public Guid TemplateId
        {
            get { return Id; }
            set { throw new NotImplementedException(); }
        }

        public string TemplateName
        {
            get { return string.Empty; }
            set { throw new NotImplementedException(); }
        }

        public IEnumerable<IModelBase> BaseChildren
        {
            get { return new List<IModelBase>(); }
            set { throw new NotImplementedException(); }
        }

        public IModelBase Parent
        {
            get { return new NullModel(); }
            set { throw new NotImplementedException(); }
        }

        public string Sortorder
        {
            get { return "0"; }
            set { throw new NotImplementedException(); }
        }

        public DateTime Created
        {
            get { return DateTime.MinValue; }
            set { throw new NotImplementedException(); }
        }

        public DateTime Updated
        {
            get { return DateTime.MinValue; }
            set { throw new NotImplementedException(); }
        }

        public int CompareTo(IModelBase other)
        {
            return 0;
        }

        public bool Equals(IModelBase other)
        {
            return other == null || other.Id == Guid.Empty;
        }

        public Guid Id
        {
            get { return Guid.Empty; }
            set { throw new NotImplementedException(); }
        }

        public Language Language
        {
            get { return Language.Current; }
            set { throw new NotImplementedException(); }
        }

        public string DisplayName
        {
            get { return "Null Item"; }
            set { throw new NotImplementedException(); }
        }

        public int Version
        {
            get { return -1; }
            set { throw new NotImplementedException(); }
        }

        public string Path
        {
            get { return "/"; }
            set { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return "Null Item"; }
            set { throw new NotImplementedException(); }
        }

        public string Url
        {
            get { return string.Empty; }
            set { throw new NotImplementedException(); }
        }
    }
}