using System;

namespace Atom.Memory.Pooling.Array
{
    public interface IArrayPool<T>
    {
        ArraySegment<T> Take(int minSize);
        void Return(ArraySegment<T> segment);
    }
}
