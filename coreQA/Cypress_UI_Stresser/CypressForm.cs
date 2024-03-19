using RestSharp;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Cypress_UI_Stresser
{
    public partial class CypressForm : Form
    {
        int currentVU_load = 1;

        public CypressForm()
        {
            InitializeComponent();

            var files = Directory.EnumerateFiles(Directory.GetCurrentDirectory());

            foreach (var file in files)

                if (file.Contains("template") && !file.EndsWith("xlsx"))
                    CboTestCase.Items.Add(file.Replace(Directory.GetCurrentDirectory() + "\\", ""));

            CboTestCase.SelectedIndex = 0;
        }

        private void checkapi_button(object sender, EventArgs e)
        {
            #region - code - 
            if (CheckAPI())
            {
                MessageBox.Show("API OK!");
            }
            else
            {
                Process.Start("api/Master.exe");

                MessageBox.Show("Api nok!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }
        private void clearOutput_button(object sender, EventArgs e)
        {
            #region - code - 
            TxtOutput.Text = "";
            #endregion
        }

        private void go_Button(object sender, EventArgs e)
        {
            #region - code - 

            lblStats.Text = "1/" + TxtRampUp.Value;

            progressBar1.Value = 0;

            var step = Convert.ToInt32(100 / Convert.ToInt32((TxtRampUp.Value) / TxtInc.Value));

            currentVU_load = Convert.ToInt32(TxtInc.Value);

            if (!Setup())
            {
                MessageBox.Show("Go Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CleanupAPI();

            for (int i = 0; i < Convert.ToInt32(TxtRampUp.Value); i += Convert.ToInt32(TxtInc.Value))
            {
                lblStats.Text = currentVU_load + "/" + TxtRampUp.Value;
                System.Windows.Forms.Application.DoEvents();

                if (!Work())
                {
                    return;
                }

                if (!Report())
                {
                    MessageBox.Show("Report Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (progressBar1.Value + step > 100)
                    progressBar1.Value = 100;
                else
                    progressBar1.Value += step;

                Thread.Sleep(1000);
                System.Windows.Forms.Application.DoEvents();

                currentVU_load += Convert.ToInt32(TxtInc.Value);
            }

            // vus computed!
            progressBar1.Value = 100;
            Thread.Sleep(1000);
            System.Windows.Forms.Application.DoEvents();

            if (!ReportFinal())
            {
                MessageBox.Show("Report Final Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion
        }

        public void Trace(string msg)
        {
            #region - code - 
            TxtOutput.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") +
                " - " +
                msg + "\r\n" +
                TxtOutput.Text;

            #endregion
        }

        public bool Setup()
        {
            #region - code - 

            Trace("checking api...");

            if (!CheckAPI())
            {
                Trace("api nok - ");
                return false;
            }
            else
                Trace("api ok - ");

            Trace("checking cypress...");

            if (!CheckCypress())
            {
                return false;
            }
            else
                Trace("cypress ok - ");

            return true;

            #endregion
        }

        public bool CheckAPI()
        {
            #region - code - 

            RestClient client = new RestClient(txtApi.Text);
            RestRequest request = new RestRequest("/regStatus", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            //request.AddJsonBody(new { key1 = "value1", key2 = "value2" });

            IRestResponse response = client.Execute(request);

            return response.IsSuccessful;

            #endregion
        }

        public bool CleanupAPI()
        {
            #region - code - 

            RestClient client = new RestClient(txtApi.Text);
            RestRequest request = new RestRequest("/regCleanup", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            //request.AddJsonBody(new { key1 = "value1", key2 = "value2" });

            IRestResponse response = client.Execute(request);

            return response.IsSuccessful;

            #endregion
        }

        public bool CheckCypress()
        {
            #region - code - 

            var file = "cypress.config.js";
            var ret = File.Exists(file);

            if (!ret)
            {
                Trace("File: " + file + " is missing");
                return false;
            }

            file = "cypress.config.safe.js";
            ret = File.Exists(file);

            if (!ret)
            {
                Trace("File: " + file + " is missing");
                return false;
            }

            file = "template.test.js";
            ret = File.Exists(file);

            if (!ret)
            {
                Trace("File: " + file + " is missing");
                return false;
            }

            file = "package.safe.json";
            ret = File.Exists(file);

            if (!ret)
            {
                Trace("File: " + file + " is missing");
                return false;
            }

            return true;

            #endregion
        }

        public bool Work()
        {
            #region - code - 

            Trace(" set " + currentVU_load + " running... ");

            var threads = currentVU_load;

            if (ChkMeasure.Checked)
                threads = 1;

            Trace(" #1 prepare cypress.config.js");

            var st_file_content = File.ReadAllText("cypress.config.safe.js");

            var st_replace = "";

            for (int i = 0; i < threads; i++)
            {
                st_replace += "'cypress/tests/orcamento/" + threads + "/template" + i + ".test.js',\r\n";
            }

            st_file_content =
                st_file_content.
                    Replace("//'cypress/tests/orcamento/1/template*.test.js',",
                    st_replace);

            File.WriteAllText("cypress.config.js", st_file_content);

            Trace(" #2 directory setup");

            string currentDirectory = Environment.CurrentDirectory + "\\cypress";

            Trace(" > " + currentDirectory);

            if (!Directory.Exists(currentDirectory))
            {
                Trace("Dir missing: " + currentDirectory);
                return false;
            }

            currentDirectory += "\\tests";

            if (!Directory.Exists(currentDirectory))
            {
                Trace("Dir missing: " + currentDirectory);
                return false;
            }

            currentDirectory += "\\orcamento";

            if (!Directory.Exists(currentDirectory))
            {
                Trace("Dir missing: " + currentDirectory);
                return false;
            }

            currentDirectory += "\\" + currentVU_load;

            if (!Directory.Exists(currentDirectory))
            {
                Directory.CreateDirectory(currentDirectory);
            }

            var st_template_file_content = File.ReadAllText(CboTestCase.SelectedItem.ToString());


            for (int i = 0; i < threads; i++)
            {
                var st_filename = currentDirectory + "/template" + i + ".test.js";

                if (File.Exists(st_filename))
                {
                    File.Delete(st_filename);
                }

                File.WriteAllText(st_filename, st_template_file_content);
            }

            Trace(" #3 prepare package.json");

            var st_template_json_content = File.ReadAllText("package.safe.json");

            var st_json_cmd_replace =
                "cypress-parallel -s cy:run -t " + threads +
                " -d cypress/tests/orcamento/" + threads + " > result.txt";

            st_template_json_content = st_template_json_content.Replace("*", st_json_cmd_replace);

            File.Delete("package.json");
            File.WriteAllText("package.json", st_template_json_content);

            Trace(" #4 run parallel");

            // Create a new process instance
            Process process = new Process();

            Trace("Run process...");
            System.Windows.Forms.Application.DoEvents();

            try
            {
                // Set the start information for the process
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";                    // Specify the command prompt executable
                startInfo.Arguments = "/C npm run cy_parallel"; // Specify the command to run
                startInfo.WorkingDirectory = Environment.CurrentDirectory;

                // Assign the start information to the process
                process.StartInfo = startInfo;

                // Start the process
                process.Start();
                process.WaitForExit();
                process.Close();

                Trace("Proc Ended ");
                System.Windows.Forms.Application.DoEvents();

                /*
                if (File.ReadAllText("result.txt").Contains("Failing:      1"))
                {
                    MessageBox.Show("Test Failed!");
                    return false;
                }
                */

                return true;

            }
            catch (Exception ex)
            {
                Trace("FAIL " + ex.Message);
                System.Windows.Forms.Application.DoEvents();

                process.Close();
                return false;
            }

            #endregion
        }

        public bool Report()
        {
            #region - code - 

            RestClient client = new RestClient(txtApi.Text);
            RestRequest request = new RestRequest("/regReport", Method.POST);

            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            return response.IsSuccessful;

            #endregion
        }

        public bool ReportFinal()
        {
            #region - code - 

            RestClient client = new RestClient(txtApi.Text);
            RestRequest request = new RestRequest("/regReportFinal", Method.POST);

            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                return false;

            string responseBody = response.Content;
            string _jsonFile = "final.json";

            if (File.Exists(_jsonFile))
            {
                File.Delete(_jsonFile);
            }

            File.WriteAllText(_jsonFile, responseBody);

            MessageBox.Show("Test Complete!");

            return true;
        }

        public void Excel()
        {
            var finalReport = JsonConvert.DeserializeObject<DtoRegTimeReportFinal>(File.ReadAllText("final.json"));

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
                    Microsoft.Office.Interop.Excel.Range chartRange = worksheet.Range["C" + index_row_start + ":C" + (index_row_start + finalReport.reports.Count() - 1)];

                    Microsoft.Office.Interop.Excel.SeriesCollection seriesCollection = (Microsoft.Office.Interop.Excel.SeriesCollection)chart.SeriesCollection();
                    Microsoft.Office.Interop.Excel.Series series = seriesCollection.NewSeries();
                    series.Name = item;
                    series.Values = chartRange;

                    index_row_start += finalReport.reports.Count();
                }

                chart.HasTitle = true;
                chart.ChartTitle.Text = item;
            }

            string fileName = Directory.GetCurrentDirectory() + "\\" + CboTestCase.SelectedItem.ToString() + "_results.xlsx";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // Save the workbook
            workbook.SaveAs(fileName);

            // Close the workbook and Excel
            workbook.Close();
            excelApp.Quit();

            #endregion
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Excel();
            MessageBox.Show("Excel file generated!");
        }
    }

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
}
