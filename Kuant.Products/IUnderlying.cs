namespace Kuant.Products
{
    /// <summary>
    /// A PRODUCT WITH UNDERLYING
    /// </summary>
    public interface IUnderlying
    {
        IProduct Underlying {get; set;}
    }
}