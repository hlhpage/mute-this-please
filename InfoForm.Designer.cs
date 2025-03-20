namespace mute_this_please
{
    partial class InfoForm
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
            pictureBox_logo = new PictureBox();
            label_Title = new Label();
            label_Version = new Label();
            linkLabel_SourceCode = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_logo
            // 
            pictureBox_logo.Image = Properties.Resources.socialMediaAvatar;
            pictureBox_logo.Location = new Point(12, 40);
            pictureBox_logo.Name = "pictureBox_logo";
            pictureBox_logo.Size = new Size(160, 160);
            pictureBox_logo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_logo.TabIndex = 0;
            pictureBox_logo.TabStop = false;
            pictureBox_logo.Click += pictureBox_logo_Click;
            // 
            // label_Title
            // 
            label_Title.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_Title.Location = new Point(12, 9);
            label_Title.Name = "label_Title";
            label_Title.Size = new Size(160, 24);
            label_Title.TabIndex = 4;
            label_Title.Text = "mute this please";
            label_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Version
            // 
            label_Version.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label_Version.Location = new Point(147, 212);
            label_Version.Name = "label_Version";
            label_Version.Size = new Size(39, 24);
            label_Version.TabIndex = 5;
            label_Version.Text = "v1.0";
            label_Version.TextAlign = ContentAlignment.BottomRight;
            // 
            // linkLabel_SourceCode
            // 
            linkLabel_SourceCode.Location = new Point(12, 206);
            linkLabel_SourceCode.Name = "linkLabel_SourceCode";
            linkLabel_SourceCode.Size = new Size(160, 24);
            linkLabel_SourceCode.TabIndex = 6;
            linkLabel_SourceCode.TabStop = true;
            linkLabel_SourceCode.Text = "Исходный код";
            linkLabel_SourceCode.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel_SourceCode.LinkClicked += linkLabel_SourceCode_LinkClicked;
            // 
            // InfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(185, 238);
            Controls.Add(label_Version);
            Controls.Add(label_Title);
            Controls.Add(pictureBox_logo);
            Controls.Add(linkLabel_SourceCode);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "InfoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Счастье живёт здесь";
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_logo;
        private Label label_Title;
        private Label label_Version;
        private LinkLabel linkLabel_SourceCode;
    }
}