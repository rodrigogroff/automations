using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace ExtractPerf2
{
    #region - data - 

    public class DtoRegTime
    {
        public string id { get; set; }

        public string label { get; set; }
    }

    public class DtoRegTimeInfo
    {
        public string id { get; set; }

        public string label { get; set; }

        public int milis { get; set; }

        public DateTime dtStart { get; set; }

        public DateTime dtEnd { get; set; }
    }

    public class DtoRegTimeInfoStat
    {
        public string label { get; set; }

        public double avg { get; set; }

        public int min { get; set; }

        public int max { get; set; }
    }

    public class DtoRegTimeReport
    {
        public List<DtoRegTimeInfo> data { get; set; }

        public int VUs { get; set; }

        public List<string> ids { get; set; }

        public List<string> labels { get; set; }

        public List<DtoRegTimeInfoStat> stats { get; set; }
    }

    public class DtoRegTimeReportFinal
    {
        public List<int> VUs { get; set; }

        public List<DtoRegTimeReport> reports { get; set; }
    }

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            var st_input = File.ReadAllText("results.json");
            var finalReport = JsonConvert.DeserializeObject<DtoRegTimeReportFinal>(st_input);

            Application excelApp = new Application();
            Workbook workbook = excelApp.Workbooks.Add();
            Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

            var stages = finalReport.reports[0].labels;

            int indexer = 1;
            int row = 1;

            foreach (var item in "VU;ID;Stage;Milis;Start;Finish;".Split(';'))
                worksheet.Cells[row, indexer++] = item;

            row++;

            foreach (var rep in finalReport.reports)
            {
                foreach (var r in rep.data)
                {
                    worksheet.Cells[row, 1] = rep.VUs;
                    worksheet.Cells[row, 2] = r.id;
                    worksheet.Cells[row, 3] = r.label;
                    worksheet.Cells[row, 4] = r.milis;
                    worksheet.Cells[row, 5] = r.dtStart.ToString("dd/MM/yyyy HH:mm:ss:fff");
                    worksheet.Cells[row, 6] = r.dtEnd.ToString("dd/MM/yyyy HH:mm:ss:fff");

                    row++;
                }                
            }

            row++;

            indexer = 1;

            foreach (var item in "VU;Stage;Avg;Min;Max".Split(';'))
                worksheet.Cells[row, indexer++] = item;

            row++;
            
            int index_row_start = row;
                        
            foreach (var stage in stages)
            {
                Console.WriteLine(stage);

                int i = 1;

                foreach (var rep in finalReport.reports)
                {
                    foreach (var r in rep.stats)
                    {
                        if (r.label == stage)
                        {
                            Console.WriteLine(stage + " " + i + " > " + r.avg);

                            worksheet.Cells[row, 1] = i++;
                            worksheet.Cells[row, 2] = r.label;
                            worksheet.Cells[row, 3] = r.avg;
                            worksheet.Cells[row, 4] = r.min;
                            worksheet.Cells[row, 5] = r.max;
                            row++;
                        }
                    }
                }
            }

            int pos_v = 0;

            foreach (var item in stages)
            {
                Microsoft.Office.Interop.Excel.ChartObjects chartObjects = (Microsoft.Office.Interop.Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
                Microsoft.Office.Interop.Excel.ChartObject chartObject = chartObjects.Add(420, 30 + pos_v, 450, 300);
                Microsoft.Office.Interop.Excel.Chart chart = chartObject.Chart;
                chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLine;

                pos_v += 320;

                {
                    Microsoft.Office.Interop.Excel.Range chartRange = worksheet.Range["C" + index_row_start + ":C" + (index_row_start + 100)];

                    Microsoft.Office.Interop.Excel.SeriesCollection seriesCollection = (Microsoft.Office.Interop.Excel.SeriesCollection)chart.SeriesCollection();
                    Microsoft.Office.Interop.Excel.Series series = seriesCollection.NewSeries();
                    series.Name = item;
                    series.Values = chartRange;
                    

                    index_row_start += 100;
                }

                chart.HasTitle = true;
                chart.ChartTitle.Text = item;
            }
            
            string fileName = Directory.GetCurrentDirectory() + "\\final_results.xlsx";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);  
            }

            // Save the workbook
            workbook.SaveAs(fileName);

            // Close the workbook and Excel
            workbook.Close();
            excelApp.Quit();
        }
    }
}
