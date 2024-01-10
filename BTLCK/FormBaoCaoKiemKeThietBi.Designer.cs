namespace BTLCK
{
    partial class FormBaoCaoKiemKeThietBi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaoCaoKiemKeThietBi));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelTTTBYT = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Back = new System.Windows.Forms.PictureBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTTTBYT
            // 
            this.labelTTTBYT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelTTTBYT.AutoSize = true;
            this.labelTTTBYT.BackColor = System.Drawing.Color.Transparent;
            this.labelTTTBYT.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTTTBYT.Location = new System.Drawing.Point(138, 72);
            this.labelTTTBYT.Name = "labelTTTBYT";
            this.labelTTTBYT.Size = new System.Drawing.Size(785, 39);
            this.labelTTTBYT.TabIndex = 56;
            this.labelTTTBYT.Text = "THỐNG KÊ SỐ LƯỢNG THIẾT BỊ THEO VỊ TRÍ";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoad.Location = new System.Drawing.Point(1013, 629);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(146, 47);
            this.buttonLoad.TabIndex = 57;
            this.buttonLoad.Text = "Tải lại";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(937, 629);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Back.BackgroundImage")));
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Back.Location = new System.Drawing.Point(12, 23);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(90, 54);
            this.Back.TabIndex = 60;
            this.Back.TabStop = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(231, 154);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(642, 375);
            this.chart1.TabIndex = 61;
            this.chart1.Text = "chart1";
            // 
            // FormBaoCaoKiemKeThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BTLCK.Properties.Resources.Thiết_kế_chưa_có_tên__4_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1171, 688);
            this.ControlBox = false;
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.labelTTTBYT);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBaoCaoKiemKeThietBi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo kiểm kê thiết bị";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTTTBYT;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Back;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}