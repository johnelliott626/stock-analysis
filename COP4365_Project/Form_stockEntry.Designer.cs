namespace COP4365_Project
{
    partial class Form_stockEntry
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
            this.openFileDialog_stockLoader = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView_stockData = new System.Windows.Forms.DataGridView();
            this.chart_candlesticks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.button_loadStocks = new System.Windows.Forms.Button();
            this.button_updateChart = new System.Windows.Forms.Button();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.candlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_candlesticks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog_stockLoader
            // 
            this.openFileDialog_stockLoader.Filter = "All Stock files| *.csv|Daily Stocks|*-Day.csv|Weekly Stocks|*-Week.csv|Monthly St" +
    "ocks|*-Month.csv";
            this.openFileDialog_stockLoader.InitialDirectory = "..\\..\\..\\..\\Stock Data";
            // 
            // dataGridView_stockData
            // 
            this.dataGridView_stockData.AutoGenerateColumns = false;
            this.dataGridView_stockData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_stockData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.openDataGridViewTextBoxColumn,
            this.closeDataGridViewTextBoxColumn,
            this.highDataGridViewTextBoxColumn,
            this.lowDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn});
            this.dataGridView_stockData.DataSource = this.candlestickBindingSource;
            this.dataGridView_stockData.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_stockData.Name = "dataGridView_stockData";
            this.dataGridView_stockData.Size = new System.Drawing.Size(660, 178);
            this.dataGridView_stockData.TabIndex = 0;
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
            this.chart_candlesticks.Location = new System.Drawing.Point(0, 220);
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
            this.chart_candlesticks.Size = new System.Drawing.Size(878, 309);
            this.chart_candlesticks.TabIndex = 1;
            this.chart_candlesticks.Text = "chart1";
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(680, 87);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker_startDate.TabIndex = 2;
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(680, 136);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker_endDate.TabIndex = 3;
            // 
            // button_loadStocks
            // 
            this.button_loadStocks.Location = new System.Drawing.Point(686, 12);
            this.button_loadStocks.Name = "button_loadStocks";
            this.button_loadStocks.Size = new System.Drawing.Size(84, 41);
            this.button_loadStocks.TabIndex = 4;
            this.button_loadStocks.Text = "Select a Stock to Load";
            this.button_loadStocks.UseVisualStyleBackColor = true;
            this.button_loadStocks.Click += new System.EventHandler(this.button_loadStocks_Click);
            // 
            // button_updateChart
            // 
            this.button_updateChart.Location = new System.Drawing.Point(781, 13);
            this.button_updateChart.Name = "button_updateChart";
            this.button_updateChart.Size = new System.Drawing.Size(83, 40);
            this.button_updateChart.TabIndex = 5;
            this.button_updateChart.Text = "Click to Update Chart";
            this.button_updateChart.UseVisualStyleBackColor = true;
            this.button_updateChart.Click += new System.EventHandler(this.button_updateChart_Click);
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Location = new System.Drawing.Point(683, 71);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(91, 13);
            this.label_startDate.TabIndex = 6;
            this.label_startDate.Text = "Select Start Date:";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(683, 120);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(88, 13);
            this.label_endDate.TabIndex = 7;
            this.label_endDate.Text = "Select End Date:";
            // 
            // candlestickBindingSource
            // 
            this.candlestickBindingSource.DataSource = typeof(COP4365_Project.Candlestick);
            // 
            // openDataGridViewTextBoxColumn
            // 
            this.openDataGridViewTextBoxColumn.DataPropertyName = "open";
            this.openDataGridViewTextBoxColumn.HeaderText = "open";
            this.openDataGridViewTextBoxColumn.Name = "openDataGridViewTextBoxColumn";
            // 
            // closeDataGridViewTextBoxColumn
            // 
            this.closeDataGridViewTextBoxColumn.DataPropertyName = "close";
            this.closeDataGridViewTextBoxColumn.HeaderText = "close";
            this.closeDataGridViewTextBoxColumn.Name = "closeDataGridViewTextBoxColumn";
            // 
            // highDataGridViewTextBoxColumn
            // 
            this.highDataGridViewTextBoxColumn.DataPropertyName = "high";
            this.highDataGridViewTextBoxColumn.HeaderText = "high";
            this.highDataGridViewTextBoxColumn.Name = "highDataGridViewTextBoxColumn";
            // 
            // lowDataGridViewTextBoxColumn
            // 
            this.lowDataGridViewTextBoxColumn.DataPropertyName = "low";
            this.lowDataGridViewTextBoxColumn.HeaderText = "low";
            this.lowDataGridViewTextBoxColumn.Name = "lowDataGridViewTextBoxColumn";
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // Form_stockEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 529);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.button_updateChart);
            this.Controls.Add(this.button_loadStocks);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.chart_candlesticks);
            this.Controls.Add(this.dataGridView_stockData);
            this.Name = "Form_stockEntry";
            this.Text = "Stock Analysis Form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stockData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_candlesticks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candlestickBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog_stockLoader;
        private System.Windows.Forms.DataGridView dataGridView_stockData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_candlesticks;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.Button button_loadStocks;
        private System.Windows.Forms.Button button_updateChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource candlestickBindingSource;
        private System.Windows.Forms.Label label_startDate;
        private System.Windows.Forms.Label label_endDate;
    }
}

