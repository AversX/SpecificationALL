using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Data.Common;
using System.Data.SqlClient;

namespace SpecificationPack
{
    public partial class MainForm : Form
    {
        private List<Unit> Units;
        private Excel.Application excel;
        private Excel.Window excelWindow;

        struct Unit
        {
            public string Pos;
            public string Code;
            public string Name;
            public string Manufacture;
            public double Num;
            public string Measure;
        }


        public MainForm()
        {
            InitializeComponent();
        }

        private void formBtn_Click(object sender, EventArgs e)
        {
            Units = new List<Unit>();
            if (specAndrTBox.Text != "" && colNameTBox.Text != "")
                Units.AddRange(LoadSpecAndr(specAndrTBox.Text, colNameTBox.Text));
            if (specAlexTBox.Text!="")
                Units.AddRange(loadSpecAlex(specAlexTBox.Text));
            if (specAlexAvrTBox.Text != "")
                Units.AddRange(LoadSpecAlexAvr(specAlexAvrTBox.Text));
            if (specVladTBox.Text != "")
                Units.AddRange(LoadSpecVlad(specVladTBox.Text));
            Units = consolidate(Units);
            uploadData();
        }

        private List<Unit> consolidate(List<Unit> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                for (int j = i + 1; j < units.Count; j++)
                    if (unit.Code == units[j].Code)
                    {
                        if (unit.Name == units[j].Name)
                        {
                            if (unit.Measure.ToUpper().Replace(".", "") == units[j].Measure.ToUpper().Replace(".", ""))
                            {
                                if (unit.Pos != "")
                                {
                                    if (units[j].Pos != "")
                                        unit.Pos += ", " + units[j].Pos;
                                }
                                else
                                {
                                    if (units[j].Pos != "")
                                        unit.Pos += units[j].Pos;
                                }
                                unit.Num += units[j].Num;
                                units.RemoveAt(j);
                                j--;
                                units[i] = unit;
                            }
                        }
                    }
            }
            return units;
        }

        private List<Unit> loadSpecAlex(string path)
        {
            List<Unit> units = new List<Unit>();
            DataSet dataSet = new DataSet("EXCEL");
            string connectionString;
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;IMEX=0;HDR=NO'";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            System.Data.DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];

            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            OleDbDataAdapter adapter = new OleDbDataAdapter(select, connection);
            adapter.Fill(dataSet);
            connection.Close();

            for (int row = 0; row < dataSet.Tables[0].Rows.Count; row++)
            {
                if (dataSet.Tables[0].Rows[row][2].ToString().Length > 0)
                {
                    Unit unit = new Unit();
                    unit.Measure = "шт";
                    unit.Pos = dataSet.Tables[0].Rows[row][0].ToString().Trim();
                    unit.Code = dataSet.Tables[0].Rows[row][1].ToString().Trim();
                    unit.Name = dataSet.Tables[0].Rows[row][2].ToString().Trim();
                    unit.Manufacture = dataSet.Tables[0].Rows[row][3].ToString().Trim();
                    unit.Num = double.Parse(dataSet.Tables[0].Rows[row][6].ToString().Trim());
                    if ((unit.Manufacture.ToUpper() == "Helukabel" || unit.Manufacture=="HELUKABEL") && SpecAlexHelukabel.Checked) { unit.Num = unit.Num * int.Parse(SpecAlexHelukabelTxt.Text); unit.Measure = "м"; }
                    units.Add(unit);
                }
            }
            return units;
        }

        private List<Unit> LoadSpecAlexAvr(string path)
        {
            List<Unit> units = new List<Unit>();
            DataSet dataSet = new DataSet("EXCEL");
            string connectionString;
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;IMEX=0;'";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            System.Data.DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];

            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            OleDbDataAdapter adapter = new OleDbDataAdapter(select, connection);
            adapter.Fill(dataSet);
            connection.Close();

            for (int row = 2; row < dataSet.Tables[0].Rows.Count; row++)
            {
                if (dataSet.Tables[0].Rows[row][2].ToString().Length > 0 && dataSet.Tables[0].Rows[row][1].ToString().Length > 0)
                {
                    Unit unit = new Unit();
                    if (dataSet.Tables[0].Rows[row][0].ToString() == "")
                        unit.Pos = units[units.Count-1].Pos;
                    else
                        unit.Pos = dataSet.Tables[0].Rows[row][0].ToString().Trim();
                    unit.Code = dataSet.Tables[0].Rows[row][1].ToString().Trim();
                    unit.Name = dataSet.Tables[0].Rows[row][2].ToString().Trim();
                    unit.Manufacture = dataSet.Tables[0].Rows[row][3].ToString().Trim();
                    if (dataSet.Tables[0].Rows[row][4].ToString() != "")
                        if (dataSet.Tables[0].Rows[row][4].ToString().Contains("ком"))
                        {
                            string numS = "";
                            for (int i = 0; i < dataSet.Tables[0].Rows[row][4].ToString().Length; i++)
                            {
                                if (Char.IsDigit(dataSet.Tables[0].Rows[row][4].ToString()[i]))
                                    numS += dataSet.Tables[0].Rows[row][4].ToString()[i];
                            }
                            unit.Num = double.Parse(numS);
                            unit.Measure = "к";
                        }
                        else { unit.Num = double.Parse(dataSet.Tables[0].Rows[row][4].ToString().Trim()); unit.Measure = "шт"; }
                    else unit.Num = 0;
                    if ((unit.Manufacture.ToUpper() == "Helukabel" || unit.Manufacture == "HELUKABEL") && SpecAlexAvrHelukabel.Checked) { unit.Num = unit.Num * int.Parse(SpecAlexAvrHelukabelTxt.Text); unit.Measure = "м"; }
                    units.Add(unit);
                }
            }
            return units;
        }

        private List<Unit> LoadSpecAndr(string path, string colName)
        {
            List<Unit> units = new List<Unit>();
            DataSet dataSet = new DataSet("EXCEL");
            string connectionString;
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;IMEX=0;'";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            System.Data.DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];

            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            OleDbDataAdapter adapter = new OleDbDataAdapter(select, connection);
            adapter.Fill(dataSet);
            connection.Close();

            for (int row = 1; row < dataSet.Tables[0].Rows.Count; row++)
            {
                if (dataSet.Tables[0].Rows[row][2].ToString().Length > 0)
                {
                    Unit unit = new Unit();
                    unit.Pos = "";
                    unit.Code = dataSet.Tables[0].Rows[row][1].ToString().Trim();
                    if (unit.Code == "3044102")
                    {

                    }
                    unit.Name = dataSet.Tables[0].Rows[row][2].ToString().Trim();
                    unit.Manufacture = dataSet.Tables[0].Rows[row][3].ToString().Trim();
                    unit.Measure = dataSet.Tables[0].Rows[row][4].ToString().Trim();
                    int colNum = ExcelColumnNameToNumber(colName) - 1;
                    unit.Num = double.Parse(dataSet.Tables[0].Rows[row][colNum].ToString().Trim());
                    if ((unit.Manufacture.ToUpper() == "Helukabel" || unit.Manufacture == "HELUKABEL") && SpecAndrHelukabel.Checked) unit.Num = unit.Num * int.Parse(SpecAndrHelukabelTxt.Text);
                    if (unit.Num!=0)
                        units.Add(unit);
                }
            }
            return units;
        }

        private List<Unit> LoadSpecVlad(string path)
        {
            List<Unit> units = new List<Unit>();
            DataSet dataSet = new DataSet("EXCEL");
            string connectionString;
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=NO;'";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            System.Data.DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            OleDbDataAdapter adapter = new OleDbDataAdapter(select, connection);
            adapter.Fill(dataSet);
            connection.Close();

            for (int row = 0; row < dataSet.Tables[0].Rows.Count; row++)
            {
                if (dataSet.Tables[0].Rows[row][3].ToString().Length > 0)
                {
                    Unit unit = new Unit();
                    unit.Pos = dataSet.Tables[0].Rows[row][2].ToString().Trim();
                    unit.Code = dataSet.Tables[0].Rows[row][3].ToString().Trim();
                    unit.Name = dataSet.Tables[0].Rows[row][4].ToString().Trim();
                    unit.Manufacture = dataSet.Tables[0].Rows[row][7].ToString().Trim();
                    unit.Measure = dataSet.Tables[0].Rows[row][6].ToString().Trim();
                    double d = double.Parse(dataSet.Tables[0].Rows[row][5].ToString().Trim());
                    if ((unit.Manufacture.ToUpper() == "Helukabel" || unit.Manufacture == "HELUKABEL") && SpecVladHelukabel.Checked) d = d * int.Parse(SpecVladHelukabelTxt.Text); ;
                    if (unit.Code.ToUpper() == "1SDA066676R1" || unit.Manufacture == "1SDA066676R1") unit.Measure = "к";
                    unit.Num = d;
                    units.Add(unit);
                }
            }
            return units;
        }

        private void uploadData()
        {
            excel = new Excel.Application();
            excel.SheetsInNewWorkbook = 1;
            excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet sheet = (Excel.Worksheet)excel.Sheets.get_Item(1);
            //sheet.Cells[1, 1] = "Поз";
            //sheet.Columns[1].NumberFormat = "#";
            //sheet.Cells[1, 2] = "Обознач.";
            sheet.Columns[2].NumberFormat = "@";
            //sheet.Cells[1, 3] = "Артикул";
            sheet.Columns[3].NumberFormat = "@";
            //sheet.Cells[1, 4] = "Наименование";
            sheet.Columns[4].NumberFormat = "@";
            //sheet.Cells[1, 5] = "Кол.";
            //sheet.Columns[5].NumberFormat = "#";
            //sheet.Cells[1, 6] = "Ед. изм";
            sheet.Columns[6].NumberFormat = "@";
            //sheet.Cells[1, 7] = "Примечание";
            sheet.Columns[7].NumberFormat = "@";
            for (int i = 0; i < Units.Count; i++)
            {
                sheet.Cells[i + 1, 1] = i+1;
                sheet.Cells[i + 1, 2] = Units[i].Pos;
                sheet.Cells[i + 1, 3] = Units[i].Code;
                sheet.Cells[i + 1, 4] = Units[i].Name;
                sheet.Cells[i + 1, 5] = Units[i].Num;
                sheet.Cells[i + 1, 6] = Units[i].Measure;
                sheet.Cells[i + 1, 7] = Units[i].Manufacture;
            }
            excel.Visible = true;
        }
        public static int ExcelColumnNameToNumber(string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");

            columnName = columnName.ToUpperInvariant();

            int sum = 0;

            for (int i = 0; i < columnName.Length; i++)
            {
                sum *= 26;
                sum += (columnName[i] - 'A' + 1);
            }

            return sum;
        }

        private void specAlexTBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
                e.Effect = DragDropEffects.Move;
        }

        private void specAlexAvrTBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
                e.Effect = DragDropEffects.Move;
        }

        private void specAndrTBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
                e.Effect = DragDropEffects.Move;
        }

        private void specVladTBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
                e.Effect = DragDropEffects.Move;
        }

        private void clrBtn_Click(object sender, EventArgs e)
        {
            specAlexAvrTBox.Text = "";
            specAlexTBox.Text = "";
            specAndrTBox.Text = "";
            specVladTBox.Text = "";
        }

        private void specAlexTBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                specAlexTBox.Text = objects[0];
            }
        }

        private void specAlexAvrTBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                specAlexAvrTBox.Text = objects[0];
            }
        }

        private void specAndrTBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                specAndrTBox.Text = objects[0];
            }
        }

        private void specVladTBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                specVladTBox.Text = objects[0];
            }
        }

        private void addSpec1Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.xlsx); (*.xls)|*.xlsx; *.xls";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                specAlexTBox.Text = ofd.FileName;
            }
        }

        private void addSpec2Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.xlsx); (*.xls)|*.xlsx; *.xls";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                specAlexAvrTBox.Text = ofd.FileName;
            }
        }

        private void addSpec3Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.xlsx); (*.xls)|*.xlsx; *.xls";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                specAndrTBox.Text = ofd.FileName;
            }
        }

        private void addSpec4Btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.xlsx); (*.xls)|*.xlsx; *.xls";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                specVladTBox.Text = ofd.FileName;
            }
        }

        private void SpecAlexHelukabelTxt_TextChanged(object sender, EventArgs e)
        {
            //this.
        }
    }

    class NaturalStringComparer : IComparer<String>
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        static extern int StrCmpLogicalW(string s1, string s2);
        public int Compare(string x, string y)
        {
            return StrCmpLogicalW(x, y);
        }
    }
}
