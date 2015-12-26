namespace MAIB
{
    partial class DataProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataProperties));
            this.checkBoxHasFieldsEnclosedInQuotes = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDelimiterIsTab = new System.Windows.Forms.RadioButton();
            this.radioButtonDelimiterIsOther = new System.Windows.Forms.RadioButton();
            this.labelDelimiters = new System.Windows.Forms.Label();
            this.textBoxDelimiters = new System.Windows.Forms.TextBox();
            this.groupBoxDelimiterProporties = new System.Windows.Forms.GroupBox();
            this.buttonAnalyzeFile = new System.Windows.Forms.Button();
            this.buttonApplyProperties = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxDelimiterProporties.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxHasFieldsEnclosedInQuotes
            // 
            this.checkBoxHasFieldsEnclosedInQuotes.AutoSize = true;
            this.checkBoxHasFieldsEnclosedInQuotes.Enabled = false;
            this.checkBoxHasFieldsEnclosedInQuotes.Location = new System.Drawing.Point(6, 19);
            this.checkBoxHasFieldsEnclosedInQuotes.Name = "checkBoxHasFieldsEnclosedInQuotes";
            this.checkBoxHasFieldsEnclosedInQuotes.Size = new System.Drawing.Size(229, 17);
            this.checkBoxHasFieldsEnclosedInQuotes.TabIndex = 18;
            this.checkBoxHasFieldsEnclosedInQuotes.Text = "Данные заключены в двойные кавычки";
            this.checkBoxHasFieldsEnclosedInQuotes.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAnalyzeFile);
            this.groupBox1.Controls.Add(this.groupBoxDelimiterProporties);
            this.groupBox1.Controls.Add(this.checkBoxHasFieldsEnclosedInQuotes);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 160);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройка параметров чтения файлов";
            // 
            // radioButtonDelimiterIsTab
            // 
            this.radioButtonDelimiterIsTab.AutoSize = true;
            this.radioButtonDelimiterIsTab.Location = new System.Drawing.Point(15, 19);
            this.radioButtonDelimiterIsTab.Name = "radioButtonDelimiterIsTab";
            this.radioButtonDelimiterIsTab.Size = new System.Drawing.Size(79, 17);
            this.radioButtonDelimiterIsTab.TabIndex = 22;
            this.radioButtonDelimiterIsTab.TabStop = true;
            this.radioButtonDelimiterIsTab.Text = "Табуляция";
            this.radioButtonDelimiterIsTab.UseVisualStyleBackColor = true;
            // 
            // radioButtonDelimiterIsOther
            // 
            this.radioButtonDelimiterIsOther.AutoSize = true;
            this.radioButtonDelimiterIsOther.Location = new System.Drawing.Point(130, 19);
            this.radioButtonDelimiterIsOther.Name = "radioButtonDelimiterIsOther";
            this.radioButtonDelimiterIsOther.Size = new System.Drawing.Size(62, 17);
            this.radioButtonDelimiterIsOther.TabIndex = 23;
            this.radioButtonDelimiterIsOther.TabStop = true;
            this.radioButtonDelimiterIsOther.Text = "Другой";
            this.radioButtonDelimiterIsOther.UseVisualStyleBackColor = true;
            // 
            // labelDelimiters
            // 
            this.labelDelimiters.AutoSize = true;
            this.labelDelimiters.Location = new System.Drawing.Point(12, 45);
            this.labelDelimiters.Name = "labelDelimiters";
            this.labelDelimiters.Size = new System.Drawing.Size(120, 13);
            this.labelDelimiters.TabIndex = 24;
            this.labelDelimiters.Text = "Укажите разделитель";
            this.labelDelimiters.Visible = false;
            // 
            // textBoxDelimiters
            // 
            this.textBoxDelimiters.Enabled = false;
            this.textBoxDelimiters.Location = new System.Drawing.Point(138, 42);
            this.textBoxDelimiters.Name = "textBoxDelimiters";
            this.textBoxDelimiters.Size = new System.Drawing.Size(100, 20);
            this.textBoxDelimiters.TabIndex = 25;
            this.textBoxDelimiters.Visible = false;
            // 
            // groupBoxDelimiterProporties
            // 
            this.groupBoxDelimiterProporties.Controls.Add(this.radioButtonDelimiterIsTab);
            this.groupBoxDelimiterProporties.Controls.Add(this.labelDelimiters);
            this.groupBoxDelimiterProporties.Controls.Add(this.textBoxDelimiters);
            this.groupBoxDelimiterProporties.Controls.Add(this.radioButtonDelimiterIsOther);
            this.groupBoxDelimiterProporties.Location = new System.Drawing.Point(6, 42);
            this.groupBoxDelimiterProporties.Name = "groupBoxDelimiterProporties";
            this.groupBoxDelimiterProporties.Size = new System.Drawing.Size(360, 76);
            this.groupBoxDelimiterProporties.TabIndex = 26;
            this.groupBoxDelimiterProporties.TabStop = false;
            this.groupBoxDelimiterProporties.Text = "Настройка разделителя";
            // 
            // buttonAnalyzeFile
            // 
            this.buttonAnalyzeFile.Location = new System.Drawing.Point(7, 131);
            this.buttonAnalyzeFile.Name = "buttonAnalyzeFile";
            this.buttonAnalyzeFile.Size = new System.Drawing.Size(359, 23);
            this.buttonAnalyzeFile.TabIndex = 27;
            this.buttonAnalyzeFile.Text = "Анализирвать данные";
            this.buttonAnalyzeFile.UseVisualStyleBackColor = true;
            // 
            // buttonApplyProperties
            // 
            this.buttonApplyProperties.Location = new System.Drawing.Point(10, 336);
            this.buttonApplyProperties.Name = "buttonApplyProperties";
            this.buttonApplyProperties.Size = new System.Drawing.Size(372, 23);
            this.buttonApplyProperties.TabIndex = 20;
            this.buttonApplyProperties.Text = "Применить настройки";
            this.buttonApplyProperties.UseVisualStyleBackColor = true;
            this.buttonApplyProperties.Click += new System.EventHandler(this.buttonApplyProperties_Click);
            // 
            // DataProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(394, 371);
            this.Controls.Add(this.buttonApplyProperties);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DataProperties";
            this.Text = "DataProperties";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxDelimiterProporties.ResumeLayout(false);
            this.groupBoxDelimiterProporties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxHasFieldsEnclosedInQuotes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonDelimiterIsTab;
        private System.Windows.Forms.RadioButton radioButtonDelimiterIsOther;
        private System.Windows.Forms.Label labelDelimiters;
        private System.Windows.Forms.TextBox textBoxDelimiters;
        private System.Windows.Forms.GroupBox groupBoxDelimiterProporties;
        private System.Windows.Forms.Button buttonAnalyzeFile;
        private System.Windows.Forms.Button buttonApplyProperties;
    }
}