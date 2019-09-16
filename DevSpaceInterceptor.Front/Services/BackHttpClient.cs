using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevSpaceInterceptor.Front.Services
{
  public class BackHttpClient : IBackHttpClient
  {
    private readonly HttpClient client;

    public BackHttpClient(HttpClient client)
    {
      this.client = client;
    }

    public async Task<string> GetValueAsync(int id)
    {
      var response = await client.GetAsync($"api/values/{id}");
      if (response.IsSuccessStatusCode)
      {
        var result = await response.Content.ReadAsStringAsync();
        return result;
      }
      else
      {
        throw new Exception($"Value with id {id} could not be retrieved: {response.ReasonPhrase}");
      }
    }
  }
}
