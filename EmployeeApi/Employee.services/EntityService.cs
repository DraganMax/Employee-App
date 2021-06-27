using Employee.core.Models;
using Employee.core.Services;
using Employee.data;
using System.Collections.Generic;

namespace Employee.services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IEmployeesDbContext context) : base(context) { }

        public virtual bool Create(T entity)
        {
            return Create<T>(entity);
        }

        public virtual IEnumerable<T> Get()
        {
            return Get<T>();
        }
    }
}
