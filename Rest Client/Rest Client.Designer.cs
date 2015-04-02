namespace Rest_Client
{
    partial class RestClient
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
            this.CallRest = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonInput = new System.Windows.Forms.Button();
            this.buttonOutput = new System.Windows.Forms.Button();
            this.responseText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioPostalToXY = new System.Windows.Forms.RadioButton();
            this.radioXYToPostal = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // CallRest
            // 
            this.CallRest.Location = new System.Drawing.Point(473, 121);
            this.CallRest.Name = "CallRest";
            this.CallRest.Size = new System.Drawing.Size(75, 23);
            this.CallRest.TabIndex = 0;
            this.CallRest.Text = "Run";
            this.CallRest.UseVisualStyleBackColor = true;
            this.CallRest.Click += new System.EventHandler(this.CallRest_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 311);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(536, 23);
            this.progressBar.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FilterIndex = 2;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FilterIndex = 2;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 17);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(455, 20);
            this.textBoxInput.TabIndex = 4;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(12, 54);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(455, 20);
            this.textBoxOutput.TabIndex = 5;
            // 
            // buttonInput
            // 
            this.buttonInput.Location = new System.Drawing.Point(473, 15);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(75, 23);
            this.buttonInput.TabIndex = 6;
            this.buttonInput.Text = "Input File";
            this.buttonInput.UseVisualStyleBackColor = true;
            this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            // 
            // buttonOutput
            // 
            this.buttonOutput.Location = new System.Drawing.Point(473, 51);
            this.buttonOutput.Name = "buttonOutput";
            this.buttonOutput.Size = new System.Drawing.Size(75, 23);
            this.buttonOutput.TabIndex = 7;
            this.buttonOutput.Text = "Output File";
            this.buttonOutput.UseVisualStyleBackColor = true;
            this.buttonOutput.Click += new System.EventHandler(this.buttonOutput_Click);
            // 
            // responseText
            // 
            this.responseText.Location = new System.Drawing.Point(12, 215);
            this.responseText.Multiline = true;
            this.responseText.Name = "responseText";
            this.responseText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.responseText.Size = new System.Drawing.Size(536, 90);
            this.responseText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(19, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "*Input file must have a column of Singapore postal codes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(563, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 317);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "1) Click Input File Button and select the input file\r\n\r\n2) Click Output File Butt" +
    "on and select the output file\r\n\r\n4) Click Run and wait for the result to be proc" +
    "essed\r\n\r\n\r\n";
            // 
            // radioPostalToXY
            // 
            this.radioPostalToXY.AutoSize = true;
            this.radioPostalToXY.Checked = true;
            this.radioPostalToXY.Location = new System.Drawing.Point(12, 86);
            this.radioPostalToXY.Name = "radioPostalToXY";
            this.radioPostalToXY.Size = new System.Drawing.Size(83, 17);
            this.radioPostalToXY.TabIndex = 10;
            this.radioPostalToXY.TabStop = true;
            this.radioPostalToXY.Text = "Postal -> XY";
            this.radioPostalToXY.UseVisualStyleBackColor = true;
            this.radioPostalToXY.CheckedChanged += new System.EventHandler(this.radioPostalToXY_CheckedChanged);
            // 
            // radioXYToPostal
            // 
            this.radioXYToPostal.AutoSize = true;
            this.radioXYToPostal.Location = new System.Drawing.Point(12, 121);
            this.radioXYToPostal.Name = "radioXYToPostal";
            this.radioXYToPostal.Size = new System.Drawing.Size(83, 17);
            this.radioXYToPostal.TabIndex = 11;
            this.radioXYToPostal.Text = "XY -> Postal";
            this.radioXYToPostal.UseVisualStyleBackColor = true;
            this.radioXYToPostal.CheckedChanged += new System.EventHandler(this.radioXYToPostal_CheckedChanged);
            // 
            // RestClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 339);
            this.Controls.Add(this.radioXYToPostal);
            this.Controls.Add(this.radioPostalToXY);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOutput);
            this.Controls.Add(this.buttonInput);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.responseText);
            this.Controls.Add(this.CallRest);
            this.Name = "RestClient";
            this.Text = "Batch Geocode From Onemap.sg API";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CallRest;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.Button buttonOutput;
        private System.Windows.Forms.TextBox responseText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioPostalToXY;
        private System.Windows.Forms.RadioButton radioXYToPostal;
    }
}

