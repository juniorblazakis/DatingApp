using DatingApp.API.Data.Interfaces;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        public UserRepository(DataContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<User>> GetList() 
        {
            var users =  await context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        public async Task<User> Get(int Id) 
        { 
            var user = await context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == Id);
            return user;
        }

        public void Add(User entity)
        {
            context.Add(entity);
        }

        public void Delete(User entity)
        {
            context.Remove(entity);
        }

        public void Update(User entity)
        {
            context.Update(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
