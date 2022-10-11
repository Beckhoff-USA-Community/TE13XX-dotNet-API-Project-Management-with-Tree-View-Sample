namespace YT_Chart_Integration
{
    partial class Form1
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddChart = new System.Windows.Forms.ToolStripButton();
            this.btnAddAxis = new System.Windows.Forms.ToolStripButton();
            this.btnAddChannel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRun = new System.Windows.Forms.ToolStripButton();
            this.btnPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelChart = new System.Windows.Forms.ToolStripButton();
            this.scopeProjectPanel = new TwinCAT.Measurement.Scope.Control.ScopeProjectPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.toolStripSeparator1,
            this.btnAddChart,
            this.btnAddAxis,
            this.btnAddChannel,
            this.toolStripSeparator2,
            this.btnStart,
            this.btnStop,
            this.btnSave,
            this.toolStripSeparator3,
            this.btnRun,
            this.btnPause,
            this.toolStripSeparator4,
            this.btnDelChart});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(769, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(37, 22);
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddChart
            // 
            this.btnAddChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddChart.Name = "btnAddChart";
            this.btnAddChart.Size = new System.Drawing.Size(65, 22);
            this.btnAddChart.Text = "Add Chart";
            this.btnAddChart.Click += new System.EventHandler(this.btnAddChart_Click);
            // 
            // btnAddAxis
            // 
            this.btnAddAxis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddAxis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddAxis.Name = "btnAddAxis";
            this.btnAddAxis.Size = new System.Drawing.Size(58, 22);
            this.btnAddAxis.Text = "Add Axis";
            this.btnAddAxis.Click += new System.EventHandler(this.btnAddAxis_Click);
            // 
            // btnAddChannel
            // 
            this.btnAddChannel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddChannel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddChannel.Name = "btnAddChannel";
            this.btnAddChannel.Size = new System.Drawing.Size(80, 22);
            this.btnAddChannel.Text = "Add Channel";
            this.btnAddChannel.Click += new System.EventHandler(this.btnAddChannel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnStart
            // 
            this.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(35, 22);
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(35, 22);
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRun
            // 
            this.btnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(32, 22);
            this.btnRun.Text = "Run";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnPause
            // 
            this.btnPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(42, 22);
            this.btnPause.Text = "Pause";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDelChart
            // 
            this.btnDelChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelChart.Name = "btnDelChart";
            this.btnDelChart.Size = new System.Drawing.Size(76, 22);
            this.btnDelChart.Text = "Delete Chart";
            this.btnDelChart.Click += new System.EventHandler(this.btnDelChart_Click);
            // 
            // scopeProjectPanel
            // 
            this.scopeProjectPanel.AllowDrop = true;
            this.scopeProjectPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.scopeProjectPanel.ChartBackColor = System.Drawing.SystemColors.Control;
            this.scopeProjectPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.scopeProjectPanel.GraphicLibrary = TwinCAT.Scope2.Communications.GraphicLibrary.GDI_Plus;
            this.scopeProjectPanel.GridSplitColor = System.Drawing.Color.DarkSlateGray;
            this.scopeProjectPanel.HotColor = System.Drawing.SystemColors.MenuHighlight;
            this.scopeProjectPanel.InactiveTextColor = System.Drawing.Color.DarkSlateGray;
            this.scopeProjectPanel.Location = new System.Drawing.Point(128, 25);
            this.scopeProjectPanel.Name = "scopeProjectPanel";
            this.scopeProjectPanel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
            this.scopeProjectPanel.ScopeProject = null;
            this.scopeProjectPanel.SelectedColor = System.Drawing.SystemColors.Highlight;
            this.scopeProjectPanel.Size = new System.Drawing.Size(641, 449);
            this.scopeProjectPanel.TabIndex = 1;
            this.scopeProjectPanel.TextColor = System.Drawing.Color.Black;
            this.scopeProjectPanel.ActiveChartChanged += new System.EventHandler<TwinCAT.Measurement.Scope.Control.ActiveChartChangedEventArgs>(this.scopeProjectPanel_ActiveChartChanged);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(122, 449);
            this.treeView1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 474);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.scopeProjectPanel);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Sample YT Chart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAddChart;
        private System.Windows.Forms.ToolStripButton btnAddAxis;
        private System.Windows.Forms.ToolStripButton btnAddChannel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnRun;
        private System.Windows.Forms.ToolStripButton btnPause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnDelChart;
        private TwinCAT.Measurement.Scope.Control.ScopeProjectPanel scopeProjectPanel;
        private System.Windows.Forms.TreeView treeView1;
    }
}

