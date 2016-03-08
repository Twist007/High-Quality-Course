using System;

namespace _01.ManipulateTwoDimensionalArrays
{
    public class IncompatibleArraysException : Exception
    {
        public IncompatibleArraysException(string message)
            : base(message)
        {
        }

        public IncompatibleArraysException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
