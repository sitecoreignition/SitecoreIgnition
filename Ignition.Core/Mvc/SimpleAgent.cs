namespace Ignition.Foundation.Core.Mvc
{
    public class SimpleAgent<TViewModel> : Agent<TViewModel> where TViewModel : BaseViewModel, new()
    {
        public override void PopulateModel()
        {
        }
    }
}