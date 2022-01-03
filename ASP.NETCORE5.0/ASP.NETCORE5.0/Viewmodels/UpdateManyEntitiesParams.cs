using ASP.NETCORE5._0.Entities;
using System;
using System.Linq.Expressions;

namespace ASP.NETCORE5._0.Viewmodels
{
    public class UpdateManyEntitiesParams<TEntity, TField> where TEntity : BaseEntity
    {
        public Expression<Func<TEntity, TField>> Field { get; set; }
        public TField Value { get; set; }
    }
}