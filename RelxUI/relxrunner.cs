using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml;

public class RelxRunner
{
    public enum RelxState
    {
        Idle,
        Authorizing,
        NetworkError,
        SessionEstablished,
        ProcessNotFound,
        ProcessSelecting,
        SubscriptionError,
        Injecting,
        Running,
        Failed
    }

    private Process _process;
    private bool _isSelectingProcess = false;

    public RelxState CurrentState { get; private set; } = RelxState.Idle;

    // ===== 事件 =====
    public event Action<string> OnLog;
    public event Action<RelxState, int> OnStateChanged;
    public event Action<List<string>> OnProcessListUpdated;

    // ===== 启动 =====
    public void Start(string exePath, string username, string password)
    {
        if (_process != null && !_process.HasExited)
            return;

        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = exePath,
            Arguments = $"--username {username} --password {password}",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            CreateNoWindow = true
        };

        _process = new Process();
        _process.StartInfo = psi;

        _process.OutputDataReceived += (s, e) =>
        {
            if (string.IsNullOrEmpty(e.Data)) return;
            HandleLine(e.Data, false);
        };

        _process.ErrorDataReceived += (s, e) =>
        {
            if (string.IsNullOrEmpty(e.Data)) return;
            HandleLine(e.Data, true);
        };

        _process.Start();
        _process.BeginOutputReadLine();
        _process.BeginErrorReadLine();

        UpdateState(RelxState.Authorizing, 5);
    }

    // ===== 发送选择 =====
    public void SendSelection(string number)
    {
        if (_process != null && !_process.HasExited)
        {
            _process.StandardInput.WriteLine(number);
        }
    }

    // ===== 停止 =====
    public void Stop()
    {
        if (_process != null && !_process.HasExited)
        {
            _process.Kill();
            _process.Dispose();
        }
    }

    // ===== 处理输出 =====
    private void HandleLine(string line, bool isError)
    {
        OnLog?.Invoke(line);

        if (line.Contains("Press enter to continue"))
        {
            AutoSendEnter();

            // 如果是错误状态结束
            if (CurrentState == RelxState.NetworkError ||
                CurrentState == RelxState.SubscriptionError)
            {
                UpdateState(RelxState.Failed, 0);
            }

            return;
        }
        // ===== 授权失败 =====
        if (line.Contains("Failed to authorize") || line.Contains("522"))
        {
            UpdateState(RelxState.NetworkError, 0);
            AutoSendEnter();
            return;
        }

        // ===== Secure Session =====
        if (line.Contains("Secure session established"))
        {
            UpdateState(RelxState.SessionEstablished, 20);
            return;
        }

        // ===== 没找到进程 =====
        if (line.Contains("No running Minecraft processes"))
        {
            UpdateState(RelxState.ProcessNotFound, 30);
            return;
        }

        // ===== 发现进程 =====
        if (line.Contains("Found the following Minecraft processes"))
        {
            _isSelectingProcess = true;
            _collectedProcesses.Clear();
            UpdateState(RelxState.ProcessSelecting, 35);
            return;
        }

        // ===== 捕获数字选项 =====
        if (_isSelectingProcess && Regex.IsMatch(line, @"^\d+\."))
        {
            _collectedProcesses.Add(line);
            OnProcessListUpdated?.Invoke(new List<string>(_collectedProcesses));
            return;
        }

        // ===== 结束选择 =====
        if (line.Contains("Please select a process"))
        {
            _isSelectingProcess = false;
            return;
        }

        // ===== 没订阅 =====
        if (line.Contains("Active subscription required"))
        {
            UpdateState(RelxState.SubscriptionError, 0);
            return;
        }

        // ===== 注入过程 =====
        if (line.Contains("Used cached"))
        {
            UpdateState(RelxState.Injecting, 60);
            return;
        }

        if (line.Contains("Relx DLL loaded"))
        {
            UpdateState(RelxState.Injecting, 75);
            return;
        }

        if (line.Contains("Parsing Minecraft mappings"))
        {
            UpdateState(RelxState.Injecting, 85);
            return;
        }

        if (line.Contains("Starting TCP server"))
        {
            UpdateState(RelxState.Running, 100);
            return;
        }
    }

    private List<string> _collectedProcesses = new List<string>();

    private void UpdateState(RelxState state, int progress)
    {
        CurrentState = state;
        OnStateChanged?.Invoke(state, progress);
    }

    private void AutoSendEnter()
    {
        if (_process != null && !_process.HasExited)
        {
            _process.StandardInput.WriteLine();
        }
    }
}
