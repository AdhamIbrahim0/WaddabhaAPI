using Waddabha.DAL.Repositories.Categories;
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

        public IMessageRepository MessageRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        Task SaveChangesAsync();
    }
}
