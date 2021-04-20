using System;

namespace StarWing.Framework.Input
{
    public class ScrollEventArgs : EventArgs
    {
        public ScrollDirection Direction { get; }

        public ScrollEventArgs(ScrollDirection direction)
        {
            Direction = direction;
        }

        public ScrollEventArgs(int direction)
        {
            Direction = direction > 0
                            ? ScrollDirection.Up
                            : direction == 0
                                ? ScrollDirection.None
                                : ScrollDirection.Down;
        }
    }
}