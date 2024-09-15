using AutoMapper;
using Waddabha.BL.DTOs.ChatRooms;
using Waddabha.DAL;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.ChatRooms
{
    public class ChatRoomManager : IChatRoomManager

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChatRoomManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ChatRoomReadDTO> Add(ChatRoomAddDTO chatRoomAddDTO)
        {
            var chatRoom = _mapper.Map<ChatRoomAddDTO, ChatRoom>(chatRoomAddDTO);
            var result = await _unitOfWork.ChatRoomRepository.AddAsync(chatRoom);
            await _unitOfWork.SaveChangesAsync();
            var chatRoomRead = _mapper.Map<ChatRoom, ChatRoomReadDTO>(result);

            return chatRoomRead;
        }

        public async void Delete(string id)
        {
            var chatRoom = await _unitOfWork.ChatRoomRepository.GetByIdAsync(id);
            if (chatRoom == null)
            {
                throw new Exception();
            }
            await _unitOfWork.ChatRoomRepository.DeleteAsync(chatRoom);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChatRoomReadDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ChatRoomReadDTO> GetById(string id)
        {
            var ChatRoom = await _unitOfWork.ChatRoomRepository.GetByIdAsync(id);
            if (ChatRoom == null)
            {
                throw new Exception();//handle the error 
            }
            var result = _mapper.Map<ChatRoom, ChatRoomReadDTO>(ChatRoom);
            return result;
        }

        public async Task<IEnumerable<ChatRoomReadDTO>> GetChatRoomsByUserId(string userId)
        {

            var chatRooms = await _unitOfWork.ChatRoomRepository.GetChatRoomsByUserId(userId);
            var result = _mapper.Map<IEnumerable<ChatRoom>, IEnumerable<ChatRoomReadDTO>>(chatRooms);
            return result;
        }
    }


}

