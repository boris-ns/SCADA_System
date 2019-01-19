namespace TrendingComponent
{
    partial class TrendingForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartDigitalTags = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAnalogTags = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelDigitalTags = new System.Windows.Forms.Label();
            this.labelAnalogTags = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartDigitalTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnalogTags)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDigitalTags
            // 
            this.chartDigitalTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            chartArea1.Name = "ChartArea1";
            this.chartDigitalTags.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDigitalTags.Legends.Add(legend1);
            this.chartDigitalTags.Location = new System.Drawing.Point(12, 76);
            this.chartDigitalTags.Name = "chartDigitalTags";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDigitalTags.Series.Add(series1);
            this.chartDigitalTags.Size = new System.Drawing.Size(445, 316);
            this.chartDigitalTags.TabIndex = 0;
            this.chartDigitalTags.Text = "chart1";
            // 
            // chartAnalogTags
            // 
            this.chartAnalogTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartAnalogTags.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartAnalogTags.Legends.Add(legend2);
            this.chartAnalogTags.Location = new System.Drawing.Point(475, 76);
            this.chartAnalogTags.Name = "chartAnalogTags";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartAnalogTags.Series.Add(series2);
            this.chartAnalogTags.Size = new System.Drawing.Size(456, 316);
            this.chartAnalogTags.TabIndex = 1;
            this.chartAnalogTags.Text = "chart1";
            // 
            // labelDigitalTags
            // 
            this.labelDigitalTags.AutoSize = true;
            this.labelDigitalTags.Location = new System.Drawing.Point(9, 38);
            this.labelDigitalTags.Name = "labelDigitalTags";
            this.labelDigitalTags.Size = new System.Drawing.Size(81, 13);
            this.labelDigitalTags.TabIndex = 2;
            this.labelDigitalTags.Text = "DIGITAL TAGS";
            // 
            // labelAnalogTags
            // 
            this.labelAnalogTags.AutoSize = true;
            this.labelAnalogTags.Location = new System.Drawing.Point(472, 38);
            this.labelAnalogTags.Name = "labelAnalogTags";
            this.labelAnalogTags.Size = new System.Drawing.Size(83, 13);
            this.labelAnalogTags.TabIndex = 3;
            this.labelAnalogTags.Text = "ANALOG TAGS";
            // 
            // TrendingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 404);
            this.Controls.Add(this.labelAnalogTags);
            this.Controls.Add(this.labelDigitalTags);
            this.Controls.Add(this.chartAnalogTags);
            this.Controls.Add(this.chartDigitalTags);
            this.Name = "TrendingForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartDigitalTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnalogTags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDigitalTags;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnalogTags;
        private System.Windows.Forms.Label labelDigitalTags;
        private System.Windows.Forms.Label labelAnalogTags;
    }
}

