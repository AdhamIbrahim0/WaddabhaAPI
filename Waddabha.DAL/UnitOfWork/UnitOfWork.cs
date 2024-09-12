using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Repositories.Categories;
using Waddabha.DAL.Repositories.Contracts;
using Waddabha.DAL.Repositories.Messages;
using Waddabha.DAL.Repositories.Notifications;
using Waddabha.DAL.Repositories.Services;
using Waddabha.DAL.Repositories.Users;

namespace Waddabha.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICategoryRepository CategoryRepository { get; }
        public IContractRepository ContractRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWork(ICategoryRepository categoryRepository,
            IContractRepository contractRepository,
            IMessageRepository messageRepository,
            INotificationRepository notificationRepository,
            IServiceRepository serviceRepository,
            IUserRepository userRepository,
            ApplicationDbContext context)
        {
            CategoryRepository = categoryRepository;
            ContractRepository = contractRepository;
            MessageRepository = messageRepository;
            NotificationRepository = notificationRepository;
            ServiceRepository = serviceRepository;
            UserRepository = userRepository;

            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            }
    }
}
