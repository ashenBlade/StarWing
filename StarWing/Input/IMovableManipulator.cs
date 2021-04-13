using System;

namespace StarWing.Framework.Input
{
    public interface IMovableManipulator<TMoveArgs> where TMoveArgs: EventArgs
    {
        event EventHandler<TMoveArgs> Move;
    }
}