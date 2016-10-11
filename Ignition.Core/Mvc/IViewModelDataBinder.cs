using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Mvc
{
	public interface IViewModelDataBinder
	{
		void DataBind(BaseViewModel viewModel, IModelBase dataSource);
	}
}
