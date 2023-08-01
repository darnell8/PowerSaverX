using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PowerSaverX.Utils
{
    internal class PowerUtils
    {
        public static List<PowerPlan> GetPowerPlanList()
        {
            var resultList = new List<PowerPlan>();
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
                    resultList.Add(new PowerPlan() {
                        FriendlyName = planName,
                        PlanGuid = buffer,
                    });
                }
                else if (result == 259) // ERROR_NO_MORE_ITEMS (0x103)
                {
                    // 遍历完成，没有更多的电源计划
                    break;
                }
                else
                {
                    Debug.WriteLine("Failed to enumerate power plans. Error code: " + result);
                    break;
                }
            }

            // 输出相应的电源计划GUID
            // Debug.WriteLine("High performance plan GUID: " + highPerformancePlanGuid);
            // Debug.WriteLine("Balanced plan GUID: " + balancedPlanGuid);
            // Debug.WriteLine("Power saver plan GUID: " + powerSaverPlanGuid);

            return resultList;
        }

        public static void SwitchToPowerPlan(string powerPlanGuid)
        {
            // 使用 ProcessStartInfo 类来设置启动选项
            ProcessStartInfo startInfo = new()
            {
                FileName = "powercfg.exe",
                Arguments = $"/s {powerPlanGuid}",
                CreateNoWindow = true, // 设置为 true，不显示窗口
                UseShellExecute = false, // 设置为 false，不使用 shell 执行
                RedirectStandardOutput = true, // 设置为 true，捕获输出信息
                RedirectStandardError = true // 设置为 true，捕获错误信息
            };

            try
            {
                using Process process = new();
                // 将 ProcessStartInfo 对象赋值给 Process 的 StartInfo 属性
                process.StartInfo = startInfo;
                // 启动进程
                process.Start();
                // 等待进程执行完成
                process.WaitForExit();

                // 检查进程的退出代码，非零值表示执行命令出错
                if (process.ExitCode != 0)
                {
                    Console.WriteLine($"Failed to set power plan. Exit code: {process.ExitCode}");
                }
                else
                {
                    Console.WriteLine("Power plan set successfully.");
                }
            }
            catch (Exception ex)
            {
                // 处理异常情况
                Debug.WriteLine($"SwitchToPowerPlan: error -> {ex.Message}");
            }
        }

        public static string GetActiveProcessName()
        {
            string processName = string.Empty;
            try
            {
                // 获取当前活动窗口句柄
                IntPtr hWnd = GetForegroundWindow();

                // 获取进程 ID
                _ = GetWindowThreadProcessId(hWnd, out uint processId);

                // 获取进程名称
                Process process = Process.GetProcessById((int)processId);
                processName = process.ProcessName;
                Debug.WriteLine($"GetActiveProcessName: processName -> {process.ProcessName}");
            }
            catch (Exception ex)
            {
                // 处理异常情况
                Debug.WriteLine($"GetActiveProcessName: error -> {ex.Message}");
            }
            return processName;
        }

        /// <summary>
        /// 使用PowerScheme类来管理电源计划。
        /// 这个类可以通过PowerEnumerate函数和PowerGetActiveScheme函数来获取活动的电源计划信息。
        /// </summary>
        /// <returns></returns>
        public static Guid GetCurrentPowerPlanGuidNew()
        {
            Guid activeGuid = Guid.Empty;
            IntPtr activeGuidPtr = IntPtr.Zero;
            try
            {
                // 获取活动的电源计划GUID
                uint result = PowerGetActiveScheme(IntPtr.Zero, ref activeGuidPtr);

                if (result == 0)
                {
                    // 将IntPtr转换为Guid
                    activeGuid = Marshal.PtrToStructure<Guid>(activeGuidPtr);

                    // 输出活动的电源计划GUID
                    //Debug.WriteLine("Active Power Plan GUID: " + activeGuid);
                }
                else
                {
                    Debug.WriteLine("Failed to get active power plan. Error code: " + result);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // 释放资源
                if (activeGuidPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(activeGuidPtr);
                }
            }
            return activeGuid;
        }

        public static string GetPowerPlanName(Guid schemeGuid)
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
                    string? friendlyName = Marshal.PtrToStringUni(buffer);
                    Marshal.FreeHGlobal(buffer);
                    return friendlyName ?? "Unknown";
                }
            }

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

        public class PowerPlan
        {
            public string FriendlyName { get; set; } = "";
            public Guid PlanGuid { get; set; }
        }
    }
}
