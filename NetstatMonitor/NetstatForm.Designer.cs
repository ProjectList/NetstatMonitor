namespace NetstatMonitor
{
    partial class NetstatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetstatForm));
            this.label1 = new System.Windows.Forms.Label();
            this.filterTb = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.monitorGirdview = new System.Windows.Forms.DataGridView();
            this.TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoteAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.linkCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.monitorGirdview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter Condition:";
            // 
            // filterTb
            // 
            this.filterTb.Location = new System.Drawing.Point(125, 10);
            this.filterTb.Name = "filterTb";
            this.filterTb.Size = new System.Drawing.Size(401, 21);
            this.filterTb.TabIndex = 1;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(543, 8);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(127, 23);
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "Start Monitor";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // monitorGirdview
            // 
            this.monitorGirdview.AllowUserToDeleteRows = false;
            this.monitorGirdview.AllowUserToOrderColumns = true;
            this.monitorGirdview.BackgroundColor = System.Drawing.SystemColors.Window;
            this.monitorGirdview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monitorGirdview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeStamp,
            this.PID,
            this.Protocol,
            this.LocalAddress,
            this.RemoteAddress,
            this.State});
            this.monitorGirdview.Location = new System.Drawing.Point(9, 83);
            this.monitorGirdview.Name = "monitorGirdview";
            this.monitorGirdview.ReadOnly = true;
            this.monitorGirdview.RowTemplate.Height = 23;
            this.monitorGirdview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.monitorGirdview.Size = new System.Drawing.Size(661, 369);
            this.monitorGirdview.TabIndex = 3;
            // 
            // TimeStamp
            // 
            this.TimeStamp.HeaderText = "TimeStamp";
            this.TimeStamp.Name = "TimeStamp";
            this.TimeStamp.ReadOnly = true;
            // 
            // PID
            // 
            this.PID.FillWeight = 50F;
            this.PID.HeaderText = "PID";
            this.PID.Name = "PID";
            this.PID.ReadOnly = true;
            this.PID.Width = 50;
            // 
            // Protocol
            // 
            this.Protocol.FillWeight = 60F;
            this.Protocol.HeaderText = "Protocol";
            this.Protocol.Name = "Protocol";
            this.Protocol.ReadOnly = true;
            this.Protocol.Width = 60;
            // 
            // LocalAddress
            // 
            this.LocalAddress.FillWeight = 150F;
            this.LocalAddress.HeaderText = "Local Address";
            this.LocalAddress.Name = "LocalAddress";
            this.LocalAddress.ReadOnly = true;
            this.LocalAddress.Width = 150;
            // 
            // RemoteAddress
            // 
            this.RemoteAddress.FillWeight = 150F;
            this.RemoteAddress.HeaderText = "Remote Address";
            this.RemoteAddress.Name = "RemoteAddress";
            this.RemoteAddress.ReadOnly = true;
            this.RemoteAddress.Width = 150;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current tcp link count by filter condition:";
            // 
            // linkCount
            // 
            this.linkCount.AutoSize = true;
            this.linkCount.Location = new System.Drawing.Point(276, 50);
            this.linkCount.Name = "linkCount";
            this.linkCount.Size = new System.Drawing.Size(11, 12);
            this.linkCount.TabIndex = 5;
            this.linkCount.Text = "0";
            // 
            // NetstatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 485);
            this.Controls.Add(this.linkCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.monitorGirdview);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.filterTb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 523);
            this.Name = "NetstatForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Netstat Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.monitorGirdview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filterTb;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.DataGridView monitorGirdview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label linkCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemoteAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
    }
}

