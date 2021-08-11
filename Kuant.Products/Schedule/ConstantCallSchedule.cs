using System.Collections.Generic;
using System.Data;
using Kuant.Utils;

namespace Kuant.Products
{
    public class ConstantCallSchedule : IConstantSchedule, INotional
    {
        public object[] ConstantValues { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public KDateTime StartDate { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public KDateTime EndDate { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public object Clone()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetCompleteSchedule()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, object> GetRow(KDateTime date)
        {
            throw new System.NotImplementedException();
        }
    }
}