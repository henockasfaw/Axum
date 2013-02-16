using System;
using Axum.Exception;

namespace Axum
{
    public static class Guard
    {
        public static void LessThanZero(int number, string message)
        {
            if (number < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void OutOfBufferRange(int refCnt) 
        {
            if (refCnt <= 0)
            {
                throw new IllegalBufferAccessException();
            }

            if (refCnt == int.MaxValue)
            {
                throw new IllegalBufferAccessException("refCnt overflow");
            }
        }

        public static void OutOfBufferRange(int refCnt, int increment)
        {
            if (refCnt <= 0)
            {
                throw new IllegalBufferAccessException();
            }

            if (refCnt > int.MaxValue - increment)
            {
                throw new IllegalBufferAccessException("refCnt overflow");
            }
        }
    }
}