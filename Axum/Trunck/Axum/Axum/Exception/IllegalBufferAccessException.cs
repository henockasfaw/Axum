using System;

namespace Axum.Exception
{
    public class IllegalBufferAccessException : ApplicationException
    {
        public IllegalBufferAccessException(string refcntOverflow): base(refcntOverflow)
        {
            
        }

        public IllegalBufferAccessException():base(){
        }
    }
}