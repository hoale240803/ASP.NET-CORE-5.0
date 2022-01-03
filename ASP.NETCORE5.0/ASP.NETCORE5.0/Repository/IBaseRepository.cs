using ASP.NETCORE5._0.Entities;
using ASP.NETCORE5._0.Viewmodels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASP.NETCORE5._0.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IMongoCollection<TEntity> Collection { get; }
		TEntity Find(string id);

		Task<TEntity> FindAsync(string id);

		Task<long> CountAsync(Expression<Func<TEntity, bool>> filter);

		Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter);

		Task<IList<TEntity>> FindListAsync(FilterDefinition<TEntity> filter);

		Task<IList<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> filter);

		Task<IList<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> filter, int limit);

		Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

		Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> filter, string filedName);

		Task<TEntity> LastOrDefaultAsync(FilterDefinition<TEntity> filter, string sortByFieldName);

		Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

		IEnumerable<TEntity> GetAll();

		IQueryable<TEntity> Queryable { get; }

		Task InsertAsync(TEntity entity, bool isAutoAssignCreatedAt = true);

		Task InsertRangeAsync(IList<TEntity> entities);

		Task UpdateAsync(TEntity entity);

		/// <summary>
		/// Note: This method impacts to database performance if there are many entities to update
		/// </summary>
		Task UpdateRangeAsync(IEnumerable<TEntity> entities);

		Task DeleteAsync(string id);

		Task DeleteAsync(TEntity entity);

		Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter);

		TEntity Increase<TField>(string id, Expression<Func<TEntity, TField>> field, TField value);

		Task<TEntity> IncreaseAsync<TField>(string id, Expression<Func<TEntity, TField>> field, TField value);

		Task<TEntity> UpdateOneAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);

		Task UpdateOneAsync(string id, IEnumerable<UpdateManyEntitiesParams<TEntity, dynamic>> fields);

		Task UpdateOneAsync<TField>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TField>> field, TField value, UpdateOptions options = null);



		/// <summary>
		//var updates = new List<UpdateManyEntitiesParams<Integration, dynamic>>
		//	{
		//		new UpdateManyEntitiesParams<Integration, dynamic>
		//		{
		//			Field = _ => _.IsDeleted , Value = true
		//		},
		//		new UpdateManyEntitiesParams<Integration, dynamic>
		//		{
		//			Field = _ => _.DeletedAt, Value = DateTime.UtcNow
		//		},
		//		new UpdateManyEntitiesParams<Integration, dynamic>
		//		{
		//			Field = _ => _.DeletedBy, Value = userId
		//		}
		//	};
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="fields"></param>
		/// <returns></returns>
		Task UpdateOneAsync(Expression<Func<TEntity, bool>> filter, IEnumerable<UpdateManyEntitiesParams<TEntity, dynamic>> fields);

		Task<TEntity> UpdateOneAsync<TField>(string id, Expression<Func<TEntity, TField>> field, TField value);

		void UpdateMany<TField>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TField>> field, TField value);

		Task UpdateManyAsync<TField>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TField>> field, TField value, UpdateOptions options = null);

		Task UpdateManyAsync<TField>(Expression<Func<TEntity, bool>> filter, string field, TField value);

		Task UpdateManyAsync(Expression<Func<TEntity, bool>> filter, UpdateDefinition<TEntity> update);

		Task UpdateManyAsync(Expression<Func<TEntity, bool>> filter, List<UpdateManyEntitiesParams<TEntity, dynamic>> fields);

		Task BulkWriteAsync(IList<WriteModel<TEntity>> model, bool isOrdered = false);
	}
}
