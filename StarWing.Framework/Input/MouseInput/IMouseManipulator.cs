using System.Windows.Forms;

namespace StarWing.Framework.Input
{
    public interface IMouseManipulator: IPressableManipulator<MouseEventArgs>, IScrollableManipulator<ScrollEventArgs>, IMovableManipulator<MouseEventArgs>
    {

    }
}