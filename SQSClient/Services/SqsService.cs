using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Newtonsoft.Json;
using SQSClient.Interfaces;
using SQSClient.Models;

namespace SQSClient.Services
{
    public class SqsService : ISQSService
    {

        private static readonly string SecretKey = "ignore";
        private static readonly string AccessKey = "ignore";
        private static readonly string ServiceUrl = "http://localhost.localstack.cloud:4566";
        private static readonly string QueueUrl = "http://sqs.sa-east-1.localhost.localstack.cloud:4566/000000000000/teste";
        private static readonly string QueuePersonagemUrl = "http://sqs.sa-east-1.localhost.localstack.cloud:4566/000000000000/personagem";
        public async Task SendSqsLocalStack()
        {
            var message = "1234";
            var awsCreds = new BasicAWSCredentials(AccessKey, SecretKey);
            var config = new AmazonSQSConfig
            {
                ServiceURL = ServiceUrl,
                //RegionEndpoint = RegionEndpoint.SAEast1
            };
            var amazonSqsClient = new AmazonSQSClient(config);
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = QueueUrl,
                MessageBody = message
            };
            await amazonSqsClient.SendMessageAsync(sendMessageRequest);

        }


        public async Task SendSqsPersonagem(Person person)
        {
            var message = JsonConvert.SerializeObject(person);
            var awsCreds = new BasicAWSCredentials(AccessKey, SecretKey);
            var config = new AmazonSQSConfig
            {
                ServiceURL = ServiceUrl,
                //RegionEndpoint = RegionEndpoint.SAEast1
            };
            var amazonSqsClient = new AmazonSQSClient(config);
            var sendMessageRequest = new SendMessageRequest
            {
                QueueUrl = QueuePersonagemUrl,
                MessageBody = message
            };
            await amazonSqsClient.SendMessageAsync(sendMessageRequest);

        }
    }
}
