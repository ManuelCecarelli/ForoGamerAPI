using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public abstract class ServiceBase<TEntity, TDto, TCreateDto, TUpdateDto> : IServiceBase<TEntity, TDto, TCreateDto, TUpdateDto>
        where TEntity : class
        where TDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        protected readonly IRepositoryBase<TEntity> _repository;
        protected readonly IMapperService _mapper;

        protected ServiceBase(IRepositoryBase<TEntity> repository, IMapperService mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _repository.GetAllAsync(cancellationToken);

            return _mapper.MapList<TEntity, TDto>(entities);
        }

        public virtual async Task<TDto?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);

            if (entity == null)
                throw new NotFoundException("El id especificado no existe");

            return _mapper.Map<TEntity, TDto>(entity);
        }

        public virtual async Task<TDto> CreateAsync(TCreateDto createDto, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<TCreateDto, TEntity>(createDto);

            await _repository.AddAsync(entity, cancellationToken);

            return _mapper.Map<TEntity, TDto>(entity);
        }

        public virtual async Task UpdateAsync(int id, TUpdateDto updateDto, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);

            if (entity == null)
                throw new NotFoundException("El id especificado no existe");

            // Mapear los valores del updateDTO sobre la entidad existente
            _mapper.Map<TUpdateDto, TEntity>(updateDto, entity);

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
