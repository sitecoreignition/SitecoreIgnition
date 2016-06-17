
namespace Ignition.Core
{
   public interface ISiteSearchProvider
   {
      string GetResults(string queryString, int pageOffset, int pageSize);
   }
}
