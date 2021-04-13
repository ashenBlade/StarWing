using System;

namespace StarWing.Framework.Input
{
    public interface IScrollableManipulator<TScrollEvent> where TScrollEvent: ScrollEventArgs
    {
        event EventHandler<TScrollEvent> Scroll;
    }
}