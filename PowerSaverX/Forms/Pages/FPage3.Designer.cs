namespace Sunny.UI.Demo
{
    partial class FPage3
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
            uiLine1 = new UILine();
            uiRichTextBox1 = new UIRichTextBox();
            SuspendLayout();
            // 
            // uiLine1
            // 
            uiLine1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLine1.Location = new Point(12, 12);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(775, 29);
            uiLine1.TabIndex = 0;
            uiLine1.Text = "项目介绍";
            // 
            // uiRichTextBox1
            // 
            uiRichTextBox1.FillColor = Color.White;
            uiRichTextBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiRichTextBox1.Location = new Point(13, 49);
            uiRichTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiRichTextBox1.MinimumSize = new Size(1, 1);
            uiRichTextBox1.Name = "uiRichTextBox1";
            uiRichTextBox1.Padding = new Padding(2);
            uiRichTextBox1.ReadOnly = true;
            uiRichTextBox1.ShowText = false;
            uiRichTextBox1.Size = new Size(774, 180);
            uiRichTextBox1.TabIndex = 1;
            uiRichTextBox1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // FPage3
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
            Controls.Add(uiRichTextBox1);
            Controls.Add(uiLine1);
            Name = "FPage3";
            Text = "FPage3";
            ResumeLayout(false);
        }

        #endregion

        private UILine uiLine1;
        private UIRichTextBox uiRichTextBox1;
    }
}