using System.Drawing;

namespace StarWing.Framework
{
    public interface IGameWindow
    {
        Point Position { get; }
        int Width { get; }
        int Height { get; }
        string Title { get; }
    }
}