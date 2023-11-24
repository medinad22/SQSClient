using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQSClient.Interfaces;

namespace SQSClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqsController : ControllerBase
    {
        private readonly ISQSService _sqsService;

        public SqsController(ISQSService sqsService)
        {
            _sqsService = sqsService;
        }

        [HttpGet]
        public async Task Get()
        {
            await _sqsService.SendSqsLocalStack();
        }
    }
}
