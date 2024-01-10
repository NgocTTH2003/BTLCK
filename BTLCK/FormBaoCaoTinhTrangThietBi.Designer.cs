namespace BTLCK
{
    partial class FormBaoCaoTinhTrangThietBi
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
            this.labelTTTBYT = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTTTBYT
            // 
            this.labelTTTBYT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelTTTBYT.AutoSize = true;
            this.labelTTTBYT.BackColor = System.Drawing.Color.Transparent;
            this.labelTTTBYT.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTTTBYT.Location = new System.Drawing.Point(226, 56);
            this.labelTTTBYT.Name = "labelTTTBYT";
            this.labelTTTBYT.Size = new System.Drawing.Size(657, 46);
            this.labelTTTBYT.TabIndex = 57;
            this.labelTTTBYT.Text = "BÁO CÁO TÌNH TRẠNG THIẾT BỊ";
            this.labelTTTBYT.Click += new System.EventHandler(this.labelTTTBYT_Click);
            // 
            // FormBaoCaoTinhTrangThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BTLCK.Properties.Resources.Thiết_kế_chưa_có_tên__4_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1107, 644);
            this.Controls.Add(this.labelTTTBYT);
            this.DoubleBuffered = true;
            this.Name = "FormBaoCaoTinhTrangThietBi";
            this.Text = "FormBaoCaoTinhTrangThietBi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTTTBYT;
    }
}