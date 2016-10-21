using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetstatMonitor
{
    public partial class NetstatForm : Form
    {
        private bool _isMonitor ;
        private string logs;
        private int currentLogCount;
        public NetstatForm()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (startBtn.Text == "Start Monitor")
            {
                _isMonitor = true;
                Monitor(filterTb.Text);
                startBtn.Text = "Stop Monitor";
            }
            else
            {
                _isMonitor = false;
                filterTb.Text = "";
                startBtn.Text = "Start Monitor";
            }
            //GetNetstatByCmd();
        }

        private async void Monitor(String filter)
        {
            while (_isMonitor)
            {
                MonitorNetstat(filter);
                await Task.Delay(1000);
            }
            WriteLog(true);
        }

        private void MonitorNetstat(String filter)
        {
            //string cmd = "/c echo %date% %time% >> log.txt && netstat -an >> log.txt"; 
            if (String.IsNullOrEmpty(filter))
            {
                MessageBox.Show("Filter cannot be null");
                return;
            }
            var cmd = "/c netstat -anop tcp | find \"" + filter + "\"";
            var proc = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    Arguments = cmd,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true
                }
            };
            proc.Start();
            var output = proc.StandardOutput.ReadToEnd();
            var currentTime = DateTime.Now.ToLongTimeString();
            var lines = Regex.Split(output, "\r\n");
            linkCount.Text = (lines.Length - 1).ToString();
            foreach (var tcpInfo in lines.Select(line => Regex.Split(line, "\\s+")).Where(tcpInfo => tcpInfo.Length == 6))
            {
                tcpInfo[0] = currentTime;
                monitorGirdview.Rows.Add(tcpInfo[0], tcpInfo[5], tcpInfo[1], tcpInfo[2], tcpInfo[3], tcpInfo[4]);
                AddToLog(tcpInfo[0], tcpInfo[5], tcpInfo[1], tcpInfo[2], tcpInfo[3], tcpInfo[4]);
            }
            monitorGirdview.FirstDisplayedScrollingRowIndex = monitorGirdview.RowCount - 1;
        }

        private void AddToLog(params string[] logInfo)
        {
            string log = String.Join("\t", logInfo);
            logs += (log + "\r\n");
            ++currentLogCount;
            WriteLog();
        }

        private void WriteLog(bool flush = false)
        {   
            if (currentLogCount < 1000 && !flush) return;
            using (var streamWriter = new StreamWriter("Log.txt", true))
            {
                streamWriter.WriteLine(logs);
                streamWriter.Flush();
            }
            logs = "";
            currentLogCount = 0;
        }

        private static void GetNetstatByCmd()
        {
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
            cmdStartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = true;

            Process cmdProcess = new Process();
            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.ErrorDataReceived += cmd_Error;
            cmdProcess.OutputDataReceived += cmd_DataReceived;
            cmdProcess.EnableRaisingEvents = true;
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();

            cmdProcess.StandardInput.WriteLine("netstat -an | find \"80\"");
            cmdProcess.StandardInput.WriteLine("exit"); //Execute exit.
            cmdProcess.WaitForExit();
        }

        static void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("Output from other process");
            Console.WriteLine(e.Data);
        }

        static void cmd_Error(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("Error from other process");
            Console.WriteLine(e.Data);
        }
        private static void getActiveTcp()
        {
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] endPoints = ipProperties.GetActiveTcpListeners();
            TcpConnectionInformation[] tcpConnections =
                ipProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation info in tcpConnections)
            {
                Console.WriteLine("Local: {0}:{1}\nRemote: {2}:{3}\nState: {4}\n",
                    info.LocalEndPoint.Address, info.LocalEndPoint.Port,
                    info.RemoteEndPoint.Address, info.RemoteEndPoint.Port,
                    info.State.ToString());
            }
        }
    }
}
