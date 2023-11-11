﻿namespace COP4365_Project
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_candlesticks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.candlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button_updateChart = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.comboBox_selectPattern = new System.Windows.Forms.ComboBox();
            this.label_selectPattern = new System.Windows.Forms.Label();
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
            chartArea3.AlignWithChartArea = "ChartArea_Volume";
            chartArea3.AxisX.Title = "Date";
            chartArea3.AxisY.Title = "Price";
            chartArea3.Name = "ChartArea_OHLC";
            chartArea4.AlignWithChartArea = "ChartArea_OHLC";
            chartArea4.AxisX.Title = "Date";
            chartArea4.AxisY.Title = "Volume";
            chartArea4.Name = "ChartArea_Volume";
            this.chart_candlesticks.ChartAreas.Add(chartArea3);
            this.chart_candlesticks.ChartAreas.Add(chartArea4);
            this.chart_candlesticks.DataSource = this.candlestickBindingSource;
            legend2.Name = "Legend1";
            this.chart_candlesticks.Legends.Add(legend2);
            this.chart_candlesticks.Location = new System.Drawing.Point(0, 127);
            this.chart_candlesticks.Name = "chart_candlesticks";
            series3.ChartArea = "ChartArea_OHLC";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.Color = System.Drawing.Color.Black;
            series3.CustomProperties = "PriceDownColor=Red, PriceUpColor=LimeGreen";
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Series_OHLC";
            series3.XValueMember = "date";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series3.YValueMembers = "high, low, open, close";
            series3.YValuesPerPoint = 4;
            series4.ChartArea = "ChartArea_Volume";
            series4.Color = System.Drawing.Color.Orange;
            series4.IsXValueIndexed = true;
            series4.Legend = "Legend1";
            series4.Name = "Series_Volume";
            series4.XValueMember = "date";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series4.YValueMembers = "volume";
            this.chart_candlesticks.Series.Add(series3);
            this.chart_candlesticks.Series.Add(series4);
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
            this.button_updateChart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_updateChart.Location = new System.Drawing.Point(344, 68);
            this.button_updateChart.Name = "button_updateChart";
            this.button_updateChart.Size = new System.Drawing.Size(83, 40);
            this.button_updateChart.TabIndex = 5;
            this.button_updateChart.Text = "Update Chart Dates";
            this.button_updateChart.UseVisualStyleBackColor = true;
            this.button_updateChart.Click += new System.EventHandler(this.button_updateChart_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // comboBox_selectPattern
            // 
            this.comboBox_selectPattern.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_selectPattern.FormattingEnabled = true;
            this.comboBox_selectPattern.Location = new System.Drawing.Point(445, 87);
            this.comboBox_selectPattern.Name = "comboBox_selectPattern";
            this.comboBox_selectPattern.Size = new System.Drawing.Size(130, 21);
            this.comboBox_selectPattern.TabIndex = 14;
            this.comboBox_selectPattern.Text = "None";
            this.comboBox_selectPattern.SelectedIndexChanged += new System.EventHandler(this.comboBox_selectPattern_SelectedIndexChanged);
            // 
            // label_selectPattern
            // 
            this.label_selectPattern.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_selectPattern.AutoSize = true;
            this.label_selectPattern.Location = new System.Drawing.Point(442, 68);
            this.label_selectPattern.Name = "label_selectPattern";
            this.label_selectPattern.Size = new System.Drawing.Size(133, 13);
            this.label_selectPattern.TabIndex = 15;
            this.label_selectPattern.Text = "Select Pattern to Highlight:";
            // 
            // Form_stockChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 467);
            this.Controls.Add(this.label_selectPattern);
            this.Controls.Add(this.comboBox_selectPattern);
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
            this.Controls.SetChildIndex(this.comboBox_selectPattern, 0);
            this.Controls.SetChildIndex(this.label_selectPattern, 0);
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
        private System.Windows.Forms.ComboBox comboBox_selectPattern;
        private System.Windows.Forms.Label label_selectPattern;
    }
}

