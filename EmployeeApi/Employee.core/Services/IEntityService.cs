using System.Collections.Generic;
using Employee.core.Models;

namespace Employee.core.Services
{
    public interface IEntityService<T> where T : Entity
    {
        IEnumerable<T> Get();

        bool Create(T entity);
    }
}
