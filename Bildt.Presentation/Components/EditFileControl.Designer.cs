namespace Bildt.Presentation.Components
{
    partial class EditFileControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            descriptionTextBox = new TextBox();
            origPictureBox = new PictureBox();
            editedPictureBox = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            updateButton = new Button();
            saveButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)origPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editedPictureBox).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(descriptionTextBox, 0, 1);
            tableLayoutPanel1.Controls.Add(origPictureBox, 0, 0);
            tableLayoutPanel1.Controls.Add(editedPictureBox, 1, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.Size = new Size(745, 529);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Dock = DockStyle.Fill;
            descriptionTextBox.Location = new Point(3, 452);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.PlaceholderText = "Beskrivning av bilden";
            descriptionTextBox.ScrollBars = ScrollBars.Vertical;
            descriptionTextBox.Size = new Size(366, 74);
            descriptionTextBox.TabIndex = 0;
            descriptionTextBox.TextChanged += descriptionTextBox_TextChanged;
            descriptionTextBox.Leave += UpdateDescription;
            // 
            // origPictureBox
            // 
            origPictureBox.Dock = DockStyle.Fill;
            origPictureBox.Location = new Point(3, 3);
            origPictureBox.Name = "origPictureBox";
            origPictureBox.Size = new Size(366, 443);
            origPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            origPictureBox.TabIndex = 2;
            origPictureBox.TabStop = false;
            // 
            // editedPictureBox
            // 
            editedPictureBox.Dock = DockStyle.Fill;
            editedPictureBox.Location = new Point(375, 3);
            editedPictureBox.Name = "editedPictureBox";
            editedPictureBox.Size = new Size(367, 443);
            editedPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            editedPictureBox.TabIndex = 3;
            editedPictureBox.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(updateButton);
            flowLayoutPanel1.Controls.Add(saveButton);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(375, 452);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(367, 74);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(3, 3);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(94, 29);
            updateButton.TabIndex = 0;
            updateButton.Text = "Uppdatera";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += UpdateDescription;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(103, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(94, 29);
            saveButton.TabIndex = 1;
            saveButton.Text = "Spara";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += Save;
            // 
            // EditFileControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "EditFileControl";
            Size = new Size(745, 529);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)origPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)editedPictureBox).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox descriptionTextBox;
        private PictureBox origPictureBox;
        private PictureBox editedPictureBox;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button updateButton;
        private Button saveButton;
    }
}
