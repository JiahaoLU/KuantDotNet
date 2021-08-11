using System;
using System.Collections.Generic;
using System.Data;
using Kuant.Utils;

namespace Kuant.Products
{
    public interface ISchedule: ICloneable
    {
        KDateTime StartDate {get; set;}
        KDateTime EndDate { get; set; }

        DataTable GetCompleteSchedule(/*DateTimeFormatInfo*/); 

        Dictionary<string, object> GetRow(KDateTime date);
    }
}