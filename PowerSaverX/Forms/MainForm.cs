using PowerSaverX.Utils;
using Sunny.UI;
using Sunny.UI.Demo;
using System.Runtime.InteropServices;
using Timer = System.Windows.Forms.Timer;

namespace PowerSaverX
{
    public partial class MainForm : UIHeaderMainFrame
    {

        // 在这里定义你希望管理的进程名称和对应的电源计划名称
        private string targetProcessName = "YourTargetProcess.exe";
        private Guid highPerformancePlanGuid = Guid.Empty; // 可以通过 `powercfg /list` 命令获取 GUID
        private Guid balancedPlanGuid = Guid.Empty;
        private Guid powerSaverPlanGuid = Guid.Empty;
        public MainForm()
        {
            InitializeComponent();

            //设置关联
            Header.TabControl = MainTabControl;

            //增加页面到Main
            AddPage(new FPage1(), 1001);
            AddPage(new FPage2(), 1002);
            AddPage(new FPage3(), 1003);

            //设置Header节点索引
            Header.CreateNode("设置", 1001);
            Header.CreateNode("TODO", 1002);
            Header.CreateNode("关于", 1003);

            //显示默认界面
            Header.SelectedIndex = 0;

            // 设置定时器，每隔一段时间检查进程和电源计划
            //timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string currentProcessName = PowerUtils.GetActiveProcessName();
            string currentPowerPlanGuid = PowerUtils.GetCurrentPowerPlanGuidNew();

            // 如果正在运行的进程是目标进程，而且当前的电源计划不是高性能计划，则切换到高性能计划
            if (currentProcessName.Contains(targetProcessName) && currentPowerPlanGuid != highPerformancePlanGuid + "")
            {
                PowerUtils.SwitchToPowerPlan(highPerformancePlanGuid + "");
            }
            // 否则，切换到默认的平衡计划或其他你希望使用的计划
            else
            {
                // 默认的平衡计划 GUID 或其他计划 GUID
                string defaultPowerPlanGuid = "YourDefaultPlanGuid";
                PowerUtils.SwitchToPowerPlan(defaultPowerPlanGuid);
            }
        }
    }
}