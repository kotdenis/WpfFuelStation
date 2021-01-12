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
  public class WayBillReport : Report
  {
    public FastReport.Report Report;
    public FastReport.Engine.ReportEngine Engine;
    public FastReport.DataBand Data1;
    public FastReport.ReportPage Page1;
    public FastReport.PageFooterBand PageFooter1;
    public FastReport.PageHeaderBand PageHeader1;
    public FastReport.ReportSummaryBand ReportSummary1;
    public FastReport.ReportTitleBand ReportTitle1;
    public FastReport.TextObject Text1;
    public FastReport.TextObject Text10;
    public FastReport.TextObject Text11;
    public FastReport.TextObject Text12;
    public FastReport.TextObject Text13;
    public FastReport.TextObject Text14;
    public FastReport.TextObject Text15;
    public FastReport.TextObject Text16;
    public FastReport.TextObject Text17;
    public FastReport.TextObject Text18;
    public FastReport.TextObject Text2;
    public FastReport.TextObject Text3;
    public FastReport.TextObject Text4;
    public FastReport.TextObject Text5;
    public FastReport.TextObject Text6;
    public FastReport.TextObject Text7;
    public FastReport.TextObject Text8;
    public FastReport.TextObject Text9;
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
        "nfo.Created=\"01/02/2021 17:02:26\" ReportInfo.Modified=\"01/10/2021 22:32:49\" Repo" +
        "rtInfo.CreatorVersion=\"2018.2.0.0\">\r\n  <Dictionary>\r\n    <MsSqlDataConnection Na" +
        "me=\"Connection\" ConnectionString=\"rijcmlqAFHGp6KQj27H4qUwAIR20sUt9jj9MtiBYtz42Tr" +
        "kUUaO4rkF9yLBvaAJ2uTl6d2wUf8yByNwQUjoS08YDg2ei9qlbKdtmXj/SOhVQfqjDwp2BL4fqnSsMSb" +
        "Oo40Z2NnP2fBJJqQ0YhkCEvhWqTIS3o04MH4IVsFdrutInnexUdUlWF4bUjJ0CHUX3fDGyZ5f0Buzr6c" +
        "vgmt+jfY46yVJfA==\" ConnectionStringExpression=\"[ConnectString]\">\r\n      <TableDa" +
        "taSource Name=\"Table\" DataType=\"System.Int32\" Enabled=\"true\" SelectCommand=\"decl" +
        "are @wayBillNumber int = @wayNumber&#13;&#10;&#13;&#10;select way.WayBillNumber," +
        " driver.Surname, driver.Name, &#13;&#10;driver.MiddleName, trans.Transport, tran" +
        "s.TransportNumber, &#13;&#10;fuel.FuelMark, way.DepartmentPlace, way.DepartmentD" +
        "ate, &#13;&#10;way.FuelLimit&#13;&#10;from dbo.WayBill as way &#13;&#10;left joi" +
        "n dbo.DriverTransport as drTr on way.Id = drTr.WayBillId &#13;&#10;left join dbo" +
        ".Drivers as driver on drTr.DriverId = driver.Id &#13;&#10;left join dbo.Fuel as ";
      reportString += "fuel on drTr.FuelId = fuel.Id &#13;&#10;left join dbo.TransportVehicle as trans " +
        "on drTr.TransportId = trans.Id &#13;&#10;where way.IsRegistered = 'False' and wa" +
        "y.WayBillNumber = @wayBillNumber\">\r\n        <Column Name=\"WayBillNumber\" DataTyp" +
        "e=\"System.String\"/>\r\n        <Column Name=\"Surname\" DataType=\"System.String\"/>\r\n" +
        "        <Column Name=\"Name\" DataType=\"System.String\"/>\r\n        <Column Name=\"Mi" +
        "ddleName\" DataType=\"System.String\"/>\r\n        <Column Name=\"Transport\" DataType=" +
        "\"System.String\"/>\r\n        <Column Name=\"TransportNumber\" DataType=\"System.Strin" +
        "g\"/>\r\n        <Column Name=\"FuelMark\" DataType=\"System.String\"/>\r\n        <Colum" +
        "n Name=\"DepartmentPlace\" DataType=\"System.String\"/>\r\n        <Column Name=\"Depar" +
        "tmentDate\" DataType=\"System.DateTime\"/>\r\n        <Column Name=\"FuelLimit\" DataTy" +
        "pe=\"System.Single\"/>\r\n        <CommandParameter Name=\"wayNumber\" DataType=\"22\" S" +
        "ize=\"20\"/>\r\n      </TableDataSource>\r\n    </MsSqlDataConnection>\r\n    <Parameter";
      reportString += " Name=\"DateStart\" DataType=\"System.DateTime\"/>\r\n    <Parameter Name=\"DateEnd\" Da" +
        "taType=\"System.DateTime\"/>\r\n    <Parameter Name=\"ConnectString\" DataType=\"System" +
        ".String\"/>\r\n    <Total Name=\"Total\" Expression=\"[Table.Remains]\" Evaluator=\"Data" +
        "1\"/>\r\n  </Dictionary>\r\n  <ReportPage Name=\"Page1\">\r\n    <ReportTitleBand Name=\"R" +
        "eportTitle1\" Width=\"718.2\" Height=\"37.8\">\r\n      <TextObject Name=\"Text1\" Left=\"" +
        "217.35\" Top=\"18.9\" Width=\"151.2\" Height=\"18.9\" Text=\"Путевой лист № \" Font=\"Aria" +
        "l, 12pt, style=Bold\"/>\r\n      <TextObject Name=\"Text9\" Left=\"368.55\" Top=\"18.9\" " +
        "Width=\"122.85\" Height=\"18.9\" Text=\"[Table.WayBillNumber]\" Font=\"Arial, 12pt, sty" +
        "le=Bold\"/>\r\n    </ReportTitleBand>\r\n    <PageHeaderBand Name=\"PageHeader1\" Top=\"" +
        "41.8\" Width=\"718.2\"/>\r\n    <DataBand Name=\"Data1\" Top=\"45.8\" Width=\"718.2\" Heigh" +
        "t=\"292.95\" DataSource=\"Table\">\r\n      <TextObject Name=\"Text2\" Left=\"18.9\" Top=\"" +
        "18.9\" Width=\"94.5\" Height=\"18.9\" Text=\"Водитель:\" Font=\"Arial, 9.75pt, style=Bol";
      reportString += "d\"/>\r\n      <TextObject Name=\"Text3\" Left=\"18.9\" Top=\"56.7\" Width=\"94.5\" Height=" +
        "\"18.9\" Text=\"Транспорт:\" Font=\"Arial, 9.75pt, style=Bold\"/>\r\n      <TextObject N" +
        "ame=\"Text4\" Left=\"18.9\" Top=\"94.5\" Width=\"94.5\" Height=\"18.9\" Text=\"Гос. номер:\"" +
        " Font=\"Arial, 9.75pt, style=Bold\"/>\r\n      <TextObject Name=\"Text5\" Left=\"18.9\" " +
        "Top=\"132.3\" Width=\"113.4\" Height=\"18.9\" Text=\"Марка топлива:\" Font=\"Arial, 9.75p" +
        "t, style=Bold\"/>\r\n      <TextObject Name=\"Text6\" Left=\"18.9\" Top=\"170.1\" Width=\"" +
        "151.2\" Height=\"18.9\" Text=\"Место отправления:\" Font=\"Arial, 9.75pt, style=Bold\"/" +
        ">\r\n      <TextObject Name=\"Text7\" Left=\"18.9\" Top=\"207.9\" Width=\"141.75\" Height=" +
        "\"18.9\" Text=\"Дата отправления:\" Font=\"Arial, 9.75pt, style=Bold\"/>\r\n      <TextO" +
        "bject Name=\"Text8\" Left=\"18.9\" Top=\"245.7\" Width=\"207.9\" Height=\"18.9\" Text=\"Топ" +
        "ливо к заправке (литры):\" Font=\"Arial, 9.75pt, style=Bold\"/>\r\n      <TextObject " +
        "Name=\"Text10\" Left=\"132.3\" Top=\"18.9\" Width=\"132.3\" Height=\"18.9\" Text=\"[Table.S";
      reportString += "urname]\"/>\r\n      <TextObject Name=\"Text11\" Left=\"264.6\" Top=\"18.9\" Width=\"141.7" +
        "5\" Height=\"18.9\" Text=\"[Table.Name]\"/>\r\n      <TextObject Name=\"Text12\" Left=\"40" +
        "6.35\" Top=\"18.9\" Width=\"132.3\" Height=\"18.9\" Text=\"[Table.MiddleName]\"/>\r\n      " +
        "<TextObject Name=\"Text13\" Left=\"132.3\" Top=\"56.7\" Width=\"132.3\" Height=\"18.9\" Te" +
        "xt=\"[Table.Transport]\"/>\r\n      <TextObject Name=\"Text14\" Left=\"132.3\" Top=\"94.5" +
        "\" Width=\"132.3\" Height=\"18.9\" Text=\"[Table.TransportNumber]\"/>\r\n      <TextObjec" +
        "t Name=\"Text15\" Left=\"132.3\" Top=\"132.3\" Width=\"94.5\" Height=\"18.9\" Text=\"[Table" +
        ".FuelMark]\"/>\r\n      <TextObject Name=\"Text16\" Left=\"170.1\" Top=\"170.1\" Width=\"5" +
        "19.75\" Height=\"18.9\" Text=\"[Table.DepartmentPlace]\"/>\r\n      <TextObject Name=\"T" +
        "ext17\" Left=\"160.65\" Top=\"207.9\" Width=\"170.1\" Height=\"18.9\" Text=\"[Table.Depart" +
        "mentDate]\" Format=\"Date\" Format.Format=\"d\"/>\r\n      <TextObject Name=\"Text18\" Le" +
        "ft=\"226.8\" Top=\"245.7\" Width=\"94.5\" Height=\"18.9\" Text=\"[Table.FuelLimit]\"/>\r\n  ";
      reportString += "  </DataBand>\r\n    <ReportSummaryBand Name=\"ReportSummary1\" Top=\"342.75\" Width=\"" +
        "718.2\" Height=\"37.8\"/>\r\n    <PageFooterBand Name=\"PageFooter1\" Top=\"384.55\" Widt" +
        "h=\"718.2\" Height=\"47.25\"/>\r\n  </ReportPage>\r\n</Report>\r\n";
      LoadFromString(reportString);
      InternalInit();
      
    }

    public WayBillReport()
    {
      InitializeComponent();
    }
  }
}
