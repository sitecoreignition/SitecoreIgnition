using Ignition.Core.Mvc;
using Ignition.Core.Repositories;
using SimpleInjector;

namespace Ignition.Core.Factories
{
	public class SimpleInjectorAgentFactory : IAgentFactory
	{
		private readonly Container _container;

		public SimpleInjectorAgentFactory(Container container)
		{
			_container = container;
		}

		public TViewAgent CreateAgent<TViewAgent, TViewModel>(AgentContext agentContext)
			where TViewAgent : Agent<TViewModel> where TViewModel : BaseViewModel, new()
		{
			var agent = _container.GetInstance<TViewAgent>();
			agent.Initialize(agentContext);
			return agent;
		}
	}
}
