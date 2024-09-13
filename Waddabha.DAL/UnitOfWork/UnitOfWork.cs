using Microsoft.EntityFrameworkCore;
using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Repositories.Categories;
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


      
        public UnitOfWork(ApplicationDbContext context)
        {
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
       
        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository ??= new CategoryRepository(_context);
            }
        }

        public IContractRepository ContractRepository
        {
            get
            {
                return _contractRepository ??= new ContractRepository(_context);
            }
        }

        public IMessageRepository MessageRepository
        {
            get
            {
                return _messageRepository ??= new MessageRepository(_context);
            }
        }

        public INotificationRepository NotificationRepository
        {
            get
            {
                return _notificationRepository ??= new NotificationRepository(_context);
            }
        }

        public IServiceRepository ServiceRepository
        {
            get
            {
                return _serviceRepository ??= new ServiceRepository(_context);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
           public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();  // Return an int to indicate number of affected rows
        }
      
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
