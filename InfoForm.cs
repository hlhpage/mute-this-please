namespace mute_this_please
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void pictureBox_logo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://t.me/hlhpage",
                UseShellExecute = true
            });
        }

        private void linkLabel_SourceCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/hlhpage/mute-this-please",
                UseShellExecute = true
            });
        }
    }
}
