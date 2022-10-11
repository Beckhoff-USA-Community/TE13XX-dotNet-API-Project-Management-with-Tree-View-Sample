using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TwinCAT.Measurement.ProjectBase;
using TwinCAT.Measurement.Scope.API.Model;
using TwinCAT.Scope2.Communications;

namespace YT_Chart_Integration
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// AmsNetID where Sample-PLC runs
        /// </summary>
        private static string PLCNetID = "localhost";
        TreeNode rootNode;
        Chart activeChart;
        List<Chart> charts;
        List<AxisGroup> axes;
        List<Channel> channels;
        List<TriggerGroup> triggers;
        public Form1()
        {
            InitializeComponent();
            scopeProjectPanel.ScopeProject = new ScopeProject();

            AddTreeNode(scopeProjectPanel.ScopeProject, rootNode);

        }

        private string filename = @"ScopeTestChart.tcscopex";
        private void btnLoad_Click(object sender, EventArgs e)
        {
            FileInfo fInfo = new FileInfo(filename);
            if (!fInfo.Exists)
            {
                MessageBox.Show("File not found! Please use the Add Chart button to create a config! Once a config is created and saved it can be load using the Load button!", "File not found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //delete old configuration
                scopeProjectPanel.ScopeProject.Dispose();

                //load configuration
                ScopeProject Project = ScopeProject.LoadScopeProject(filename);
                DeleteTreeNode(rootNode);
                scopeProjectPanel.ScopeProject = Project;
                AddTreeNode(scopeProjectPanel.ScopeProject, rootNode);
                foreach(MeasurementMemberContainerBase member in Project.SubMember)
                {
                    FillTree(member, rootNode);
                }
            }

        }

        private void btnAddChart_Click(object sender, EventArgs e)
        {
            YTChart chart = new YTChart();
            scopeProjectPanel.ScopeProject.AddMember(chart);
            charts = scopeProjectPanel.ScopeProject.SubMember.OfType<Chart>().ToList<Chart>();
            chart.SubMember.OfType<ChartStyle>().First().ToolTipEnabled = true;
            AddTreeNode(chart, rootNode);
            
        }

        private void btnAddAxis_Click(object sender, EventArgs e)
        {
            AxisGroup axisGroup = new AxisGroup();
            if (scopeProjectPanel.ScopeProject.SubMember.OfType<Chart>().Count() == 0)
            {
                MessageBox.Show(this, "Please create a chart first!", "No chart connected!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Chart chart = (Chart)treeView1.SelectedNode.Tag;
                chart.AddMember(axisGroup);
                AddTreeNode(axisGroup, treeView1.SelectedNode);
            }
        }

        private void btnAddChannel_Click(object sender, EventArgs e)
        {
            Channel channel = new Channel();
            if (scopeProjectPanel.ScopeProject.SubMember.OfType<Chart>().Count() == 0)
            {
                MessageBox.Show(this, "Please create a chart first!", "No chart connected!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (scopeProjectPanel.ScopeProject.SubMember.OfType<Chart>().First().SubMember.OfType<AxisGroup>().Count() == 0)
            {
                MessageBox.Show(this, "Please create a axis first!", "No axis connected!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                AxisGroup axis = (AxisGroup) treeView1.SelectedNode.Tag;
                axis.AddMember(channel);
                ChangeChannelSettings(channel);
                SetAcquisitions(channel);
                AddTreeNode(channel, treeView1.SelectedNode);

            }
        }

        private void SetAcquisitions(Channel channel)
        {
            AdsAcquisition acq = new AdsAcquisition();
            acq.AmsNetIdExchange = PLCNetID;
            acq.TargetPort = 851;
            acq.SymbolBased = true;
            acq.SymbolName = "Variables.fSine";
            acq.DataType = Scope2DataType.REAL64;
            acq.SampleTime = (uint)(10 * TimeSpan.TicksPerMillisecond);
            AcquisitionInterpreter acquisitionInterpreter = new AcquisitionInterpreter();
            acquisitionInterpreter.Acquisition = acq;
            channel.AddMember(acquisitionInterpreter);
        }

        private void ChangeChannelSettings(Channel channel)
        {
            SeriesStyle style = channel.SubMember.OfType<ChannelStyle>().First().SubMember.OfType<SeriesStyle>().First();
            style.DisplayColor = Color.Red;
            style.MarkColor = Color.DarkRed;
            style.LineWidth = 2;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //dascard old data
                if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Reply)
                    scopeProjectPanel.ScopeProject.Disconnect();

                //start record
                if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Config)
                    scopeProjectPanel.ScopeProject.StartRecord();

            }
            catch (Exception err)
            {
                MessageBox.Show(this, err.Message, "Error on start record!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Record)
                {
                    scopeProjectPanel.ScopeProject.StopRecord();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(this, err.Message, "Error on stop record!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //save data and configuration
                if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Reply)
                {
                    File.Create("ExportData.svdx").Close();
                    scopeProjectPanel.ScopeProject.ShowProgress = (string header, TwinCAT.Scope2.Tools.ProgressBox.WorkDelegate work) => { return TwinCAT.Scope2.Tools.ProgressBox.Show(this, header, 100, work) == DialogResult.OK; };
                    scopeProjectPanel.ScopeProject.SaveData("ExportData.svdx");
                }
                //just save the configuration
                else
                {
                    File.Create(filename).Close();
                    scopeProjectPanel.ScopeProject.SaveToFile(filename);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(this, err.Message, "Error on save!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (scopeProjectPanel.ScopeProject.ScopeState != TwinCAT.Measurement.Scope.API.ScopeViewState.Record)
            {
                MessageBox.Show(this, "Only possible if a record is running!", "Run not possible!",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Record)
                scopeProjectPanel.ScopeProject.SubMember.OfType<Chart>().First().StartDisplay();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (scopeProjectPanel.ScopeProject.ScopeState != TwinCAT.Measurement.Scope.API.ScopeViewState.Record)
            {
                MessageBox.Show(this, "Only possible if a record is running!", "Pause not possible!",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Record)
                scopeProjectPanel.ScopeProject.SubMember.OfType<Chart>().First().StopDisplay();
        }

        private void btnDelChart_Click(object sender, EventArgs e)
        {
            if (scopeProjectPanel.ScopeProject.SubMember.OfType<Chart>().Count() == 0)
            {
                MessageBox.Show(this, "No chart is connected!", "Nothing to delete!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Record)
            {
                scopeProjectPanel.ScopeProject.StopRecord();
                scopeProjectPanel.ScopeProject.Disconnect();
            }
            else if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Reply)
            {
                scopeProjectPanel.ScopeProject.Disconnect();
            }
            else
            {
                Chart chart = (Chart)treeView1.SelectedNode.Tag;
                scopeProjectPanel.ScopeProject.RemoveMember(chart);
                DeleteTreeNode(treeView1.SelectedNode);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (scopeProjectPanel != null && scopeProjectPanel.ScopeProject != null)
            {
                if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Record)
                {
                    scopeProjectPanel.ScopeProject.StopRecord();
                }
                if (scopeProjectPanel.ScopeProject.ScopeState == TwinCAT.Measurement.Scope.API.ScopeViewState.Reply)
                {
                    scopeProjectPanel.ScopeProject.Disconnect();
                }
            }
        }

        private void scopeProjectPanel_ActiveChartChanged(object sender, TwinCAT.Measurement.Scope.Control.ActiveChartChangedEventArgs e)
        {
            activeChart = e.Chart;
        }

        private void AddTreeNode(MeasurementMemberBase member, TreeNode nodeToAddTo)
        {
            if (treeView1.Nodes.Count != 0)
            {
                TreeNode aNode = new TreeNode(member.Name);
                AddContextMenu(member, aNode);
                aNode.Tag = member;
                nodeToAddTo.Nodes.Add(aNode);
            }
            else
            {
                rootNode = new TreeNode(member.Name);
                rootNode.Tag = member;
                AddContextMenu(member, rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }
        private void DeleteTreeNode(TreeNode node)
        {
            treeView1.Nodes.Remove(node);
        }

        private void FillTree(MeasurementMemberContainerBase member, TreeNode node)
        {
            AddTreeNode(member, node);
            foreach(MeasurementMemberContainerBase subMember in member.SubMember)
            {
                FillTree(subMember, node.LastNode);
            }
        }

        private void AddContextMenu(MeasurementMemberBase member, TreeNode nodeToAddTo) 
        {
            ContextMenuStrip nodeMenu = new ContextMenuStrip();
            switch (member.GetType().Name)
            {
                case "ScopeProject":
                    nodeMenu.Items.Add("Add Chart");
                    nodeMenu.Items[0].Click += btnAddChart_Click;
                    nodeToAddTo.ContextMenuStrip = nodeMenu;
                    break;
                case "YTChart":

                    nodeMenu.Items.Add("Add Axis");
                    nodeMenu.Items.Add("Delete");
                    nodeMenu.Items[0].Click += btnAddAxis_Click;
                    nodeMenu.Items[1].Click += btnDelChart_Click;
                    nodeToAddTo.ContextMenuStrip = nodeMenu;
                    break;

                case "AxisGroup":
                    nodeMenu.Items.Add("Add Channel");
                    nodeMenu.Items[0].Click += btnAddChannel_Click;
                    nodeToAddTo.ContextMenuStrip = nodeMenu;
                    break;


                default:
                    break;

            }
        }


    }
}

