using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;

namespace Ignition.Data.ExtensionMethods
{
    public static class IgnitionExtensions
    {
        public static Guid ToGuid(this string id)
        {
            Guid test;
            return Guid.TryParse(id, out test) ? test : Guid.Empty;
        }
        public static ID ToId(this string id)
        {
            return id.ToGuid().ToId();
        }
        public static ID ToId(this Guid id)
        {
            return new ID(id);
        }

        public static bool IsEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        public static string UrlEncode(this string text)
        {
            return HttpUtility.UrlEncode(text);
        }

        public static string UrlDecode(this string text)
        {
            return HttpUtility.UrlDecode(text);
        }

        public static Item[] MultiSelectValues(this string values, string databaseName)
        {
            var db = Factory.GetDatabase(databaseName);
            var items = values.Split('|');
            return items.Select(a => db.GetItem(a.ToId())).ToArray();
        }
        public static IEnumerable<TemplateItem> GetAllMasters(this Item item)
        {
            return TemplateManager.GetTemplate(item).GetBaseTemplates().Cast<TemplateItem>();
        }
    }
}
