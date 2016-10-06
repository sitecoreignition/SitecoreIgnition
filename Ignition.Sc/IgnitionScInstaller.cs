using Ignition.Core.Mvc;
using Ignition.Core.SimpleInjector;
using Ignition.FormIgnition.Sc.Contracts;
using Ignition.FormIgnition.Sc.Contracts.Form;
using Ignition.FormIgnition.Sc.Contracts.Form.Request;
using Ignition.FormIgnition.Sc.Contracts.Form.Submit;
using SimpleInjector;

namespace Ignition.Sc
{
	public class IgnitionScInstaller : SimpleInjectorInstaller
	{
		public override void Install(Container container)
		{
			container.RegisterMvcControllers(ThisAssembly);
			container.RegisterAllConcreteTypesFor(typeof(Agent<>), ThisAssembly, Lifestyle.Transient);
			container.RegisterAllConcreteTypesFor(typeof(IFormHtmlProcessor), ThisAssembly, Lifestyle.Transient);
			container.RegisterAllConcreteTypesFor(typeof(IFormDataProvider), ThisAssembly, Lifestyle.Transient);
			container.RegisterAllConcreteTypesFor(typeof(IFormFailedSubmitProcessor), ThisAssembly, Lifestyle.Transient);
			container.RegisterAllConcreteTypesFor(typeof(IFormDataProcessor), ThisAssembly, Lifestyle.Transient);
			container.RegisterAllConcreteTypesFor(typeof(IFormSubmissionProvider), ThisAssembly, Lifestyle.Transient);
			container.RegisterAllConcreteTypesFor(typeof(IFormConfiguration), ThisAssembly, Lifestyle.Transient);
			container.RegisterAllConcreteTypesFor(typeof(IFormRuleAction), ThisAssembly, Lifestyle.Transient);
			container.RegisterAllConcreteTypesFor(typeof(IFormRuleCondition), ThisAssembly, Lifestyle.Transient);
			container.RegisterAllConcreteTypesFor(typeof(IFormAuthentication), ThisAssembly, Lifestyle.Transient);
			container.RegisterAllConcreteTypesFor(typeof(IPersonalizationDataConsumerProvider), ThisAssembly, Lifestyle.Transient);
			container.RegisterAllConcreteTypesFor(typeof(IPersonalizationDataUpdateProvider), ThisAssembly, Lifestyle.Transient);
		}
	}
}
