using AutoMapper;
using Waddabha.BL.CustomExceptions;
using Waddabha.BL.DTOs.ChatRooms;
using Waddabha.BL.DTOs.Messages;
using Waddabha.BL.DTOs.Users;
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
            var ChatRoom = await _unitOfWork.ChatRoomRepository.GetChatRoomWithMessages(id);
            if (ChatRoom == null)
            {
                throw new RecordNotFoundException();//handle the error 
            }
            var result = new ChatRoomReadDTO {
                Id = ChatRoom.Id, 
                CreatedAt = ChatRoom.CreatedAt, 
                Messages = ChatRoom.Messages.Select(m => _mapper.Map<Message, MessageReadDTO>(m)),
                SellerId = ChatRoom.SellerId,
                BuyerId = ChatRoom.BuyerId
            };
            return result;
        }

        public async Task<IEnumerable<ChatRoomReadDTO>> GetChatRoomsByUserId(string userId)
        {

            var chatRooms = await _unitOfWork.ChatRoomRepository.GetChatRoomsByUserId(userId);

            var result = _mapper.Map<IEnumerable<ChatRoom>, IEnumerable<ChatRoomReadDTO>>(chatRooms);
            //var result = chatRooms.Select(cr => new ChatRoomReadDTO
            //{
            //    Id = cr.Id,
            //    CreatedAt = cr.CreatedAt,
            //    SellerId = cr.SellerId,
            //    BuyerId = cr.BuyerId,
            //    Seller = new GetUserDTO { 
            //        Id = cr.Seller.Id, 
            //        UserName = cr.Seller.UserName,
            //        Email = cr.Seller.Email,
            //        Fname = cr.Seller.Fname,
            //        Lname = cr.Seller.Lname,
            //        Role = "Seller",
            //        Gender = cr.Seller.Gender.ToString(),
            //        Image = new ImageDto { ImageUrl = cr.Seller.Image.ImageUrl, PublicId = cr.Seller.Image.PublicId} },
            //    Buyer = new GetUserDTO
            //    {
            //        Id = cr.Buyer.Id,
            //        UserName = cr.Buyer.UserName,
            //        Email = cr.Buyer.Email,
            //        Fname = cr.Buyer.Fname,
            //        Lname = cr.Buyer.Lname,
            //        Role = "Buyer",
            //        Gender = cr.Buyer.Gender.ToString(),
            //        Image = new ImageDto { ImageUrl = cr.Buyer.Image.ImageUrl, PublicId = cr.Buyer.Image.PublicId }
            //    },
            //});
            return result;
        }
    }


}

