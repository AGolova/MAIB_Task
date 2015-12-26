namespace MAIB
{
    partial class MaibTask
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaibTask));
            this.toolStripMainForm = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.labelServerAddress = new System.Windows.Forms.Label();
            this.textBoxServerAddress = new System.Windows.Forms.TextBox();
            this.labelConnectionType = new System.Windows.Forms.Label();
            this.comboBoxConnectionType = new System.Windows.Forms.ComboBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonCheckConnection = new System.Windows.Forms.Button();
            this.openFileDialogScript = new System.Windows.Forms.OpenFileDialog();
            this.buttonScriptSelect = new System.Windows.Forms.Button();
            this.textBoxScriptPath = new System.Windows.Forms.TextBox();
            this.buttonInputDataFolder = new System.Windows.Forms.Button();
            this.textBoxInputDataFolderPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialogInputData = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.toolTipMainForm = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDataProperties = new System.Windows.Forms.Button();
            this.toolStripMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMainForm
            // 
            this.toolStripMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonExit});
            this.toolStripMainForm.Location = new System.Drawing.Point(0, 0);
            this.toolStripMainForm.Name = "toolStripMainForm";
            this.toolStripMainForm.Size = new System.Drawing.Size(394, 25);
            this.toolStripMainForm.TabIndex = 0;
            this.toolStripMainForm.Text = "toolStripMainForm";
            // 
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExit.Image")));
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Size = new System.Drawing.Size(45, 22);
            this.toolStripButtonExit.Text = "Выход";
            this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // labelServerAddress
            // 
            this.labelServerAddress.AutoSize = true;
            this.labelServerAddress.Location = new System.Drawing.Point(12, 28);
            this.labelServerAddress.Name = "labelServerAddress";
            this.labelServerAddress.Size = new System.Drawing.Size(130, 13);
            this.labelServerAddress.TabIndex = 1;
            this.labelServerAddress.Text = "Укажите адрес сервера";
            // 
            // textBoxServerAddress
            // 
            this.textBoxServerAddress.Location = new System.Drawing.Point(169, 25);
            this.textBoxServerAddress.Name = "textBoxServerAddress";
            this.textBoxServerAddress.Size = new System.Drawing.Size(207, 20);
            this.textBoxServerAddress.TabIndex = 2;
            this.textBoxServerAddress.Text = "(local)";
            // 
            // labelConnectionType
            // 
            this.labelConnectionType.AutoSize = true;
            this.labelConnectionType.Location = new System.Drawing.Point(12, 58);
            this.labelConnectionType.Name = "labelConnectionType";
            this.labelConnectionType.Size = new System.Drawing.Size(147, 13);
            this.labelConnectionType.TabIndex = 3;
            this.labelConnectionType.Text = "Выберите тип подключения";
            // 
            // comboBoxConnectionType
            // 
            this.comboBoxConnectionType.FormattingEnabled = true;
            this.comboBoxConnectionType.Items.AddRange(new object[] {
            "Windows аутентификация",
            "SQL аутентификация"});
            this.comboBoxConnectionType.Location = new System.Drawing.Point(169, 55);
            this.comboBoxConnectionType.Name = "comboBoxConnectionType";
            this.comboBoxConnectionType.Size = new System.Drawing.Size(207, 21);
            this.comboBoxConnectionType.TabIndex = 4;
            this.comboBoxConnectionType.SelectedIndexChanged += new System.EventHandler(this.comboBoxConnectionType_SelectedIndexChanged);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(121, 87);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(38, 13);
            this.labelLogin.TabIndex = 5;
            this.labelLogin.Text = "Логин";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Enabled = false;
            this.textBoxLogin.Location = new System.Drawing.Point(169, 84);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(207, 20);
            this.textBoxLogin.TabIndex = 6;
            this.textBoxLogin.TextChanged += new System.EventHandler(this.textBoxLogin_TextChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(114, 114);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(45, 13);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Пароль";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(169, 111);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(207, 20);
            this.textBoxPassword.TabIndex = 8;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // buttonCheckConnection
            // 
            this.buttonCheckConnection.Enabled = false;
            this.buttonCheckConnection.Location = new System.Drawing.Point(15, 137);
            this.buttonCheckConnection.Name = "buttonCheckConnection";
            this.buttonCheckConnection.Size = new System.Drawing.Size(361, 23);
            this.buttonCheckConnection.TabIndex = 9;
            this.buttonCheckConnection.Text = "Проверить подключение";
            this.buttonCheckConnection.UseVisualStyleBackColor = true;
            this.buttonCheckConnection.Click += new System.EventHandler(this.buttonCheckConnection_Click);
            // 
            // openFileDialogScript
            // 
            this.openFileDialogScript.FileName = "openFileDialog";
            // 
            // buttonScriptSelect
            // 
            this.buttonScriptSelect.Enabled = false;
            this.buttonScriptSelect.Location = new System.Drawing.Point(15, 172);
            this.buttonScriptSelect.Name = "buttonScriptSelect";
            this.buttonScriptSelect.Size = new System.Drawing.Size(361, 23);
            this.buttonScriptSelect.TabIndex = 11;
            this.buttonScriptSelect.Text = "Выберите скрипт";
            this.buttonScriptSelect.UseVisualStyleBackColor = true;
            this.buttonScriptSelect.Click += new System.EventHandler(this.buttonScriptSelect_Click);
            // 
            // textBoxScriptPath
            // 
            this.textBoxScriptPath.Location = new System.Drawing.Point(15, 201);
            this.textBoxScriptPath.Name = "textBoxScriptPath";
            this.textBoxScriptPath.ReadOnly = true;
            this.textBoxScriptPath.Size = new System.Drawing.Size(361, 20);
            this.textBoxScriptPath.TabIndex = 12;
            this.textBoxScriptPath.TabStop = false;
            // 
            // buttonInputDataFolder
            // 
            this.buttonInputDataFolder.Enabled = false;
            this.buttonInputDataFolder.Location = new System.Drawing.Point(15, 227);
            this.buttonInputDataFolder.Name = "buttonInputDataFolder";
            this.buttonInputDataFolder.Size = new System.Drawing.Size(361, 23);
            this.buttonInputDataFolder.TabIndex = 13;
            this.buttonInputDataFolder.Text = "Выберите путь к данным для обработки";
            this.buttonInputDataFolder.UseVisualStyleBackColor = true;
            this.buttonInputDataFolder.Click += new System.EventHandler(this.buttonInputDataFolder_Click);
            // 
            // textBoxInputDataFolderPath
            // 
            this.textBoxInputDataFolderPath.Location = new System.Drawing.Point(15, 256);
            this.textBoxInputDataFolderPath.Name = "textBoxInputDataFolderPath";
            this.textBoxInputDataFolderPath.ReadOnly = true;
            this.textBoxInputDataFolderPath.Size = new System.Drawing.Size(361, 20);
            this.textBoxInputDataFolderPath.TabIndex = 14;
            this.textBoxInputDataFolderPath.TabStop = false;
            // 
            // buttonFinish
            // 
            this.buttonFinish.Enabled = false;
            this.buttonFinish.Location = new System.Drawing.Point(15, 308);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(361, 23);
            this.buttonFinish.TabIndex = 15;
            this.buttonFinish.Text = "Запустить обработку данных";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // toolTipMainForm
            // 
            this.toolTipMainForm.ToolTipTitle = "Внимание";
            // 
            // buttonDataProperties
            // 
            this.buttonDataProperties.Location = new System.Drawing.Point(15, 279);
            this.buttonDataProperties.Name = "buttonDataProperties";
            this.buttonDataProperties.Size = new System.Drawing.Size(361, 23);
            this.buttonDataProperties.TabIndex = 16;
            this.buttonDataProperties.Text = "Настройка параметров";
            this.buttonDataProperties.UseVisualStyleBackColor = true;
            this.buttonDataProperties.Click += new System.EventHandler(this.buttonDataProperties_Click);
            // 
            // MaibTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 343);
            this.Controls.Add(this.buttonDataProperties);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.textBoxInputDataFolderPath);
            this.Controls.Add(this.buttonInputDataFolder);
            this.Controls.Add(this.textBoxScriptPath);
            this.Controls.Add(this.buttonScriptSelect);
            this.Controls.Add(this.buttonCheckConnection);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.comboBoxConnectionType);
            this.Controls.Add(this.labelConnectionType);
            this.Controls.Add(this.textBoxServerAddress);
            this.Controls.Add(this.labelServerAddress);
            this.Controls.Add(this.toolStripMainForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MaibTask";
            this.Text = "MAIB Task";
            this.toolStripMainForm.ResumeLayout(false);
            this.toolStripMainForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMainForm;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
        private System.Windows.Forms.Label labelServerAddress;
        private System.Windows.Forms.TextBox textBoxServerAddress;
        private System.Windows.Forms.Label labelConnectionType;
        private System.Windows.Forms.ComboBox comboBoxConnectionType;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonCheckConnection;
        private System.Windows.Forms.OpenFileDialog openFileDialogScript;
        private System.Windows.Forms.Button buttonScriptSelect;
        private System.Windows.Forms.TextBox textBoxScriptPath;
        private System.Windows.Forms.Button buttonInputDataFolder;
        private System.Windows.Forms.TextBox textBoxInputDataFolderPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogInputData;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.ToolTip toolTipMainForm;
        private System.Windows.Forms.Button buttonDataProperties;
    }
}

