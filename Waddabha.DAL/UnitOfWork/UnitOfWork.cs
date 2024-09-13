using Microsoft.EntityFrameworkCore;
using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Repositories.Categories;
using Waddabha.DAL.Repositories.Contracts;
using Waddabha.DAL.Repositories.Messages;
using Waddabha.DAL.Repositories.Notifications;
using Waddabha.DAL.Repositories.Services;

namespace Waddabha.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        private ICategoryRepository _categoryRepository;
        private IContractRepository _contractRepository;
        private IMessageRepository _messageRepository;
        private INotificationRepository _notificationRepository;
        private IServiceRepository _serviceRepository;




        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();  // Return an int to indicate number of affected rows
        }

        public UnitOfWork(ApplicationDbContext context)
        {
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

      
      
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
