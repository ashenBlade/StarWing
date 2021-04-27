namespace StarWing.UI
{
    public class UIButton: UIComponent
    {
        public UIComponent Content { get; set; }

        public Action Click;

        public Action MouseEnter;

        public Action MouseLeave;

        public Action MouseHover;
    }
}