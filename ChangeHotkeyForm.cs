namespace mute_this_please
{
    public partial class ChangeHotkeyForm : Form
    {
        public ChangeHotkeyForm(bool isMuteHotkeyChange)
        {
            InitializeComponent();

            string labelStart = isMuteHotkeyChange ? MainForm.localization.Label_MuteHotkeyChange : MainForm.localization.Label_MuteHotkeyChange;
            label_ChangeHotheyHelp.Text = $"{labelStart}\n{MainForm.localization.Label_HotkeyInstruction}";
            nonSelectableButton_Confirm.Text = MainForm.localization.Button_ConfirmHotkeyChange;
            Text = MainForm.localization.Title_ChangeHotkey;
        }

        public void ChangeLabelText(string _text)
        {
            label_ChangeHotheyHelp.Text = _text;
        }

        public void ActivateButton()
        {
            nonSelectableButton_Confirm.Enabled = true;
        }

        private void nonSelectableButton_Confirm_Click(object sender, EventArgs e)
        {
            MainForm.isClosedByButton = true;

            Close();
        }
    }
}
