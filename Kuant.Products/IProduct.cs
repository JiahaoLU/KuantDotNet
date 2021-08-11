using System;
using Kuant.Utils;
using Kuant.Common;

namespace Kuant.Products
{
    public interface IProduct : ICloneable
    {
        KDateTime StartDate {get; set;}
        KDateTime EndDate { get; set; } 
        double? PV {get; set;}
        bool IsPriceable();
    }
}