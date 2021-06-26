using System.Collections.Generic;
using log4net;

namespace KuantDotNet.Instruments.Interpolation
{
    public static class Interpolator<T>
    {
        #region Logger
            public static ILog Logger { get; }    
        #endregion
        private static volatile IInterpolator<T> _interpolator;
        public static LinearInterpol<T> LinearHandler
        {
            get { 
                if (_interpolator == null || !(_interpolator is LinearInterpol<T>)) 
                {
                    Logger.Info("Switch interpolator to : linear");
                    _interpolator = new LinearInterpol<T>();
                }
                return (LinearInterpol<T>)_interpolator;
            }

            set
            {
                _interpolator = value;
            }
        }     
        static Interpolator()
        {
            Logger = LogManager.GetLogger("Interpolator");
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