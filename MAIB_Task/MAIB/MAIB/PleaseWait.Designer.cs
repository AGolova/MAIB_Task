namespace MAIB
{
    partial class PleaseWait
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PleaseWait));
            this.richTextBoxPleaseWait = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxPleaseWait
            // 
            this.richTextBoxPleaseWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxPleaseWait.Location = new System.Drawing.Point(1, -1);
            this.richTextBoxPleaseWait.Name = "richTextBoxPleaseWait";
            this.richTextBoxPleaseWait.ReadOnly = true;
            this.richTextBoxPleaseWait.Size = new System.Drawing.Size(416, 123);
            this.richTextBoxPleaseWait.TabIndex = 0;
            this.richTextBoxPleaseWait.Text = "Идет обработка данных. Пожалуйста подождите.";
            // 
            // PleaseWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 120);
            this.Controls.Add(this.richTextBoxPleaseWait);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PleaseWait";
            this.Text = "PleaseWait";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxPleaseWait;

    }
}