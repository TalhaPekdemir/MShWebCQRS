using MShWeb.Application.Services.Repositories;
using MShWeb.Domain.Entities;
using MShWeb.Persistence.Contexts;
using MShWeb.Persistence.Repositories;

namespace MShWeb.Application.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private BaseDbContext _context;

        private IProductRepository _productRepository;
        private IImageRepository _imageRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_context);

                return _productRepository;
            }
        }

        public IImageRepository ImageRepository
        {
            get
            {
                if ( _imageRepository == null)
                    _imageRepository = new ImageRepository(_context);

                return _imageRepository;
            }
        }

        public UnitOfWork(BaseDbContext context)
        {
            _context = context;
        }

        //public IAsyncRepository<TEntity, Guid> GetRepository<TEntity>() where TEntity : Entity<Guid>
        //{
        //    return new BaseRepository<TEntity, Guid, BaseDbContext>(_context);
        //}

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                this._disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
