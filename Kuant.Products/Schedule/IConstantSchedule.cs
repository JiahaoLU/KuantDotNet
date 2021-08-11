namespace Kuant.Products
{
    public interface IConstantSchedule : ISchedule
    {
         object[] ConstantValues {get; set;}
    }
}