using examen2_aaron_lemus_61421189.Context;
using examen2_aaron_lemus_61421189.Models;
using Microsoft.EntityFrameworkCore;

namespace examen2_aaron_lemus_61421189.Services
{
    public class TaskService
    {
        private readonly DataContext _context;
        public TaskService(DataContext context)
        {
            _context = context;
        }

        //Obtiene todas los tareas
        public async Task<List<Models.Task>> getTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        //Obtiene tarea por id
        public async Task<Models.Task?> GetById(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(u => u.Id == id);
        }

        //crear un tarea 
        public async Task<Models.Task> CreateTask(Models.Task task)
        {

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        //actualizar un tarea
        public async Task<bool> UpdateTask(int id, Models.Task updatedTask)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            task.Tittle = updatedTask.Tittle;
            task.Description = updatedTask.Description;

            await _context.SaveChangesAsync();
            return true;
        }

        //eliminar un tarea
        public async Task<bool> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
