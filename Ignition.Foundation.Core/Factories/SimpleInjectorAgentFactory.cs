using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Mvc;
using SimpleInjector;

namespace Ignition.Foundation.Core.Factories
{
	public class SimpleInjectorAgentFactory : IAgentFactory
	{
		private readonly Container _container;

		public SimpleInjectorAgentFactory(Container container)
		{
			_container = container;
		}

		public TViewAgent CreateAgent<TViewAgent, TViewModel>(AgentContext agentContext)
			where TViewAgent : Agent<TViewModel> where TViewModel : IgnitionViewModel, new()
		{
			var agent = _container.GetInstance<TViewAgent>();
			agent.Initialize(agentContext);
			return agent;
		}
	}
}
