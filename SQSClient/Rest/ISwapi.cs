using SQSClient.Models;

namespace SQSClient.Rest
{
    public interface ISwapi
    {

        Task<List<Person>> GetPeople();

        Task<List<Person>> GetPeople(int page);

        Task<Person> GetPerson();
    }
}
