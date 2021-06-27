using Employee.core.Models;
using System.Collections.Generic;

namespace Employee.core.Services
{
    public interface IDbService
    {
        IEnumerable<T> Get<T>() where T : Entity;
        
        bool Create<T>(T entity) where T : Entity;
    }
}
