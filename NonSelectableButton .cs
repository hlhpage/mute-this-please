namespace mute_this_please
{
    public class NonSelectableButton : Button
    {
        public NonSelectableButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
