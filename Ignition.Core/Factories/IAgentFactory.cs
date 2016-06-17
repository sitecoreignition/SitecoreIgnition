using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Core.Factories
{
	public interface IAgentFactory
	{
		TViewAgent CreateAgent<TViewAgent, TViewModel>(ItemContext context)
			where TViewAgent : Agent<TViewModel>
			where TViewModel : BaseViewModel, new();
	}
}
