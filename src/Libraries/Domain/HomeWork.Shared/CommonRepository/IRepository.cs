

namespace HomeWork.Shared.CommonRepository;

public interface IRepository<in TEntity, IModel, T> 
		where TEntity : class, IEntity<T>, new()
	  where IModel : class, IVM<T>
		where T : IEquatable<T>

{


	public Task<IModel> GetById(T id);

	public Task<IEnumerable<IModel>> GetList();

	public Task Delete(T id);

	public Task<IModel> Update(T id, TEntity entity);


	public Task<IModel> Add(TEntity entity);




	





}
