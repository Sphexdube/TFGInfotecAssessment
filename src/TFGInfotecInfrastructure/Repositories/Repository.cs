namespace TFGInfotecInfrastructure.Repositories
{
	public class Repository<T> : RepositoryBase, IRepository<T> where T : Entity
	{
		private DbSet<T> entitySet => _context.Set<T>();

		public Repository(ApplicationDbContext context, ILogger<Repository<T>> logger)
			: base(context, logger)
		{
		}

		public async Task<T> Add(T entity)
		{
			try
			{
				EntityEntry<T>? addedEntity = await entitySet.AddAsync(entity);
				await _context.SaveChangesAsync();
				return addedEntity.Entity;
			}
			catch (DbUpdateException ex)
			{
				_logger.LogError(ex.Message, AddErrorMessage);
				throw new Exception($"{AddErrorMessage} {ex?.InnerException?.Message}");
			}
		}

		public async Task<List<T>> AddAll(List<T> entities)
		{
			try
			{
				await entitySet.AddRangeAsync(entities);
				await _context.SaveChangesAsync();
				return entities.ToList();
			}
			catch (DbUpdateException ex)
			{
				_logger.LogError(ex, AddAllErrorMessage);
				throw new Exception($"{AddAllErrorMessage} {ex?.InnerException?.Message}");
			}
		}

		public async Task<T> GetByID(int? Id)
		{
			try
			{
				T? entity = await entitySet.FindAsync(Id);
				return entity!;
			}
			catch (DbUpdateException ex)
			{
				_logger.LogError(ex, GetByIdErrorMessage);
				throw new Exception($"{GetByIdErrorMessage} {ex?.InnerException?.Message}");
			}
		}

		public async Task<List<T>> GetAll()
		{
			try
			{
				List<T>? entities = await entitySet.AsNoTracking().ToListAsync();
				return entities;
			}
			catch (DbUpdateException ex)
			{
				_logger.LogError(ex, GetAllErrorMessage);
				throw new Exception($"{GetAllErrorMessage} {ex?.InnerException?.Message}");
			}
		}

		public async Task<T> Update(T entity)
		{
			try
			{
				EntityEntry<T>? updatedEntity = entitySet.Update(entity);
				await _context.SaveChangesAsync();
				return updatedEntity.Entity;
			}
			catch (DbUpdateException ex)
			{
				_logger.LogError(ex, UpdateErrorMessage);
				throw new Exception($"{UpdateErrorMessage} {ex?.InnerException?.Message}");
			}
		}

		public async Task<bool> Delete(int Id)
		{
			try
			{
				T? entity = await GetByID(Id);
				if (entity == null) return false;
				entitySet.Remove(entity);
				await _context.SaveChangesAsync();
				return await GetByID(Id) == null;
			}
			catch (DbUpdateException ex)
			{
				_logger.LogError(ex, DeleteErrorMessage);
				throw new Exception($"{DeleteErrorMessage} {ex?.InnerException?.Message}");
			}
		}

		public async Task<T> GetOne(
			Func<IQueryable<T>, IQueryable<T>> filter,
			Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null)
		{
			try
			{
				IQueryable<T>? query = entitySet.AsNoTracking();
				query = filter(query);
				if (include != null) query = include(query);
				T? entity = await query.FirstOrDefaultAsync();
				return entity!;
			}
			catch (DbUpdateException ex)
			{
				_logger.LogError(ex, GetOneErrorMessage);
				throw new Exception($"{GetOneErrorMessage} {ex?.InnerException?.Message}");
			}
		}

		public async Task<List<T>> Get(
			Func<IQueryable<T>, IQueryable<T>>? filter,
			Func<IQueryable<T>, IOrderedQueryable<T>>? order = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null)
		{
			try
			{
				IQueryable<T> query = entitySet.AsNoTracking();

				query = include?.Invoke(query) ?? query;
				query = filter?.Invoke(query) ?? query;
				query = order?.Invoke(query) ?? query;

				List<T>? entities = await query.ToListAsync();
				return entities;
			}
			catch (DbUpdateException ex)
			{
				_logger.LogError(ex, GetErrorMessage);
				throw new Exception($"{GetErrorMessage} {ex?.InnerException?.Message}");
			}
		}
	}
}