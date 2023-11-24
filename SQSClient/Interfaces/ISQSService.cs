using SQSClient.Models;

namespace SQSClient.Interfaces
{
    public interface ISQSService
    {

        Task SendSqsLocalStack();

        Task SendSqsPersonagem(Person person);
    }
}
