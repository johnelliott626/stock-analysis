namespace COP4365_Project
{
    partial class Form_stockChart
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_candlesticks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.candlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_updateChart = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.chart_candlesticks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(445, 28);
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(241, 28);
            // 
            // button_loadStocks
            // 
            this.button_loadStocks.Location = new System.Drawing.Point(398, 68);
            this.button_loadStocks.Visible = false;
            // 
            // label_endDate
            // 
            this.label_endDate.Location = new System.Drawing.Point(442, 12);
            // 
            // label_startDate
            // 
            this.label_startDate.Location = new System.Drawing.Point(238, 12);
            // 
            // chart_candlesticks
            // 
            this.chart_candlesticks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AlignWithChartArea = "ChartArea_Volume";
            chartArea1.AxisX.Title = "Date";
            chartArea1.AxisY.Title = "Price";
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.AlignWithChartArea = "ChartArea_OHLC";
            chartArea2.AxisX.Title = "Date";
            chartArea2.AxisY.Title = "Volume";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_candlesticks.ChartAreas.Add(chartArea1);
            this.chart_candlesticks.ChartAreas.Add(chartArea2);
            this.chart_candlesticks.DataSource = this.candlestickBindingSource;
            legend1.Name = "Legend1";
            this.chart_candlesticks.Legends.Add(legend1);
            this.chart_candlesticks.Location = new System.Drawing.Point(0, 127);
            this.chart_candlesticks.Name = "chart_candlesticks";
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.Black;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=LimeGreen";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series_OHLC";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "high, low, open, close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_Volume";
            series2.Color = System.Drawing.Color.Orange;
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Series_Volume";
            series2.XValueMember = "date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "volume";
            this.chart_candlesticks.Series.Add(series1);
            this.chart_candlesticks.Series.Add(series2);
            this.chart_candlesticks.Size = new System.Drawing.Size(878, 341);
            this.chart_candlesticks.TabIndex = 1;
            this.chart_candlesticks.Text = "chart1";
            // 
            // candlestickBindingSource
            // 
            this.candlestickBindingSource.DataSource = typeof(COP4365_Project.Candlestick);
            // 
            // button_updateChart
            // 
            this.button_updateChart.Location = new System.Drawing.Point(399, 68);
            this.button_updateChart.Name = "button_updateChart";
            this.button_updateChart.Size = new System.Drawing.Size(83, 40);
            this.button_updateChart.TabIndex = 5;
            this.button_updateChart.Text = "Click to Update Chart";
            this.button_updateChart.UseVisualStyleBackColor = true;
            this.button_updateChart.Click += new System.EventHandler(this.button_updateChart_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form_stockChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 467);
            this.Controls.Add(this.button_updateChart);
            this.Controls.Add(this.chart_candlesticks);
            this.Name = "Form_stockChart";
            this.Text = "Stock Analysis Form";
            this.Controls.SetChildIndex(this.label_startDate, 0);
            this.Controls.SetChildIndex(this.label_endDate, 0);
            this.Controls.SetChildIndex(this.button_loadStocks, 0);
            this.Controls.SetChildIndex(this.chart_candlesticks, 0);
            this.Controls.SetChildIndex(this.button_updateChart, 0);
            this.Controls.SetChildIndex(this.dateTimePicker_startDate, 0);
            this.Controls.SetChildIndex(this.dateTimePicker_endDate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chart_candlesticks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_candlesticks;
        private System.Windows.Forms.Button button_updateChart;
        private System.Windows.Forms.BindingSource candlestickBindingSource;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

