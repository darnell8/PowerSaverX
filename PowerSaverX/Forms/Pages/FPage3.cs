using System.Diagnostics;

namespace Sunny.UI.Demo
{
    public partial class FPage3 : UIPage
    {
        public const int pageIndex = 1030;
        public FPage3()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();

            uiRichTextBox1.Text = @"
# PowerSaverX
这是一个Windows管理电源计划的小工具。

项目地址：https://github.com/darnell8/PowerSaverX.git

## 使用方法
首先为环境运行创建一些电源计划，电源计划中设置好CPU使用状态的最大值和最小值。
然后运行程序即可。

设置路径：
选择电源计划 -> 编辑电源计划 -> 处理器电源管理 -> 最小处理器状态/最大处理器状态

## 原理
这个工具的原理是代替人工进行电源计划的切换，每隔5秒程序会检测是否有特定的进程在运行。如果有切换到平衡模式或者高性能模式，反正则切换到省电模式。
            ";
        }
    }
}