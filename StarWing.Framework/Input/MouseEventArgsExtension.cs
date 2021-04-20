using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public static class MouseEventArgsExtension
    {
        public static ScrollEventArgs ToScrollEventArgs(this MouseEventArgs args)
        {
            var direction = args.Delta > 0
                                ? ScrollDirection.Up
                                : args.Delta == 0
                                    ? ScrollDirection.None
                                    : ScrollDirection.Down;
            return new ScrollEventArgs(direction);
        }
    }
}