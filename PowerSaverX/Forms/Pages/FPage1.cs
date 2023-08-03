using PowerSaverX.Properties;
using PowerSaverX.Utils;
using System.Diagnostics;

namespace Sunny.UI.Demo
{
    public partial class FPage1 : UIPage
    {
        public const int pageIndex = 1010;

        public FPage1()
        {
            InitializeComponent();
            InitView();
        }

        //放在 [重载Init] 的内容每次页面切换，进入页面都会执行。
        public override void Init()
        {
            Debug.WriteLine("2. FButton_Init");
            base.Init();

            InitData();

            // 设置定时器，每隔一段时间检查进程和电源计划
            timer1.ReStart();

            if (uiComboBox2.SelectedValue != null && uiComboBox2.SelectedValue is Guid tempGuid)
            {
                PowerUtils.SetProcessorState(tempGuid);
            }
        }

        private void InitView()
        {
            uiComboBox1.DisplayMember = "FriendlyName";
            uiComboBox1.ValueMember = "PlanGuid";
            uiComboBox2.DisplayMember = "FriendlyName";
            uiComboBox2.ValueMember = "PlanGuid";

            uiComboDataGridView1.DataGridView.Init();
            uiComboDataGridView1.DataGridView.MultiSelect = true;//设置可多选
            //uiComboDataGridView1.ItemSize = new Size(360, 240);
            //uiComboDataGridView1.DataGridView.AddColumn("序号", "Id");
            uiComboDataGridView1.DataGridView.AddColumn("窗口名称", "MainWindowTitle");
            uiComboDataGridView1.DataGridView.AddColumn("启动时间", "StartTime");
            uiComboDataGridView1.DataGridView.AddColumn("进程名称", "ProcessName");
            //uiComboDataGridView1.DataGridView.AddColumn("SessionId", "SessionId");
            //uiComboDataGridView1.DataGridView.AddColumn("私有内存使用量1", "PrivateMemorySize");
            //uiComboDataGridView1.DataGridView.AddColumn("私有内存使用量2", "PrivateMemorySize64");
            //uiComboDataGridView1.DataGridView.AddColumn("虚拟内存使用量1", "VirtualMemorySize");
            //uiComboDataGridView1.DataGridView.AddColumn("虚拟内存使用量2", "VirtualMemorySize64");
            uiComboDataGridView1.DataGridView.ReadOnly = true;
            uiComboDataGridView1.ShowFilter = true;
        }

        public override void Final()
        {
            Debug.WriteLine("4. FButton_Final");
            base.Final();

            Settings.Default.ListeningInterval = uiIntegerUpDown1.Value;
            //Settings.Default.ListeningProcessName = uiTextBox1.Text;
            Settings.Default.ListeningProcessName = uiComboDataGridView1.Text;

            if (uiComboBox1.SelectedValue is Guid dailyPlanGuid)
            {
                Settings.Default.DailyPlanGuid = dailyPlanGuid;
            }
            if (uiComboBox2.SelectedValue is Guid switchPlanGuid)
            {
                Settings.Default.SwitchPlanGuid = switchPlanGuid;
            }
            Settings.Default.Save();
        }

        private void InitData()
        {
            var powerPlanList = PowerUtils.GetPowerPlanList();
            uiComboBox1.DataSource = powerPlanList;
            uiComboBox2.DataSource = powerPlanList;

            Guid currentPowerPlanGuid = PowerUtils.GetCurrentPowerPlanGuidNew();
            var currentPowerPlan = powerPlanList.Find(item => item.PlanGuid == currentPowerPlanGuid);
            uiTextBox2.Text = currentPowerPlan?.FriendlyName;

            uiComboBox1.SelectedValue = Settings.Default.DailyPlanGuid;
            uiComboBox2.SelectedValue = Settings.Default.SwitchPlanGuid;

            uiIntegerUpDown1.Value = Settings.Default.ListeningInterval;
            uiTextBox1.Text = Settings.Default.ListeningProcessName;
            uiComboDataGridView1.Text = Settings.Default.ListeningProcessName;

            RefreshComboDataGridView();
        }

        private void RefreshComboDataGridView()
        {
            // 选择当前所有程序
            // 获取当前设备上所有正在运行的进程
            Process[] processes = Process.GetProcesses();
            processes = processes.Where(p => p.SessionId != 0 && p.MainWindowTitle != "").DistinctBy(p => p.ProcessName)
                .OrderByDescending(p => p.StartTime).ToArray();

            uiComboDataGridView1.DataGridView.DataSource = processes;
            //uiComboDataGridView1.FilterColumnName = "Column1"; //不设置则全部列过滤
        }

        private int progress_value;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progress_value == 100)
            {
                // 进度条满100的时候执行
                string currentProcessName = PowerUtils.GetActiveProcessName();
                Guid currentPowerPlanGuid = PowerUtils.GetCurrentPowerPlanGuidNew();
                // 在这里定义你希望管理的进程名称和对应的电源计划名称
                // 可以通过 `powercfg /list` 命令获取 GUID

                var selectedValueObj = uiComboBox1.SelectedValue;

                string[] runningProcessName = uiComboDataGridView1.Text.Split(";").Select(p => p.Trim()).ToArray();
                // 如果正在运行的进程是目标进程，而且当前的电源计划不是选中计划，则切换到选中计划
                if (!runningProcessName.Contains(currentProcessName)
                    && selectedValueObj is Guid dailyPlanGuid
                    && currentPowerPlanGuid != dailyPlanGuid)
                {
                    PowerUtils.SwitchToPowerPlan(dailyPlanGuid + "");
                }
                // 否则，切换到默认的平衡计划或其他你希望使用的计划
                else if (runningProcessName.Contains(currentProcessName)
                    && uiComboBox2.SelectedValue is Guid switchPlanGuid
                    && currentPowerPlanGuid != switchPlanGuid)
                {
                    // 默认的平衡计划 GUID 或其他计划 GUID
                    PowerUtils.SwitchToPowerPlan(switchPlanGuid + "");
                }

                uiTextBox2.Text = PowerUtils.GetPowerPlanName(PowerUtils.GetCurrentPowerPlanGuidNew());
                RefreshComboDataGridView();

                progress_value = 0;
            }
            else
            {
                ++progress_value;
            }

            uiRoundProcess1.Value = progress_value;
        }

        private void uiComboDataGridView1_ValueChanged(object sender, object value)
        {
            uiComboDataGridView1.Text = "";
            if (value is DataGridViewSelectedRowCollection collection)
            {
                foreach (var item in collection)
                {
                    DataGridViewRow row = (DataGridViewRow)item;
                    uiComboDataGridView1.Text += row.Cells["进程名称"].Value + "";
                    uiComboDataGridView1.Text += "; ";
                }
            }
        }
    }
}