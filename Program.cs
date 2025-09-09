namespace mute_this_please
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MainForm.PreferencesInit();
            MainForm.LoadLocalizationsFromFiles();

            bool isInstanceExist;

            using (Mutex mutex = new Mutex(true, "mute this please", out isInstanceExist))
            {
                if (!isInstanceExist)
                {
                    MessageBox.Show(MainForm.localization.Message_InstanceError, MainForm.localization.Title_MessageError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MainForm mainForm;
                    // To customize application configuration such as set high DPI settings or default font,
                    // see https://aka.ms/applicationconfiguration.
                    ApplicationConfiguration.Initialize();
                    Application.Run(mainForm = new MainForm());
                }
            }
        }
    }
}