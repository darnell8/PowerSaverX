using PowerSaverX.Utils;
using System.Diagnostics;

namespace Sunny.UI.Demo
{
    public partial class FPage1 : UIPage
    {
        public const int pageIndex = 1010;

        // 在这里定义你希望管理的进程名称和对应的电源计划名称
        private string targetProcessName = "YourTargetProcess.exe";
        private Guid selectedPlanGuid = Guid.Empty; // 可以通过 `powercfg /list` 命令获取 GUID

        public FPage1()
        {
            InitializeComponent();
        }

        //放在 [重载Init] 的内容每次页面切换，进入页面都会执行。
        public override void Init()
        {
            Debug.WriteLine("2. FButton_Init");
            base.Init();

            InitData();

            // 设置定时器，每隔一段时间检查进程和电源计划
            timer1.Start();
        }

        private void InitData()
        {
            var powerPlanList = PowerUtils.GetPowerPlanList();
            uiComboBox1.DisplayMember = "FriendlyName";
            uiComboBox1.DataSource = powerPlanList;

            uiComboBox2.DisplayMember = "FriendlyName";
            uiComboBox2.DataSource = powerPlanList;

            Guid currentPowerPlanGuid = PowerUtils.GetCurrentPowerPlanGuidNew();
            var currentPowerPlan = powerPlanList.Find(item => item.PlanGuid == currentPowerPlanGuid);
            uiComboBox1.SelectedItem = currentPowerPlan;
            uiTextBox2.Text = currentPowerPlan?.FriendlyName;
        }

        private int value;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (value == 100)
            {
                string currentProcessName = PowerUtils.GetActiveProcessName();
                Guid currentPowerPlanGuid = PowerUtils.GetCurrentPowerPlanGuidNew();

                var selectedValueObj = uiComboBox1.SelectedValue;
                if (selectedValueObj is PowerUtils.PowerPlan selectedValue)
                {
                    selectedPlanGuid = selectedValue.PlanGuid;
                    Debug.WriteLine($"当前选择的电源计划为：{selectedPlanGuid}");
                }

                // 如果正在运行的进程是目标进程，而且当前的电源计划不是选中计划，则切换到选中计划
                if (currentProcessName.Contains(targetProcessName) && currentPowerPlanGuid != selectedPlanGuid)
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

                uiTextBox2.Text = PowerUtils.GetPowerPlanName(PowerUtils.GetCurrentPowerPlanGuidNew());

                value = 0;
            }
            else
            {
                ++value;
            }

            uiRoundProcess1.Value = value;
        }
    }
}