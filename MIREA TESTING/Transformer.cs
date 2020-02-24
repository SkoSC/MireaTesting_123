using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mirea
{
    public delegate T Transformer<F, T>(F from);

    public static class TransformerUtils
    {
        public static Transformer<T, T> Chain<T>(params Transformer<T, T>[] transformers)
            => (T f) => transformers.Aggregate(f, (acc, next) => next(acc));
    }
}