using System.Collections.Generic;

namespace KuantDotNet.Instruments.Interpolation
{
    public static class Interpolator<T>
    {
        private static volatile IInterpolator<T> _interpolator;
        public static IInterpolator<T> Handler
        {
            get { 
                if (_interpolator == null) 
                {
                    System.Console.WriteLine("Default interpolator : linear");
                    _interpolator = new LinearInterpol<T>();
                }
                return _interpolator;
            }

            set
            {
                _interpolator = value;
            }
        }     

    }

    public static class Interpolator
    {
        private static volatile IInterpolator<double> _interpolator;
        public static IInterpolator<double> Handler
        {
            get { 
                if (_interpolator == null) 
                {
                    System.Console.WriteLine("Default interpolator : linear");
                    _interpolator = new LinearInterpol<double>();
                }
                return _interpolator;
            }

            set
            {
                _interpolator = value;
            }
        }    

    }
}