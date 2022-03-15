
namespace PathFindingAlgorithms.BFS
{
    partial class BFS_Graph
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
            this.components = new System.ComponentModel.Container();
            this.label6 = new System.Windows.Forms.Label();
            this.linklabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crtlReset = new System.Windows.Forms.Button();
            this.ctrlPathFinding = new System.Windows.Forms.Button();
            this.VertexControlMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctrlRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlToStart = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlToEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.graphPanel1 = new PathFindingAlgorithms.CustomControls.GraphPanel();
            this.Title = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.VertexControlMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(3, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(316, 34);
            this.label6.TabIndex = 11;
            this.label6.Text = "Rememer Start Node and End Node Must Exist";
            this.label6.UseWaitCursor = true;
            // 
            // linklabel1
            // 
            this.linklabel1.AutoSize = true;
            this.linklabel1.Location = new System.Drawing.Point(3, 98);
            this.linklabel1.Name = "linklabel1";
            this.linklabel1.Size = new System.Drawing.Size(78, 15);
            this.linklabel1.TabIndex = 14;
            this.linklabel1.TabStop = true;
            this.linklabel1.Text = "MyGitHub ♥";
            this.linklabel1.UseWaitCursor = true;
            this.linklabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabel1_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crtlReset);
            this.groupBox1.Controls.Add(this.ctrlPathFinding);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 58);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            this.groupBox1.UseWaitCursor = true;
            // 
            // crtlReset
            // 
            this.crtlReset.Location = new System.Drawing.Point(7, 22);
            this.crtlReset.Name = "crtlReset";
            this.crtlReset.Size = new System.Drawing.Size(135, 23);
            this.crtlReset.TabIndex = 4;
            this.crtlReset.Text = "reset";
            this.crtlReset.UseVisualStyleBackColor = true;
            this.crtlReset.UseWaitCursor = true;
            this.crtlReset.Click += new System.EventHandler(this.ctrlReset_Click);
            // 
            // ctrlPathFinding
            // 
            this.ctrlPathFinding.Location = new System.Drawing.Point(148, 22);
            this.ctrlPathFinding.Name = "ctrlPathFinding";
            this.ctrlPathFinding.Size = new System.Drawing.Size(155, 23);
            this.ctrlPathFinding.TabIndex = 4;
            this.ctrlPathFinding.Text = "PathFinding";
            this.ctrlPathFinding.UseVisualStyleBackColor = true;
            this.ctrlPathFinding.UseWaitCursor = true;
            this.ctrlPathFinding.Click += new System.EventHandler(this.ctrlPathFinding_Click);
            // 
            // VertexControlMenu
            // 
            this.VertexControlMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrlRemove,
            this.ctrlConnect,
            this.ctrlToStart,
            this.ctrlToEnd});
            this.VertexControlMenu.Name = "contextMenuStrip1";
            this.VertexControlMenu.Size = new System.Drawing.Size(118, 92);
            // 
            // ctrlRemove
            // 
            this.ctrlRemove.Name = "ctrlRemove";
            this.ctrlRemove.Size = new System.Drawing.Size(117, 22);
            this.ctrlRemove.Text = "Remove";
            this.ctrlRemove.Click += new System.EventHandler(this.ctrlRemove_Click);
            // 
            // ctrlConnect
            // 
            this.ctrlConnect.Name = "ctrlConnect";
            this.ctrlConnect.Size = new System.Drawing.Size(117, 22);
            this.ctrlConnect.Text = "From";
            this.ctrlConnect.Click += new System.EventHandler(this.ctrlConnect_Click);
            // 
            // ctrlToStart
            // 
            this.ctrlToStart.Name = "ctrlToStart";
            this.ctrlToStart.Size = new System.Drawing.Size(117, 22);
            this.ctrlToStart.Text = "toStart";
            this.ctrlToStart.Click += new System.EventHandler(this.ctrlToStart_Click);
            // 
            // ctrlToEnd
            // 
            this.ctrlToEnd.Name = "ctrlToEnd";
            this.ctrlToEnd.Size = new System.Drawing.Size(117, 22);
            this.ctrlToEnd.Text = "toEnd";
            this.ctrlToEnd.Click += new System.EventHandler(this.ctrlToEnd_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 415);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.linklabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(393, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(384, 409);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.graphPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(384, 409);
            this.panel1.TabIndex = 1;
            // 
            // graphPanel1
            // 
            this.graphPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel1.Location = new System.Drawing.Point(5, 5);
            this.graphPanel1.Name = "graphPanel1";
            this.graphPanel1.Size = new System.Drawing.Size(374, 399);
            this.graphPanel1.TabIndex = 0;
            this.graphPanel1.Click += new System.EventHandler(this.GraphPanelOnClick);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Microsoft YaHei Light", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(399, 46);
            this.Title.TabIndex = 2;
            this.Title.Text = "BFS-PathFinding(Graph)";
            this.Title.UseWaitCursor = true;
            // 
            // BFS_Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BFS_Graph";
            this.Text = "BFS_Graph";
            this.groupBox1.ResumeLayout(false);
            this.VertexControlMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linklabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button crtlReset;
        private System.Windows.Forms.Button ctrlPathFinding;
        private System.Windows.Forms.ContextMenuStrip VertexControlMenu;
        private System.Windows.Forms.ToolStripMenuItem ctrlRemove;
        private System.Windows.Forms.ToolStripMenuItem ctrlConnect;
        private System.Windows.Forms.ToolStripMenuItem ctrlToStart;
        private System.Windows.Forms.ToolStripMenuItem ctrlToEnd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.GraphPanel graphPanel1;
    }
}