using System;
using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public static class ScrollEventHandlerExtension
    {
        public static MouseEventHandler ToMouseEventHandler(this EventHandler<ScrollEventArgs> scrollEventHandler)
        {
            return (sender, args) =>
                scrollEventHandler?.Invoke(sender, new ScrollEventArgs(args.Delta));
        }
    }
}