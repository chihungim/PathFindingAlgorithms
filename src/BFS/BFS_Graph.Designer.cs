
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
            this.ToMyGithub = new System.Windows.Forms.LinkLabel();
            this.Title = new System.Windows.Forms.Label();
            this.graphPanel1 = new PathFindingAlgorithms.CustomControls.GraphPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ToMyGithub
            // 
            this.ToMyGithub.AutoSize = true;
            this.ToMyGithub.Location = new System.Drawing.Point(692, 26);
            this.ToMyGithub.Name = "ToMyGithub";
            this.ToMyGithub.Size = new System.Drawing.Size(78, 15);
            this.ToMyGithub.TabIndex = 14;
            this.ToMyGithub.TabStop = true;
            this.ToMyGithub.Text = "MyGitHub ♥";
            this.ToMyGithub.UseWaitCursor = true;
            this.ToMyGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ToMyGithub_LinkClicked);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(5, 5);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(410, 41);
            this.Title.TabIndex = 2;
            this.Title.Text = "BFS-PathFinding(Graph)";
            this.Title.UseWaitCursor = true;
            // 
            // graphPanel1
            // 
            this.graphPanel1.BackColor = System.Drawing.Color.White;
            this.graphPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel1.Location = new System.Drawing.Point(5, 46);
            this.graphPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.graphPanel1.Name = "graphPanel1";
            this.graphPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.graphPanel1.Size = new System.Drawing.Size(765, 410);
            this.graphPanel1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(416, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "FindPath";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ctrlPathFinding_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(497, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ctrlReset_Click);
            // 
            // BFS_Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(775, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.graphPanel1);
            this.Controls.Add(this.ToMyGithub);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BFS_Graph";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "BFS_Graph";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel ToMyGithub;
        private System.Windows.Forms.Label Title;
        private CustomControls.GraphPanel graphPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}