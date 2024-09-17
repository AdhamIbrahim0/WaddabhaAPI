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
        private readonly IMessageManager _messageService;

        public ChatHub(IMessageManager messageService)
        {
            _messageService = messageService;
        }
        public async Task JoinChatRoom(string chatRoomId)
        {  
            await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId);
            //await Clients.Group(chatRoomId).SendAsync("ReceiveMessage", "System", $"User {Context.ConnectionId} has joined the chatroom.", DateTime.Now);
        }

        public async Task LeaveChatRoom(string chatRoomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatRoomId);
            await Clients.Group(chatRoomId).SendAsync("ReceiveMessage", "System", $"User {Context.ConnectionId} has left the chatroom.", DateTime.Now);
        }
        public async Task SendMessageToChatRoom(string senderId, string content, string ChatRoomId)
        {  
            try
            {

                var messageAddDTO = new MessageAddDTO
                {
                    SenderId = senderId,
                    Body = content,
                    ChatRoomId = ChatRoomId

                };

                await _messageService.SendMessageAsync(messageAddDTO);
                await Clients.Group(ChatRoomId).SendAsync("ReceiveMessage", senderId, content, DateTime.Now);

            }
            catch (Exception ex)
            {
                // Log the error and provide more context for debugging
                Console.WriteLine($"Error in SendMessageToChatRoom: {ex.Message}");
                throw;
               


            }
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // You can remove the user from all groups (chat rooms) or perform other cleanup
            // await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatRoomId); // Example
            await base.OnDisconnectedAsync(exception);
        }
    }
}
