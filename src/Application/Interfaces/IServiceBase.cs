using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServiceBase<TEntity, TDto, TCreateDto, TUpdateDto>
        where TEntity : class
        where TDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<TDto?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;

        Task<TDto> CreateAsync(TCreateDto createDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(int id, TUpdateDto updateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
