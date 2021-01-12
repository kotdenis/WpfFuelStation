using FastReport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFuelStation.Infrastructure
{
    public static class ReportHelper
    {
        public static bool TrySetCommandParam(CommandParameterCollection queryParameters, string paramName, object paramValue)
        {
            var param = queryParameters.FindByName(paramName);
            if (param != null)
            {
                param.Value = paramValue;
                return true;
            }
            return false;
        }
    }
}
