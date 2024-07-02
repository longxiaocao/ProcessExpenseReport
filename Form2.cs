using System;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ProcessExpenseReport
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFolderPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnProcessFiles_Click(object sender, EventArgs e)
        {
            string folderPath = txtFolderPath.Text;

            if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
            {
                MessageBox.Show("请选择有效的文件夹路径！");
                return;
            }

            string[] files = Directory.GetFiles(folderPath, "*.xlsx");
            progressBar1.Maximum = files.Length;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("ProcessedData");
                worksheet.Cells[1, 1].Value = "文件名";
                worksheet.Cells[1, 2].Value = "费用所属类别";
                worksheet.Cells[1, 3].Value = "项目名称";
                worksheet.Cells[1, 4].Value = "项目单价";
                worksheet.Cells[1, 5].Value = "项目数量";
                worksheet.Cells[1, 6].Value = "政策范围内金额";
                worksheet.Cells[1, 7].Value = "自费金额";
                worksheet.Cells[1, 8].Value = "报销比例";

                int rowIndex = 2;

                foreach (var file in files)
                {
                    ProcessFile(file, worksheet, ref rowIndex);
                    progressBar1.PerformStep();
                }

                string savePath = Path.Combine(folderPath, "ProcessedData.xlsx");
                package.SaveAs(new FileInfo(savePath));
                MessageBox.Show($"处理完成！文件已保存到: {savePath}");
            }
        }

        private void ProcessFile(string filePath, ExcelWorksheet worksheet, ref int rowIndex)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(stream);
                ISheet sheet = workbook.GetSheetAt(0);

                string category = string.Empty;

                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;

                    string cellValue = row.GetCell(0)?.ToString().Trim();

                    if (!string.IsNullOrEmpty(cellValue) && cellValue.StartsWith("【") && cellValue.EndsWith("】"))
                    {
                        category = cellValue.Trim('【', '】');
                    }
                    else if (!string.IsNullOrEmpty(cellValue))
                    {
                        worksheet.Cells[rowIndex, 1].Value = Path.GetFileName(filePath);
                        worksheet.Cells[rowIndex, 2].Value = category;
                        worksheet.Cells[rowIndex, 3].Value = row.GetCell(0)?.ToString();
                        worksheet.Cells[rowIndex, 4].Value = row.GetCell(2)?.ToString();
                        worksheet.Cells[rowIndex, 5].Value = row.GetCell(3)?.ToString();
                        worksheet.Cells[rowIndex, 6].Value = row.GetCell(5)?.ToString();
                        worksheet.Cells[rowIndex, 7].Value = row.GetCell(6)?.ToString();
                        worksheet.Cells[rowIndex, 8].Value = row.GetCell(7)?.ToString();
                        rowIndex++;
                    }
                }
            }
        }
    }
}
