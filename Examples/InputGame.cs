using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using StarWing.Framework;
using StarWing.Framework.Primitives;

namespace Examples
{
    public class InputGame : Game
    {
        private string _text;
        private Vector2D _textPosition;
        private Font _font;
        private Brush _fontBrush;
        private int _clickCount;

        protected override void OnLoad()
        {
            base.OnLoad();
            _text = string.Empty;
            _textPosition = new Vector2D(100, 100);
            _font = new Font(FontFamily.GenericMonospace, 12);
            _fontBrush = Brushes.Black;
            _clickCount = 0;
        }

        protected override void Update(IGameTime gameTime)
        {
            base.Update(gameTime);
            var keyboardStatus = Keyboard.Status;
            _text += keyboardStatus.Pressed.Where(key => keyboardStatus.IsKeyJustPressed(key))
                          .Select(key => key.ToString())
                          .Aggregate(string.Empty, (empty, key) => key);
            var mouseStatus = Mouse.Status;
            if (mouseStatus.IsButtonJustPressed(MouseButtons.Left))
            {
                _clickCount++;
            }

        }

        protected override void Render(Graphics graphics)
        {
            base.Render(graphics);
            graphics.DrawString(_text, _font, _fontBrush, _textPosition);
            graphics.DrawString($"Clicks count: {_clickCount}", _font, _fontBrush, _textPosition + (Vector2D.Down * 10));
        }
    }
}