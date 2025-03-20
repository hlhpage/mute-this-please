namespace mute_this_please
{
    public partial class AddProgramByNameForm : Form
    {
        public AddProgramByNameForm()
        {
            InitializeComponent();
            label_Insteuctions.Text = MainForm.localization.Label_AddByNameInstruction;
            button_Add.Text = MainForm.localization.Button_ConfirmAddByName;
            Text = MainForm.localization.Title_AddByName;
        }



        private void button_Add_Click(object sender, EventArgs e)
        {
            string[] newProgs = textBox_Programs.Text.Split('/');

            MainForm.addNewProgsArray = newProgs;

            MainForm.isClosedByButton = true;

            this.Close();
        }
    }
}
