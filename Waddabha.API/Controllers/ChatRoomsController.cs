using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.ChatRooms;
using Waddabha.BL.Managers.ChatRooms;

namespace Waddabha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatRoomsController : ControllerBase
    {

        private readonly IChatRoomManager _chatRoomManager;

        public ChatRoomsController(IChatRoomManager chatRoomManger)
        {
            _chatRoomManager = chatRoomManger;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var ChatRooms = await _chatRoomManager.GetChatRoomsByUserId(userId);
            var response = ApiResponse<IEnumerable<ChatRoomReadDTO>>.SuccessResponse(ChatRooms);
            return Ok(response);//response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var service = await _chatRoomManager.GetById(id);
            var response = ApiResponse<ChatRoomReadDTO>.SuccessResponse(service);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Add(ChatRoomAddDTO chatRoomAddDTO)
        {
            var chatRoom = await _chatRoomManager.Add(chatRoomAddDTO);
            var response = ApiResponse<ChatRoomReadDTO>.SuccessResponse(chatRoom);
            return Ok(response);
        }
    }
}
