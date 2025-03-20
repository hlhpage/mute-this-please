namespace mute_this_please
{
    partial class FocusedProgramsListInteractForm
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
            label_Instructions = new Label();
            checkedListBox = new CheckedListBox();
            button_Confirm = new Button();
            button_SelectAll = new Button();
            button_DeselectAll = new Button();
            SuspendLayout();
            // 
            // label_Instructions
            // 
            label_Instructions.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_Instructions.Location = new Point(6, 8);
            label_Instructions.Name = "label_Instructions";
            label_Instructions.Size = new Size(321, 29);
            label_Instructions.TabIndex = 1;
            label_Instructions.Text = "Выберите программы для добавления";
            label_Instructions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkedListBox
            // 
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Location = new Point(6, 46);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(321, 130);
            checkedListBox.TabIndex = 3;
            // 
            // button_Confirm
            // 
            button_Confirm.Location = new Point(6, 217);
            button_Confirm.Name = "button_Confirm";
            button_Confirm.Size = new Size(321, 38);
            button_Confirm.TabIndex = 4;
            button_Confirm.Text = "Подтвердить";
            button_Confirm.UseVisualStyleBackColor = true;
            button_Confirm.Click += button_Confirm_Click;
            // 
            // button_SelectAll
            // 
            button_SelectAll.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button_SelectAll.Location = new Point(6, 183);
            button_SelectAll.Name = "button_SelectAll";
            button_SelectAll.Size = new Size(160, 28);
            button_SelectAll.TabIndex = 5;
            button_SelectAll.Text = "Выделить всё пункты";
            button_SelectAll.UseVisualStyleBackColor = true;
            button_SelectAll.Click += button_SelectAll_Click;
            // 
            // button_DeselectAll
            // 
            button_DeselectAll.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button_DeselectAll.Location = new Point(167, 183);
            button_DeselectAll.Name = "button_DeselectAll";
            button_DeselectAll.Size = new Size(160, 28);
            button_DeselectAll.TabIndex = 6;
            button_DeselectAll.Text = "Очистить выделение";
            button_DeselectAll.UseVisualStyleBackColor = true;
            button_DeselectAll.Click += button1_Click;
            // 
            // FocusedProgramsInteract
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(332, 262);
            Controls.Add(button_DeselectAll);
            Controls.Add(button_SelectAll);
            Controls.Add(button_Confirm);
            Controls.Add(checkedListBox);
            Controls.Add(label_Instructions);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FocusedProgramsInteract";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Пупупу";
            ResumeLayout(false);
        }

        #endregion
        private Label label_Instructions;
        private CheckedListBox checkedListBox;
        private Button button_Confirm;
        private Button button_SelectAll;
        private Button button_DeselectAll;
    }
}