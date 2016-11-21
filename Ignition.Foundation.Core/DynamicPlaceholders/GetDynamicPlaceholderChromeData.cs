//Code credit to Stack Overflow user Dunston - http://stackoverflow.com/questions/15134720/sitecore-dynamic-placeholders-with-mvc

using System;
using System.Text.RegularExpressions;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetChromeData;
using Sitecore.Web.UI.PageModes;
using Debug = System.Diagnostics.Debug;

namespace Ignition.Foundation.Core.DynamicPlaceholders
{
    public class GetDynamicPlaceholderChromeData : GetChromeDataProcessor
    {
        //text that ends in a GUID
        private const string DynamicKeyRegex = @"(.+)_[\d\w]{8}\-([\d\w]{4}\-){3}[\d\w]{12}";

        public override void Process(GetChromeDataArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.IsNotNull(args.ChromeData, "Chrome Data");
            if (!"placeholder".Equals(args.ChromeType, StringComparison.OrdinalIgnoreCase)) return;
            var argument = args.CustomData["placeHolderKey"] as string;

            var placeholderKey = argument;
            var regex = new Regex(DynamicKeyRegex);
            Debug.Assert(placeholderKey != null, "placeholderKey != null");
            var match = regex.Match(placeholderKey);
            if (match.Success && match.Groups.Count > 0)
            {
                // Is a Dynamic Placeholder
                placeholderKey = match.Groups[1].Value;
            }
            else
            {
                return;
            }

            // Handles replacing the displayname of the placeholder area to the master reference
            if (args.Item == null) return;
            var layout = ChromeContext.GetLayout(args.Item);
            var item = Sitecore.Client.Page.GetPlaceholderItem(placeholderKey, args.Item.Database, layout);
            if (item != null)
            {
                args.ChromeData.DisplayName = item.DisplayName;
            }
            if ((item != null) && !string.IsNullOrEmpty(item.Appearance.ShortDescription))
            {
                args.ChromeData.ExpandedDisplayName = item.Appearance.ShortDescription;
            }
        }
    }
}
