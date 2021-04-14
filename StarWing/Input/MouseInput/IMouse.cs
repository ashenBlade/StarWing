using System.Drawing;

namespace StarWing.Framework.Input
{
    public interface IMouse
    {
        MouseStatus Status { get; }
        Point Position { get; }
    }
}