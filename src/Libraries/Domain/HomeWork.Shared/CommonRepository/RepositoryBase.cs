using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace HomeWork.Shared.CommonRepository;

public abstract class RepositoryBase<TEntity, IModel, T> : IRepository<TEntity, IModel, T>
	where TEntity : class, IEntity<T>, new()
	where IModel : class, IVM<T>
	where T : IEquatable<T>
{
	private readonly IMapper _mapper;
	private readonly DbContext _dbContext;

	protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

	public RepositoryBase(IMapper mapper, DbContext dbContext)
	{
		_mapper = mapper;
		_dbContext = dbContext;
	}

	public async Task<IModel> Add(TEntity entity)
	{
		DbSet.Add(entity);
		await _dbContext.SaveChangesAsync();
		return _mapper.Map<IModel>(entity);
	}

	public async Task Delete(T id)
	{
		var entity = await DbSet.FindAsync(id);
		if (entity == null)
		{
			throw new InvalidOperationException("Data  not found");
		}



		DbSet.Remove(entity);
		await _dbContext.SaveChangesAsync();
	}

	

	public async Task<IModel> GetById(T id)
	{
		var Data = await DbSet.FindAsync(id);
		return _mapper.Map<IModel>(Data);
	}

	public async Task<IModel> Update(T id, TEntity entity)
	{
		if (!id.Equals(entity.Id))
		{
			throw new InvalidOperationException("ID Not match");
		}

		_dbContext.Entry(entity).State = EntityState.Modified;
		await _dbContext.SaveChangesAsync();
		return _mapper.Map<IModel>(entity);
	}

	public Task<IEnumerable<IModel>> GetList()
	{
		var data = DbSet.AsEnumerable();
		var models = _mapper.Map<IEnumerable<IModel>>(data);
		return Task.FromResult(models);
	}
}
