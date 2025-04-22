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
    public abstract class ServiceBase<T, TDto> : IServiceBase<T, TDto>
        where T : class
        where TDto : class
    {
        protected readonly IRepositoryBase<T> _repository;
        protected readonly IMapperService _mapper;

        protected ServiceBase(IRepositoryBase<T> repository, IMapperService mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);

            return _mapper.MapList<T, TDto>(entities);
        }

        public virtual async Task<TDto?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);

            if (entity == null)
                throw new NotFoundException("El id especificado no existe");

            return _mapper.Map<T, TDto>(entity);
        }

        public virtual async Task<TDto> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            //hacer validaciones y mapear RequestDto en entity

            await _repository.AddAsync(entity, cancellationToken);

            return _mapper.Map<T, TDto>(entity);
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            //hacer validaciones y mapear RequestDto en entity

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
