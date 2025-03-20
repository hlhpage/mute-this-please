namespace mute_this_please
{
    public partial class FocusedProgramsListInteractForm : Form
    {

        public FocusedProgramsListInteractForm()
        {
            InitializeComponent();   
        }

        public FocusedProgramsListInteractForm(List<string> avalibleItems, string title)
        {
            InitializeComponent();

            button_SelectAll.Text = MainForm.localization.Button_SelectAllFromMixer;
            button_DeselectAll.Text = MainForm.localization.Button_DeselectAllFromMixer;
            button_Confirm.Text = MainForm.localization.Button_ConfirmHotkeyChange;

            checkedListBox.Items.Clear();

            foreach (var item in avalibleItems)
            {
                checkedListBox.Items.Add(item);
            }

            Text = title;
        }

        public void ChangeInstuction(string instruction)
        {
            label_Instructions.Text = instruction;
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();

            foreach (string item in checkedListBox.CheckedItems) selectedItems.Add(item);

            MainForm.addNewProgsArray = selectedItems.ToArray();
            MainForm.isClosedByButton = true;

            Close();
        }

        private void button_SelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++) checkedListBox.SetItemChecked(i, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++) checkedListBox.SetItemChecked(i, false);
        }
    }
}
