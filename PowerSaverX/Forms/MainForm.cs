using PowerSaverX.Utils;
using Sunny.UI;
using Sunny.UI.Demo;
using System.Diagnostics;

namespace PowerSaverX
{
    public partial class MainForm : UIHeaderMainFrame
    {

        // 在这里定义你希望管理的进程名称和对应的电源计划名称
        private string targetProcessName = "YourTargetProcess.exe";
        private Guid selectedPlanGuid = Guid.Empty; // 可以通过 `powercfg /list` 命令获取 GUID

        public MainForm()
        {
            InitializeComponent();

            //设置关联
            Header.TabControl = MainTabControl;

            //增加页面到Main
            AddPage(new FPage1(), FPage1.pageIndex);
            AddPage(new FPage2(), FPage2.pageIndex);
            AddPage(new FPage3(), FPage3.pageIndex);

            //设置Header节点索引
            Header.CreateNode("设置", FPage1.pageIndex);
            Header.CreateNode("TODO", FPage2.pageIndex);
            Header.CreateNode("关于", FPage3.pageIndex);

            //显示默认界面
            Header.SelectedIndex = 0;

            // 设置定时器，每隔一段时间检查进程和电源计划
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string currentProcessName = PowerUtils.GetActiveProcessName();
            string currentPowerPlanGuid = PowerUtils.GetCurrentPowerPlanGuidNew();

            if (GetPage(FPage1.pageIndex) is FPage1 fPage1)
            {
                var selectedValueObj = fPage1.uiComboBox1.SelectedValue;
                if (selectedValueObj is PowerUtils.PowerPlan selectedValue)
                {
                    selectedPlanGuid = selectedValue.PlanGuid;
                    Debug.WriteLine($"当前选择的电源计划为：${selectedPlanGuid}");
                } 
            }

            // 如果正在运行的进程是目标进程，而且当前的电源计划不是选中计划，则切换到选中计划
            if (currentProcessName.Contains(targetProcessName) && currentPowerPlanGuid != selectedPlanGuid + "")
            {
                PowerUtils.SwitchToPowerPlan(selectedPlanGuid + "");
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