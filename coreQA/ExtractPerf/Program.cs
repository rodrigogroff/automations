using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Excel;

namespace ExtractPerf
{
    public class Node
    {
        public string vus { get; set; }
        public string req_per_second { get; set; }
        public string pct { get; set; }

        public string fails { get; set; }
    }

    public class NodeJson
    {
        public string iteration { get; set; }

        public string position { get; set; }

        public string iteration_duration { get; set; }

        public string fail { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var st_input = File.ReadAllText("results.txt");

            var lstNodes = new List<Node>();

            Node currentNode = null;

            foreach (var text in st_input.Split('\n')) 
            {
                if (text.Trim().StartsWith("checks"))
                {
                    #region - code - 

                    currentNode = new Node { };
                    lstNodes.Add(currentNode);

                    var opt = text.Trim().Split(' ');

                    foreach (var item in opt)
                    {
                        if (item.EndsWith("%"))
                        {
                            var target = Convert.ToDouble(item.Replace("%", ""), CultureInfo.InvariantCulture);

                            currentNode.pct = target.ToString("0");
                        }
                    }

                    #endregion
                }

                if (text.Trim().StartsWith("iterations"))
                {
                    #region - code - 

                    var opt = text.Trim().Split(' ');

                    foreach (var item in opt)
                    {
                        if (item.EndsWith("/s"))
                        {
                            var target = Convert.ToDouble(item.Replace("/s", ""), CultureInfo.InvariantCulture);

                            currentNode.req_per_second = target.ToString("0.00");
                        }
                    }

                    #endregion
                }

                if (text.Trim().StartsWith("vus_max"))
                {
                    #region - code - 

                    var opt = text.Trim().Split(' ');

                    foreach (var item in opt)
                    {
                        if (item.StartsWith("max="))
                        {
                            currentNode.vus = item.Replace("max=","");
                        }
                    }

                    #endregion
                }
            }

            var lstNodesJson = new List<NodeJson>();

            int it = 1, posIndex = 1;
            int firstValue = 0,
                magicNumber = 0;

            while (true)
            {
                string fileName = "test_results" + it + ".json";

                if (!File.Exists(fileName))
                    break;

                posIndex = 1;

                var st_json = File.ReadAllText(fileName);

                bool check = true;

                foreach (var text in st_json.Split('\n'))
                {
                    if (text.Contains("\"value\":0,\"tags\":{\"check\""))
                        check = false;

                    if (text.Contains("{\"metric\":\"iteration_duration\""))
                    {
                        posIndex++;

                        if (it == 1)
                        {
                            magicNumber++;
                        }

                        //if (check)
                        {
                            var numericString = text.Replace(",\"value\":", "¨").Split('¨')[1].Split('.')[0];
                            int numericValue = int.Parse(numericString);

                            if (firstValue == 0)
                                firstValue =  numericValue;
                            else
                            {
                                if (numericValue < firstValue / 3)
                                {
                                    numericValue = 0;
                                }
                                else if (numericValue > firstValue * 5)
                                {
                                    numericValue = 0;
                                }
                            }

                            lstNodesJson.Add(
                                new NodeJson
                                {
                                    iteration = it.ToString(),
                                    position =( posIndex - 1).ToString(),
                                    iteration_duration = numericValue > 0 ? numericValue.ToString("N0") : "",
                                    fail = check == false ? "1" : "0"                                    
                                });
                        }

                        check = true;
                    }
                }

                it++;
            }            

            Application excelApp = new Application();
            Workbook workbook = excelApp.Workbooks.Add();
            Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

            int indexer = 1;
            int row = 1;

            foreach (var item in "VUS MAX;CHECKS;FAIL;".Split(';'))
                worksheet.Cells[row, indexer++] = item;

            row++;
            
            foreach (var item in lstNodes)
            {
                worksheet.Cells[row, 1] = item.vus;
                worksheet.Cells[row, 2] = item.pct;
                worksheet.Cells[row, 3] = lstNodesJson.Where ( y=> y.iteration == item.vus && y.fail == "1").Count();
                row++;
            }

            row++;

            indexer = 1;

            foreach (var item in "ITERATION;POSITION;TIME;FAIL;".Split(';'))
                worksheet.Cells[row, indexer++] = item;

            row++;

            foreach (var item in lstNodesJson)
            {
                worksheet.Cells[row, 1] = item.iteration;
                worksheet.Cells[row, 2] = item.position;
                worksheet.Cells[row, 3] = item.iteration_duration;
                worksheet.Cells[row, 4] = item.fail;
                row++;
            }

            // performance
            {
                ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects(Type.Missing);
                ChartObject chartObject = chartObjects.Add(250, 50, 900, 600);
                Chart chart = chartObject.Chart;
                chart.ChartType = XlChartType.xlLine;

                int rIndex = 9;

                foreach (var item in lstNodesJson.Select(y => y.iteration).Distinct())
                {
                    Range chartRange = worksheet.Range["C" + rIndex + ":C" + (rIndex + magicNumber - 1).ToString()];
                    Series series = chart.SeriesCollection().NewSeries();

                    series.Name = "VU " + item;
                    series.Values = chartRange;
                    rIndex += magicNumber;
                }

                chart.HasTitle = true;
                chart.ChartTitle.Text = "Performance";
            }


            // failures
            {
                ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects(Type.Missing);
                ChartObject chartObject = chartObjects.Add(250, 700, 300, 300);
                Chart chart = chartObject.Chart;
                chart.ChartType = XlChartType.xlLine;
                int max = lstNodesJson.Select(y => y.iteration).Distinct().Count();

                Range chartRange = worksheet.Range["C2:C" + (max + 2).ToString()];
                Series series = chart.SeriesCollection().NewSeries();
                series.Values = chartRange;

                chart.HasTitle = true;
                chart.ChartTitle.Text = "Failures";
            }


            // CHECKS
            {
                ChartObjects chartObjects = (ChartObjects)worksheet.ChartObjects(Type.Missing);
                ChartObject chartObject = chartObjects.Add(600, 700, 300, 300);
                Chart chart = chartObject.Chart;
                chart.ChartType = XlChartType.xlLine;
                int max = lstNodesJson.Select(y => y.iteration).Distinct().Count();
                
                Range chartRange = worksheet.Range["B2:B" + (max + 2).ToString()];
                Series series = chart.SeriesCollection().NewSeries();
                series.Values = chartRange;

                chart.HasTitle = true;
                chart.ChartTitle.Text = "Checks";
            }

            // Save the workbook
            workbook.SaveAs(Directory.GetCurrentDirectory() + "\\results.xlsx");

            // Close the workbook and Excel
            workbook.Close();
            excelApp.Quit();
        }
    }
}
