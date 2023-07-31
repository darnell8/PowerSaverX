namespace Sunny.UI.Demo
{
    partial class FPage1
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
            uiComboBox1 = new UIComboBox();
            uiLabel1 = new UILabel();
            uiIntegerUpDown1 = new UIIntegerUpDown();
            uiLine2 = new UILine();
            uiLabel2 = new UILabel();
            uiTextBox1 = new UITextBox();
            SuspendLayout();
            // 
            // uiLine1
            // 
            uiLine1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLine1.Location = new Point(12, 12);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(360, 29);
            uiLine1.TabIndex = 0;
            uiLine1.Text = "选择电源计划";
            // 
            // uiComboBox1
            // 
            uiComboBox1.DataSource = null;
            uiComboBox1.DropDownStyle = UIDropDownStyle.DropDownList;
            uiComboBox1.FillColor = Color.White;
            uiComboBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiComboBox1.Location = new Point(13, 49);
            uiComboBox1.Margin = new Padding(4, 5, 4, 5);
            uiComboBox1.MinimumSize = new Size(63, 0);
            uiComboBox1.Name = "uiComboBox1";
            uiComboBox1.Padding = new Padding(0, 0, 30, 2);
            uiComboBox1.Size = new Size(359, 29);
            uiComboBox1.TabIndex = 1;
            uiComboBox1.Text = "uiComboBox1";
            uiComboBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiComboBox1.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.AutoSize = true;
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(13, 151);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(122, 21);
            uiLabel1.TabIndex = 2;
            uiLabel1.Text = "监听间隔（秒）";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiIntegerUpDown1
            // 
            uiIntegerUpDown1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiIntegerUpDown1.Location = new Point(222, 145);
            uiIntegerUpDown1.Margin = new Padding(4, 5, 4, 5);
            uiIntegerUpDown1.MinimumSize = new Size(100, 0);
            uiIntegerUpDown1.Name = "uiIntegerUpDown1";
            uiIntegerUpDown1.ShowText = false;
            uiIntegerUpDown1.Size = new Size(150, 29);
            uiIntegerUpDown1.TabIndex = 3;
            uiIntegerUpDown1.Text = "uiIntegerUpDown1";
            uiIntegerUpDown1.TextAlignment = ContentAlignment.MiddleCenter;
            uiIntegerUpDown1.Value = 5;
            // 
            // uiLine2
            // 
            uiLine2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLine2.Location = new Point(12, 108);
            uiLine2.MinimumSize = new Size(1, 1);
            uiLine2.Name = "uiLine2";
            uiLine2.Size = new Size(360, 29);
            uiLine2.TabIndex = 4;
            uiLine2.Text = "设置监听参数";
            // 
            // uiLabel2
            // 
            uiLabel2.AutoSize = true;
            uiLabel2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel2.Location = new Point(13, 190);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(90, 21);
            uiLabel2.TabIndex = 5;
            uiLabel2.Text = "监听进程名";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiTextBox1
            // 
            uiTextBox1.ButtonSymbolOffset = new Point(0, 0);
            uiTextBox1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextBox1.Location = new Point(222, 184);
            uiTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new Padding(5);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(150, 29);
            uiTextBox1.TabIndex = 6;
            uiTextBox1.Text = "uiTextBox1";
            uiTextBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "";
            // 
            // FPage1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
            Controls.Add(uiTextBox1);
            Controls.Add(uiLabel2);
            Controls.Add(uiLine2);
            Controls.Add(uiIntegerUpDown1);
            Controls.Add(uiLabel1);
            Controls.Add(uiComboBox1);
            Controls.Add(uiLine1);
            Name = "FPage1";
            Text = "FPage1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UILine uiLine1;
        private UILabel uiLabel1;
        private UIIntegerUpDown uiIntegerUpDown1;
        private UILine uiLine2;
        private UILabel uiLabel2;
        private UITextBox uiTextBox1;
        public UIComboBox uiComboBox1;
    }
}