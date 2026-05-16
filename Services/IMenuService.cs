using Misbah_VisualProgramming_Project.Data.Entities;

namespace Misbah_VisualProgramming_Project.Services
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetAllMenuItemsAsync();
    }
}