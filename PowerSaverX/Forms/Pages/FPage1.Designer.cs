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
            components = new System.ComponentModel.Container();
            uiLine1 = new UILine();
            uiComboBox1 = new UIComboBox();
            uiLabel1 = new UILabel();
            uiIntegerUpDown1 = new UIIntegerUpDown();
            uiLine2 = new UILine();
            uiLabel2 = new UILabel();
            uiTextBox1 = new UITextBox();
            uiLine3 = new UILine();
            uiRoundProcess1 = new UIRoundProcess();
            timer1 = new System.Windows.Forms.Timer(components);
            uiComboBox2 = new UIComboBox();
            uiLabel3 = new UILabel();
            uiLabel4 = new UILabel();
            uiLabel5 = new UILabel();
            uiTextBox2 = new UITextBox();
            uiComboDataGridView1 = new UIComboDataGridView();
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
            uiComboBox1.Location = new Point(139, 49);
            uiComboBox1.Margin = new Padding(4, 5, 4, 5);
            uiComboBox1.MinimumSize = new Size(63, 0);
            uiComboBox1.Name = "uiComboBox1";
            uiComboBox1.Padding = new Padding(0, 0, 30, 2);
            uiComboBox1.Size = new Size(233, 29);
            uiComboBox1.TabIndex = 1;
            uiComboBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiComboBox1.Watermark = "";
            // 
            // uiLabel1
            // 
            uiLabel1.AutoSize = true;
            uiLabel1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.Location = new Point(17, 216);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(122, 21);
            uiLabel1.TabIndex = 2;
            uiLabel1.Text = "监听间隔（秒）";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiIntegerUpDown1
            // 
            uiIntegerUpDown1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiIntegerUpDown1.Location = new Point(226, 210);
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
            uiLine2.Location = new Point(16, 173);
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
            uiLabel2.Location = new Point(17, 255);
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
            uiTextBox1.Location = new Point(139, 288);
            uiTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new Padding(5);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(237, 29);
            uiTextBox1.TabIndex = 6;
            uiTextBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox1.Visible = false;
            uiTextBox1.Watermark = "";
            // 
            // uiLine3
            // 
            uiLine3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLine3.Location = new Point(428, 12);
            uiLine3.MinimumSize = new Size(1, 1);
            uiLine3.Name = "uiLine3";
            uiLine3.Size = new Size(360, 29);
            uiLine3.TabIndex = 7;
            uiLine3.Text = "监听状态";
            // 
            // uiRoundProcess1
            // 
            uiRoundProcess1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiRoundProcess1.ForeColor2 = Color.Black;
            uiRoundProcess1.Location = new Point(428, 47);
            uiRoundProcess1.MinimumSize = new Size(1, 1);
            uiRoundProcess1.Name = "uiRoundProcess1";
            uiRoundProcess1.Size = new Size(120, 120);
            uiRoundProcess1.TabIndex = 8;
            uiRoundProcess1.Text = "uiRoundProcess1";
            // 
            // timer1
            // 
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // uiComboBox2
            // 
            uiComboBox2.DataSource = null;
            uiComboBox2.DropDownStyle = UIDropDownStyle.DropDownList;
            uiComboBox2.FillColor = Color.White;
            uiComboBox2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiComboBox2.Location = new Point(139, 88);
            uiComboBox2.Margin = new Padding(4, 5, 4, 5);
            uiComboBox2.MinimumSize = new Size(63, 0);
            uiComboBox2.Name = "uiComboBox2";
            uiComboBox2.Padding = new Padding(0, 0, 30, 2);
            uiComboBox2.Size = new Size(233, 29);
            uiComboBox2.TabIndex = 2;
            uiComboBox2.TextAlignment = ContentAlignment.MiddleLeft;
            uiComboBox2.Watermark = "";
            // 
            // uiLabel3
            // 
            uiLabel3.AutoSize = true;
            uiLabel3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel3.Location = new Point(16, 57);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(74, 21);
            uiLabel3.TabIndex = 9;
            uiLabel3.Text = "平时计划";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            uiLabel4.AutoSize = true;
            uiLabel4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel4.Location = new Point(16, 96);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(74, 21);
            uiLabel4.TabIndex = 10;
            uiLabel4.Text = "切换计划";
            uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            uiLabel5.AutoSize = true;
            uiLabel5.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel5.Location = new Point(16, 135);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(74, 21);
            uiLabel5.TabIndex = 11;
            uiLabel5.Text = "当前计划";
            uiLabel5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiTextBox2
            // 
            uiTextBox2.ButtonSymbolOffset = new Point(0, 0);
            uiTextBox2.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextBox2.Location = new Point(139, 127);
            uiTextBox2.Margin = new Padding(4, 5, 4, 5);
            uiTextBox2.MinimumSize = new Size(1, 16);
            uiTextBox2.Name = "uiTextBox2";
            uiTextBox2.Padding = new Padding(5);
            uiTextBox2.ReadOnly = true;
            uiTextBox2.ShowText = false;
            uiTextBox2.Size = new Size(233, 29);
            uiTextBox2.TabIndex = 12;
            uiTextBox2.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox2.Watermark = "";
            // 
            // uiComboDataGridView1
            // 
            uiComboDataGridView1.DropDownStyle = UIDropDownStyle.DropDownList;
            uiComboDataGridView1.FillColor = Color.White;
            uiComboDataGridView1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiComboDataGridView1.Location = new Point(139, 249);
            uiComboDataGridView1.Margin = new Padding(4, 5, 4, 5);
            uiComboDataGridView1.MinimumSize = new Size(63, 0);
            uiComboDataGridView1.Name = "uiComboDataGridView1";
            uiComboDataGridView1.Padding = new Padding(0, 0, 30, 2);
            uiComboDataGridView1.Size = new Size(237, 29);
            uiComboDataGridView1.TabIndex = 13;
            uiComboDataGridView1.TextAlignment = ContentAlignment.MiddleLeft;
            uiComboDataGridView1.Watermark = "";
            uiComboDataGridView1.ValueChanged += uiComboDataGridView1_ValueChanged;
            // 
            // FPage1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
            Controls.Add(uiComboDataGridView1);
            Controls.Add(uiTextBox2);
            Controls.Add(uiLabel5);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel3);
            Controls.Add(uiComboBox2);
            Controls.Add(uiRoundProcess1);
            Controls.Add(uiLine3);
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
        private UILine uiLine3;
        private UIRoundProcess uiRoundProcess1;
        private System.Windows.Forms.Timer timer1;
        public UIComboBox uiComboBox2;
        private UILabel uiLabel3;
        private UILabel uiLabel4;
        private UILabel uiLabel5;
        private UITextBox uiTextBox2;
        private UIComboDataGridView uiComboDataGridView1;
    }
}