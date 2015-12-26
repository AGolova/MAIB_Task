using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

//TODO: ProviderError
namespace MAIB
{
    public partial class MaibTask : Form
    {
        #region Блок переменных для всех функций
        
        private bool _connectionStatus = false;
        private string _connectionString;
        
        #endregion Блок переменных для всех функций
        #region Блок изменения показателей формы

        public MaibTask()
        {
            InitializeComponent();
        }
        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"Вы уверены?", @"Выход из программы", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return;
            Close();
        }
        private void EnableStatus()
        {
            if (comboBoxConnectionType.SelectedIndex == 1)
            {
                textBoxLogin.Enabled = true;
                textBoxPassword.Enabled = true;
                buttonCheckConnection.Enabled = false;
            }
            else
            {
                buttonCheckConnection.Enabled = true;
                textBoxLogin.Enabled = false;
                textBoxPassword.Enabled = false;
            }

            if (textBoxLogin.Text != "" && textBoxPassword.Text!=""
                && textBoxServerAddress.Text !="")
                buttonCheckConnection.Enabled = true;

            buttonScriptSelect.Enabled = _connectionStatus;
           
            if (_connectionStatus && textBoxScriptPath.Text != "")
                buttonInputDataFolder.Enabled = true;
            else buttonInputDataFolder.Enabled = false;
            
            if (_connectionStatus && textBoxInputDataFolderPath.Text != "")
                buttonFinish.Enabled = true;
            else buttonFinish.Enabled = false;

            if (textBoxScriptPath.Text != "")
                checkBoxHasFieldsEnclosedInQuotes.Enabled = true;
            else
                checkBoxHasFieldsEnclosedInQuotes.Enabled = false;

            if (textBoxScriptPath.Text != "")
                textBoxDelimiters.Enabled = true;
            else
                textBoxDelimiters.Enabled = false;
        }
        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            EnableStatus();
        }
        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            EnableStatus();
        }
        private void comboBoxConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableStatus();
        }
        private void textBoxDelimiters_Enter(object sender, EventArgs e)
        {
            if (checkBoxHasFieldsEnclosedInQuotes.Checked)
                toolTipMainForm.Show("Можно использовать любые,\r\n"
                                    + @"КРОМЕ ""значение""(двойных кавычек) " + "\r\n"
                                    + "Для неотобржаемых:\r\n"
                                    + "табуляция - \\t\r\n", textBoxDelimiters);
            else
                toolTipMainForm.Show("Можно использовать любые.\r\n"
                                    + "Для неотобржаемых:\r\n"
                                    + "табуляция - \\t\r\n", textBoxDelimiters);
        }
        private void textBoxDelimiters_MouseEnter(object sender, EventArgs e)
        {
            if (checkBoxHasFieldsEnclosedInQuotes.Checked)
                toolTipMainForm.Show("Можно использовать любые,\r\n"
                                    + @"КРОМЕ ""значение""(двойных кавычек) " + "\r\n"
                                    + "Для неотобржаемых:\r\n"
                                    + "табуляция - \\t\r\n", textBoxDelimiters);
            else
                toolTipMainForm.Show("Можно использовать любые.\r\n"
                                    + "Для неотобржаемых:\r\n"
                                    + "табуляция - \\t\r\n", textBoxDelimiters);
        }
        private void textBoxDelimiters_Leave(object sender, EventArgs e)
        {
            toolTipMainForm.Hide(textBoxDelimiters);
        }

        #endregion Блок изменения показателей формы
        #region блок работы с подключением к БД
        
        private static bool TestConnection(string connectionString)
        {
            var canConnect = false;
            var connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    canConnect = true;
                }
            }

            catch (Exception){}
            finally{connection.Close();}
            return canConnect;
        }
        private void buttonCheckConnection_Click(object sender, EventArgs e)
        {
            _connectionString = "Server="+textBoxServerAddress.Text
                                 +";Database=tempdb;";
            if (comboBoxConnectionType.SelectedIndex == 0)
                _connectionString = _connectionString + "Trusted_Connection=True;";
            else
            {
                _connectionString = _connectionString + "User Id=" + textBoxLogin.Text
                                   + ";Password=" + textBoxPassword.Text + ";";
            }

            _connectionStatus = TestConnection(_connectionString);
            MessageBox.Show(_connectionStatus ? @"Связь установлена" : @"Проверьте правильность данных", @"Статус");
            
            EnableStatus();
        }
        
        #endregion блок работы с подключением к БД
        #region блок работы с файловой системой

        private string OpenScriptFile()
        {
            var initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialogScript.InitialDirectory = initialDirectory;
            openFileDialogScript.Filter = @"SQL Files (*.sql)|*.sql";
            openFileDialogScript.FileName = string.Empty;
            if (openFileDialogScript.ShowDialog() != DialogResult.OK) return "error";
            var selectedFile = openFileDialogScript.FileName;
            return selectedFile;
        }
        private void buttonScriptSelect_Click(object sender, EventArgs e)
        {
            var status = OpenScriptFile();
            if (status == "error") return;
            textBoxScriptPath.Text = status;
            EnableStatus();
        }
        private void buttonInputDataFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogInputData.ShowDialog() == DialogResult.OK)
            {
                textBoxInputDataFolderPath.Text = folderBrowserDialogInputData.SelectedPath;
            }
            EnableStatus();
        }
        private static string CheckPaths(string pathToCheck)
        {
            if (!Directory.Exists(pathToCheck))
                Directory.CreateDirectory(pathToCheck);
            return pathToCheck;
        }
        private static string[] ProcessDirectory(string targetDirectory)
        {
            var fileEntries = Directory.GetFiles(targetDirectory);
            return fileEntries;
        }
        private DataTable GetDataTabletFromInputFile(string inputFilePath)
        {
            
            //var Delimiter = textBoxDelimiters.Text;
            //var pattern = new Regex("\\\\");
            //Delimiter=pattern.Replace(Delimiter, "\\");
            var inputFileData = new DataTable();
            //Delimiter = Delimiter.Replace(@"\", "");

            using (var fileReader = new TextFieldParser(inputFilePath))
            {
                fileReader.SetDelimiters(new[] { "\t" });
                fileReader.HasFieldsEnclosedInQuotes = checkBoxHasFieldsEnclosedInQuotes.Checked;
                fileReader.TrimWhiteSpace = true;
                var colFields = fileReader.ReadFields();
                if (colFields != null)
                    foreach (var column in colFields)
                    {
                        var datecolumn = new DataColumn(column) { AllowDBNull = true };
                        inputFileData.Columns.Add(datecolumn);
                    }
                while (!fileReader.EndOfData)
                {
                    var fieldData = fileReader.ReadFields();
                    //Making empty value as null
                    for (var i = 0; i < fieldData.Length; i++)
                    //TODO: повесить это на скл сервер
                    {
                        //fieldData[i].Replace(string.Empty, null);
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    inputFileData.Rows.Add(fieldData);
                }
            }
            return inputFileData;
        }
        private static void WriteToHtmlFile(DataSet inputDataSet, string pathToCheck, string stepNumber)
        {
            var stepFolder = CheckPaths(pathToCheck + @"\Step_" + stepNumber);
            var stepReport = 0;
            foreach (DataTable table in inputDataSet.Tables)
            {
                stepReport++;
                var textToWrite = table.Rows[0].ItemArray[0].ToString();
                File.WriteAllText(stepFolder + @"\Report_" + stepReport + ".html", textToWrite);
            }
        }

        #endregion блок работы с файловой системой
        #region блок блок работы  с объектами и самой БД

        protected string ParametrIntoScriptNameSearch(string script, string type)
        {
            var phraseStart = "";
            var phraseEnd = "";
            var startProcedureNamePosition = 0;
            var lastProcedureNamePosition = 0;

            if (type == "Main")
            {
                phraseStart = "/*CREATE PROCEDURE";
                phraseEnd = "MAIN PROCEDURE*/";
                startProcedureNamePosition = script.IndexOf(phraseStart, StringComparison.Ordinal);
                lastProcedureNamePosition = script.IndexOf(phraseEnd, StringComparison.Ordinal);
            }
            
            //TODO: сделать возможность задавать название таблицы в ГУИ
            if (type == "DataTableName")
            {
                phraseStart = "/*TABLE NAME";
                phraseEnd = "FOR DATA INSERTING*/";
                startProcedureNamePosition = script.LastIndexOf(phraseStart, StringComparison.Ordinal);
                lastProcedureNamePosition = script.IndexOf(phraseEnd, StringComparison.Ordinal);   
            }
            
            var objectName = script.Substring(startProcedureNamePosition + phraseStart.Length,
                            lastProcedureNamePosition - (startProcedureNamePosition + phraseStart.Length));
            objectName = objectName.Trim();
            return objectName;
        }
        private void DropObject(string objectType,string objectTypeName, string objectName)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            var dropScript =
                "IF EXISTS (SELECT * FROM sys.objects " 
                            +"WHERE type = '"+objectType+"' AND name = '" + objectName + "')" +
                    "DROP " + objectTypeName + " " + objectName;
            var dropCommand = new SqlCommand(dropScript, connection) { CommandTimeout = 180 };
            dropCommand.ExecuteNonQuery();
            connection.Close();
        }
        private void DropCreatedDbObjects(IList<string> dBobjectsName)
        {
            DropObject("P", "PROCEDURE", dBobjectsName[0]);
            DropObject("U", "TABLE", dBobjectsName[1]);
        }
        private void CreateProcedure(string script)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            var command = new SqlCommand(script, connection) { CommandTimeout = 180 };
            command.ExecuteNonQuery();
            connection.Close();
        }
        private DataSet ExecuteProcedure(string procedureName,string tableName)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            var sqlCommand = new SqlCommand(procedureName, connection)
            {
                CommandTimeout = 180,
                CommandType = CommandType.StoredProcedure
            };
            sqlCommand.Parameters.AddWithValue("@TableName", tableName);
            var reader = sqlCommand.ExecuteReader();
            var dataset = new DataSet();
            while (reader.IsClosed == false)
            {
                dataset.Load(reader, LoadOption.PreserveChanges, "");
            }
            connection.Close();
            return dataset;
        }
        private void InsertDataIntoSqlServerUsingSqlBulkCopy(DataTable inputFileData,string tableName)
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            using (var s = new SqlBulkCopy(connection))
            {
                s.DestinationTableName = tableName;

                foreach (var column in inputFileData.Columns)
                    s.ColumnMappings.Add(column.ToString(), column.ToString());

                s.WriteToServer(inputFileData);
            }
            connection.Close();
        }

        #endregion блок работы  с объектами и самой БД
        private void buttonFinish_Click(object sender, EventArgs e)
        {
            
            var pleaseWaitForm = new PleaseWait();
            pleaseWaitForm.Show();
            pleaseWaitForm.Refresh();
            Hide();
           
            var script = File.ReadAllText(textBoxScriptPath.Text, Encoding.Default);
            var dBobjectsName = new[] { 
                                ParametrIntoScriptNameSearch(script, "Main")
                                ,ParametrIntoScriptNameSearch(script, "DataTableName")};

            DropCreatedDbObjects(dBobjectsName);
            CreateProcedure(script);
            ExecuteProcedure(dBobjectsName[0], dBobjectsName[1]);

            var pathToCheck = CheckPaths(textBoxInputDataFolderPath.Text + @"\OutputData");
            var directoryPaths = ProcessDirectory(textBoxInputDataFolderPath.Text);
            var timeStamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            timeStamp = timeStamp.Replace(":", "_").Replace("T", "-");
            pathToCheck = CheckPaths(pathToCheck + @"\" + timeStamp);


            for (var i = 0; directoryPaths.Count() > i; i++)
            {
                var pathToAnalyse = directoryPaths.ElementAt(i);
                //TODO: Оптимизировать этот кусок
                InsertDataIntoSqlServerUsingSqlBulkCopy(
                    GetDataTabletFromInputFile(pathToAnalyse), dBobjectsName[1]);
                 var resultDataSet = ExecuteProcedure(dBobjectsName[0], dBobjectsName[1]);
                WriteToHtmlFile(resultDataSet, pathToCheck, i.ToString(CultureInfo.InvariantCulture));
            }
            
            DropCreatedDbObjects(dBobjectsName);
            
            pleaseWaitForm.Close();
            pleaseWaitForm.Dispose();
            Show();

            var dialogResult = MessageBox.Show(@"Задача выполнена. Открыть папку с выходными файлами?", @"Информация", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) return;
            Process.Start(pathToCheck);
        }

        private void buttonDataProperties_Click(object sender, EventArgs e)
        {
            var dataProperties = new DataProperties();
            Hide();
            dataProperties.Show();
            dataProperties.Refresh();
            Show();
        }

      
      
    }
}