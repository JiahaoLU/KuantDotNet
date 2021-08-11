namespace Kuant.Products
{
    public class Swaption : Instrument, IUnderlying
    {
        public int id = 0;
        public IProduct Underlying { get ; set ; }

        public Swap UnderlyingSwap { get; set; }
        

        public override object Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}