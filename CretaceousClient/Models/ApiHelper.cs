using System.Threading.Tasks;
using RestSharp;

namespace CretaceousClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5001/api");
      RestRequest request = new RestRequest($"animals", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5001/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.GET);

      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals", Method.POST);
      //Whenever making an API request that modifies the database it needs a headder and a body. This way the API can recognize the data type it receives and registers and argument for the controller route.
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newAnimal);
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}