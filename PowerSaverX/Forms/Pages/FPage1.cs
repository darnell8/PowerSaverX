using PowerSaverX.Properties;
using PowerSaverX.Utils;
using System.Diagnostics;

namespace Sunny.UI.Demo
{
    public partial class FPage1 : UIPage
    {
        public const int pageIndex = 1010;

        // 在这里定义你希望管理的进程名称和对应的电源计划名称
        private readonly string targetProcessName = "YourTargetProcess.exe";
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

            InitView();
            InitData();

            // 设置定时器，每隔一段时间检查进程和电源计划
            timer1.Start();
        }

        private void InitView()
        {
            uiComboBox1.DisplayMember = "FriendlyName";
            uiComboBox1.ValueMember = "PlanGuid";
            uiComboBox2.DisplayMember = "FriendlyName";
            uiComboBox2.ValueMember = "PlanGuid";
        }

        public override void Final()
        {
            Debug.WriteLine("4. FButton_Final");
            base.Final();

            Settings.Default.ListeningInterval = uiIntegerUpDown1.Value;
            //Settings.Default.ListeningProceeName = uiTextBox1.Text;
            Settings.Default.ListeningProceeName = uiComboDataGridView1.Text;

            if (uiComboBox2.SelectedValue is Guid selectedValue)
            {
                Settings.Default.SwitchPlanGuid = selectedValue;
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
            uiComboBox1.SelectedItem = currentPowerPlan;
            uiComboBox2.SelectedValue = Settings.Default.SwitchPlanGuid;

            uiTextBox2.Text = currentPowerPlan?.FriendlyName;

            uiIntegerUpDown1.Value = Settings.Default.ListeningInterval;
            uiTextBox1.Text = Settings.Default.ListeningProceeName;
            uiComboDataGridView1.Text = Settings.Default.ListeningProceeName;

            InitComboDataGridView();
        }

        private void InitComboDataGridView()
        {
            // 选择当前所有程序
            // 获取当前设备上所有正在运行的进程
            Process[] processes = Process.GetProcesses();
            processes = processes.Where(p => p.SessionId != 0 && p.MainWindowTitle != "").DistinctBy(p => p.ProcessName)
                .OrderByDescending(p => p.StartTime).ToArray();
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
            uiComboDataGridView1.DataGridView.DataSource = processes;
            //uiComboDataGridView1.FilterColumnName = "Column1"; //不设置则全部列过滤
        }

        private int value;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (value == 100)
            {
                // 进度条满100的时候执行
                string currentProcessName = PowerUtils.GetActiveProcessName();
                Guid currentPowerPlanGuid = PowerUtils.GetCurrentPowerPlanGuidNew();

                var selectedValueObj = uiComboBox1.SelectedValue;
                if (selectedValueObj is Guid selectedValue)
                {
                    selectedPlanGuid = selectedValue;
                    Debug.WriteLine($"当前选择的电源计划为：{selectedPlanGuid}");
                }

                string[] runningProcessName = uiComboDataGridView1.Text.Split(";").Select(p => p.Trim()).ToArray();
                // 如果正在运行的进程是目标进程，而且当前的电源计划不是选中计划，则切换到选中计划
                if (!runningProcessName.Contains(currentProcessName) && currentPowerPlanGuid != selectedPlanGuid)
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
                InitComboDataGridView();

                value = 0;
            }
            else
            {
                ++value;
            }

            uiRoundProcess1.Value = value;
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