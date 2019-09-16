using System.Threading.Tasks;

namespace DevSpaceInterceptor.Front.Services
{
  public interface IBackHttpClient
  {
    Task<string> GetValueAsync(int id);
  }
}