using Ignition.Foundation.Core.Mvc;

namespace Ignition.Foundation.Core.Factories
{
	public interface IAgentFactory
	{
		TViewAgent CreateAgent<TViewAgent, TViewModel>(AgentContext agentContext)
			where TViewAgent : Agent<TViewModel>
			where TViewModel : BaseViewModel, new();
	}
}
