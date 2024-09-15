using Microsoft.AspNetCore.Mvc;
using Waddabha.BL.Managers.Messages;

namespace Waddabha.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class MessagesController : ControllerBase
    {
        private readonly IMessageManager _messageManager;

        public MessagesController(IMessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        [HttpGet("{senderId}/{receiverId}")]
        public async Task<IActionResult> GetMessages(string senderId, string receiverId)
        {
            var messages = await _messageManager.GetMessagesAsync(senderId, receiverId);
            return Ok(messages);
        }
    }

}

