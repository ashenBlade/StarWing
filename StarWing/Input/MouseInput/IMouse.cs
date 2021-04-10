using System.Drawing;
using StarWing.Framework.Primitives;

namespace StarWing.Framework.Input
{
    public interface IMouse
    {
        MouseStatus Status { get; }
        Point Position { get; }
    }
}