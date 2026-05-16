using Misbah_VisualProgramming_Project.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misbah_VisualProgramming_Project.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetActiveOrdersAsync();
    }
}