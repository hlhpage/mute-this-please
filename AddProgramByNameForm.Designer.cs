namespace mute_this_please
{
    partial class AddProgramByNameForm
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
            label_Insteuctions = new Label();
            textBox_Programs = new TextBox();
            button_Add = new Button();
            SuspendLayout();
            // 
            // label_Insteuctions
            // 
            label_Insteuctions.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_Insteuctions.Location = new Point(6, 5);
            label_Insteuctions.Name = "label_Insteuctions";
            label_Insteuctions.Size = new Size(740, 44);
            label_Insteuctions.TabIndex = 2;
            label_Insteuctions.Text = "Для добавления процесса введите его название без указания расширения \".exe\" на конце\r\nДля добавления нескольких процессов введите их названия через /";
            label_Insteuctions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox_Programs
            // 
            textBox_Programs.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_Programs.Location = new Point(6, 57);
            textBox_Programs.Name = "textBox_Programs";
            textBox_Programs.Size = new Size(740, 25);
            textBox_Programs.TabIndex = 3;
            // 
            // button_Add
            // 
            button_Add.Location = new Point(6, 88);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(740, 33);
            button_Add.TabIndex = 4;
            button_Add.Text = "Подтвердить";
            button_Add.UseVisualStyleBackColor = true;
            button_Add.Click += button_Add_Click;
            // 
            // ForceAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(751, 128);
            Controls.Add(button_Add);
            Controls.Add(textBox_Programs);
            Controls.Add(label_Insteuctions);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ForceAdd";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить программу по названию";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Insteuctions;
        private TextBox textBox_Programs;
        private Button button_Add;
    }
}