using Microsoft.Win32;
using Sunny.UI;
using Sunny.UI.Demo;
using System.Diagnostics;
using System.Management;
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
            Header.CreateNode("Page1", 1001);
            Header.CreateNode("Page2", 1002);
            Header.CreateNode("Page3", 1003);

            //设置Header节点索引
            Header.SetNodePageIndex(Header.Nodes[0], 1001);
            Header.SetNodePageIndex(Header.Nodes[1], 1002);
            Header.SetNodePageIndex(Header.Nodes[2], 1003);

            //显示默认界面
            Header.SelectedIndex = 0;

            // 遍历电源计划，获取所有计划的GUID
            for (uint index = 0; ; index++)
            {
                Guid buffer = Guid.Empty;
                uint bufferSize = (uint)Marshal.SizeOf(typeof(Guid));
                uint result = PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ACCESS_SCHEME, index, ref buffer, ref bufferSize);

                if (result == 0)
                {
                    // 检查电源计划的名称，根据名称为相应的GUID赋值
                    string planName = GetPowerPlanName(buffer);
                    if (planName == "High performance" || planName == "高性能")
                    {
                        highPerformancePlanGuid = buffer;
                    }
                    else if (planName == "Balanced" || planName == "平衡")
                    {
                        balancedPlanGuid = buffer;
                    }
                    else if (planName == "Power saver" || planName == "节能")
                    {
                        powerSaverPlanGuid = buffer;
                    }
                }
                else if (result == 259) // ERROR_NO_MORE_ITEMS (0x103)
                {
                    // 遍历完成，没有更多的电源计划
                    break;
                }
                else
                {
                    Console.WriteLine("Failed to enumerate power plans. Error code: " + result);
                    break;
                }
            }

            // 输出相应的电源计划GUID
            Console.WriteLine("High performance plan GUID: " + highPerformancePlanGuid);
            Console.WriteLine("Balanced plan GUID: " + balancedPlanGuid);
            Console.WriteLine("Power saver plan GUID: " + powerSaverPlanGuid);

            // 设置定时器，每隔一段时间检查进程和电源计划
            Timer timer = new Timer
            {
                Interval = 5000 // 5秒钟检查一次
            };
            timer.Tick += Timer_Tick;
            //timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string currentProcessName = GetActiveProcessName();
            string currentPowerPlanGuid = GetCurrentPowerPlanGuidNew();

            // 如果正在运行的进程是目标进程，而且当前的电源计划不是高性能计划，则切换到高性能计划
            if (currentProcessName.Contains(targetProcessName) && currentPowerPlanGuid != highPerformancePlanGuid + "")
            {
                SwitchToPowerPlan(highPerformancePlanGuid + "");
            }
            // 否则，切换到默认的平衡计划或其他你希望使用的计划
            else
            {
                // 默认的平衡计划 GUID 或其他计划 GUID
                string defaultPowerPlanGuid = "YourDefaultPlanGuid";
                SwitchToPowerPlan(defaultPowerPlanGuid);
            }
        }

        private string GetActiveProcessName()
        {
            string processName = string.Empty;
            try
            {
                // 获取当前活动窗口句柄
                IntPtr hWnd = GetForegroundWindow();

                // 获取进程 ID
                uint processId;
                GetWindowThreadProcessId(hWnd, out processId);

                // 获取进程名称
                Process process = Process.GetProcessById((int)processId);
                processName = process.ProcessName;
            }
            catch (Exception ex)
            {
                // 处理异常情况
                Console.WriteLine($"GetActiveProcessName: error -> {ex.Message}");
            }
            return processName;
        }

        /// <summary>
        /// 在新版本的Windows操作系统中，Win32_PowerPlan WMI类已被弃用，并且不再直接可用。
        /// </summary>
        /// <returns></returns>
        private string GetCurrentPowerPlanGuid()
        {
            string powerPlanGuid = string.Empty;
            try
            {
                ManagementClass powerClass = new ManagementClass("Win32_PowerPlan");
                ManagementObjectCollection powerPlans = powerClass.GetInstances();

                foreach (ManagementObject powerPlan in powerPlans)
                {
                    if ((bool)powerPlan["IsActive"])
                    {
                        powerPlanGuid = powerPlan["InstanceID"] + "";
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // 处理异常情况
                Console.WriteLine($"GetCurrentPowerPlanGuid: error -> {ex.Message}");
            }
            return powerPlanGuid;
        }

        /// <summary>
        /// 使用PowerScheme类来管理电源计划。
        /// 这个类可以通过PowerEnumerate函数和PowerGetActiveScheme函数来获取活动的电源计划信息。
        /// </summary>
        /// <returns></returns>
        private string GetCurrentPowerPlanGuidNew()
        {
            string powerPlanGuid = string.Empty;
            IntPtr activeGuidPtr = IntPtr.Zero;
            try
            {
                // 获取活动的电源计划GUID
                uint result = PowerGetActiveScheme(IntPtr.Zero, ref activeGuidPtr);

                if (result == 0)
                {
                    // 将IntPtr转换为Guid
                    Guid activeGuid = (Guid)Marshal.PtrToStructure(activeGuidPtr, typeof(Guid));

                    // 输出活动的电源计划GUID
                    Console.WriteLine("Active Power Plan GUID: " + activeGuid);
                    powerPlanGuid = activeGuid + "";
                }
                else
                {
                    Console.WriteLine("Failed to get active power plan. Error code: " + result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // 释放资源
                if (activeGuidPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(activeGuidPtr);
                }
            }
            return powerPlanGuid;
        }

        private void SwitchToPowerPlan(string powerPlanGuid)
        {
            try
            {
                Process.Start("powercfg.exe", $"/s {powerPlanGuid}");
            }
            catch (Exception ex)
            {
                // 处理异常情况
                Console.WriteLine($"SwitchToPowerPlan: error -> {ex.Message}");
            }
        }

        /// <summary>
        /// 调用PowerEnumerate() 为highPerformancePlanGuid、balancedPlanGuid、powerSaverPlanGuid赋值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static Guid GetPowerPlanGuid(uint index)
        {
            Guid buffer = Guid.Empty;
            uint bufferSize = (uint)Marshal.SizeOf(typeof(Guid));
            uint result = PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ACCESS_SCHEME, index, ref buffer, ref bufferSize);
            if (result == 0)
            {
                return buffer;
            }
            else
            {
                throw new Exception("Failed to get power plan GUID. Error code: " + result);
            }
        }

        private static string GetPowerPlanName(Guid schemeGuid)
        {
            uint bufferSize = 0;
            uint result = PowerReadFriendlyName(IntPtr.Zero, ref schemeGuid, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, ref bufferSize);

            if (result == 0 && bufferSize > 0)
            {
                // 分配足够大的缓冲区
                IntPtr buffer = Marshal.AllocHGlobal((int)bufferSize);
                result = PowerReadFriendlyName(IntPtr.Zero, ref schemeGuid, IntPtr.Zero, IntPtr.Zero, buffer, ref bufferSize);

                if (result == 0)
                {
                    // 从缓冲区中获取友好名称并释放缓冲区
                    string friendlyName = Marshal.PtrToStringUni(buffer);
                    Marshal.FreeHGlobal(buffer);
                    return friendlyName;
                }
            }

            return "Unknown";
        }

        private static string GetPowerPlanNameOld(Guid schemeGuid)
        {
            // 电源计划注册表路径
            string powerPlanRegPath = @"SYSTEM\CurrentControlSet\Control\Power\User\PowerSchemes";

            // 构建电源计划GUID的字符串表示形式
            string schemeGuidString = schemeGuid.ToString("B").ToUpper();

            // 在注册表中查找对应电源计划的名称
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(powerPlanRegPath))
            {
                foreach (string subKeyName in key.GetSubKeyNames())
                {
                    using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                    {
                        string guidValue = subKey.GetValue("Alias") as string;
                        if (guidValue != null && guidValue.Equals(schemeGuidString, StringComparison.OrdinalIgnoreCase))
                        {
                            return subKey.GetValue("FriendlyName") as string;
                        }
                    }
                }
            }

            // 如果未找到对应的电源计划名称，返回默认名称
            return "Unknown";
        }

        // 需要引入以下声明来获取窗口句柄
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("powrprof.dll", SetLastError = true)]
        private static extern uint PowerEnumerate(IntPtr RootPowerKey, IntPtr SchemeGuid, IntPtr SubGroupOfPowerSettingsGuid, uint AccessFlags, uint Index, ref Guid Buffer, ref uint BufferSize);

        [DllImport("powrprof.dll", SetLastError = true)]
        private static extern uint PowerGetActiveScheme(IntPtr UserRootPowerKey, ref IntPtr ActivePolicyGuid);

        [DllImport("powrprof.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern uint PowerReadFriendlyName(IntPtr RootPowerKey, ref Guid SchemeGuid, IntPtr SubGroupOfPowerSettingsGuid, IntPtr PowerSettingGuid, IntPtr Buffer, ref uint BufferSize);


        private const uint ACCESS_SCHEME = 16;
        private const uint ACCESS_SUBGROUP = 17;
        private const uint ACCESS_INDIVIDUAL_SETTING = 18;
    }
}