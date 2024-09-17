using AutoMapper;
using Waddabha.BL.DTOs.Messages;
using Waddabha.DAL;
using Waddabha.DAL.Data.Models;


namespace Waddabha.BL.Managers.Messages
{
    public class MessageManager : IMessageManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MessageReadDTO> SendMessageAsync(MessageAddDTO messageAddDTO)
        {
            // Map MessageAddDTO to Message entity
            var messageEntity = _mapper.Map<Message>(messageAddDTO);

            // Add the message using the MessageRepository
            var result = await _unitOfWork.MessageRepository.AddAsync(messageEntity);
            await _unitOfWork.SaveChangesAsync();

            // Map the saved message back to MessageReadDTO
            var messageReadDTO = _mapper.Map<MessageReadDTO>(result);

            return messageReadDTO;
        }

        //public async Task<IEnumerable<MessageReadDTO>> GetMessagesAsync(string senderId, string receiverId)
        //{
        //    // Get the messages between the sender and receiver
        //    var messages = await _unitOfWork.MessageRepository
        //        .GetMessages(senderId, receiverId); // Assuming GetMessages method is defined in the repository

        //    // Map the list of messages to MessageReadDTO
        //    var messageReadDTOs = _mapper.Map<IEnumerable<MessageReadDTO>>(messages);

        //    return messageReadDTOs;
        //}
        public async Task<IEnumerable<MessageReadDTO>> GetMessagesByChatRoomIdAsync(string chatRoomId)
        {

            var messages = await _unitOfWork.MessageRepository.GetMessagesByChatRoomId(chatRoomId);

            var messageReadDTOs = _mapper.Map<IEnumerable<MessageReadDTO>>(messages);
            return messageReadDTOs;

        }
    }
}
