namespace Bildt.Presentation;

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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        splitContainer1 = new SplitContainer();
        listView1 = new ListView();
        imageList1 = new ImageList(components);
        editFileControl1 = new Components.EditFileControl();
        toolStrip1 = new ToolStrip();
        toolStripButton1 = new ToolStripButton();
        toolStripContainer1 = new ToolStripContainer();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        toolStrip1.SuspendLayout();
        toolStripContainer1.ContentPanel.SuspendLayout();
        toolStripContainer1.TopToolStripPanel.SuspendLayout();
        toolStripContainer1.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(listView1);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(editFileControl1);
        splitContainer1.Size = new Size(798, 423);
        splitContainer1.SplitterDistance = 199;
        splitContainer1.TabIndex = 1;
        // 
        // listView1
        // 
        listView1.CheckBoxes = true;
        listView1.Dock = DockStyle.Fill;
        listView1.FullRowSelect = true;
        listView1.LargeImageList = imageList1;
        listView1.Location = new Point(0, 0);
        listView1.MultiSelect = false;
        listView1.Name = "listView1";
        listView1.Size = new Size(199, 423);
        listView1.TabIndex = 0;
        listView1.UseCompatibleStateImageBehavior = false;
        listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        // 
        // imageList1
        // 
        imageList1.ColorDepth = ColorDepth.Depth32Bit;
        imageList1.ImageSize = new Size(64, 64);
        imageList1.TransparentColor = Color.Transparent;
        // 
        // editFileControl1
        // 
        editFileControl1.Dock = DockStyle.Fill;
        editFileControl1.Location = new Point(0, 0);
        editFileControl1.Margin = new Padding(4);
        editFileControl1.Name = "editFileControl1";
        editFileControl1.Size = new Size(595, 423);
        editFileControl1.TabIndex = 0;
        editFileControl1.SaveClicked += editFileControl1_SaveClicked;
        // 
        // toolStrip1
        // 
        toolStrip1.Dock = DockStyle.None;
        toolStrip1.ImageScalingSize = new Size(24, 24);
        toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
        toolStrip1.Location = new Point(4, 0);
        toolStrip1.Name = "toolStrip1";
        toolStrip1.Size = new Size(65, 27);
        toolStrip1.TabIndex = 2;
        toolStrip1.Text = "toolStrip1";
        // 
        // toolStripButton1
        // 
        toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
        toolStripButton1.ImageTransparentColor = Color.Magenta;
        toolStripButton1.Name = "toolStripButton1";
        toolStripButton1.Size = new Size(52, 24);
        toolStripButton1.Text = "Mapp";
        toolStripButton1.Click += laddaToolStripMenuItem_Click;
        // 
        // toolStripContainer1
        // 
        // 
        // toolStripContainer1.ContentPanel
        // 
        toolStripContainer1.ContentPanel.Controls.Add(splitContainer1);
        toolStripContainer1.ContentPanel.Margin = new Padding(2);
        toolStripContainer1.ContentPanel.Size = new Size(798, 423);
        toolStripContainer1.Dock = DockStyle.Fill;
        toolStripContainer1.Location = new Point(0, 0);
        toolStripContainer1.Margin = new Padding(2);
        toolStripContainer1.Name = "toolStripContainer1";
        toolStripContainer1.Size = new Size(798, 450);
        toolStripContainer1.TabIndex = 3;
        toolStripContainer1.Text = "toolStripContainer1";
        // 
        // toolStripContainer1.TopToolStripPanel
        // 
        toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(798, 450);
        Controls.Add(toolStripContainer1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "MainForm";
        Text = "Bildt";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        toolStrip1.ResumeLayout(false);
        toolStrip1.PerformLayout();
        toolStripContainer1.ContentPanel.ResumeLayout(false);
        toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
        toolStripContainer1.TopToolStripPanel.PerformLayout();
        toolStripContainer1.ResumeLayout(false);
        toolStripContainer1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private SplitContainer splitContainer1;
    private ListView listView1;
    private ImageList imageList1;
    private Components.EditFileControl editFileControl1;
    private ToolStrip toolStrip1;
    private ToolStripButton toolStripButton1;
    private ToolStripContainer toolStripContainer1;
}