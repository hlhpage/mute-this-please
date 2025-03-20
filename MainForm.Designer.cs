namespace mute_this_please
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            groupBox_Mode = new GroupBox();
            comboBox_Languages = new ComboBox();
            checkBox_treyIcon = new CheckBox();
            radioButton_Whitelist = new RadioButton();
            radioButton_Blacklist = new RadioButton();
            toolTip = new ToolTip(components);
            trackBar_VolumeValue = new TrackBar();
            label_VolumeValue = new Label();
            label_HotkeyExit = new Label();
            label_HotkeyVolume = new Label();
            trackBar_BeepVolume = new TrackBar();
            label_BeepVolume = new Label();
            button_HotkeyExit = new Button();
            button_HotkeyVolume = new Button();
            groupBox_Volume = new GroupBox();
            groupBox_Device = new GroupBox();
            button_UpdateDevices = new Button();
            comboBox_audioDevice = new ComboBox();
            button_start = new Button();
            groupBox_hotkeys = new GroupBox();
            groupBox_ExitHotkey = new GroupBox();
            groupBox_MuteHotkey = new GroupBox();
            groupBox_FocusedProgramsList = new GroupBox();
            listBox_focusedPrograms = new ListBox();
            button_removeProgram = new Button();
            button_addProgramByName = new Button();
            button_addProgramFromMixer = new Button();
            groupBox_SoundIndication = new GroupBox();
            linkLabel_hlh = new LinkLabel();
            notifyIcon = new NotifyIcon(components);
            panel_Work = new Panel();
            label_Work = new Label();
            groupBox_Mode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_VolumeValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_BeepVolume).BeginInit();
            groupBox_Volume.SuspendLayout();
            groupBox_Device.SuspendLayout();
            groupBox_hotkeys.SuspendLayout();
            groupBox_ExitHotkey.SuspendLayout();
            groupBox_MuteHotkey.SuspendLayout();
            groupBox_FocusedProgramsList.SuspendLayout();
            groupBox_SoundIndication.SuspendLayout();
            panel_Work.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox_Mode
            // 
            groupBox_Mode.Controls.Add(comboBox_Languages);
            groupBox_Mode.Controls.Add(checkBox_treyIcon);
            groupBox_Mode.Controls.Add(radioButton_Whitelist);
            groupBox_Mode.Controls.Add(radioButton_Blacklist);
            groupBox_Mode.Location = new Point(10, 129);
            groupBox_Mode.Name = "groupBox_Mode";
            groupBox_Mode.Size = new Size(233, 100);
            groupBox_Mode.TabIndex = 2;
            groupBox_Mode.TabStop = false;
            groupBox_Mode.Text = "Режим работы";
            // 
            // comboBox_Languages
            // 
            comboBox_Languages.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Languages.FormattingEnabled = true;
            comboBox_Languages.Location = new Point(6, 20);
            comboBox_Languages.Name = "comboBox_Languages";
            comboBox_Languages.Size = new Size(221, 23);
            comboBox_Languages.TabIndex = 5;
            comboBox_Languages.SelectedIndexChanged += comboBox_Languages_SelectedIndexChanged;
            // 
            // checkBox_treyIcon
            // 
            checkBox_treyIcon.AutoSize = true;
            checkBox_treyIcon.Location = new Point(10, 74);
            checkBox_treyIcon.Name = "checkBox_treyIcon";
            checkBox_treyIcon.Size = new Size(200, 19);
            checkBox_treyIcon.TabIndex = 2;
            checkBox_treyIcon.Text = "Сворачивать программу в трей";
            checkBox_treyIcon.UseVisualStyleBackColor = true;
            checkBox_treyIcon.CheckedChanged += checkBox_treyIcon_CheckedChanged;
            // 
            // radioButton_Whitelist
            // 
            radioButton_Whitelist.AutoSize = true;
            radioButton_Whitelist.Location = new Point(126, 48);
            radioButton_Whitelist.Name = "radioButton_Whitelist";
            radioButton_Whitelist.Size = new Size(103, 19);
            radioButton_Whitelist.TabIndex = 1;
            radioButton_Whitelist.Text = "Белый список";
            toolTip.SetToolTip(radioButton_Whitelist, "В режиме белого списка громкость будет меняться у всех процессов,\r\nкроме тех которые находятся в списке сфокусированных программ.");
            radioButton_Whitelist.UseVisualStyleBackColor = true;
            // 
            // radioButton_Blacklist
            // 
            radioButton_Blacklist.AutoSize = true;
            radioButton_Blacklist.Checked = true;
            radioButton_Blacklist.Location = new Point(10, 48);
            radioButton_Blacklist.Name = "radioButton_Blacklist";
            radioButton_Blacklist.Size = new Size(111, 19);
            radioButton_Blacklist.TabIndex = 0;
            radioButton_Blacklist.TabStop = true;
            radioButton_Blacklist.Text = "Чёрный список";
            toolTip.SetToolTip(radioButton_Blacklist, "В режиме чёрного списка громкость будет меняться только у процессов,\r\nкоторые находятся в списке сфокусированных программ.");
            radioButton_Blacklist.UseVisualStyleBackColor = true;
            // 
            // trackBar_VolumeValue
            // 
            trackBar_VolumeValue.Location = new Point(6, 23);
            trackBar_VolumeValue.Maximum = 99;
            trackBar_VolumeValue.Name = "trackBar_VolumeValue";
            trackBar_VolumeValue.Size = new Size(180, 45);
            trackBar_VolumeValue.TabIndex = 2;
            toolTip.SetToolTip(trackBar_VolumeValue, "Значение до которого будет изменяться уровень громкости\r\nпроцессов из списка сфокусированных программ.");
            trackBar_VolumeValue.ValueChanged += trackBar_VolumeValue_ValueChanged;
            trackBar_VolumeValue.KeyUp += trackBar_VolumeValue_KeyUp;
            trackBar_VolumeValue.MouseUp += trackBar_VolumeValue_MouseUp;
            // 
            // label_VolumeValue
            // 
            label_VolumeValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_VolumeValue.Location = new Point(180, 26);
            label_VolumeValue.Name = "label_VolumeValue";
            label_VolumeValue.Size = new Size(51, 24);
            label_VolumeValue.TabIndex = 0;
            label_VolumeValue.Text = "99%";
            label_VolumeValue.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(label_VolumeValue, "Значение до которого будет изменяться уровень громкости\r\nпроцессов из списка сфокусированных программ.");
            // 
            // label_HotkeyExit
            // 
            label_HotkeyExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_HotkeyExit.Location = new Point(6, 19);
            label_HotkeyExit.Name = "label_HotkeyExit";
            label_HotkeyExit.Size = new Size(205, 21);
            label_HotkeyExit.TabIndex = 3;
            label_HotkeyExit.Text = "Numpad -";
            label_HotkeyExit.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(label_HotkeyExit, "Клавиша, нажатие на которую будет\r\nпрекращать работу программы.");
            // 
            // label_HotkeyVolume
            // 
            label_HotkeyVolume.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_HotkeyVolume.Location = new Point(6, 19);
            label_HotkeyVolume.Name = "label_HotkeyVolume";
            label_HotkeyVolume.Size = new Size(205, 21);
            label_HotkeyVolume.TabIndex = 3;
            label_HotkeyVolume.Text = "`";
            label_HotkeyVolume.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(label_HotkeyVolume, "Клавиша, нажатие на которую будет\r\nактивировать изменение громкости.");
            // 
            // trackBar_BeepVolume
            // 
            trackBar_BeepVolume.Location = new Point(6, 23);
            trackBar_BeepVolume.Maximum = 100;
            trackBar_BeepVolume.Name = "trackBar_BeepVolume";
            trackBar_BeepVolume.Size = new Size(180, 45);
            trackBar_BeepVolume.TabIndex = 2;
            toolTip.SetToolTip(trackBar_BeepVolume, "Значение громкости с которой будут воспроизводится звуки,\r\nсигнализирующие о активации или деактивации изменения громкости.");
            trackBar_BeepVolume.ValueChanged += trackBar_BeepVolume_ValueChanged;
            trackBar_BeepVolume.KeyUp += trackBar_BeepVolume_KeyUp;
            trackBar_BeepVolume.MouseUp += trackBar_BeepVolume_MouseUp;
            // 
            // label_BeepVolume
            // 
            label_BeepVolume.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_BeepVolume.ImageAlign = ContentAlignment.MiddleLeft;
            label_BeepVolume.Location = new Point(180, 26);
            label_BeepVolume.Name = "label_BeepVolume";
            label_BeepVolume.Size = new Size(51, 24);
            label_BeepVolume.TabIndex = 0;
            label_BeepVolume.Text = "100%";
            label_BeepVolume.TextAlign = ContentAlignment.MiddleCenter;
            toolTip.SetToolTip(label_BeepVolume, "Значение до которого будет изменяться уровень громкости\r\nпроцессов из списка сфокусированных программ.");
            // 
            // button_HotkeyExit
            // 
            button_HotkeyExit.Location = new Point(6, 43);
            button_HotkeyExit.Name = "button_HotkeyExit";
            button_HotkeyExit.Size = new Size(205, 23);
            button_HotkeyExit.TabIndex = 2;
            button_HotkeyExit.Text = "Изменить";
            button_HotkeyExit.UseVisualStyleBackColor = true;
            button_HotkeyExit.Click += button_HotkeyExit_Click;
            // 
            // button_HotkeyVolume
            // 
            button_HotkeyVolume.Location = new Point(6, 43);
            button_HotkeyVolume.Name = "button_HotkeyVolume";
            button_HotkeyVolume.Size = new Size(205, 23);
            button_HotkeyVolume.TabIndex = 2;
            button_HotkeyVolume.Text = "Изменить";
            button_HotkeyVolume.UseVisualStyleBackColor = true;
            button_HotkeyVolume.Click += button_HotkeyVolume_Click;
            // 
            // groupBox_Volume
            // 
            groupBox_Volume.Controls.Add(trackBar_VolumeValue);
            groupBox_Volume.Controls.Add(label_VolumeValue);
            groupBox_Volume.Location = new Point(10, 230);
            groupBox_Volume.Name = "groupBox_Volume";
            groupBox_Volume.Size = new Size(233, 75);
            groupBox_Volume.TabIndex = 4;
            groupBox_Volume.TabStop = false;
            groupBox_Volume.Text = "Уровень громкости";
            // 
            // groupBox_Device
            // 
            groupBox_Device.Controls.Add(button_UpdateDevices);
            groupBox_Device.Controls.Add(comboBox_audioDevice);
            groupBox_Device.Location = new Point(10, 46);
            groupBox_Device.Name = "groupBox_Device";
            groupBox_Device.Size = new Size(519, 82);
            groupBox_Device.TabIndex = 5;
            groupBox_Device.TabStop = false;
            groupBox_Device.Text = "Устройство воспроизведения звука";
            // 
            // button_UpdateDevices
            // 
            button_UpdateDevices.Location = new Point(8, 51);
            button_UpdateDevices.Name = "button_UpdateDevices";
            button_UpdateDevices.Size = new Size(505, 23);
            button_UpdateDevices.TabIndex = 3;
            button_UpdateDevices.Text = "Обновить список активных устройств";
            button_UpdateDevices.UseVisualStyleBackColor = true;
            button_UpdateDevices.Click += button_UpdateDevices_Click;
            // 
            // comboBox_audioDevice
            // 
            comboBox_audioDevice.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_audioDevice.FormattingEnabled = true;
            comboBox_audioDevice.Items.AddRange(new object[] { "(Устройство по умолчанию)" });
            comboBox_audioDevice.Location = new Point(8, 22);
            comboBox_audioDevice.Name = "comboBox_audioDevice";
            comboBox_audioDevice.Size = new Size(505, 23);
            comboBox_audioDevice.TabIndex = 0;
            // 
            // button_start
            // 
            button_start.Location = new Point(10, 12);
            button_start.Name = "button_start";
            button_start.Size = new Size(519, 33);
            button_start.TabIndex = 3;
            button_start.Text = "За работу!";
            button_start.UseVisualStyleBackColor = true;
            button_start.Click += button_start_Click;
            // 
            // groupBox_hotkeys
            // 
            groupBox_hotkeys.Controls.Add(groupBox_ExitHotkey);
            groupBox_hotkeys.Controls.Add(groupBox_MuteHotkey);
            groupBox_hotkeys.Location = new Point(10, 310);
            groupBox_hotkeys.Name = "groupBox_hotkeys";
            groupBox_hotkeys.Size = new Size(233, 183);
            groupBox_hotkeys.TabIndex = 5;
            groupBox_hotkeys.TabStop = false;
            groupBox_hotkeys.Text = "Горячие клавиши";
            // 
            // groupBox_ExitHotkey
            // 
            groupBox_ExitHotkey.Controls.Add(label_HotkeyExit);
            groupBox_ExitHotkey.Controls.Add(button_HotkeyExit);
            groupBox_ExitHotkey.Location = new Point(8, 99);
            groupBox_ExitHotkey.Name = "groupBox_ExitHotkey";
            groupBox_ExitHotkey.Size = new Size(217, 74);
            groupBox_ExitHotkey.TabIndex = 4;
            groupBox_ExitHotkey.TabStop = false;
            groupBox_ExitHotkey.Text = "Кнопка прекращения работы";
            // 
            // groupBox_MuteHotkey
            // 
            groupBox_MuteHotkey.Controls.Add(label_HotkeyVolume);
            groupBox_MuteHotkey.Controls.Add(button_HotkeyVolume);
            groupBox_MuteHotkey.Location = new Point(8, 19);
            groupBox_MuteHotkey.Name = "groupBox_MuteHotkey";
            groupBox_MuteHotkey.Size = new Size(217, 74);
            groupBox_MuteHotkey.TabIndex = 3;
            groupBox_MuteHotkey.TabStop = false;
            groupBox_MuteHotkey.Text = "Кнопка изменения громкости";
            // 
            // groupBox_FocusedProgramsList
            // 
            groupBox_FocusedProgramsList.Controls.Add(listBox_focusedPrograms);
            groupBox_FocusedProgramsList.Controls.Add(button_removeProgram);
            groupBox_FocusedProgramsList.Controls.Add(button_addProgramByName);
            groupBox_FocusedProgramsList.Controls.Add(button_addProgramFromMixer);
            groupBox_FocusedProgramsList.Location = new Point(249, 134);
            groupBox_FocusedProgramsList.Name = "groupBox_FocusedProgramsList";
            groupBox_FocusedProgramsList.Size = new Size(280, 439);
            groupBox_FocusedProgramsList.TabIndex = 3;
            groupBox_FocusedProgramsList.TabStop = false;
            groupBox_FocusedProgramsList.Text = "Список сфокусированных программ";
            // 
            // listBox_focusedPrograms
            // 
            listBox_focusedPrograms.FormattingEnabled = true;
            listBox_focusedPrograms.ItemHeight = 15;
            listBox_focusedPrograms.Location = new Point(6, 25);
            listBox_focusedPrograms.Name = "listBox_focusedPrograms";
            listBox_focusedPrograms.Size = new Size(268, 319);
            listBox_focusedPrograms.TabIndex = 7;
            // 
            // button_removeProgram
            // 
            button_removeProgram.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_removeProgram.Location = new Point(5, 409);
            button_removeProgram.Name = "button_removeProgram";
            button_removeProgram.Size = new Size(269, 23);
            button_removeProgram.TabIndex = 6;
            button_removeProgram.Text = "Удалить программу из списка";
            button_removeProgram.UseVisualStyleBackColor = true;
            button_removeProgram.Click += button_removeProgram_Click;
            // 
            // button_addProgramByName
            // 
            button_addProgramByName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_addProgramByName.Location = new Point(5, 380);
            button_addProgramByName.Name = "button_addProgramByName";
            button_addProgramByName.Size = new Size(269, 23);
            button_addProgramByName.TabIndex = 5;
            button_addProgramByName.Text = "Добавить программу по названию процесса";
            button_addProgramByName.UseVisualStyleBackColor = true;
            button_addProgramByName.Click += button_addProgramByName_Click;
            // 
            // button_addProgramFromMixer
            // 
            button_addProgramFromMixer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_addProgramFromMixer.Location = new Point(5, 351);
            button_addProgramFromMixer.Name = "button_addProgramFromMixer";
            button_addProgramFromMixer.Size = new Size(269, 23);
            button_addProgramFromMixer.TabIndex = 4;
            button_addProgramFromMixer.Text = "Добавить программу из микшера";
            button_addProgramFromMixer.UseVisualStyleBackColor = true;
            button_addProgramFromMixer.Click += button_addProgramFromMixer_Click;
            // 
            // groupBox_SoundIndication
            // 
            groupBox_SoundIndication.Controls.Add(label_BeepVolume);
            groupBox_SoundIndication.Controls.Add(trackBar_BeepVolume);
            groupBox_SoundIndication.Location = new Point(10, 498);
            groupBox_SoundIndication.Name = "groupBox_SoundIndication";
            groupBox_SoundIndication.Size = new Size(233, 75);
            groupBox_SoundIndication.TabIndex = 5;
            groupBox_SoundIndication.TabStop = false;
            groupBox_SoundIndication.Text = "Громкость звуковой индикации";
            // 
            // linkLabel_hlh
            // 
            linkLabel_hlh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            linkLabel_hlh.Location = new Point(12, 579);
            linkLabel_hlh.Name = "linkLabel_hlh";
            linkLabel_hlh.Size = new Size(515, 15);
            linkLabel_hlh.TabIndex = 6;
            linkLabel_hlh.TabStop = true;
            linkLabel_hlh.Text = "Всего хорошего!!";
            linkLabel_hlh.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel_hlh.LinkClicked += linkLabel_hlh_LinkClicked;
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "mute this please";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // panel_Work
            // 
            panel_Work.Controls.Add(label_Work);
            panel_Work.Location = new Point(600, 12);
            panel_Work.Name = "panel_Work";
            panel_Work.Size = new Size(519, 583);
            panel_Work.TabIndex = 7;
            panel_Work.Visible = false;
            // 
            // label_Work
            // 
            label_Work.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_Work.Location = new Point(0, 151);
            label_Work.Name = "label_Work";
            label_Work.Size = new Size(519, 223);
            label_Work.TabIndex = 0;
            label_Work.Text = "Программа работает!\r\nНажмите ` для изменения уровня громкости.\r\nНажмите Numpad - для прекращения работы.";
            label_Work.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(539, 602);
            Controls.Add(panel_Work);
            Controls.Add(linkLabel_hlh);
            Controls.Add(groupBox_SoundIndication);
            Controls.Add(groupBox_Device);
            Controls.Add(groupBox_FocusedProgramsList);
            Controls.Add(groupBox_hotkeys);
            Controls.Add(groupBox_Volume);
            Controls.Add(button_start);
            Controls.Add(groupBox_Mode);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "mute this please";
            Resize += MainForm_Resize;
            groupBox_Mode.ResumeLayout(false);
            groupBox_Mode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_VolumeValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_BeepVolume).EndInit();
            groupBox_Volume.ResumeLayout(false);
            groupBox_Volume.PerformLayout();
            groupBox_Device.ResumeLayout(false);
            groupBox_hotkeys.ResumeLayout(false);
            groupBox_ExitHotkey.ResumeLayout(false);
            groupBox_MuteHotkey.ResumeLayout(false);
            groupBox_FocusedProgramsList.ResumeLayout(false);
            groupBox_SoundIndication.ResumeLayout(false);
            groupBox_SoundIndication.PerformLayout();
            panel_Work.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox_Mode;
        private RadioButton radioButton_Whitelist;
        private RadioButton radioButton_Blacklist;
        private ToolTip toolTip;
        private Button button_start;
        private GroupBox groupBox_Volume;
        private GroupBox groupBox_hotkeys;
        private GroupBox groupBox_MuteHotkey;
        private Label label_HotkeyVolume;
        private Button button_HotkeyVolume;
        private GroupBox groupBox_ExitHotkey;
        private Label label_HotkeyExit;
        private Button button_HotkeyExit;
        private GroupBox groupBox_FocusedProgramsList;
        private Button button_removeProgram;
        private Button button_addProgramByName;
        private Button button_addProgramFromMixer;
        private GroupBox groupBox_Device;
        private Button button_UpdateDevices;
        private ComboBox comboBox_audioDevice;
        private ListBox listBox_focusedPrograms;
        private TrackBar trackBar_VolumeValue;
        private Label label_VolumeValue;
        private GroupBox groupBox_SoundIndication;
        private TrackBar trackBar_BeepVolume;
        private Label label_BeepVolume;
        private LinkLabel linkLabel_hlh;
        private NotifyIcon notifyIcon;
        private CheckBox checkBox_treyIcon;
        private Panel panel_Work;
        private Label label_Work;
        private ComboBox comboBox_Languages;
    }
}