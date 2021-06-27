using Employee.core.Models;
using Employee.core.Services;
using Employee.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee.services
{
    public class DbService : IDbService
    {
        public DbService(IEmployeesDbContext context)
        {
            _ctx = context;
        }

        public bool Create<T>(T entity) where T : Entity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();

            return true;
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return Query<T>().ToList();
        }

        private IQueryable<T> Query<T>() where T : Entity
        {
            return _ctx.Set<T>().AsQueryable();
        }

        private readonly IEmployeesDbContext _ctx;
    }
}
