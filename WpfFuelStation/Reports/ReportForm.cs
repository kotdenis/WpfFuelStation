using FastReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfFuelStation.Reports
{
    public partial class ReportForm : Form
    {
        public ReportForm(string title, Report report)
        {
            InitializeComponent();
            Text = title;

            try
            {
                preview_report.ToolBar.Items[preview_report.ToolBar.Items.IndexOf("btnSave")].SubItems.RemoveAt(0);
                report.Preview = preview_report;

                //for (int i = 0; i < report.Dictionary.Connections.Count; i++)
                //{
                //    report.Dictionary.Connections[i].ConnectionString = ConfigurationManager.ConnectionStrings["SQLContext"].ConnectionString;
                //}

                if (report.Prepare())
                {
                    report.Show();
                }
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.Write(ex.Message);
                //CustomMessageBox.ShowBox(ex.ToString(), " ", CustomMessageBox.MessageIcon.Error, false);//"При формировании отчета возникла ошибка", "Ошибка формирования отчета", CustomMessageBox.MessageIcon.Error, false);
            }
        }
    }
}
