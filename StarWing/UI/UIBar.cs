using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace StarWing.UI
{
    public class UIBar : UIComponent
    {
        public float MaxValue { get; set; }
        public float CurrentValue { get; set; }
        public Color BarColor { get; set; }

        public UIBar(float maxValue, float startValue) : this(maxValue, startValue, Color.White) { }
        public UIBar(float maxValue, float startValue, Color barColor)
        {
            MaxValue = maxValue;
            CurrentValue = startValue;
            BarColor = barColor;
        }
    }
}