namespace Blorc.Components
{
    using System;
    using System.ComponentModel;

    public interface IBlorcComponent : IDisposable, INotifyPropertyChanged
    {
        void ForceUpdate();
    }
}
