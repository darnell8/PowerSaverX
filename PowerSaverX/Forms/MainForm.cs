using Sunny.UI;
using Sunny.UI.Demo;

namespace PowerSaverX
{
    public partial class MainForm : UIHeaderMainFrame
    {

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

            Header.SetNodeSymbol(Header.Nodes[0], 61818);
            Header.SetNodeSymbol(Header.Nodes[1], 362614);
            Header.SetNodeSymbol(Header.Nodes[2], 61502);

            //显示默认界面
            Header.SelectedIndex = 0;
        }
    }
}