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
  public class FuelCheck : Report
  {
    public FastReport.Report Report;
    public FastReport.Engine.ReportEngine Engine;
    public FastReport.DataBand Data1;
    public FastReport.ReportPage Page1;
    public FastReport.PageFooterBand PageFooter1;
    public FastReport.PageHeaderBand PageHeader1;
    public FastReport.ReportTitleBand ReportTitle1;
    public FastReport.TextObject Text1;
    public FastReport.TextObject Text10;
    public FastReport.TextObject Text11;
    public FastReport.TextObject Text12;
    public FastReport.TextObject Text13;
    public FastReport.TextObject Text14;
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
        "nfo.Created=\"01/02/2021 12:32:57\" ReportInfo.Modified=\"01/10/2021 19:32:16\" Repo" +
        "rtInfo.CreatorVersion=\"2018.2.0.0\">\r\n  <Dictionary>\r\n    <MsSqlDataConnection Na" +
        "me=\"Connection\" ConnectionString=\"rijcmlqAFHGp6KQj27H4qUwAIR20sUt9jj9MtiBYtz42Tr" +
        "kUUaO4rkF9yLBvaAJ2uTl6d2wUf8yByNwQUjoS08YDg2ei9qlbKdtmXj/SOhVQfqjDwp2BL4fqnSsMSb" +
        "Oo40Z2NnP2fBJJqQ0YhkCEvhWqTIS3o04MH4IVsFdrutInnexUdUlWF4bUjJ0CHUX3fDGyZ5fKaLzJnw" +
        "iPaVmKvNEyGgbZg==\" ConnectionStringExpression=\"[ConnectString]\">\r\n      <TableDa" +
        "taSource Name=\"Table\" DataType=\"System.Int32\" Enabled=\"true\" SelectCommand=\"decl" +
        "are @wayBillId int = @billId&#13;&#10;select driver.Name as Name, driver.MiddleN" +
        "ame as MiddleName, &#13;&#10;driver.Surname as Surname, fuel.FuelMark as FuelMar" +
        "k, &#13;&#10;charge.Quantity as Quantity, charge.TotalPrice as price, &#13;&#10;" +
        "charge.ChargeDate as [Date]&#13;&#10;from dbo.WayBill as way &#13;&#10;join dbo." +
        "Charge as charge on way.Id = charge.WaybillId &#13;&#10;join dbo.DriverTransport" +
        " as drTr on way.Id = drTr.WayBillId&#13;&#10;join dbo.Drivers as driver on drTr.";
      reportString += "DriverId = driver.Id&#13;&#10;join dbo.Fuel as fuel on drTr.FuelId = fuel.Id &#1" +
        "3;&#10;where way.Id = @wayBillId\">\r\n        <Column Name=\"Name\" DataType=\"System" +
        ".String\"/>\r\n        <Column Name=\"MiddleName\" DataType=\"System.String\"/>\r\n      " +
        "  <Column Name=\"Surname\" DataType=\"System.String\"/>\r\n        <Column Name=\"FuelM" +
        "ark\" DataType=\"System.String\"/>\r\n        <Column Name=\"Quantity\" DataType=\"Syste" +
        "m.Single\"/>\r\n        <Column Name=\"price\" DataType=\"System.Decimal\"/>\r\n        <" +
        "Column Name=\"Date\" DataType=\"System.DateTime\"/>\r\n        <CommandParameter Name=" +
        "\"billId\" DataType=\"22\" Size=\"10\"/>\r\n      </TableDataSource>\r\n    </MsSqlDataCon" +
        "nection>\r\n    <Parameter Name=\"ConnectString\" DataType=\"System.String\"/>\r\n  </Di" +
        "ctionary>\r\n  <ReportPage Name=\"Page1\" PaperWidth=\"148.1\" PaperHeight=\"210.1\" Raw" +
        "PaperSize=\"11\" FirstPageSource=\"15\" OtherPagesSource=\"15\">\r\n    <ReportTitleBand" +
        " Name=\"ReportTitle1\" Width=\"484.22\" Height=\"37.8\">\r\n      <TextObject Name=\"Text";
      reportString += "1\" Left=\"141.75\" Top=\"18.9\" Width=\"170.1\" Height=\"18.9\" Text=\"Чек о заправке ТС." +
        "\" Font=\"Arial, 12pt, style=Bold\"/>\r\n    </ReportTitleBand>\r\n    <PageHeaderBand " +
        "Name=\"PageHeader1\" Top=\"41.8\" Width=\"484.22\"/>\r\n    <DataBand Name=\"Data1\" Top=\"" +
        "45.8\" Width=\"484.22\" Height=\"255.15\" DataSource=\"Table\">\r\n      <TextObject Name" +
        "=\"Text2\" Left=\"37.8\" Top=\"28.35\" Width=\"94.5\" Height=\"18.9\" Text=\"Водитель:\" Fon" +
        "t=\"Arial, 9.75pt, style=Bold\"/>\r\n      <TextObject Name=\"Text3\" Left=\"37.8\" Top=" +
        "\"66.15\" Width=\"94.5\" Height=\"18.9\" Text=\"Марка топлива:\" Font=\"Arial, 9.75pt, st" +
        "yle=Bold\"/>\r\n      <TextObject Name=\"Text4\" Left=\"37.8\" Top=\"103.95\" Width=\"94.5" +
        "\" Height=\"18.9\" Text=\"Количество:\" Font=\"Arial, 9.75pt, style=Bold\"/>\r\n      <Te" +
        "xtObject Name=\"Text5\" Left=\"37.8\" Top=\"141.75\" Width=\"94.5\" Height=\"18.9\" Text=\"" +
        "Цена:\" Font=\"Arial, 9.75pt, style=Bold\"/>\r\n      <TextObject Name=\"Text6\" Left=\"" +
        "37.8\" Top=\"179.55\" Width=\"113.4\" Height=\"18.9\" Text=\"Дата заправки:\" Font=\"Arial";
      reportString += ", 9.75pt, style=Bold\"/>\r\n      <TextObject Name=\"Text7\" Left=\"160.65\" Top=\"28.35" +
        "\" Width=\"94.5\" Height=\"18.9\" Text=\"[Table.Name]\"/>\r\n      <TextObject Name=\"Text" +
        "8\" Left=\"160.65\" Top=\"66.15\" Width=\"94.5\" Height=\"18.9\" Text=\"[Table.FuelMark]\"/" +
        ">\r\n      <TextObject Name=\"Text9\" Left=\"255.15\" Top=\"28.35\" Width=\"94.5\" Height=" +
        "\"18.9\" Text=\"[Table.MiddleName]\"/>\r\n      <TextObject Name=\"Text10\" Left=\"349.65" +
        "\" Top=\"28.35\" Width=\"94.5\" Height=\"18.9\" Text=\"[Table.Surname]\"/>\r\n      <TextOb" +
        "ject Name=\"Text11\" Left=\"160.65\" Top=\"103.95\" Width=\"94.5\" Height=\"18.9\" Text=\"[" +
        "Table.Quantity]\"/>\r\n      <TextObject Name=\"Text12\" Left=\"160.65\" Top=\"141.75\" W" +
        "idth=\"94.5\" Height=\"18.9\" Text=\"[Table.price]\"/>\r\n      <TextObject Name=\"Text13" +
        "\" Left=\"160.65\" Top=\"179.55\" Width=\"94.5\" Height=\"18.9\" Text=\"[Table.Date]\"/>\r\n " +
        "     <TextObject Name=\"Text14\" Left=\"132.3\" Top=\"217.35\" Width=\"189\" Height=\"18." +
        "9\" Text=\"Спасибо за заправку!\" Font=\"Arial, 12pt, style=Bold\"/>\r\n    </DataBand>";
      reportString += "\r\n    <PageFooterBand Name=\"PageFooter1\" Top=\"304.95\" Width=\"484.22\" Height=\"37." +
        "8\"/>\r\n  </ReportPage>\r\n</Report>\r\n";
      LoadFromString(reportString);
      InternalInit();
      
    }

    public FuelCheck()
    {
      InitializeComponent();
    }
  }
}
