using System.Linq.Expressions;
using StockManager.Domain.Entities;

namespace StockManager.DAL.Repositories;

/// <summary>
/// Interfaz genérica de repositorio para todas las entidades
/// </summary>
/// <typeparam name="T">Tipo de entidad que hereda de BaseEntity</typeparam>
public interface IRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Obtiene una entidad por su ID
    /// </summary>
    Task<T?> GetByIdAsync(int id);
    
    /// <summary>
    /// Obtiene todas las entidades
    /// </summary>
    Task<IEnumerable<T>> GetAllAsync();
    
    /// <summary>
    /// Obtiene todas las entidades activas
    /// </summary>
    Task<IEnumerable<T>> GetAllActiveAsync();
    
    /// <summary>
    /// Busca entidades que cumplan con un predicado
    /// </summary>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    
    /// <summary>
    /// Busca una única entidad que cumpla con un predicado
    /// </summary>
    Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
    
    /// <summary>
    /// Agrega una nueva entidad
    /// </summary>
    Task AddAsync(T entity);
    
    /// <summary>
    /// Agrega múltiples entidades
    /// </summary>
    Task AddRangeAsync(IEnumerable<T> entities);
    
    /// <summary>
    /// Actualiza una entidad existente
    /// </summary>
    void Update(T entity);
    
    /// <summary>
    /// Elimina una entidad (soft delete - marca como inactiva)
    /// </summary>
    void Remove(T entity);
    
    /// <summary>
    /// Elimina múltiples entidades (soft delete)
    /// </summary>
    void RemoveRange(IEnumerable<T> entities);
    
    /// <summary>
    /// Elimina permanentemente una entidad
    /// </summary>
    void HardRemove(T entity);
    
    /// <summary>
    /// Cuenta entidades que cumplan con un predicado
    /// </summary>
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    
    /// <summary>
    /// Verifica si existe alguna entidad que cumpla con un predicado
    /// </summary>
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
}
