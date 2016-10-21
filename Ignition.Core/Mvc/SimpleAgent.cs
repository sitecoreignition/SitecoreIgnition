namespace Ignition.Foundation.Core.Mvc
{
    public class SimpleAgent<TViewModel> : Agent<TViewModel> where TViewModel : IgnitionViewModel, new()
    {
        public override void PopulateModel()
        {
        }
    }
}