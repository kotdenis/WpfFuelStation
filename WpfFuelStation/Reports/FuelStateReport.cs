using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using FastReport;
using FastReport.Data;
using FastReport.Dialog;
using FastReport.Barcode;
using FastReport.Table;
using FastReport.Utils;

namespace WpfFuelStation.Reports
{
  public class FuelStateReport : Report
  {
    public FastReport.Report Report;
    public FastReport.Engine.ReportEngine Engine;
    public FastReport.Table.TableCell Cell18;
    public FastReport.Table.TableCell Cell19;
    public FastReport.Table.TableCell Cell20;
    public FastReport.Table.TableCell Cell21;
    public FastReport.Table.TableCell Cell22;
    public FastReport.Table.TableCell Cell23;
    public FastReport.Table.TableCell Cell24;
    public FastReport.Table.TableCell Cell25;
    public FastReport.Table.TableCell Cell26;
    public FastReport.Table.TableCell Cell27;
    public FastReport.Table.TableColumn Column13;
    public FastReport.Table.TableColumn Column14;
    public FastReport.Table.TableColumn Column15;
    public FastReport.Table.TableColumn Column16;
    public FastReport.Table.TableColumn Column17;
    public FastReport.Table.TableColumn Column18;
    public FastReport.Table.TableColumn Column19;
    public FastReport.Table.TableColumn Column20;
    public FastReport.Table.TableColumn Column21;
    public FastReport.Table.TableColumn Column22;
    public FastReport.ColumnHeaderBand ColumnHeader1;
    public FastReport.DataBand Data1;
    public FastReport.ReportPage Page1;
    public FastReport.PageFooterBand PageFooter1;
    public FastReport.PageHeaderBand PageHeader1;
    public FastReport.ReportSummaryBand ReportSummary1;
    public FastReport.ReportTitleBand ReportTitle1;
    public FastReport.Table.TableRow Row5;
    public FastReport.Table.TableRow Row6;
    public FastReport.Table.TableObject Table1;
    public FastReport.TextObject Text1;
    public FastReport.TextObject Text2;
    public FastReport.TextObject Text3;
    public FastReport.TextObject Text4;
    public FastReport.TextObject Text5;
    private object Sum(TableCell cell)
    {
      return cell.Table.Sum(cell);
    }

    private object Min(TableCell cell)
    {
      return cell.Table.Min(cell);
    }

    private object Max(TableCell cell)
    {
      return cell.Table.Max(cell);
    }

    private object Avg(TableCell cell)
    {
      return cell.Table.Avg(cell);
    }

    private object Count(TableCell cell)
    {
      return cell.Table.Count(cell);
    }

    protected override object CalcExpression(string expression, Variant Value)
    {
      if (expression == "[Table.Remains]")
        return "[Table.Remains]";
      return null;
    }

    private SByte Abs(SByte value)
    {
      return System.Math.Abs(value);
    }

    private Int16 Abs(Int16 value)
    {
      return System.Math.Abs(value);
    }

    private Int32 Abs(Int32 value)
    {
      return System.Math.Abs(value);
    }

    private Int64 Abs(Int64 value)
    {
      return System.Math.Abs(value);
    }

    private Single Abs(Single value)
    {
      return System.Math.Abs(value);
    }

    private Double Abs(Double value)
    {
      return System.Math.Abs(value);
    }

    private Decimal Abs(Decimal value)
    {
      return System.Math.Abs(value);
    }

    private Double Acos(Double d)
    {
      return System.Math.Acos(d);
    }

    private Double Asin(Double d)
    {
      return System.Math.Asin(d);
    }

    private Double Atan(Double d)
    {
      return System.Math.Atan(d);
    }

    private Double Ceiling(Double a)
    {
      return System.Math.Ceiling(a);
    }

    private Decimal Ceiling(Decimal d)
    {
      return System.Math.Ceiling(d);
    }

    private Double Cos(Double d)
    {
      return System.Math.Cos(d);
    }

    private Double Exp(Double d)
    {
      return System.Math.Exp(d);
    }

    private Double Floor(Double d)
    {
      return System.Math.Floor(d);
    }

    private Decimal Floor(Decimal d)
    {
      return System.Math.Floor(d);
    }

    private Double Log(Double d)
    {
      return System.Math.Log(d);
    }

    private Int32 Maximum(Int32 val1, Int32 val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Int64 Maximum(Int64 val1, Int64 val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Single Maximum(Single val1, Single val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Double Maximum(Double val1, Double val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Decimal Maximum(Decimal val1, Decimal val2)
    {
      return FastReport.Functions.StdFunctions.Maximum(val1, val2);
    }

    private Int32 Minimum(Int32 val1, Int32 val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Int64 Minimum(Int64 val1, Int64 val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Single Minimum(Single val1, Single val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Double Minimum(Double val1, Double val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Decimal Minimum(Decimal val1, Decimal val2)
    {
      return FastReport.Functions.StdFunctions.Minimum(val1, val2);
    }

    private Double Round(Double a)
    {
      return System.Math.Round(a);
    }

    private Decimal Round(Decimal d)
    {
      return System.Math.Round(d);
    }

    private Double Round(Double value, Int32 digits)
    {
      return System.Math.Round(value, digits);
    }

    private Decimal Round(Decimal d, Int32 decimals)
    {
      return System.Math.Round(d, decimals);
    }

    private Double Sin(Double a)
    {
      return System.Math.Sin(a);
    }

    private Double Sqrt(Double d)
    {
      return System.Math.Sqrt(d);
    }

    private Double Tan(Double a)
    {
      return System.Math.Tan(a);
    }

    private Double Truncate(Double d)
    {
      return System.Math.Truncate(d);
    }

    private Decimal Truncate(Decimal d)
    {
      return System.Math.Truncate(d);
    }

    private Int32 Asc(Char c)
    {
      return FastReport.Functions.StdFunctions.Asc(c);
    }

    private Char Chr(Int32 i)
    {
      return FastReport.Functions.StdFunctions.Chr(i);
    }

    private String Insert(String s, Int32 startIndex, String value)
    {
      return FastReport.Functions.StdFunctions.Insert(s, startIndex, value);
    }

    private Int32 Length(String s)
    {
      return FastReport.Functions.StdFunctions.Length(s);
    }

    private String LowerCase(String s)
    {
      return FastReport.Functions.StdFunctions.LowerCase(s);
    }

    private String PadLeft(String s, Int32 totalWidth)
    {
      return FastReport.Functions.StdFunctions.PadLeft(s, totalWidth);
    }

    private String PadLeft(String s, Int32 totalWidth, Char paddingChar)
    {
      return FastReport.Functions.StdFunctions.PadLeft(s, totalWidth, paddingChar);
    }

    private String PadRight(String s, Int32 totalWidth)
    {
      return FastReport.Functions.StdFunctions.PadRight(s, totalWidth);
    }

    private String PadRight(String s, Int32 totalWidth, Char paddingChar)
    {
      return FastReport.Functions.StdFunctions.PadRight(s, totalWidth, paddingChar);
    }

    private String Remove(String s, Int32 startIndex)
    {
      return FastReport.Functions.StdFunctions.Remove(s, startIndex);
    }

    private String Remove(String s, Int32 startIndex, Int32 count)
    {
      return FastReport.Functions.StdFunctions.Remove(s, startIndex, count);
    }

    private String Replace(String s, String oldValue, String newValue)
    {
      return FastReport.Functions.StdFunctions.Replace(s, oldValue, newValue);
    }

    private String Substring(String s, Int32 startIndex)
    {
      return FastReport.Functions.StdFunctions.Substring(s, startIndex);
    }

    private String Substring(String s, Int32 startIndex, Int32 length)
    {
      return FastReport.Functions.StdFunctions.Substring(s, startIndex, length);
    }

    private String TitleCase(String s)
    {
      return FastReport.Functions.StdFunctions.TitleCase(s);
    }

    private String Trim(String s)
    {
      return FastReport.Functions.StdFunctions.Trim(s);
    }

    private String UpperCase(String s)
    {
      return FastReport.Functions.StdFunctions.UpperCase(s);
    }

    private DateTime AddDays(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddDays(date, value);
    }

    private DateTime AddHours(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddHours(date, value);
    }

    private DateTime AddMinutes(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddMinutes(date, value);
    }

    private DateTime AddMonths(DateTime date, Int32 value)
    {
      return FastReport.Functions.StdFunctions.AddMonths(date, value);
    }

    private DateTime AddSeconds(DateTime date, Double value)
    {
      return FastReport.Functions.StdFunctions.AddSeconds(date, value);
    }

    private DateTime AddYears(DateTime date, Int32 value)
    {
      return FastReport.Functions.StdFunctions.AddYears(date, value);
    }

    private TimeSpan DateDiff(DateTime date1, DateTime date2)
    {
      return FastReport.Functions.StdFunctions.DateDiff(date1, date2);
    }

    private DateTime DateSerial(Int32 year, Int32 month, Int32 day)
    {
      return FastReport.Functions.StdFunctions.DateSerial(year, month, day);
    }

    private Int32 Day(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Day(date);
    }

    private String DayOfWeek(DateTime date)
    {
      return FastReport.Functions.StdFunctions.DayOfWeek(date);
    }

    private Int32 DayOfYear(DateTime date)
    {
      return FastReport.Functions.StdFunctions.DayOfYear(date);
    }

    private Int32 DaysInMonth(Int32 year, Int32 month)
    {
      return FastReport.Functions.StdFunctions.DaysInMonth(year, month);
    }

    private Int32 Hour(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Hour(date);
    }

    private Int32 Minute(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Minute(date);
    }

    private Int32 Month(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Month(date);
    }

    private String MonthName(Int32 month)
    {
      return FastReport.Functions.StdFunctions.MonthName(month);
    }

    private Int32 Second(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Second(date);
    }

    private Int32 WeekOfYear(DateTime date)
    {
      return FastReport.Functions.StdFunctions.WeekOfYear(date);
    }

    private Int32 Year(DateTime date)
    {
      return FastReport.Functions.StdFunctions.Year(date);
    }

    private String Format(String format, params Object[] args)
    {
      return FastReport.Functions.StdFunctions.Format(format, args);
    }

    private String FormatCurrency(Object value)
    {
      return FastReport.Functions.StdFunctions.FormatCurrency(value);
    }

    private String FormatCurrency(Object value, Int32 decimalDigits)
    {
      return FastReport.Functions.StdFunctions.FormatCurrency(value, decimalDigits);
    }

    private String FormatDateTime(DateTime value)
    {
      return FastReport.Functions.StdFunctions.FormatDateTime(value);
    }

    private String FormatDateTime(DateTime value, String format)
    {
      return FastReport.Functions.StdFunctions.FormatDateTime(value, format);
    }

    private String FormatNumber(Object value)
    {
      return FastReport.Functions.StdFunctions.FormatNumber(value);
    }

    private String FormatNumber(Object value, Int32 decimalDigits)
    {
      return FastReport.Functions.StdFunctions.FormatNumber(value, decimalDigits);
    }

    private String FormatPercent(Object value)
    {
      return FastReport.Functions.StdFunctions.FormatPercent(value);
    }

    private String FormatPercent(Object value, Int32 decimalDigits)
    {
      return FastReport.Functions.StdFunctions.FormatPercent(value, decimalDigits);
    }

    private Boolean ToBoolean(Object value)
    {
      return System.Convert.ToBoolean(value);
    }

    private Byte ToByte(Object value)
    {
      return System.Convert.ToByte(value);
    }

    private Char ToChar(Object value)
    {
      return System.Convert.ToChar(value);
    }

    private DateTime ToDateTime(Object value)
    {
      return System.Convert.ToDateTime(value);
    }

    private Decimal ToDecimal(Object value)
    {
      return System.Convert.ToDecimal(value);
    }

    private Double ToDouble(Object value)
    {
      return System.Convert.ToDouble(value);
    }

    private Int32 ToInt32(Object value)
    {
      return System.Convert.ToInt32(value);
    }

    private String ToRoman(Object value)
    {
      return FastReport.Functions.StdFunctions.ToRoman(value);
    }

    private Single ToSingle(Object value)
    {
      return System.Convert.ToSingle(value);
    }

    private String ToString(Object value)
    {
      return System.Convert.ToString(value);
    }

    private String ToWords(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWords(value);
    }

    private String ToWords(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWords(value, currencyName);
    }

    private String ToWords(Object value, String one, String many)
    {
      return FastReport.Functions.StdFunctions.ToWords(value, one, many);
    }

    private String ToWordsEnGb(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWordsEnGb(value);
    }

    private String ToWordsEnGb(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWordsEnGb(value, currencyName);
    }

    private String ToWordsEnGb(Object value, String one, String many)
    {
      return FastReport.Functions.StdFunctions.ToWordsEnGb(value, one, many);
    }

    private String ToWordsEs(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWordsEs(value);
    }

    private String ToWordsEs(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWordsEs(value, currencyName);
    }

    private String ToWordsEs(Object value, String one, String many)
    {
      return FastReport.Functions.StdFunctions.ToWordsEs(value, one, many);
    }

    private String ToWordsRu(Object value)
    {
      return FastReport.Functions.StdFunctions.ToWordsRu(value);
    }

    private String ToWordsRu(Object value, String currencyName)
    {
      return FastReport.Functions.StdFunctions.ToWordsRu(value, currencyName);
    }

    private String ToWordsRu(Object value, Boolean male, String one, String two, String many)
    {
      return FastReport.Functions.StdFunctions.ToWordsRu(value, male, one, two, many);
    }

    private Object Choose(Double index, params Object[] choice)
    {
      return FastReport.Functions.StdFunctions.Choose(index, choice);
    }

    private Object IIf(Boolean expression, Object truePart, Object falsePart)
    {
      return FastReport.Functions.StdFunctions.IIf(expression, truePart, falsePart);
    }

    private Object Switch(params Object[] expressions)
    {
      return FastReport.Functions.StdFunctions.Switch(expressions);
    }

    private Boolean IsNull(String name)
    {
      return FastReport.Functions.StdFunctions.IsNull(Report, name);
    }

    private void InitializeComponent()
    {
      string reportString = 
        "﻿<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Report ScriptLanguage=\"CSharp\" ReportI" +
        "nfo.Created=\"01/02/2021 17:02:26\" ReportInfo.Modified=\"01/10/2021 23:59:54\" Repo" +
        "rtInfo.CreatorVersion=\"2018.2.0.0\">\r\n  <Dictionary>\r\n    <MsSqlDataConnection Na" +
        "me=\"Connection\" ConnectionString=\"rijcmlqAFHGp6KQj27H4qUwAIR20sUt9jj9MtiBYtz42Tr" +
        "kUUaO4rkF9yLBvaAJ2uTl6d2wUf8yByNwQUjoS08YDg2ei9qlbKdtmXj/SOhVQfqjDwp2BL4fqnSsMSb" +
        "Oo40Z2NnP2fBJJqQ0YhkCEvhWqTIS3o04MH4IVsFdrutInnexUdUlWF4bUjJ0CHUX3fDGyZ5f5KRe3Sm" +
        "MEjUoMo9Z8PWc4g==\" ConnectionStringExpression=\"[ConnectString]\">\r\n      <TableDa" +
        "taSource Name=\"Table\" DataType=\"System.Int32\" Enabled=\"true\" SelectCommand=\"decl" +
        "are @start datetime = @StartDate &#13;&#10;declare @end datetime = @EndDate&#13;" +
        "&#10;declare @fuelId int = @IdFuel&#13;&#10;&#13;&#10;select fuel.FuelMark, stat" +
        "es.Pressure, states.Temperature, &#13;&#10;states.CheckingDate&#13;&#10;from dbo" +
        ".Fuel as fuel &#13;&#10;left join dbo.FuelState as states on states.FuelId = fue" +
        "l.Id &#13;&#10;where fuel.Id = @fuelId and states.CheckingDate &gt;= @start and " +
        "&#13;&#10;states.CheckingDate &lt;= @end\">\r\n        <Column Name=\"FuelMark\" Data";
      reportString += "Type=\"System.String\"/>\r\n        <Column Name=\"Pressure\" DataType=\"System.Single\"" +
        "/>\r\n        <Column Name=\"Temperature\" DataType=\"System.Single\"/>\r\n        <Colu" +
        "mn Name=\"CheckingDate\" DataType=\"System.DateTime\"/>\r\n        <CommandParameter N" +
        "ame=\"StartDate\" DataType=\"22\" Size=\"20\"/>\r\n        <CommandParameter Name=\"EndDa" +
        "te\" DataType=\"22\" Size=\"20\"/>\r\n        <CommandParameter Name=\"IdFuel\" DataType=" +
        "\"22\" Size=\"10\"/>\r\n      </TableDataSource>\r\n    </MsSqlDataConnection>\r\n    <Par" +
        "ameter Name=\"DateStart\" DataType=\"System.DateTime\"/>\r\n    <Parameter Name=\"DateE" +
        "nd\" DataType=\"System.DateTime\"/>\r\n    <Parameter Name=\"ConnectString\" DataType=\"" +
        "System.String\"/>\r\n    <Total Name=\"Total\" Expression=\"[Table.Remains]\" Evaluator" +
        "=\"Data1\"/>\r\n  </Dictionary>\r\n  <ReportPage Name=\"Page1\">\r\n    <ReportTitleBand N" +
        "ame=\"ReportTitle1\" Width=\"718.2\" Height=\"37.8\">\r\n      <TextObject Name=\"Text1\" " +
        "Left=\"245.7\" Top=\"18.9\" Width=\"179.55\" Height=\"18.9\" Text=\"Состояние топлива.\" F";
      reportString += "ont=\"Arial, 12pt, style=Bold\"/>\r\n    </ReportTitleBand>\r\n    <PageHeaderBand Nam" +
        "e=\"PageHeader1\" Top=\"41.8\" Width=\"718.2\" Height=\"28.35\">\r\n      <TextObject Name" +
        "=\"Text2\" Left=\"18.9\" Top=\"9.45\" Width=\"132.3\" Height=\"18.9\" Text=\"Отчет за перио" +
        "д с\"/>\r\n      <TextObject Name=\"Text3\" Left=\"151.2\" Top=\"9.45\" Width=\"113.4\" Hei" +
        "ght=\"18.9\" Text=\"[DateStart]\" Format=\"Date\" Format.Format=\"d\"/>\r\n      <TextObje" +
        "ct Name=\"Text4\" Left=\"264.6\" Top=\"9.45\" Width=\"28.35\" Height=\"18.9\" Text=\"по\"/>\r" +
        "\n      <TextObject Name=\"Text5\" Left=\"292.95\" Top=\"9.45\" Width=\"113.4\" Height=\"1" +
        "8.9\" Text=\"[DateEnd]\" Format=\"Date\" Format.Format=\"d\"/>\r\n    </PageHeaderBand>\r\n" +
        "    <ColumnHeaderBand Name=\"ColumnHeader1\" Top=\"74.15\" Width=\"718.2\" Height=\"37." +
        "8\">\r\n      <TableObject Name=\"Table1\" Left=\"18.9\" Top=\"18.9\" Width=\"462.94\" Heig" +
        "ht=\"18.9\">\r\n        <TableColumn Name=\"Column13\" Width=\"54.31\"/>\r\n        <Table" +
        "Column Name=\"Column14\" Width=\"92.11\"/>\r\n        <TableColumn Name=\"Column15\" Wid";
      reportString += "th=\"129.91\"/>\r\n        <TableColumn Name=\"Column16\" Width=\"101.56\"/>\r\n        <T" +
        "ableColumn Name=\"Column17\" Width=\"85.05\"/>\r\n        <TableRow Name=\"Row5\">\r\n    " +
        "      <TableCell Name=\"Cell18\" Border.Lines=\"All\" Border.Width=\"2\" Text=\"№\" Horz" +
        "Align=\"Center\" Font=\"Arial, 9.75pt, style=Bold\"/>\r\n          <TableCell Name=\"Ce" +
        "ll19\" Border.Lines=\"All\" Border.Width=\"2\" Text=\"Марка топлива\" HorzAlign=\"Center" +
        "\" Font=\"Arial, 9.75pt, style=Bold\"/>\r\n          <TableCell Name=\"Cell20\" Border." +
        "Lines=\"All\" Border.Width=\"2\" Text=\"Давление\" HorzAlign=\"Center\" Font=\"Arial, 9.7" +
        "5pt, style=Bold\"/>\r\n          <TableCell Name=\"Cell21\" Border.Lines=\"All\" Border" +
        ".Width=\"2\" Text=\"Температура\" HorzAlign=\"Center\" Font=\"Arial, 9.75pt, style=Bold" +
        "\"/>\r\n          <TableCell Name=\"Cell22\" Border.Lines=\"All\" Border.Width=\"2\" Text" +
        "=\"Дата\" Font=\"Arial, 9.75pt, style=Bold\"/>\r\n        </TableRow>\r\n      </TableOb" +
        "ject>\r\n    </ColumnHeaderBand>\r\n    <DataBand Name=\"Data1\" Top=\"115.95\" Width=\"7";
      reportString += "18.2\" Height=\"94.5\" DataSource=\"Table\">\r\n      <TableObject Name=\"Table1\" Left=\"" +
        "18.9\" Width=\"462.94\" Height=\"18.9\">\r\n        <TableColumn Name=\"Column18\" Width=" +
        "\"54.31\"/>\r\n        <TableColumn Name=\"Column19\" Width=\"92.11\"/>\r\n        <TableC" +
        "olumn Name=\"Column20\" Width=\"129.91\"/>\r\n        <TableColumn Name=\"Column21\" Wid" +
        "th=\"101.56\"/>\r\n        <TableColumn Name=\"Column22\" Width=\"85.05\"/>\r\n        <Ta" +
        "bleRow Name=\"Row6\">\r\n          <TableCell Name=\"Cell23\" Border.Lines=\"All\" Text=" +
        "\"[Row#]№\" HorzAlign=\"Center\" Font=\"Arial, 9.75pt, style=Bold\"/>\r\n          <Tabl" +
        "eCell Name=\"Cell24\" Border.Lines=\"All\" Text=\"[Table.FuelMark]\" HorzAlign=\"Center" +
        "\" Font=\"Arial, 9.75pt, style=Bold\"/>\r\n          <TableCell Name=\"Cell25\" Border." +
        "Lines=\"All\" Text=\"[Table.Pressure]\" HorzAlign=\"Center\" Font=\"Arial, 9.75pt, styl" +
        "e=Bold\"/>\r\n          <TableCell Name=\"Cell26\" Border.Lines=\"All\" Text=\"[Table.Te" +
        "mperature]\" HorzAlign=\"Center\" Font=\"Arial, 9.75pt, style=Bold\"/>\r\n          <Ta";
      reportString += "bleCell Name=\"Cell27\" Border.Lines=\"All\" Text=\"[Table.CheckingDate]\" Format=\"Dat" +
        "e\" Format.Format=\"d\"/>\r\n        </TableRow>\r\n      </TableObject>\r\n    </DataBan" +
        "d>\r\n    <ReportSummaryBand Name=\"ReportSummary1\" Top=\"214.45\" Width=\"718.2\" Heig" +
        "ht=\"37.8\"/>\r\n    <PageFooterBand Name=\"PageFooter1\" Top=\"256.25\" Width=\"718.2\" H" +
        "eight=\"47.25\"/>\r\n  </ReportPage>\r\n</Report>\r\n";
      LoadFromString(reportString);
      InternalInit();
      
    }

    public FuelStateReport()
    {
      InitializeComponent();
    }
  }
}
