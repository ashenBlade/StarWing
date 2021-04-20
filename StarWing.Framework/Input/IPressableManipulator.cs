using System;

namespace StarWing.Framework.Input
{
    public interface IPressableManipulator<TKeyType>
    {
        event EventHandler<TKeyType> KeyDown;
        event EventHandler<TKeyType> KeyUp;
    }
}