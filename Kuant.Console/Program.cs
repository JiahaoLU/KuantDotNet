using System;
using Kuant.Products;

namespace Kuant.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var swaption = new Swaption();
            swaption.id = 10;
            // swaption.IUnderlying.Underlying = new Swap();
            System.Console.ReadLine();
        }
    }
}
