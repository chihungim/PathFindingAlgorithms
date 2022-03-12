
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
            this.label1 = new System.Windows.Forms.Label();
            this.BackGround = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.linklabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crtlReset = new System.Windows.Forms.Button();
            this.ctrlPathFinding = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.NodeControlMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctrlRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlToStart = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlToEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.NodeControlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei Light", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "BFS-PathFinding(Graph)";
            this.label1.UseWaitCursor = true;
            // 
            // BackGround
            // 
            this.BackGround.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackGround.Location = new System.Drawing.Point(12, 49);
            this.BackGround.Name = "BackGround";
            this.BackGround.Size = new System.Drawing.Size(400, 400);
            this.BackGround.TabIndex = 3;
            this.BackGround.Click += new System.EventHandler(this.BackGround_Click);
            this.BackGround.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(456, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(316, 34);
            this.label6.TabIndex = 11;
            this.label6.Text = "Rememer Start Node and End Node Must Exist";
            this.label6.UseWaitCursor = true;
            // 
            // linklabel1
            // 
            this.linklabel1.AutoSize = true;
            this.linklabel1.Location = new System.Drawing.Point(456, 251);
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
            this.groupBox1.Location = new System.Drawing.Point(456, 190);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(449, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 37);
            this.label2.TabIndex = 10;
            this.label2.Text = "How to use?";
            this.label2.UseWaitCursor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "1. Right Click on Bordered Area will add Node ",
            "\t\t\t(Max Amount = 10)",
            "2. Left Click on Node will Show PopupMenu ",
            "                             (Remove, Connect, toStart, toEnd)"});
            this.listBox1.Location = new System.Drawing.Point(456, 105);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(309, 64);
            this.listBox1.TabIndex = 15;
            // 
            // NodeControlMenu
            // 
            this.NodeControlMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrlRemove,
            this.ctrlConnect,
            this.ctrlToStart,
            this.ctrlToEnd});
            this.NodeControlMenu.Name = "contextMenuStrip1";
            this.NodeControlMenu.Size = new System.Drawing.Size(118, 92);
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
            // BFS_Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 461);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linklabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BackGround);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BFS_Graph";
            this.Text = "BFS_Graph";
            this.groupBox1.ResumeLayout(false);
            this.NodeControlMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel BackGround;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linklabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button crtlReset;
        private System.Windows.Forms.Button ctrlPathFinding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip NodeControlMenu;
        private System.Windows.Forms.ToolStripMenuItem ctrlRemove;
        private System.Windows.Forms.ToolStripMenuItem ctrlConnect;
        private System.Windows.Forms.ToolStripMenuItem ctrlToStart;
        private System.Windows.Forms.ToolStripMenuItem ctrlToEnd;
    }
}