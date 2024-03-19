namespace Cypress_UI_Stresser
{
    partial class CypressForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtApi = new TextBox();
            label2 = new Label();
            TxtRampUp = new NumericUpDown();
            label3 = new Label();
            TxtInc = new NumericUpDown();
            button1 = new Button();
            label4 = new Label();
            TxtOutput = new TextBox();
            lblStats = new Label();
            progressBar1 = new ProgressBar();
            button2 = new Button();
            button3 = new Button();
            label8 = new Label();
            CboTestCase = new ComboBox();
            ChkMeasure = new CheckBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)TxtRampUp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TxtInc).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 29);
            label1.Name = "label1";
            label1.Size = new Size(25, 15);
            label1.TabIndex = 0;
            label1.Text = "API";
            // 
            // txtApi
            // 
            txtApi.Location = new Point(108, 28);
            txtApi.Name = "txtApi";
            txtApi.Size = new Size(454, 23);
            txtApi.TabIndex = 1;
            txtApi.Text = "http://127.0.0.1:5000/api/";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 114);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 2;
            label2.Text = "Ramp Up";
            // 
            // TxtRampUp
            // 
            TxtRampUp.Location = new Point(108, 112);
            TxtRampUp.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            TxtRampUp.Name = "TxtRampUp";
            TxtRampUp.Size = new Size(77, 23);
            TxtRampUp.TabIndex = 3;
            TxtRampUp.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(218, 114);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 4;
            label3.Text = "Increment";
            // 
            // TxtInc
            // 
            TxtInc.Location = new Point(285, 112);
            TxtInc.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            TxtInc.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            TxtInc.Name = "TxtInc";
            TxtInc.Size = new Size(40, 23);
            TxtInc.TabIndex = 5;
            TxtInc.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button1
            // 
            button1.BackColor = Color.LawnGreen;
            button1.Location = new Point(576, 67);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "GO!";
            button1.UseVisualStyleBackColor = false;
            button1.Click += go_Button;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 196);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 7;
            label4.Text = "Output";
            // 
            // TxtOutput
            // 
            TxtOutput.Location = new Point(108, 196);
            TxtOutput.Multiline = true;
            TxtOutput.Name = "TxtOutput";
            TxtOutput.ScrollBars = ScrollBars.Vertical;
            TxtOutput.Size = new Size(543, 180);
            TxtOutput.TabIndex = 8;
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.Location = new Point(36, 155);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(39, 15);
            lblStats.TabIndex = 9;
            lblStats.Text = "Status";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(108, 152);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(543, 23);
            progressBar1.TabIndex = 10;
            // 
            // button2
            // 
            button2.Location = new Point(576, 29);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 13;
            button2.Text = "Check";
            button2.UseVisualStyleBackColor = true;
            button2.Click += checkapi_button;
            // 
            // button3
            // 
            button3.Location = new Point(36, 223);
            button3.Name = "button3";
            button3.Size = new Size(54, 23);
            button3.TabIndex = 14;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = true;
            button3.Click += clearOutput_button;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 75);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 17;
            label8.Text = "Test Case";
            // 
            // CboTestCase
            // 
            CboTestCase.FormattingEnabled = true;
            CboTestCase.Location = new Point(108, 72);
            CboTestCase.Name = "CboTestCase";
            CboTestCase.Size = new Size(454, 23);
            CboTestCase.TabIndex = 18;
            // 
            // ChkMeasure
            // 
            ChkMeasure.AutoSize = true;
            ChkMeasure.Checked = true;
            ChkMeasure.CheckState = CheckState.Checked;
            ChkMeasure.Location = new Point(388, 116);
            ChkMeasure.Name = "ChkMeasure";
            ChkMeasure.Size = new Size(99, 19);
            ChkMeasure.TabIndex = 19;
            ChkMeasure.Text = "Measurement";
            ChkMeasure.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.BackColor = Color.LightGoldenrodYellow;
            button4.Location = new Point(576, 106);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 20;
            button4.Text = "Excel";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 396);
            Controls.Add(button4);
            Controls.Add(ChkMeasure);
            Controls.Add(CboTestCase);
            Controls.Add(label8);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(progressBar1);
            Controls.Add(lblStats);
            Controls.Add(TxtOutput);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(TxtInc);
            Controls.Add(label3);
            Controls.Add(TxtRampUp);
            Controls.Add(label2);
            Controls.Add(txtApi);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Cypress UI Stress Tool";
            ((System.ComponentModel.ISupportInitialize)TxtRampUp).EndInit();
            ((System.ComponentModel.ISupportInitialize)TxtInc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtApi;
        private Label label2;
        private NumericUpDown TxtRampUp;
        private Label label3;
        private NumericUpDown TxtInc;
        private Button button1;
        private Label label4;
        private TextBox TxtOutput;
        private Label lblStats;
        private ProgressBar progressBar1;
        private Button button2;
        private Button button3;
        private Label label8;
        private ComboBox CboTestCase;
        private CheckBox ChkMeasure;
        private Button button4;
    }
}