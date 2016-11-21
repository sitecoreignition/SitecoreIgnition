using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Mvc;

namespace Ignition.Foundation.Core.Contracts
{
	public interface IViewModelDataBinder
	{
		void DataBind(IgnitionViewModel viewModel, IModelBase dataSource);
	}
}
