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
        private string _logs="";
        private int _currentLogCount;
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
                monitorGirdview.Rows.Clear();
                startBtn.Text = "Start Monitor";
            }
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
                //monitorGirdview.Rows.Add(tcpInfo[0], tcpInfo[5], tcpInfo[1], tcpInfo[2], tcpInfo[3], tcpInfo[4]);
                AddToView(tcpInfo);
                AddToLog(tcpInfo[0], tcpInfo[5], tcpInfo[1], tcpInfo[2], tcpInfo[3], tcpInfo[4]);
            }
            if (lines.Length == 1)
            {
                AddToView(new[] { currentTime, "-", "-", "-", "-", "-" });
            }
            monitorGirdview.FirstDisplayedScrollingRowIndex = monitorGirdview.RowCount - 1;
        }

        private void AddToView(string[] tcpInfo)
        {
            string id = tcpInfo[5] + "\t" + tcpInfo[1] + "\t" + tcpInfo[2] + "\t" + tcpInfo[3] + "\t" + tcpInfo[4];
            if(!deDupCb.Checked || !_logs.Contains(id))
            monitorGirdview.Rows.Add(tcpInfo[0], tcpInfo[5], tcpInfo[1], tcpInfo[2], tcpInfo[3], tcpInfo[4]);
        }

        private void AddToLog(params string[] logInfo)
        {
            var log = String.Join("\t", logInfo);
            _logs += (log + "\r\n");
            ++_currentLogCount;
            WriteLog();
        }

        private void WriteLog(bool flush = false)
        {   
            if (_currentLogCount < 1000 && !flush) return;
            using (var streamWriter = new StreamWriter("Log.txt", true))
            {
                streamWriter.WriteLine(_logs);
                streamWriter.Flush();
            }
            _logs = "";
            _currentLogCount = 0;
        }
    }
}
