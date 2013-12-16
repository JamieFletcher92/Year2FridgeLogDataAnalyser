namespace Assignment_Data_Analyser
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Browse = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_Open = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_Plot = new System.Windows.Forms.Button();
            this.cb_Plot = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_Collumn = new System.Windows.Forms.Button();
            this.btn_Line = new System.Windows.Forms.Button();
            this.groupBoxValues = new System.Windows.Forms.GroupBox();
            this.cb_Hour = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMinLight = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMaxLight = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMaxTemp = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblMinTemp = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblAveLight = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblAveTemp = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblMaxVolt = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblAveVolt = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lblMinVolt = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_BoxPlot = new System.Windows.Forms.Button();
            this.btn_Point = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cb_FileType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBoxValues.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // txt_Browse
            // 
            this.txt_Browse.Location = new System.Drawing.Point(61, 37);
            this.txt_Browse.Name = "txt_Browse";
            this.txt_Browse.Size = new System.Drawing.Size(613, 20);
            this.txt_Browse.TabIndex = 1;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(680, 35);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 2;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(680, 65);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 3;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_Plot
            // 
            this.btn_Plot.Location = new System.Drawing.Point(327, 127);
            this.btn_Plot.Name = "btn_Plot";
            this.btn_Plot.Size = new System.Drawing.Size(75, 23);
            this.btn_Plot.TabIndex = 5;
            this.btn_Plot.Text = "Plot Chart";
            this.btn_Plot.UseVisualStyleBackColor = true;
            this.btn_Plot.Click += new System.EventHandler(this.btn_Plot_Click);
            // 
            // cb_Plot
            // 
            this.cb_Plot.FormattingEnabled = true;
            this.cb_Plot.Items.AddRange(new object[] {
            "Average Temperature/Hour",
            "Average Light/Hour",
            "Average Voltage/Hour",
            "Average Temp vs Average Light/Hour",
            "Average Voltage vs Average Light/Hour",
            "Average Temp vs Average Voltage/Hour"});
            this.cb_Plot.Location = new System.Drawing.Point(14, 129);
            this.cb_Plot.Name = "cb_Plot";
            this.cb_Plot.Size = new System.Drawing.Size(307, 21);
            this.cb_Plot.TabIndex = 6;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(490, 111);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(608, 461);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // btn_Collumn
            // 
            this.btn_Collumn.Location = new System.Drawing.Point(91, 19);
            this.btn_Collumn.Name = "btn_Collumn";
            this.btn_Collumn.Size = new System.Drawing.Size(75, 23);
            this.btn_Collumn.TabIndex = 8;
            this.btn_Collumn.Text = "Collumn";
            this.btn_Collumn.UseVisualStyleBackColor = true;
            this.btn_Collumn.Click += new System.EventHandler(this.btn_Collumn_Click);
            // 
            // btn_Line
            // 
            this.btn_Line.Location = new System.Drawing.Point(91, 49);
            this.btn_Line.Name = "btn_Line";
            this.btn_Line.Size = new System.Drawing.Size(75, 23);
            this.btn_Line.TabIndex = 9;
            this.btn_Line.Text = "Line";
            this.btn_Line.UseVisualStyleBackColor = true;
            this.btn_Line.Click += new System.EventHandler(this.btn_Line_Click);
            // 
            // groupBoxValues
            // 
            this.groupBoxValues.Controls.Add(this.cb_Hour);
            this.groupBoxValues.Controls.Add(this.label2);
            this.groupBoxValues.Location = new System.Drawing.Point(14, 172);
            this.groupBoxValues.Name = "groupBoxValues";
            this.groupBoxValues.Size = new System.Drawing.Size(200, 100);
            this.groupBoxValues.TabIndex = 10;
            this.groupBoxValues.TabStop = false;
            this.groupBoxValues.Text = "Show Values";
            // 
            // cb_Hour
            // 
            this.cb_Hour.FormattingEnabled = true;
            this.cb_Hour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "Overall"});
            this.cb_Hour.Location = new System.Drawing.Point(46, 43);
            this.cb_Hour.Name = "cb_Hour";
            this.cb_Hour.Size = new System.Drawing.Size(121, 21);
            this.cb_Hour.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hour:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMinLight);
            this.groupBox2.Location = new System.Drawing.Point(14, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(147, 82);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Minimum Light";
            // 
            // lblMinLight
            // 
            this.lblMinLight.AutoSize = true;
            this.lblMinLight.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinLight.Location = new System.Drawing.Point(17, 26);
            this.lblMinLight.Name = "lblMinLight";
            this.lblMinLight.Size = new System.Drawing.Size(35, 37);
            this.lblMinLight.TabIndex = 1;
            this.lblMinLight.Text = "0";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(246, 209);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 12;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMaxLight);
            this.groupBox1.Location = new System.Drawing.Point(14, 384);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 82);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maximum Light";
            // 
            // lblMaxLight
            // 
            this.lblMaxLight.AutoSize = true;
            this.lblMaxLight.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLight.Location = new System.Drawing.Point(17, 26);
            this.lblMaxLight.Name = "lblMaxLight";
            this.lblMaxLight.Size = new System.Drawing.Size(35, 37);
            this.lblMaxLight.TabIndex = 1;
            this.lblMaxLight.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblMaxTemp);
            this.groupBox3.Location = new System.Drawing.Point(174, 384);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(147, 82);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Maximum Temperature";
            // 
            // lblMaxTemp
            // 
            this.lblMaxTemp.AutoSize = true;
            this.lblMaxTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxTemp.Location = new System.Drawing.Point(17, 26);
            this.lblMaxTemp.Name = "lblMaxTemp";
            this.lblMaxTemp.Size = new System.Drawing.Size(35, 37);
            this.lblMaxTemp.TabIndex = 1;
            this.lblMaxTemp.Text = "0";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblMinTemp);
            this.groupBox4.Location = new System.Drawing.Point(174, 278);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(147, 82);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Minimum Temperature";
            // 
            // lblMinTemp
            // 
            this.lblMinTemp.AutoSize = true;
            this.lblMinTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinTemp.Location = new System.Drawing.Point(17, 26);
            this.lblMinTemp.Name = "lblMinTemp";
            this.lblMinTemp.Size = new System.Drawing.Size(35, 37);
            this.lblMinTemp.TabIndex = 1;
            this.lblMinTemp.Text = "0";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblAveLight);
            this.groupBox5.Location = new System.Drawing.Point(14, 490);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(147, 82);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Average Light";
            // 
            // lblAveLight
            // 
            this.lblAveLight.AutoSize = true;
            this.lblAveLight.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAveLight.Location = new System.Drawing.Point(17, 26);
            this.lblAveLight.Name = "lblAveLight";
            this.lblAveLight.Size = new System.Drawing.Size(35, 37);
            this.lblAveLight.TabIndex = 1;
            this.lblAveLight.Text = "0";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblAveTemp);
            this.groupBox6.Location = new System.Drawing.Point(174, 490);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(147, 82);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Average Temperature";
            // 
            // lblAveTemp
            // 
            this.lblAveTemp.AutoSize = true;
            this.lblAveTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAveTemp.Location = new System.Drawing.Point(17, 26);
            this.lblAveTemp.Name = "lblAveTemp";
            this.lblAveTemp.Size = new System.Drawing.Size(35, 37);
            this.lblAveTemp.TabIndex = 1;
            this.lblAveTemp.Text = "0";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblMaxVolt);
            this.groupBox7.Location = new System.Drawing.Point(337, 384);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(147, 82);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Maximum Voltage";
            // 
            // lblMaxVolt
            // 
            this.lblMaxVolt.AutoSize = true;
            this.lblMaxVolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxVolt.Location = new System.Drawing.Point(17, 26);
            this.lblMaxVolt.Name = "lblMaxVolt";
            this.lblMaxVolt.Size = new System.Drawing.Size(35, 37);
            this.lblMaxVolt.TabIndex = 1;
            this.lblMaxVolt.Text = "0";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblAveVolt);
            this.groupBox8.Location = new System.Drawing.Point(337, 490);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(147, 82);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Average Voltage";
            // 
            // lblAveVolt
            // 
            this.lblAveVolt.AutoSize = true;
            this.lblAveVolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAveVolt.Location = new System.Drawing.Point(17, 26);
            this.lblAveVolt.Name = "lblAveVolt";
            this.lblAveVolt.Size = new System.Drawing.Size(35, 37);
            this.lblAveVolt.TabIndex = 1;
            this.lblAveVolt.Text = "0";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblMinVolt);
            this.groupBox9.Location = new System.Drawing.Point(337, 278);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(147, 82);
            this.groupBox9.TabIndex = 11;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Minimum Voltage";
            // 
            // lblMinVolt
            // 
            this.lblMinVolt.AutoSize = true;
            this.lblMinVolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinVolt.Location = new System.Drawing.Point(17, 26);
            this.lblMinVolt.Name = "lblMinVolt";
            this.lblMinVolt.Size = new System.Drawing.Size(35, 37);
            this.lblMinVolt.TabIndex = 1;
            this.lblMinVolt.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1108, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btn_BoxPlot
            // 
            this.btn_BoxPlot.Location = new System.Drawing.Point(10, 49);
            this.btn_BoxPlot.Name = "btn_BoxPlot";
            this.btn_BoxPlot.Size = new System.Drawing.Size(75, 23);
            this.btn_BoxPlot.TabIndex = 14;
            this.btn_BoxPlot.Text = "Box Plot";
            this.btn_BoxPlot.UseVisualStyleBackColor = true;
            this.btn_BoxPlot.Click += new System.EventHandler(this.btn_BoxPlot_Click);
            // 
            // btn_Point
            // 
            this.btn_Point.Location = new System.Drawing.Point(10, 19);
            this.btn_Point.Name = "btn_Point";
            this.btn_Point.Size = new System.Drawing.Size(75, 23);
            this.btn_Point.TabIndex = 15;
            this.btn_Point.Text = "Point";
            this.btn_Point.UseVisualStyleBackColor = true;
            this.btn_Point.Click += new System.EventHandler(this.btn_Point_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btn_Point);
            this.groupBox10.Controls.Add(this.btn_Collumn);
            this.groupBox10.Controls.Add(this.btn_BoxPlot);
            this.groupBox10.Controls.Add(this.btn_Line);
            this.groupBox10.Location = new System.Drawing.Point(926, 27);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(172, 78);
            this.groupBox10.TabIndex = 16;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Chart Options";
            // 
            // cb_FileType
            // 
            this.cb_FileType.FormattingEnabled = true;
            this.cb_FileType.Items.AddRange(new object[] {
            "CSV",
            "XML",
            "JSON"});
            this.cb_FileType.Location = new System.Drawing.Point(61, 67);
            this.cb_FileType.Name = "cb_FileType";
            this.cb_FileType.Size = new System.Drawing.Size(121, 21);
            this.cb_FileType.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "File Type:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 583);
            this.Controls.Add(this.cb_FileType);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxValues);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.cb_Plot);
            this.Controls.Add(this.btn_Plot);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.txt_Browse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBoxValues.ResumeLayout(false);
            this.groupBoxValues.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Browse;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_Plot;
        private System.Windows.Forms.ComboBox cb_Plot;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btn_Collumn;
        private System.Windows.Forms.Button btn_Line;
        private System.Windows.Forms.GroupBox groupBoxValues;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMinLight;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ComboBox cb_Hour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMaxLight;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblMaxTemp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblMinTemp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblAveLight;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblAveTemp;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblMaxVolt;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lblAveVolt;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label lblMinVolt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btn_BoxPlot;
        private System.Windows.Forms.Button btn_Point;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox cb_FileType;
        private System.Windows.Forms.Label label3;
    }
}

