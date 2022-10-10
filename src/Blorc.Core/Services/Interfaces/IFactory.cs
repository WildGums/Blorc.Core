namespace Blorc.Services
{
    using System;
    using System.Collections;

    public interface IFactory
    {
        IEnumerable Get(object source);

        object? Get(object source, Type targetType);
    }
}
