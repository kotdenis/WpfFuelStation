namespace WpfFuelStation.Reports
{
    partial class ReportForm
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
            this.preview_report = new FastReport.Preview.PreviewControl();
            this.SuspendLayout();
            // 
            // preview_report
            // 
            this.preview_report.BackColor = System.Drawing.Color.White;
            this.preview_report.Buttons = ((FastReport.PreviewButtons)((((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Save) 
            | FastReport.PreviewButtons.Find) 
            | FastReport.PreviewButtons.Zoom) 
            | FastReport.PreviewButtons.PageSetup) 
            | FastReport.PreviewButtons.Navigator)));
            this.preview_report.Clouds = FastReport.PreviewClouds.None;
            this.preview_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preview_report.Exports = ((FastReport.PreviewExports)(((((((FastReport.PreviewExports.Prepared | FastReport.PreviewExports.PDFExport) 
            | FastReport.PreviewExports.XMLExport) 
            | FastReport.PreviewExports.Excel2007Export) 
            | FastReport.PreviewExports.Excel2003Document) 
            | FastReport.PreviewExports.Word2007Export) 
            | FastReport.PreviewExports.CSVExport)));
            this.preview_report.Font = new System.Drawing.Font("Tahoma", 8F);
            this.preview_report.Location = new System.Drawing.Point(0, 0);
            this.preview_report.Name = "preview_report";
            this.preview_report.PageOffset = new System.Drawing.Point(10, 10);
            this.preview_report.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.preview_report.Size = new System.Drawing.Size(945, 700);
            this.preview_report.TabIndex = 1;
            this.preview_report.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005;
            this.preview_report.UseBackColor = true;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 700);
            this.Controls.Add(this.preview_report);
            this.MinimizeBox = false;
            this.Name = "ReportForm";
            this.Text = "Отчет";
            this.ResumeLayout(false);

        }

        #endregion

        private FastReport.Preview.PreviewControl preview_report;
    }
}