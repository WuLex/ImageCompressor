using System;

namespace ImageCompressorTool
{
    partial class MainForm
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
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picCompressed = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCompress = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.lblQuality = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompressed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOriginal.Location = new System.Drawing.Point(18, 20);
            this.picOriginal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(479, 399);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            // 
            // picCompressed
            // 
            this.picCompressed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCompressed.Location = new System.Drawing.Point(534, 20);
            this.picCompressed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picCompressed.Name = "picCompressed";
            this.picCompressed.Size = new System.Drawing.Size(479, 399);
            this.picCompressed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCompressed.TabIndex = 1;
            this.picCompressed.TabStop = false;
            this.picCompressed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCompressed_MouseDown);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(18, 472);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(112, 38);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "浏览";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(534, 472);
            this.btnCompress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(112, 38);
            this.btnCompress.TabIndex = 3;
            this.btnCompress.Text = "压缩";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(230, 472);
            this.trackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(156, 56);
            this.trackBar.TabIndex = 4;
            this.trackBar.Value = 80;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(220, 447);
            this.lblQuality.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(164, 20);
            this.lblQuality.TabIndex = 5;
            this.lblQuality.Text = "压缩质量:";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(18, 542);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(74, 20);
            this.lblFilePath.TabIndex = 6;
            this.lblFilePath.Text = "文件路径:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(116, 537);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(896, 27);
            this.txtFilePath.TabIndex = 7;
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(18, 600);
            this.lblFileSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(71, 20);
            this.lblFileSize.TabIndex = 8;
            this.lblFileSize.Text = "文件大小:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.saveToolStripMenuItem.Text = "保存";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 652);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.lblQuality);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.picCompressed);
            this.Controls.Add(this.picOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Compression Tool";
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompressed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picCompressed;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCompress;
        public System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblFileSize;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem saveToolStripMenuItem;
    }


}