namespace AppUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            okButton = new Button();
            imagePictureBox = new PictureBox();
            directoryTextBox = new TextBox();
            insertDirectoryLabel = new Label();
            keepButton = new Button();
            tossButton = new Button();
            ((System.ComponentModel.ISupportInitialize)imagePictureBox).BeginInit();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Location = new Point(345, 517);
            okButton.Margin = new Padding(2);
            okButton.Name = "okButton";
            okButton.Size = new Size(78, 20);
            okButton.TabIndex = 0;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += button1_Click;
            // 
            // imagePictureBox
            // 
            imagePictureBox.Location = new Point(277, 11);
            imagePictureBox.Margin = new Padding(2);
            imagePictureBox.Name = "imagePictureBox";
            imagePictureBox.Size = new Size(200, 200);
            imagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            imagePictureBox.TabIndex = 1;
            imagePictureBox.TabStop = false;
            imagePictureBox.Visible = false;
            // 
            // directoryTextBox
            // 
            directoryTextBox.Location = new Point(333, 489);
            directoryTextBox.Name = "directoryTextBox";
            directoryTextBox.Size = new Size(100, 23);
            directoryTextBox.TabIndex = 2;
            // 
            // insertDirectoryLabel
            // 
            insertDirectoryLabel.AutoSize = true;
            insertDirectoryLabel.Location = new Point(326, 471);
            insertDirectoryLabel.Name = "insertDirectoryLabel";
            insertDirectoryLabel.Size = new Size(114, 15);
            insertDirectoryLabel.TabIndex = 3;
            insertDirectoryLabel.Text = "Insert Directory Path";
            // 
            // keepButton
            // 
            keepButton.Location = new Point(293, 514);
            keepButton.Name = "keepButton";
            keepButton.Size = new Size(75, 23);
            keepButton.TabIndex = 4;
            keepButton.Text = "&Keep";
            keepButton.UseVisualStyleBackColor = true;
            keepButton.Visible = false;
            keepButton.Click += keepButton_Click;
            // 
            // tossButton
            // 
            tossButton.Location = new Point(402, 514);
            tossButton.Name = "tossButton";
            tossButton.Size = new Size(75, 23);
            tossButton.TabIndex = 5;
            tossButton.Text = "&Toss";
            tossButton.UseVisualStyleBackColor = true;
            tossButton.Visible = false;
            tossButton.Click += tossButton_Click;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(tossButton);
            Controls.Add(keepButton);
            Controls.Add(insertDirectoryLabel);
            Controls.Add(directoryTextBox);
            Controls.Add(imagePictureBox);
            Controls.Add(okButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            MaximumSize = new Size(800, 600);
            MinimizeBox = false;
            MinimumSize = new Size(800, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KeepOrTossApp";
            ((System.ComponentModel.ISupportInitialize)imagePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button okButton;
        private PictureBox imagePictureBox;
        private TextBox directoryTextBox;
        private Label insertDirectoryLabel;
        private Button keepButton;
        private Button tossButton;
    }
}