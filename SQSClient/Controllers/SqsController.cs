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
        private readonly ISwapiCore _swapiCore;

        public SqsController(ISQSService sqsService, ISwapiCore swapiCore)
        {
            _sqsService = sqsService;
            _swapiCore = swapiCore;
        }

        [HttpGet]
        public async Task Get()
        {
            await _sqsService.SendSqsLocalStack();
        }

        [HttpPost("syncPeople")]
        public async Task Sync()
        {
            await _swapiCore.SyncPeople();
        }
    }
}
