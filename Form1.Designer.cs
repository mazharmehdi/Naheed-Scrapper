namespace Naheed_Scrapper_2
{
    partial class Form1
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
            buttonStart = new Button();
            buttonAlfatha = new Button();
            buttonAlfathaFromDisk = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(7, 6);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(94, 29);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonAlfatha
            // 
            buttonAlfatha.Location = new Point(106, 8);
            buttonAlfatha.Name = "buttonAlfatha";
            buttonAlfatha.Size = new Size(94, 29);
            buttonAlfatha.TabIndex = 1;
            buttonAlfatha.Text = "Alfatha";
            buttonAlfatha.UseVisualStyleBackColor = true;
            buttonAlfatha.Click += buttonAlfatha_Click;
            // 
            // buttonAlfathaFromDisk
            // 
            buttonAlfathaFromDisk.Location = new Point(205, 10);
            buttonAlfathaFromDisk.Name = "buttonAlfathaFromDisk";
            buttonAlfathaFromDisk.Size = new Size(152, 29);
            buttonAlfathaFromDisk.TabIndex = 2;
            buttonAlfathaFromDisk.Text = "AlfathaFromDisk";
            buttonAlfathaFromDisk.UseVisualStyleBackColor = true;
            buttonAlfathaFromDisk.Click += buttonAlfathaFromDisk_Click;
            // 
            // button1
            // 
            button1.Location = new Point(362, 14);
            button1.Name = "button1";
            button1.Size = new Size(153, 29);
            button1.TabIndex = 3;
            button1.Text = "Delete Images";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(buttonAlfathaFromDisk);
            Controls.Add(buttonAlfatha);
            Controls.Add(buttonStart);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonStart;
        private Button buttonAlfatha;
        private Button buttonAlfathaFromDisk;
        private Button button1;
    }
}
