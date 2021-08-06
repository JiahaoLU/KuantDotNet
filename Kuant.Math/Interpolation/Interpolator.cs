using System;
using System.Collections.Generic;
using System.Linq;

namespace Kuant.Math
{

    public static class Interpolator<Ti, Tv> where Ti : IComparable<Ti>
    {
        /// <summary>
        /// Ti must have vaild "-" operator<br/>
        /// Tv must be one of double, int, long, float, ...
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="interpolType"></param>
        /// <returns></returns>
        public static Tv Interpolate(
            List<Ti> labels, List<Tv> list, Ti index, InterpolType interpolType)
        {
            switch (interpolType)
            {
                case InterpolType.Linear:
                    return Linear(labels, list, index);
                default:
                    throw new System.Exception("Interpolation type not found.");
            }
            
        }

        private static Tv Linear(List<Ti> labels, List<Tv> list, Ti index)
        {
            if(list.Count != labels.Count)
                throw new Exception("labels and values number not consistent.");
            
            var len = list.Count;
            var lastIdx = labels.LastOrDefault(s => s.CompareTo(index) <= 0);
            var nextIdx = labels.FirstOrDefault(s => s.CompareTo(index) > 0);
            double interpol;

            if (nextIdx == null)
            {
                if (len < 2) throw new Exception("list contains less than 2 elements, cannot do interpolation");

                //extrapolation
                var dt1 = (dynamic)index - (dynamic)labels[len - 1];
                var dt2 = (dynamic)labels[len - 1] - (dynamic)labels[len - 2];
                interpol = (Convert.ToDouble(list[len - 1]) - Convert.ToDouble(list[len - 2]))
                            * dt1 / dt2
                             + Convert.ToDouble(list[len - 1]);
                return (Tv)Convert.ChangeType(interpol, typeof(Tv));
            }
            if (lastIdx == null)
            {
                if (len < 2) throw new Exception("list contains less than 2 elements, cannot do interpolation");
                //extrapolation
                var dt1 = (dynamic)index - (dynamic)labels[1];
                var dt2 = (dynamic)labels[1] - (dynamic)labels[0];
                interpol = (Convert.ToDouble(list[1]) - Convert.ToDouble(list[0]))
                            * dt1 / dt2
                             + Convert.ToDouble(list[1]);
                return (Tv)Convert.ChangeType(interpol, typeof(Tv));
            }
            if (lastIdx.Equals(index) || nextIdx.Equals(index))
                {
                    return list[labels.IndexOf(index)];
                }

            var dt3 = (dynamic)index - (dynamic)nextIdx;
            var dt4 = (dynamic)nextIdx - (dynamic)lastIdx;
            interpol = (Convert.ToDouble(list[labels.IndexOf(nextIdx)]) - Convert.ToDouble(list[labels.IndexOf(lastIdx)]))
                        * dt3 / dt4
                         + Convert.ToDouble(list[labels.IndexOf(nextIdx)]);
            return (Tv)Convert.ChangeType(interpol, typeof(Tv));
        }
    }
}