using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.ChatRooms;
using Waddabha.BL.DTOs.Services;
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

        public ChatRoomReadDTO Add(ChatRoomAddDTO chatRoomAddDTO)
        {
            var chatRoom = _mapper.Map<ChatRoomAddDTO, ChatRoom>(chatRoomAddDTO);
            var result = _unitOfWork.ChatRoomRepository.Add(chatRoom);
            _unitOfWork.SaveChanges();
            var chatRoomRead = _mapper.Map<ChatRoom, ChatRoomReadDTO>(result);

            return chatRoomRead;
        }

        public void Delete(int id)
        {
            var chatRoom = _unitOfWork.ChatRoomRepository.GetById(id);
            if (chatRoom == null)
            {
                throw new Exception();
            }
            _unitOfWork.ChatRoomRepository.Delete(chatRoom);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<ChatRoomReadDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ChatRoomReadDTO GetById(int id)
        {
            var ChatRoom = _unitOfWork.ChatRoomRepository.GetById(id);
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
          var result =_mapper.Map<IEnumerable<ChatRoom>,IEnumerable<ChatRoomReadDTO>>(chatRooms);
            return result;
        }
    }

        
    }

