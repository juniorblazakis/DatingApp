using DatingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Data.Interfaces
{
    public interface IDatingRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetList();
        Task<T> Get (int Id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<bool> SaveAll();

    }
}
