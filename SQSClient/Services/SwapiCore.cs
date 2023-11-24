using SQSClient.Interfaces;
using SQSClient.Models;
using SQSClient.Rest;

namespace SQSClient.Services
{
    public class SwapiCore : ISwapiCore
    {

        private readonly ISwapi _swapi;

        private readonly ISQSService _sqsService;

        public SwapiCore(ISwapi swapi, ISQSService sqsService)
        {
            _swapi = swapi;
            _sqsService = sqsService;
        }

        public async Task SyncPeople()
        {
            var page = 1;
            var people = new List<Person>();
            do
            {
                people = new List<Person>();
                people = await _swapi.GetPeople(page);

                if (people != null)
                {
                    people.ForEach(async person => { Console.WriteLine(person.Name); await _sqsService.SendSqsPersonagem(person); });
                }

                page++;


            } while (people == null || people.Any());
        }
    }
}
