namespace PowerSaverX
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            uiAvatar1 = new Sunny.UI.UIAvatar();
            Header.SuspendLayout();
            SuspendLayout();
            // 
            // Header
            // 
            Header.Controls.Add(uiAvatar1);
            // 
            // uiAvatar1
            // 
            uiAvatar1.BackgroundImage = Properties.Resources.Logo;
            uiAvatar1.BackgroundImageLayout = ImageLayout.Stretch;
            uiAvatar1.FillColor = Color.Transparent;
            uiAvatar1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiAvatar1.Icon = Sunny.UI.UIAvatar.UIIcon.Image;
            uiAvatar1.Location = new Point(20, 23);
            uiAvatar1.MinimumSize = new Size(1, 1);
            uiAvatar1.Name = "uiAvatar1";
            uiAvatar1.Size = new Size(256, 66);
            uiAvatar1.Style = Sunny.UI.UIStyle.Custom;
            uiAvatar1.TabIndex = 0;
            uiAvatar1.Text = "uiAvatar1";
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
            Name = "MainForm";
            Text = "PowerSaverX";
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Header.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIAvatar uiAvatar1;
    }
}