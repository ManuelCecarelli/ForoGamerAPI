namespace Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        // <summary>
        // Finds all entities of <typeparamref name="T" /> from the database.
        // </summary>
        // <returns>
        // A task that represents the asynchronous operation.
        // The task result contains a <see cref="List{T}" /> that contains elements from the input sequence.
        // </returns>
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        // <summary>
        // Finds an entity with the given primary key value.
        // </summary>
        // <typeparam name="TId">The type of primary key.</typeparam>
        // <param name="id">The value of the primary key for the entity to be found.</param>
        // <param name="cancellationToken"></param>
        // <returns>
        // A task that represents the asynchronous operation.
        // The task result contains the <typeparamref name="T" />, or <see langword="null"/>.
        // </returns>
        Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;

        // <summary>
        // Adds an entity in the database.
        // </summary>
        // <param name="entity">The entity to add.</param>
        // <param name="cancellationToken"></param>
        // <returns>
        // A task that represents the asynchronous operation.
        // The task result contains the <typeparamref name="T" />.
        // </returns>
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        // <summary>
        // Updates an entity in the database
        // </summary>
        // <param name="entity">The entity to update.</param>
        // <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        // <summary>
        // Removes an entity in the database
        // </summary>
        // <param name="entity">The entity to delete.</param>
        // <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        // <summary>
        // Persists changes to the database.
        // </summary>
        // <returns>A task that represents the asynchronous operation.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
