using System.Drawing;

namespace StarWing.UI
{
    public class UILabel: UIComponent
    {
        public string Text { get; set; }
        public float Size { get; set; }
        public Color FontColor { get; set; } = Color.Black;
        public Font Font { get; set; }
        public override void Render(Graphics graphics)
        {
            base.Render(graphics);
            graphics.DrawString(Text, Font, new SolidBrush(FontColor), Position);
        }
    }
}