using Ignition.Core.Models.BaseModels;

namespace Ignition.Core.Mvc
{
	public interface IViewModelDataBinder
	{
		void DataBind(BaseViewModel viewModel, IModelBase dataSource);
	}
}
