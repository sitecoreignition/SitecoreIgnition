using System;
using Castle.MicroKernel;
using Ignition.Core.Mvc;
using Ignition.Core.Repositories;

namespace Ignition.Core.Factories
{
    public class WindsorAgentFactory : IAgentFactory
    {
		private readonly IKernel _kernel;

		public WindsorAgentFactory(IKernel kernel)
		{
			if (kernel == null) throw new ArgumentNullException(nameof(kernel));
			_kernel = kernel;
		}

		public TViewAgent CreateAgent<TViewAgent, TViewModel>(ItemContext context)
		  where TViewAgent : Agent<TViewModel>
		  where TViewModel : BaseViewModel, new()
		{
			var agent = _kernel.Resolve<TViewAgent>();
			agent.Initialize(context);
			_kernel.ReleaseComponent(agent);
			return agent;
		}
    }
}
