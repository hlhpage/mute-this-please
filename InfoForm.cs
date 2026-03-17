using System.Diagnostics;
using System.Reflection;

namespace mute_this_please
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();

            string version = FileVersionInfo.GetVersionInfo(Environment.ProcessPath).FileVersion ?? "пупупу";
            label_Version.Text = version;
        }

        private void pictureBox_logo_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://t.me/hlhpage",
                UseShellExecute = true
            });
        }

        private void linkLabel_SourceCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/hlhpage/mute-this-please",
                UseShellExecute = true
            });
        }
    }
}
