using Application.Interfaces;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        protected ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }

        public virtual async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }

        public virtual async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            return await _repository.AddAsync(entity, cancellationToken);
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _repository.UpdateAsync(entity, cancellationToken);
        }

        public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);

            if (entity == null)
                throw new NotFoundException("El recurso que desea eliminar no existe");

            await _repository.DeleteAsync(entity, cancellationToken);
        }
    }
}
