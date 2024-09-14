using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.ChatRooms;
using Waddabha.BL.DTOs.Services;
using Waddabha.BL.Managers.ChatRooms;
using Waddabha.BL.Managers.Services;

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
        
        public async Task <IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var ChatRooms = await _chatRoomManager.GetChatRoomsByUserId(userId);
            var response = ApiResponse<IEnumerable<ChatRoomReadDTO>>.SuccessResponse(ChatRooms);
            return Ok(response);//response);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var service = _chatRoomManager.GetById(id);
            var response = ApiResponse<ChatRoomReadDTO>.SuccessResponse(service);
            return Ok(response);
        }

        
        [HttpPost]
        public IActionResult Add(ChatRoomAddDTO chatRoomAddDTO)
        {
            var chatRoom = _chatRoomManager.Add(chatRoomAddDTO);
            var response = ApiResponse<ChatRoomReadDTO>.SuccessResponse(chatRoom);
            return Ok(response);
        }
    }
}
