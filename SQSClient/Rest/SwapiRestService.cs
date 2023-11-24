using SQSClient.Models;
using System.Text.Json;

namespace SQSClient.Rest
{
    public class SwapiRestService : ISwapi 
    {
        public async Task<List<Person>> GetPeople()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://swapi.dev/api/people");
            using (var httpClient = new HttpClient())
            {
                var responseSwapi = await httpClient.SendAsync(request);
                if (responseSwapi.IsSuccessStatusCode)
                {
                    var contentResp = await responseSwapi.Content.ReadAsStringAsync();


                    var options = new JsonSerializerOptions()
                    {
                        IncludeFields = true,
                    };
                    var objResponse = JsonSerializer.Deserialize<SwapiData>(contentResp, options);
                    return objResponse is null || objResponse.Results is null? new List<Person>() : objResponse.Results;
                }

                return new List<Person>();

                

            }
        }

        public async Task<List<Person>> GetPeople(int page)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://swapi.dev/api/people?page={page}");
            using (var httpClient = new HttpClient())
            {
                var responseSwapi = await httpClient.SendAsync(request);
                if (responseSwapi.IsSuccessStatusCode)
                {
                    var contentResp = await responseSwapi.Content.ReadAsStringAsync();


                    var options = new JsonSerializerOptions()
                    {
                        IncludeFields = true,
                    };
                    var objResponse = JsonSerializer.Deserialize<SwapiData>(contentResp, options);
                    return objResponse is null || objResponse.Results is null ? new List<Person>() : objResponse.Results;
                }

                return new List<Person>();

            }
        }

        public async Task<Person> GetPerson()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://swapi.dev/api/people/1");
            using (var httpClient = new HttpClient())
            {
                var responseSwapi = await httpClient.SendAsync(request);
                var contentResp = await responseSwapi.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions()
                {
                    IncludeFields = true,
                };
                var objResponse = JsonSerializer.Deserialize<Person>(contentResp, options);
                return objResponse;

            }
        }
    }
}
