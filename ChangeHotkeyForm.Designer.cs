namespace mute_this_please
{
    partial class ChangeHotkeyForm
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
            label_ChangeHotheyHelp = new Label();
            nonSelectableButton_Confirm = new NonSelectableButton();
            SuspendLayout();
            // 
            // label_ChangeHotheyHelp
            // 
            label_ChangeHotheyHelp.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_ChangeHotheyHelp.Location = new Point(6, 9);
            label_ChangeHotheyHelp.Name = "label_ChangeHotheyHelp";
            label_ChangeHotheyHelp.Size = new Size(502, 49);
            label_ChangeHotheyHelp.TabIndex = 0;
            label_ChangeHotheyHelp.Text = "Нажмите и отпустите желаемую клавишу";
            label_ChangeHotheyHelp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nonSelectableButton_Confirm
            // 
            nonSelectableButton_Confirm.Enabled = false;
            nonSelectableButton_Confirm.Location = new Point(6, 65);
            nonSelectableButton_Confirm.Name = "nonSelectableButton_Confirm";
            nonSelectableButton_Confirm.Size = new Size(502, 32);
            nonSelectableButton_Confirm.TabIndex = 2;
            nonSelectableButton_Confirm.Text = "Подтвердить";
            nonSelectableButton_Confirm.UseVisualStyleBackColor = true;
            nonSelectableButton_Confirm.Click += nonSelectableButton_Confirm_Click;
            // 
            // ChangeKey
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(514, 104);
            Controls.Add(nonSelectableButton_Confirm);
            Controls.Add(label_ChangeHotheyHelp);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ChangeKey";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Изменение горячей клавиши";
            ResumeLayout(false);
        }

        #endregion

        private Label label_ChangeHotheyHelp;
        private NonSelectableButton nonSelectableButton_Confirm;
    }
}