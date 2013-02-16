using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Axum.Util;

namespace Axum.Io.Buffer
{
    public interface IMessageBuf<T> :ICustomQueue<T>,IBuf
    {
        bool UnfoldAndAdd(Object o);
        //TODO:we have to figure out the conversion from (Collection<? super T> c to c# 
        int DrainTo(IEnumerable<T> c);
        int DrainTo(IEnumerable<T> c, int maxElements);
        IMessageBuf<T> Retain();
        IMessageBuf<T> Retain(int increment);
        
    }
}