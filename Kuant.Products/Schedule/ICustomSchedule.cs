using System.Data;

namespace Kuant.Products
{
    public interface ICustomSchedule : ISchedule
    {
        DataTable Values { get; set; }
        
    }
}