using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Waddabha.BL.DTOs.Messages;
using Waddabha.BL.Managers.Messages;
using Waddabha.DAL.Data.Models;

namespace Waddabha.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly MessageManager _messageService;

        public ChatHub(MessageManager messageService)
        {
            _messageService = messageService;
        }

        public async Task SendMessage(string senderId, string receiverId, string content)
        {
            var messageAddDTO = new MessageAddDTO
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Body = content,
            };

            await _messageService.SendMessageAsync(messageAddDTO);
            await Clients.User(receiverId).SendAsync("ReceiveMessage", senderId, content, DateTime.Now);
        }
    }
}
