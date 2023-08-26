using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace MQ4_PC
{
    public class Export
    {
        public void Save_txt(DataGridView dgv)
        {
            Export_txt(dgv);
        }

        public void Save_Excel(DataGridView dgv)
        {
            Export_excel(dgv);
        }

        private void Export_excel(DataGridView dgv)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = null;
            object misValue = System.Reflection.Missing.Value;

            try
            {
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!");
                    return;
                }

                xlApp.Visible = false;
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Methane Data";
                for (int i = 1; i < dgv.Columns.Count + 1; i++)
                {
                    worksheet.Cells[i, 1] = dgv.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = "";
                        }
                    }
                }
                
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Excel file created");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                workbook.Close();
                xlApp.Quit();
                workbook = null;
                worksheet = null;
            }
        }

        private void Export_txt(DataGridView data)
        {
            try
            {
                SaveFileDialog filedialog = new SaveFileDialog();
                filedialog.Filter = "Text File | .txt";
                if (filedialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(filedialog.FileName);
                    writer.WriteLine("ms\tCH4 %");
                    foreach (DataGridViewRow row in data.Rows)
                    {
                        writer.WriteLine(string.Format("{0}\t{1}", row.Cells[0].Value, row.Cells[1].Value));
                    }
                    writer.Dispose();
                    writer.Close();
                    MessageBox.Show("Notepad file created");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Export TXT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void Save_Calibration(double ro)
        {
            try
            {
                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                using (var file = new StreamWriter(string.Format(@"{0}\calibration.txt", desktop)))
                {
                    file.WriteLine(string.Format("{0}", ro));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Calibration Save File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Read_Calibration()
        {
            String line;
            try
            {
                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                String filename = string.Format(@"{0}\calibration.txt", desktop);
                if (File.Exists(filename))
                {
                    var file = new StreamReader(filename);
                    line = file.ReadToEnd();
                    Config.Ro_calibration = Convert.ToDouble(line);
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Read Calibration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
