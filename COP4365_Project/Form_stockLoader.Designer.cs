namespace COP4365_Project
{
    partial class Form_stockLoader
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
            this.label_endDate = new System.Windows.Forms.Label();
            this.label_startDate = new System.Windows.Forms.Label();
            this.button_loadStocks = new System.Windows.Forms.Button();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog_stockLoader = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label_endDate
            // 
            this.label_endDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(220, 17);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(88, 13);
            this.label_endDate.TabIndex = 13;
            this.label_endDate.Text = "Select End Date:";
            // 
            // label_startDate
            // 
            this.label_startDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_startDate.AutoSize = true;
            this.label_startDate.Location = new System.Drawing.Point(16, 17);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(91, 13);
            this.label_startDate.TabIndex = 12;
            this.label_startDate.Text = "Select Start Date:";
            // 
            // button_loadStocks
            // 
            this.button_loadStocks.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_loadStocks.Location = new System.Drawing.Point(176, 73);
            this.button_loadStocks.Name = "button_loadStocks";
            this.button_loadStocks.Size = new System.Drawing.Size(84, 41);
            this.button_loadStocks.TabIndex = 10;
            this.button_loadStocks.Text = "Select a Stock to Load";
            this.button_loadStocks.UseVisualStyleBackColor = true;
            this.button_loadStocks.Click += new System.EventHandler(this.button_loadStocks_Click);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(223, 33);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker_endDate.TabIndex = 9;
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(19, 33);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker_startDate.TabIndex = 8;
            this.dateTimePicker_startDate.Value = new System.DateTime(2013, 11, 1, 15, 2, 0, 0);
            // 
            // openFileDialog_stockLoader
            // 
            this.openFileDialog_stockLoader.Filter = "All Stock files| *.csv|Daily Stocks|*-Day.csv|Weekly Stocks|*-Week.csv|Monthly St" +
    "ocks|*-Month.csv";
            this.openFileDialog_stockLoader.InitialDirectory = "..\\..\\..\\..\\Stock Data";
            this.openFileDialog_stockLoader.Multiselect = true;
            this.openFileDialog_stockLoader.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_stockLoader_FileOk);
            // 
            // Form_stockLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 132);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.button_loadStocks);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Name = "Form_stockLoader";
            this.Text = "Form_stockLoader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        protected System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        protected System.Windows.Forms.Button button_loadStocks;
        protected System.Windows.Forms.Label label_endDate;
        protected System.Windows.Forms.Label label_startDate;
        protected System.Windows.Forms.OpenFileDialog openFileDialog_stockLoader;
    }
}