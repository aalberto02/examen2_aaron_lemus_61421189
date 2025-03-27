using examen2_aaron_lemus_61421189.Context;
using examen2_aaron_lemus_61421189.Models;
using Microsoft.EntityFrameworkCore;

namespace examen2_aaron_lemus_61421189.Services
{
    public class UserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        //Obtiene todos los usuarios
        public async Task<List<User>> getUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //Obtiene usuario por id
        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        //crear un usuario 
        public async Task<User> CreateUser(User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        //actualizar un usuario
        public async Task<bool> UpdateUser(int id, User updatedUser)
        {
            var usuario = await _context.Users.FindAsync(id);
            if (usuario == null) return false;

            usuario.Name = updatedUser.Name;
            usuario.Email= updatedUser.Email;
            usuario.Password= updatedUser.Password;

            await _context.SaveChangesAsync();
            return true;
        }

        //eliminar un usuario
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
