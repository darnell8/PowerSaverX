using PowerSaverX.Utils;
using System.Diagnostics;

namespace Sunny.UI.Demo
{
    public partial class FPage1 : UIPage
    {
        public FPage1()
        {
            InitializeComponent();
        }

        //放在 [重载Init] 的内容每次页面切换，进入页面都会执行。
        public override void Init()
        {
            base.Init();

            var powerPlanList = PowerUtils.GetPowerPlanList();
            uiComboBox1.DisplayMember = "FriendlyName";
            uiComboBox1.DataSource = powerPlanList;

            Debug.WriteLine("2. FButton_Init");

        }
    }
}