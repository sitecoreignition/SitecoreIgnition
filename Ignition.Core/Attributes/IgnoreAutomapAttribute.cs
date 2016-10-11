using System;

namespace Ignition.Foundation.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Interface)]
    public class IgnoreAutomapAttribute : Attribute
    {
    }
}
