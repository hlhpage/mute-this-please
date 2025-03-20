using System.Diagnostics;
using System.Runtime.InteropServices;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace mute_this_please
{
    public partial class MainForm : Form
    {
        #region Поля
        private static Preferences preferences;
        public static Localization localization;

        private Dictionary<string, string> activeDevices = new Dictionary<string, string>();
        private Dictionary<string, float> defaultVolumeLevel = new Dictionary<string, float>();
        private bool isMuted = false;
        private bool isWork = false;

        private string CURRENT_DIR = AppDomain.CurrentDomain.BaseDirectory;
        private const string PREFERENCES_FILE = "preferences.json";
        private string LOCALIZATION_PATH = "languages";
        private const string MUTE_SOUND = "mute.mp3";
        private const string UNMUTE_SOUND = "unmute.mp3";

        private List<string> localizationsPaths = new List<string>();


        private string PREFERENCES_PATH;

        private bool isTracking = false;

        static ChangeHotkeyForm? cachedChangeKeyForm = null;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        private bool isFormLoaded = false;
        public static bool isLoacalizationLoaded = false;
        private int newHotkey;
        public static bool isClosedByButton;
        public static string[]? addNewProgsArray;

        private WaveOutEvent outputDeviceMute;
        private AudioFileReader audioFileMute;
        private WaveOutEvent outputDeviceUnmute;
        private AudioFileReader audioFileUnmute;

        private static IntPtr hookID = IntPtr.Zero;
        private static LowLevelKeyboardProc proc;

        private Dictionary<int, bool> pressedKeys = new Dictionary<int, bool>();

        public static Dictionary<int, string> humanKeys = new Dictionary<int, string>
        {
            { 8, "Backspace" },
            { 9, "Tab" },
            { 12, "Clear" },
            { 13, "Enter" },
            { 16, "Shift" },
            { 17, "Ctrl" },
            { 18, "Alt" },
            { 19, "Pause/Break" },
            { 20, "Caps Lock" },
            { 27, "Escape" },
            { 32, "Space" },
            { 33, "Page Up" },
            { 34, "Page Down" },
            { 35, "End" },
            { 36, "Home" },
            { 37, "Left Arrow" },
            { 38, "Up Arrow" },
            { 39, "Right Arrow" },
            { 40, "Down Arrow" },
            { 44, "Print Screen" },
            { 45, "Insert" },
            { 46, "Delete" },
            { 48, "0" },
            { 49, "1" },
            { 50, "2" },
            { 51, "3" },
            { 52, "4" },
            { 53, "5" },
            { 54, "6" },
            { 55, "7" },
            { 56, "8" },
            { 57, "9" },
            { 91, "Left Windows" },
            { 92, "Right Windows" },
            { 93, "Menu" },
            { 96, "Numpad 0" },
            { 97, "Numpad 1" },
            { 98, "Numpad 2" },
            { 99, "Numpad 3" },
            { 100, "Numpad 4" },
            { 101, "Numpad 5" },
            { 102, "Numpad 6" },
            { 103, "Numpad 7" },
            { 104, "Numpad 8" },
            { 105, "Numpad 9" },
            { 106, "Numpad *" },
            { 107, "Numpad +" },
            { 109, "Numpad -" },
            { 110, "Numpad ." },
            { 111, "Numpad /" },
            { 112, "F1" },
            { 113, "F2" },
            { 114, "F3" },
            { 115, "F4" },
            { 116, "F5" },
            { 117, "F6" },
            { 118, "F7" },
            { 119, "F8" },
            { 120, "F9" },
            { 121, "F10" },
            { 122, "F11" },
            { 123, "F12" },
            { 144, "Num Lock" },
            { 145, "Scroll Lock" },
            { 160, "Left Shift" },
            { 161, "Right Shift" },
            { 162, "Left Control" },
            { 163, "Right Control" },
            { 164, "Left ALT" },
            { 165, "Right ALT" },
            { 65, "A" },
            { 66, "B" },
            { 67, "C" },
            { 68, "D" },
            { 69, "E" },
            { 70, "F" },
            { 71, "G" },
            { 72, "H" },
            { 73, "I" },
            { 74, "J" },
            { 75, "K" },
            { 76, "L" },
            { 77, "M" },
            { 78, "N" },
            { 79, "O" },
            { 80, "P" },
            { 81, "Q" },
            { 82, "R" },
            { 83, "S" },
            { 84, "T" },
            { 85, "U" },
            { 86, "V" },
            { 87, "W" },
            { 88, "X" },
            { 89, "Y" },
            { 90, "Z" },
            { 186, ";" },
            { 187, "=" },
            { 188, "," },
            { 189, "-" },
            { 190, "." },
            { 191, "/" },
            { 192, "~" },
            { 219, "[" },
            { 220, "\\" },
            { 221, "]" },
            { 222, "'" }
        };
        #endregion

        public MainForm()
        {
            PREFERENCES_PATH = Path.Combine(CURRENT_DIR, PREFERENCES_FILE);
            LOCALIZATION_PATH = Path.Combine(CURRENT_DIR, LOCALIZATION_PATH);

            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;

            InitializeComponent();
            proc = HookCallback;
        }



        private void PreferencesInit()
        {
            if (File.Exists(PREFERENCES_PATH))
            {
                LoadPreferencesFromFile(PREFERENCES_PATH);
            }
            else
            {
                SavePreferencesToFile(PREFERENCES_PATH, true);
            }
        }

        private void LoadPreferencesFromFile(string path = "")
        {
            if (path == "") path = PREFERENCES_PATH;

            var json = File.ReadAllText(path);
            preferences = JsonSerializer.Deserialize<Preferences>(json);
        }

        private void SavePreferencesToFile(string path = "", bool isNew = false)
        {
            if (path == "") path = PREFERENCES_PATH;
            if (isNew) preferences = new Preferences();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string json = JsonSerializer.Serialize(preferences, options);
            File.WriteAllText(path, json);
        }

        private void LoadLocalizationsFromFiles()
        {
            if (!Directory.Exists(LOCALIZATION_PATH)) Directory.CreateDirectory(LOCALIZATION_PATH);

            var currentLocalization = Path.Combine(LOCALIZATION_PATH, preferences.Language);
            if (File.Exists(currentLocalization))
            {
                var locateJson = File.ReadAllText(currentLocalization);
                localization = JsonSerializer.Deserialize<Localization>(locateJson);
            }
            else
            {
                localization = new Localization();
                currentLocalization = Path.Combine(LOCALIZATION_PATH, "Русский.json");

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                MessageBox.Show(Directory.GetFiles(LOCALIZATION_PATH).Length == 0
                    ? "Not a single localization file was found! A new one was created for Russian language in \"languages\" folder. If you want to localize the program to your language, change the Русский.json file or duplicate this file, change its name and translate the values inside it from Russian to your language. More languages translated using ChatGPT are available in the release version at the link https://github.com/hlhpage/mute-this-please/releases"
                    : "Current localization file was missing! A new one was created for Russian language in \"languages\" folder. If you want to localize the program to your language, change the Русский.json file or duplicate this file, change its name and translate the values inside it from Russian to your language. More languages translated using ChatGPT are available in the release version at the link https://github.com/hlhpage/mute-this-please/releases",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                preferences.Language = "Русский.json";
                string json = JsonSerializer.Serialize(localization, options);
                
                File.WriteAllText(currentLocalization, json);
                SavePreferencesToFile();
            }

            isLoacalizationLoaded = true;
        }

        private void UpdadeDevices()
        {
            comboBox_audioDevice.Items.Clear();
            comboBox_audioDevice.Items.Add(localization.List_DefaultDevice);

            var deviceEnumerator = new MMDeviceEnumerator();

            var devices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

            foreach (var device in devices)
            {
                activeDevices[device.FriendlyName] = device.ID;
                comboBox_audioDevice.Items.Add(device.FriendlyName);
            }

            comboBox_audioDevice.SelectedIndex = 0;
        }

        void InitPlayers()
        {
            string muteSoundPath = Path.Combine(CURRENT_DIR, MUTE_SOUND);
            string unmuteSoundPath = Path.Combine(CURRENT_DIR, UNMUTE_SOUND);

            audioFileMute = new AudioFileReader(muteSoundPath);
            outputDeviceMute = new WaveOutEvent();
            outputDeviceMute.Init(audioFileMute);

            audioFileUnmute = new AudioFileReader(unmuteSoundPath);
            outputDeviceUnmute = new WaveOutEvent();
            outputDeviceUnmute.Init(audioFileUnmute);

            UpdateBeepVolumes();
        }

        private void SetLocalization()
        {
            button_start.Text = localization.Button_StartWork;

            groupBox_Device.Text = localization.Group_Device;
            comboBox_audioDevice.Items[0] = localization.List_DefaultDevice;
            button_UpdateDevices.Text = localization.Button_UpdateDevices;

            groupBox_Mode.Text = localization.Group_WorkMode;
            radioButton_Blacklist.Text = localization.Radio_Blacklist;
            toolTip.SetToolTip(radioButton_Blacklist, localization.Tooltip_Blacklist);
            radioButton_Whitelist.Text = localization.Radio_Whitelist;
            toolTip.SetToolTip(radioButton_Whitelist, localization.Tooltip_Whitelist);
            checkBox_treyIcon.Text = localization.Check_HideToTrey;
            toolTip.SetToolTip(comboBox_Languages, localization.Tooltip_Language);

            groupBox_Volume.Text = localization.Group_Volume;
            toolTip.SetToolTip(trackBar_VolumeValue, localization.Tooltip_Volume);
            toolTip.SetToolTip(label_VolumeValue, localization.Tooltip_Volume);

            groupBox_hotkeys.Text = localization.Group_Hotkeys;

            groupBox_MuteHotkey.Text = localization.Group_MuteHotkey;
            button_HotkeyVolume.Text = localization.Button_ChangeMuteHothey;
            toolTip.SetToolTip(label_HotkeyVolume, localization.Tooltip_MuteHotkey);

            groupBox_ExitHotkey.Text = localization.Group_ExitHotkey;
            button_HotkeyExit.Text = localization.Button_ChangeExitHothey;
            toolTip.SetToolTip(label_HotkeyExit, localization.Tooltip_ExitHotkey);

            groupBox_SoundIndication.Text = localization.Group_SoundIndication;
            toolTip.SetToolTip(trackBar_BeepVolume, localization.Tooltip_IndicationVolume);
            toolTip.SetToolTip(label_BeepVolume, localization.Tooltip_IndicationVolume);

            groupBox_FocusedProgramsList.Text = localization.Group_FocusedProgramList;
            button_addProgramFromMixer.Text = localization.Button_AddToListWithMixer;
            button_addProgramByName.Text = localization.Button_AddToListByName;
            button_removeProgram.Text = localization.Button_RemoveFromList;

            label_Work.Text = localization.Label_Work;
        }

        private void UpdateUI()
        {
            label_VolumeValue.Text = $"{preferences.Volume}%";
            trackBar_VolumeValue.Value = preferences.Volume;
            label_BeepVolume.Text = $"{preferences.BeepVolume}%";
            trackBar_BeepVolume.Value = preferences.BeepVolume;
            humanKeys.TryGetValue(preferences.MuteHotkey, out string muteKey);
            label_HotkeyVolume.Text = muteKey;
            humanKeys.TryGetValue(preferences.ExitHotkey, out string exitKey);
            label_HotkeyExit.Text = exitKey;
            label_Work.Text = localization.Label_Work;

            if (preferences.WhitelistMode)
            {
                radioButton_Blacklist.Checked = false;
                radioButton_Whitelist.Checked = true;
            }
            else
            {
                radioButton_Blacklist.Checked = true;
                radioButton_Whitelist.Checked = false;
            }

            listBox_focusedPrograms.Items.Clear();

            foreach (var item in preferences.Programs)
            {
                listBox_focusedPrograms.Items.Add(item);
            }

            button_start.Enabled = preferences.Programs.Count != 0 ? true : false;
            checkBox_treyIcon.Checked = preferences.HideToTrey;

            localizationsPaths = Directory.GetFiles(LOCALIZATION_PATH, "*.json").ToList<string>();
            comboBox_Languages.Items.Clear();
            for (int i = 0; i < localizationsPaths.Count; i++)
            {
                var filename = localizationsPaths[i].Split('\\')[^1];
                comboBox_Languages.Items.Add(filename.Substring(0, filename.Length - 5));
                if (filename == preferences.Language) comboBox_Languages.SelectedIndex = i;
            }
        }



        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;

                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
                {
                    Application.OpenForms[0]?.BeginInvoke(new Action(() =>
                    {
                        MainForm mainForm = Application.OpenForms[0] as MainForm;
                        if (mainForm != null) mainForm.pressedKeys[vkCode] = true;
                    }));
                }

                if (wParam == WM_KEYUP || wParam == WM_SYSKEYUP)
                {

                    Application.OpenForms[0]?.BeginInvoke(new Action(() =>
                    {
                        MainForm mainForm = Application.OpenForms[0] as MainForm;
                        if (mainForm != null)
                        {
                            if (mainForm.isWork && vkCode == preferences.ExitHotkey)
                            {
                                mainForm.EndWork();
                            }

                            if (mainForm.isWork && vkCode == preferences.MuteHotkey)
                            {
                                mainForm.PlaySound();

                                if (!preferences.WhitelistMode)
                                {
                                    if (!mainForm.isMuted) mainForm.defaultVolumeLevel = mainForm.GetDefaultLevels();

                                    foreach (var item in preferences.Programs)
                                    {
                                        if (!mainForm.defaultVolumeLevel.ContainsKey(item)) continue;

                                        mainForm.ChangeVolume(item, !mainForm.isMuted ? preferences.Volume : (int)(mainForm.defaultVolumeLevel[item] * 100));
                                    }

                                }
                                else
                                {
                                    var allActiveSessions = mainForm.GetAllSessions();
                                    if (!mainForm.isMuted) mainForm.defaultVolumeLevel = mainForm.GetDefaultLevels();

                                    foreach (var item in allActiveSessions)
                                    {
                                        if (preferences.Programs.Contains(item)) continue;

                                        mainForm.ChangeVolume(item, !mainForm.isMuted ? preferences.Volume : (int)(mainForm.defaultVolumeLevel[item] * 100));
                                    }

                                }


                                mainForm.isMuted = !mainForm.isMuted;
                            }

                            if (humanKeys.TryGetValue(vkCode, out string humanKey))
                            {
                                if (cachedChangeKeyForm != null && mainForm.pressedKeys.Count == 1)
                                {
                                    cachedChangeKeyForm.ChangeLabelText(localization.Label_HotkeyDetect + humanKey);
                                    mainForm.newHotkey = vkCode;
                                    cachedChangeKeyForm.ActivateButton();
                                }
                            }

                            mainForm.pressedKeys.Remove(vkCode);
                        }
                    }));
                }

            }

            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);



        private void StartWork()
        {
            isMuted = false;

            linkLabel_hlh.Enabled = false;
            checkBox_treyIcon.Enabled = false;
            button_addProgramByName.Enabled = false;
            button_addProgramFromMixer.Enabled = false;
            button_removeProgram.Enabled = false;
            button_HotkeyVolume.Enabled = false;
            button_HotkeyExit.Enabled = false;
            comboBox_audioDevice.Enabled = false;
            button_UpdateDevices.Enabled = false;
            trackBar_VolumeValue.Enabled = false;
            trackBar_BeepVolume.Enabled = false;
            radioButton_Whitelist.Enabled = false;
            radioButton_Blacklist.Enabled = false;
            button_start.Enabled = false;
            panel_Work.Visible = true;

            isWork = true;
        }

        private void EndWork()
        {
            isWork = false;

            if (isMuted)
            {
                foreach (var item in defaultVolumeLevel.Keys)
                {
                    ChangeVolume(item, (int)(defaultVolumeLevel[item] * 100));
                }

                isMuted = false;
            }

            defaultVolumeLevel = new Dictionary<string, float>();

            linkLabel_hlh.Enabled = true;
            checkBox_treyIcon.Enabled = true;
            button_addProgramByName.Enabled = true;
            button_addProgramFromMixer.Enabled = true;
            button_removeProgram.Enabled = true;
            button_HotkeyVolume.Enabled = true;
            button_HotkeyExit.Enabled = true;
            comboBox_audioDevice.Enabled = true;
            button_UpdateDevices.Enabled = true;
            trackBar_VolumeValue.Enabled = true;
            trackBar_BeepVolume.Enabled = true;
            radioButton_Whitelist.Enabled = true;
            radioButton_Blacklist.Enabled = true;
            button_start.Enabled = true;
            panel_Work.Visible = false;
        }

        private void ChangeVolume(string processName, int settedVolume)
        {
            var deviceEnumerator = new MMDeviceEnumerator();
            var defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);


            if (comboBox_audioDevice.Text == localization.List_DefaultDevice)
            {
                defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            }
            else
            {
                defaultDevice = deviceEnumerator.GetDevice(activeDevices[comboBox_audioDevice.Text]);
            }

            var sessionManager = defaultDevice.AudioSessionManager;
            var sessions = sessionManager.Sessions;

            for (int i = 0; i < sessions.Count; i++)
            {
                var session = sessions[i];
                var processId = (int)session.GetProcessID;
                var process = Process.GetProcessById(processId);

                if (processName != $"{process.ProcessName}.exe") continue;

                var selectedSession = sessions[i];
                selectedSession.SimpleAudioVolume.Volume = settedVolume / 100f;
            }
        }

        private List<string> GetAllSessions()
        {
            List<string> result = new List<string>();
            var deviceEnumerator = new MMDeviceEnumerator();
            var defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);


            if (comboBox_audioDevice.Text == localization.List_DefaultDevice)
            {
                defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            }
            else
            {
                defaultDevice = deviceEnumerator.GetDevice(activeDevices[comboBox_audioDevice.Text]);
            }

            var sessionManager = defaultDevice.AudioSessionManager;
            var sessions = sessionManager.Sessions;

            for (int i = 0; i < sessions.Count; i++)
            {
                var session = sessions[i];
                var processId = (int)session.GetProcessID;

                if (processId == 0) continue;

                var process = Process.GetProcessById(processId);
                if (process.ProcessName == "mute this please") continue;

                result.Add($"{process.ProcessName}.exe");
            }

            return result;
        }

        private Dictionary<string, float> GetDefaultLevels()
        {
            Dictionary<string, float> result = new Dictionary<string, float>();
            var deviceEnumerator = new MMDeviceEnumerator();
            var defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);


            if (comboBox_audioDevice.Text == localization.List_DefaultDevice)
            {
                defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            }
            else
            {
                defaultDevice = deviceEnumerator.GetDevice(activeDevices[comboBox_audioDevice.Text]);
            }

            var sessionManager = defaultDevice.AudioSessionManager;
            var sessions = sessionManager.Sessions;

            for (int i = 0; i < sessions.Count; i++)
            {
                var session = sessions[i];
                var processId = (int)session.GetProcessID;

                if (processId == 0) continue;

                var process = Process.GetProcessById(processId);
                result[$"{process.ProcessName}.exe"] = session.SimpleAudioVolume.Volume;
            }

            return result;
        }

        private void VolumeValueEndChange()
        {
            if (isTracking)
            {
                isTracking = false;

                preferences.Volume = trackBar_VolumeValue.Value;

                SavePreferencesToFile();
                UpdateUI();
            }
        }

        private void BeepValueEndChange()
        {
            if (isTracking)
            {
                isTracking = false;

                preferences.BeepVolume = trackBar_BeepVolume.Value;

                SavePreferencesToFile();
                UpdateBeepVolumes();
                UpdateUI();

                PlaySound();
            }
        }

        private void ChangeHotkey(bool isMuteKey)
        {
            isClosedByButton = false;
            ChangeHotkeyForm changeKey = new ChangeHotkeyForm(isMuteKey);
            cachedChangeKeyForm = changeKey;
            newHotkey = -1;
            changeKey.ShowDialog();

            if (!isClosedByButton || newHotkey == -1)
            {
                cachedChangeKeyForm = null;
                return;
            }

            if ((isMuteKey && newHotkey == preferences.ExitHotkey) || (!isMuteKey && newHotkey == preferences.MuteHotkey))
            {
                cachedChangeKeyForm = null;
                MessageBox.Show(localization.Message_SimilarHotkeys, localization.Message_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isMuteKey) preferences.MuteHotkey = newHotkey;
            else preferences.ExitHotkey = newHotkey;
            cachedChangeKeyForm = null;
            SavePreferencesToFile();
            UpdateUI();
        }



        private void PlaySound()
        {
            outputDeviceUnmute.Stop();
            outputDeviceMute.Stop();

            if (isMuted)
            {
                audioFileUnmute.Position = 0;
                outputDeviceUnmute.Play();
            }
            else
            {
                audioFileMute.Position = 0;
                outputDeviceMute.Play();
            }
        }

        private void UpdateBeepVolumes()
        {
            audioFileUnmute.Volume = preferences.BeepVolume / 100f;
            audioFileMute.Volume = preferences.BeepVolume / 100f;
        }

        void DisposePlayer()
        {
            if (outputDeviceMute != null) outputDeviceMute.Dispose();
            if (audioFileMute != null) audioFileMute.Dispose();

            if (outputDeviceUnmute != null) outputDeviceUnmute.Dispose();
            if (audioFileUnmute != null) audioFileUnmute.Dispose();
        }


        #region Классы
        class Preferences
        {
            public bool WhitelistMode { get; set; }
            public bool HideToTrey { get; set; }
            public List<string> Programs { get; set; }
            public int Volume { get; set; }
            public int BeepVolume { get; set; }
            public int MuteHotkey { get; set; }
            public int ExitHotkey { get; set; }
            public string Language { get; set; }

            public Preferences()
            {
                WhitelistMode = false;
                HideToTrey = false;
                Programs = new List<string>();
                Volume = 0;
                BeepVolume = 75;
                MuteHotkey = 192;
                ExitHotkey = 109;
                Language = "Русский.json";
            }
        }

        public class Localization
        {
            public string Button_StartWork { get; set; }
            public string Button_UpdateDevices { get; set; }
            public string Button_AddToListWithMixer { get; set; }
            public string Button_AddToListByName { get; set; }
            public string Button_RemoveFromList { get; set; }
            public string Button_ChangeMuteHothey { get; set; }
            public string Button_ChangeExitHothey { get; set; }
            public string Button_ConfirmHotkeyChange { get; set; }
            public string Button_ConfirmAddByName { get; set; }
            public string Button_ConfirmFromMixer { get; set; }
            public string Button_SelectAllFromMixer { get; set; }
            public string Button_DeselectAllFromMixer { get; set; }
            public string Group_Device { get; set; }
            public string Group_WorkMode { get; set; }
            public string Group_Volume { get; set; }
            public string Group_Hotkeys { get; set; }
            public string Group_MuteHotkey { get; set; }
            public string Group_ExitHotkey { get; set; }
            public string Group_SoundIndication { get; set; }
            public string Group_FocusedProgramList { get; set; }
            public string Radio_Blacklist { get; set; }
            public string Radio_Whitelist { get; set; }
            public string Check_HideToTrey { get; set; }
            public string Label_AddByNameInstruction { get; set; }
            public string Label_AddWithMixer { get; set; }
            public string Label_RemoveWithMixer { get; set; }
            public string Label_MuteHotkeyChange { get; set; }
            public string Label_ExitHotkeyChange { get; set; }
            public string Label_HotkeyInstruction { get; set; }
            public string Label_HotkeyDetect { get; set; }
            private string label_Work;
            public string Label_Work
            {
                get
                {
                    string newLabel = "";

                    if (!isLoacalizationLoaded)
                    {
                        newLabel = label_Work;
                    }
                    else
                    {
                        var splitted = label_Work.Split("[KEY]");
                        newLabel += splitted[0];
                        humanKeys.TryGetValue(preferences.MuteHotkey, out string humanMuteKey);
                        newLabel += humanMuteKey;
                        newLabel += splitted[1];
                        humanKeys.TryGetValue(preferences.ExitHotkey, out string humanExitKey);
                        newLabel += humanExitKey;
                        newLabel += splitted[2];
                    }

                    return newLabel;
                }
                set
                {
                    label_Work = value;
                }
            }

            public string Title_AddByName { get; set; }
            public string Title_AddWithMixer { get; set; }
            public string Title_RemoveWithMixer { get; set; }
            public string Title_ChangeHotkey { get; set; }
            public string List_DefaultDevice { get; set; }
            public string Message_ErrorTitle { get; set; }
            public string Message_EmptyList { get; set; }
            public string Message_EmptyMixer { get; set; }
            public string Message_SimilarHotkeys { get; set; }
            public string Tooltip_Blacklist { get; set; }
            public string Tooltip_Whitelist { get; set; }
            public string Tooltip_Volume { get; set; }
            public string Tooltip_MuteHotkey { get; set; }
            public string Tooltip_ExitHotkey { get; set; }
            public string Tooltip_IndicationVolume { get; set; }
            public string Tooltip_Language { get; set; }

            public Localization()
            {
                Button_StartWork = "За работу!";
                Button_UpdateDevices = "Обновить список активных устройств";
                Button_AddToListWithMixer = "Добавить программу из микшера";
                Button_AddToListByName = "Добавить программу по названию процесса";
                Button_RemoveFromList = "Удалить программу из списка";
                Button_ChangeMuteHothey = "Изменить";
                Button_ChangeExitHothey = "Изменить";
                Button_ConfirmHotkeyChange = "Подтвердить";
                Button_ConfirmAddByName = "Подтвердить";
                Button_ConfirmFromMixer = "Подтвердить";
                Button_SelectAllFromMixer = "Выделить всё пункты";
                Button_DeselectAllFromMixer = "Очистить выделение";
                Group_Device = "Устройство воспроизведения звука";
                Group_WorkMode = "Режим работы";
                Group_Volume = "Уровень громкости";
                Group_Hotkeys = "Горячие клавиши";
                Group_MuteHotkey = "Кнопка изменения громкости";
                Group_ExitHotkey = "Кнопка прекращения работы";
                Group_SoundIndication = "Громкость звуковой индикации";
                Group_FocusedProgramList = "Список сфокусированных программ";
                Radio_Blacklist = "Чёрный список";
                Radio_Whitelist = "Белый список";
                Check_HideToTrey = "Сворачивать программу в трей";
                Label_AddByNameInstruction = "Для добавления процесса введите его название без указания расширения \".exe\" на конце\nДля добавления нескольких процессов введите их названия через /";
                Label_AddWithMixer = "Выберите программы для добавления";
                Label_RemoveWithMixer = "Выберите программы для удаления";
                Label_MuteHotkeyChange = "Изменение кнопки изменения громкости";
                Label_ExitHotkeyChange = "Изменение кнопки прекращения работы";
                Label_HotkeyInstruction = "Нажмите и отпустите желаемую клавишу";
                Label_HotkeyDetect = "Зафиксировано нажатие ";
                Label_Work = "Программа работает!\nНажмите [KEY] для изменения уровня громкости.\nНажмите [KEY] для прекращения работы.";
                Title_AddByName = "Добавить по названию";
                Title_AddWithMixer = "Добавить из микшера";
                Title_RemoveWithMixer = "Удалить из списка сфокусированных программ";
                Title_ChangeHotkey = "Изменение горячей клавиши";
                List_DefaultDevice = "(Устройство по умолчанию)";
                Message_ErrorTitle = "Ошибка";
                Message_EmptyList = "В списке сфокусированных програм нет ни одной позиции!";
                Message_EmptyMixer = "В микшере не найдено ни одного процесса!";
                Message_SimilarHotkeys = "Клавиша изменения громкости и клавиша прекращения работы не должны совпадать!";
                Tooltip_Blacklist = "В режиме чёрного списка громкость будет меняться только у процессов,\nкоторые находятся в списке сфокусированных программ.";
                Tooltip_Whitelist = "В режиме белого списка громкость будет меняться у всех процессов,\nкроме тех которые находятся в списке сфокусированных программ.";
                Tooltip_Volume = "Значение до которого будет изменяться уровень громкости\nпроцессов из списка сфокусированных программ.";
                Tooltip_MuteHotkey = "Клавиша, нажатие на которую будет активировать изменение громкости.";
                Tooltip_ExitHotkey = "Клавиша, нажатие на которую будет прекращать работу программы.";
                Tooltip_IndicationVolume = "Значение громкости с которой будут воспроизводится звуки,\nсигнализирующие о активации или деактивации изменения громкости.";
                Tooltip_Language = "Язык интерфейса программы.";
            }
        }
        #endregion

        #region События
        private void MainForm_Load(object sender, EventArgs e)
        {
            PreferencesInit();
            LoadLocalizationsFromFiles();
            UpdadeDevices();
            InitPlayers();

            panel_Work.Location = new Point(10, 12);

            radioButton_Blacklist.CheckedChanged += RadioButton_CheckedChanged;
            radioButton_Whitelist.CheckedChanged += RadioButton_CheckedChanged;

            hookID = SetHook(proc);

            SetLocalization();
            UpdateUI();
            isFormLoaded = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(hookID);

            EndWork();
            DisposePlayer();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (!preferences.HideToTrey) return;

            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                Hide();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }



        private void button_addProgramFromMixer_Click(object sender, EventArgs e)
        {
            addNewProgsArray = null;

            var acriveProcces = GetAllSessions();

            if (acriveProcces.Count == 0)
            {
                MessageBox.Show(localization.Message_EmptyMixer, localization.Message_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var _form = new FocusedProgramsListInteractForm(acriveProcces, localization.Title_AddWithMixer);

            _form.ChangeInstuction(localization.Label_AddWithMixer);
            _form.ShowDialog();

            if (!isClosedByButton || addNewProgsArray == null) return;

            foreach (var item in addNewProgsArray)
            {
                if (preferences.Programs.Contains(item)) continue;
                preferences.Programs.Add(item);
            }

            addNewProgsArray = null;
            isClosedByButton = false;

            SavePreferencesToFile();
            UpdateUI();
        }

        private void button_addProgramByName_Click(object sender, EventArgs e)
        {
            addNewProgsArray = null;
            isClosedByButton = false;

            var _form = new AddProgramByNameForm();

            _form.ShowDialog();

            if (!isClosedByButton || addNewProgsArray == null) return;

            foreach (var item in addNewProgsArray)
            {
                if (preferences.Programs.Contains($"{item}.exe") || item == "") continue;

                preferences.Programs.Add($"{item}.exe");
            }

            addNewProgsArray = null;
            isClosedByButton = false;

            SavePreferencesToFile();
            UpdateUI();
        }

        private void button_removeProgram_Click(object sender, EventArgs e)
        {
            if (preferences.Programs.Count == 0)
            {
                MessageBox.Show(localization.Message_EmptyList, localization.Message_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            addNewProgsArray = null;
            isClosedByButton = false;

            var _form = new FocusedProgramsListInteractForm(preferences.Programs, localization.Title_RemoveWithMixer);

            _form.ChangeInstuction(localization.Label_RemoveWithMixer);
            _form.ShowDialog();

            if (!isClosedByButton || addNewProgsArray == null) return;

            foreach (var item in addNewProgsArray)
            {
                preferences.Programs.Remove(item);
            }

            addNewProgsArray = null;
            isClosedByButton = false;

            SavePreferencesToFile();
            UpdateUI();
        }



        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!isFormLoaded) return;

            RadioButton rb = sender as RadioButton;

            if (rb != null && rb.Checked)
            {
                preferences.WhitelistMode = rb == radioButton_Whitelist ? true : false;

                SavePreferencesToFile();
            }
        }

        private void checkBox_treyIcon_CheckedChanged(object sender, EventArgs e)
        {
            preferences.HideToTrey = checkBox_treyIcon.Checked;

            SavePreferencesToFile();
            UpdateUI();
        }

        private void comboBox_Languages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFormLoaded || !isLoacalizationLoaded) return;

            isLoacalizationLoaded = false;
            preferences.Language = comboBox_Languages.Text + ".json";

            SavePreferencesToFile();
            LoadLocalizationsFromFiles();
            SetLocalization();
        }



        private void button_HotkeyVolume_Click(object sender, EventArgs e)
        {
            ChangeHotkey(true);
        }

        private void button_HotkeyExit_Click(object sender, EventArgs e)
        {
            ChangeHotkey(false);
        }



        private void trackBar_VolumeValue_ValueChanged(object sender, EventArgs e)
        {
            isTracking = true;

            label_VolumeValue.Text = $"{trackBar_VolumeValue.Value}%";
        }

        private void trackBar_VolumeValue_MouseUp(object sender, MouseEventArgs e)
        {
            VolumeValueEndChange();
        }

        private void trackBar_VolumeValue_KeyUp(object sender, KeyEventArgs e)
        {
            VolumeValueEndChange();
        }



        private void trackBar_BeepVolume_ValueChanged(object sender, EventArgs e)
        {
            isTracking = true;

            label_BeepVolume.Text = $"{trackBar_BeepVolume.Value}%";
        }

        private void trackBar_BeepVolume_MouseUp(object sender, MouseEventArgs e)
        {
            BeepValueEndChange();
        }

        private void trackBar_BeepVolume_KeyUp(object sender, KeyEventArgs e)
        {
            BeepValueEndChange();
        }



        private void button_start_Click(object sender, EventArgs e)
        {
            StartWork();
        }



        private void button_UpdateDevices_Click(object sender, EventArgs e)
        {
            UpdadeDevices();
        }



        private void linkLabel_hlh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var infoForm = new InfoForm();
            infoForm.ShowDialog();
        }
        #endregion
    }
}
