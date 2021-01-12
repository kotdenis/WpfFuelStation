using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFuelStation.Converters
{
    public class DateConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                      System.Globalization.CultureInfo culture)
        {
            if (value is DateTime)
            {
                DateTime test = (DateTime)value;
                string date = test.ToString("dd.MM.yyyy");
                return (date);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return DateTime.Parse(value.ToString());
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.ToString()); return null; }
        }
    }
}
