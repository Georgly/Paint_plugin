namespace SamplePlugin
{
    partial class uControl
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
            this.brushStyleListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // brushStyleListBox
            // 
            this.brushStyleListBox.FormattingEnabled = true;
            this.brushStyleListBox.Location = new System.Drawing.Point(14, 12);
            this.brushStyleListBox.Name = "brushStyleListBox";
            this.brushStyleListBox.Size = new System.Drawing.Size(120, 95);
            this.brushStyleListBox.TabIndex = 0;
            // 
            // uControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.brushStyleListBox);
            this.Name = "uControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox brushStyleListBox;
    }
}
