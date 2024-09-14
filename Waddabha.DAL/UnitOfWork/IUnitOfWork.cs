using Waddabha.DAL.Repositories.Categories;
using Waddabha.DAL.Repositories.ChatRooms;
using Waddabha.DAL.Repositories.Contracts;
using Waddabha.DAL.Repositories.Messages;
using Waddabha.DAL.Repositories.Notifications;
using Waddabha.DAL.Repositories.Services;
using Waddabha.DAL.Repositories.Users;

namespace Waddabha.DAL
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IContractRepository ContractRepository { get; }
        public IUserRepository UserRepository { get; }
        public IChatRoomRepository ChatRoomRepository { get; }

        public IMessageRepository MessageRepository { get; }
        Task<int> SaveChangesAsync();

        public INotificationRepository NotificationRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        Task SaveChangesAsync();
    }
}
