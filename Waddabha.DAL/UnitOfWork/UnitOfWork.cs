using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Repositories.Categories;
using Waddabha.DAL.Repositories.ChatRooms;
using Waddabha.DAL.Repositories.Contracts;
using Waddabha.DAL.Repositories.Messages;
using Waddabha.DAL.Repositories.Notifications;
using Waddabha.DAL.Repositories.Services;
using Waddabha.DAL.Repositories.Users;

namespace Waddabha.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public ICategoryRepository CategoryRepository { get; }
        public IContractRepository ContractRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        public IUserRepository UserRepository { get; }
        public IChatRoomRepository ChatRoomRepository { get; }

        public UnitOfWork(ICategoryRepository categoryRepository,
            IContractRepository contractRepository,
            IMessageRepository messageRepository,
            INotificationRepository notificationRepository,
            IServiceRepository serviceRepository,
            IUserRepository userRepository,
            IChatRoomRepository chatRoomRepository,
            ApplicationDbContext context)
        {
            ChatRoomRepository = chatRoomRepository;
            CategoryRepository = categoryRepository;
            ContractRepository = contractRepository;
            MessageRepository = messageRepository;
            NotificationRepository = notificationRepository;
            ServiceRepository = serviceRepository;
            UserRepository = userRepository;

            _context = context;
        }




        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync(); // Use the async version
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException?.Message;
                Console.WriteLine("Error: " + ex.Message + " Inner Exception: " + innerException);


                Console.WriteLine("StackTrace: " + ex.StackTrace);
            }

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
