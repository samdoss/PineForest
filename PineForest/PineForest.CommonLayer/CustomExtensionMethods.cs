using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace PineForest.CommonLayer
{
  public static class CustomExtensionMethods
  {
    public static object cxBooleanChoice2BitValue(this E_BooleanChoice pBooleanChoice)
    {
      return CustomFunctions.BooleanChoice2BitValue(pBooleanChoice);
    }

    //public static S_RectangleSize cxBoundRectangleSize(this S_RectangleSize pOriginalSize, S_RectangleSize pTargetSize)
    //{
    //  return CustomFunctions.BoundRectangleSize(pOriginalSize, pTargetSize);
    //}

    public static int cxCalculateAge(this DateTime pCalculateDate)
    {
      return CustomFunctions.CalculateAge(DateTime.Now, pCalculateDate);
    }

    public static int cxCalculateAge(this DateTime pCalculateDate, DateTime pReferenceDate)
    {
      return CustomFunctions.CalculateAge(pReferenceDate, pCalculateDate);
    }

    public static StringBuilder cxClearStringBuilder(this StringBuilder pStringBuilder)
    {
      return CustomFunctions.ClearStringBuilder(pStringBuilder);
    }

    public static void cxCloseDatabaseConnection(this SqlConnection pConnection)
    {
      CustomFunctions.CloseDatabaseConnection(pConnection);
    }

    public static void cxCloseDataReader(this SqlDataReader pDataReader)
    {
      CustomFunctions.CloseDataReader(pDataReader);
    }

    public static DateTime cxDateTimeToDate(this DateTime pDateTime)
    {
      return CustomFunctions.DateTimeToDate(pDateTime);
    }

    public static DateTime cxDateTimeToDate(this DateTime pDateTime, DateTime pDefaultValue)
    {
      return CustomFunctions.DateTimeToDate(pDateTime, pDefaultValue);
    }

    public static short cxDefaultIfEmptyOrNull(this byte pValue, byte pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue);
    }

    public static decimal cxDefaultIfEmptyOrNull(this decimal pValue, decimal pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue);
    }

    public static double cxDefaultIfEmptyOrNull(this double pValue, double pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue);
    }

    public static short cxDefaultIfEmptyOrNull(this short pValue, short pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue);
    }

    public static int cxDefaultIfEmptyOrNull(this int pValue, int pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue);
    }

    public static long cxDefaultIfEmptyOrNull(this long pValue, long pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue);
    }

    public static string cxDefaultIfEmptyOrNull(this string pValue, string pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue);
    }

    public static short cxDefaultIfEmptyOrNull(this byte pValue, byte pDefaultValue, byte pEmptyValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue, pEmptyValue);
    }

    public static decimal cxDefaultIfEmptyOrNull(this decimal pValue, decimal pDefaultValue, decimal pEmptyValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue, pEmptyValue);
    }

    public static double cxDefaultIfEmptyOrNull(this double pValue, double pDefaultValue, double pEmptyValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue, pEmptyValue);
    }

    public static short cxDefaultIfEmptyOrNull(this short pValue, short pDefaultValue, short pEmptyValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue, pEmptyValue);
    }

    public static int cxDefaultIfEmptyOrNull(this int pValue, int pDefaultValue, int pEmptyValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue, pEmptyValue);
    }

    public static long cxDefaultIfEmptyOrNull(this long pValue, long pDefaultValue, long pEmptyValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull(pValue, pDefaultValue, pEmptyValue);
    }

    public static DateTime cxDefaultIfEmptyOrNull_DateTime(this DateTime pValue, DateTime pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull_DateTime(pValue, pDefaultValue);
    }

    public static object cxDefaultIfEmptyOrNull_DateTime(this object pValue, object pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull_DateTime(pValue, pDefaultValue);
    }

    public static DateTime cxDefaultIfEmptyOrNull_DateTime(this DateTime pValue, DateTime pDefaultValue, DateTime pEmptyValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNull_DateTime(pValue, pDefaultValue, pEmptyValue);
    }

    public static short cxDefaultIfEmptyOrNullU(this byte pValue, byte pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNullU(pValue, pDefaultValue);
    }

    public static short cxDefaultIfEmptyOrNullU(this short pValue, short pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNullU(pValue, pDefaultValue);
    }

    public static int cxDefaultIfEmptyOrNullU(this int pValue, int pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNullU(pValue, pDefaultValue);
    }

    public static long cxDefaultIfEmptyOrNullU(this long pValue, long pDefaultValue)
    {
      return CustomFunctions.DefaultIfEmptyOrNullU(pValue, pDefaultValue);
    }

    public static bool cxEqualValues(this string pValue1, string pValue2)
    {
      return CustomFunctions.EqualValues(pValue1, pValue2);
    }

    public static bool cxEqualValues(this string pValue1, string pValue2, bool pCaseSensitive)
    {
      return CustomFunctions.EqualValues(pValue1, pValue2, pCaseSensitive);
    }

    public static string cxGetFullWebExceptionMessage(this Exception ex, string pMessageSeperatorText)
    {
      return CustomFunctions.GetFullWebExceptionMessage(ex, pMessageSeperatorText);
    }

    public static string cxGetFullWinExceptionMessage(this Exception ex)
    {
      return CustomFunctions.GetFullWinExceptionMessage(ex);
    }

    public static bool cxHasValue(this object pValue)
    {
      return CustomFunctions.HasValue(pValue);
    }

    public static string cxLeftString(this string pValue, int pLength)
    {
      return CustomFunctions.LeftString(pValue, pLength);
    }

    public static string cxLeftString(this string pValue, int pLength, string pDefaultValue)
    {
      return CustomFunctions.LeftString(pValue, pLength, pDefaultValue);
    }

    public static bool cxNotEqualOrAllEmpty(this byte pValue1, byte pValue2)
    {
      return CustomFunctions.NotEqualOrAllEmpty((int)pValue1, (int)pValue2);
    }

    public static bool cxNotEqualOrAllEmpty(this decimal pValue1, decimal pValue2)
    {
      return CustomFunctions.NotEqualOrAllEmpty(pValue1, pValue2);
    }

    public static bool cxNotEqualOrAllEmpty(this double pValue1, double pValue2)
    {
      return CustomFunctions.NotEqualOrAllEmpty(pValue1, pValue2);
    }

    public static bool cxNotEqualOrAllEmpty(this short pValue1, short pValue2)
    {
      return CustomFunctions.NotEqualOrAllEmpty((int)pValue1, (int)pValue2);
    }

    public static bool cxNotEqualOrAllEmpty(this int pValue1, int pValue2)
    {
      return CustomFunctions.NotEqualOrAllEmpty(pValue1, pValue2);
    }

    public static bool cxNotEqualOrAllEmpty(this long pValue1, long pValue2)
    {
      return CustomFunctions.NotEqualOrAllEmpty(pValue1, pValue2);
    }

    public static bool cxNotEqualOrAllEmpty(this string pValue1, string pValue2)
    {
      return CustomFunctions.NotEqualOrAllEmpty(pValue1, pValue2);
    }

    public static bool cxNotEqualOrAllEmpty(this byte pValue1, byte pValue2, byte pEmptyValue)
    {
      return CustomFunctions.NotEqualOrAllEmpty((int)pValue1, (int)pValue2, (int)pEmptyValue);
    }

    public static bool cxNotEqualOrAllEmpty(this decimal pValue1, decimal pValue2, decimal pEmptyValue)
    {
      return CustomFunctions.NotEqualOrAllEmpty(pValue1, pValue2, pEmptyValue);
    }

    public static bool cxNotEqualOrAllEmpty(this double pValue1, double pValue2, double pEmptyValue)
    {
      return CustomFunctions.NotEqualOrAllEmpty(pValue1, pValue2, pEmptyValue);
    }

    public static bool cxNotEqualOrAllEmpty(this short pValue1, short pValue2, short pEmptyValue)
    {
      return CustomFunctions.NotEqualOrAllEmpty((int)pValue1, (int)pValue2, (int)pEmptyValue);
    }

    public static bool cxNotEqualOrAllEmpty(this int pValue1, int pValue2, int pEmptyValue)
    {
      return CustomFunctions.NotEqualOrAllEmpty(pValue1, pValue2, pEmptyValue);
    }

    public static bool cxNotEqualOrAllEmpty(this long pValue1, long pValue2, long pEmptyValue)
    {
      return CustomFunctions.NotEqualOrAllEmpty(pValue1, pValue2, pEmptyValue);
    }

    public static bool cxNotEqualOrAllEmpty_DateTime(this DateTime pValue1, DateTime pValue2)
    {
      return CustomFunctions.NotEqualOrAllEmpty_DateTime(pValue1, pValue2);
    }

    public static bool cxNotEqualOrAllEmpty_DateTime(this DateTime pValue1, DateTime pValue2, DateTime pEmptyDateTimeValue)
    {
      return CustomFunctions.NotEqualOrAllEmpty_DateTime(pValue1, pValue2, pEmptyDateTimeValue);
    }

    public static void cxOpenDatabaseConnection(this SqlConnection pConnection)
    {
      CustomFunctions.OpenDatabaseConnection(pConnection);
    }

    //public static object cxRecordStatus2BitValue(this E_RecordStatus pRecordStatus)
    //{
    //  return CustomFunctions.RecordStatus2BitValue(pRecordStatus);
    //}

    public static string cxReplPineStringCharacter(this string pSourceString, string pNewValue, int pReplPinePosition)
    {
      return CustomFunctions.ReplPineStringCharacter(pSourceString, pNewValue, pReplPinePosition);
    }

    //public static S_RectangleSize cxResizeRectangle(this S_RectangleSize pOriginalSize, S_RectangleSize pTargetSize, E_RectangleResizeAction pRectangleResizeAction)
    //{
    //  return CustomFunctions.ResizeRectangle(pOriginalSize, pTargetSize, pRectangleResizeAction);
    //}

    public static string cxReverseString(this string pValue)
    {
      char[] array = pValue.ToCharArray();
      Array.Reverse(array);
      return new string(array);
    }

    public static string cxRightString(this string pValue, int pLength)
    {
      return CustomFunctions.RightString(pValue, pLength);
    }

    public static string cxRightString(this string pValue, int pLength, string pDefaultValue)
    {
      return CustomFunctions.RightString(pValue, pLength, pDefaultValue);
    }

    public static object cxStringBitToBitValue(this string pStringBitValue)
    {
      return CustomFunctions.StringBitToBitValue(pStringBitValue);
    }

    public static string cxSubString(this string pValue, int pStartIndex)
    {
      return CustomFunctions.SubString(pValue, pStartIndex);
    }

    public static string cxSubString(this string pValue, int pStartIndex, int pLength)
    {
      return CustomFunctions.SubString(pValue, pStartIndex, pLength);
    }

    public static string cxSubString(this string pValue, int pStartIndex, string pDefaultValue)
    {
      return CustomFunctions.SubString(pValue, pStartIndex, pDefaultValue);
    }

    public static string cxSubString(this string pValue, int pStartIndex, int pLength, string pDefaultValue)
    {
      return CustomFunctions.SubString(pValue, pStartIndex, pLength, pDefaultValue);
    }

    public static string cxToBitString(this bool pValue)
    {
      return CustomFunctions.ToBitString(pValue);
    }

    public static string cxToBitString(this string pValue)
    {
      return CustomFunctions.ToBitString(pValue);
    }

    public static bool cxToBoolean(this int pValue)
    {
      return CustomFunctions.ToBoolean(pValue);
    }

    public static bool cxToBoolean(this object pValue)
    {
      return CustomFunctions.ToBoolean(pValue);
    }

    public static bool cxToBoolean(this string pValue)
    {
      return CustomFunctions.ToBoolean(pValue);
    }

    public static bool cxToBoolean(this int pValue, int pTrueValue)
    {
      return CustomFunctions.ToBoolean(pValue, pTrueValue);
    }

    public static bool cxToBoolean(this object pValue, bool pDefault)
    {
      return CustomFunctions.ToBoolean(pValue, pDefault);
    }

    public static byte cxToByte(this object pValue)
    {
      return CustomFunctions.ToByte(pValue);
    }

    public static byte cxToByte(this object pValue, byte pDefault)
    {
      return CustomFunctions.ToByte(pValue, pDefault);
    }

    public static DateTime cxToDateTime(this object pValue)
    {
      return CustomFunctions.ToDateTime(pValue);
    }

    public static DateTime cxToDateTime(this object pValue, DateTime pDefault)
    {
      return CustomFunctions.ToDateTime(pValue, pDefault);
    }

    public static object cxToDbValue(this byte pValue)
    {
      return CustomFunctions.ToDbValue(pValue);
    }

    public static object cxToDbValue(this decimal pValue)
    {
      return CustomFunctions.ToDbValue(pValue);
    }

    public static object cxToDbValue(this double pValue)
    {
      return CustomFunctions.ToDbValue(pValue);
    }

    public static object cxToDbValue(this short pValue)
    {
      return CustomFunctions.ToDbValue(pValue);
    }

    public static object cxToDbValue(this int pValue)
    {
      return CustomFunctions.ToDbValue(pValue);
    }

    public static object cxToDbValue(this long pValue)
    {
      return CustomFunctions.ToDbValue(pValue);
    }

    public static object cxToDbValue(this string pValue)
    {
      return CustomFunctions.ToDbValue(pValue);
    }

    public static object cxToDbValue(this byte pValue, byte pEmptyValue)
    {
      return CustomFunctions.ToDbValue((short)pValue, (short)pEmptyValue);
    }

    public static object cxToDbValue(this decimal pValue, decimal pEmptyValue)
    {
      return CustomFunctions.ToDbValue(pValue, pEmptyValue);
    }

    public static object cxToDbValue(this double pValue, double pEmptyValue)
    {
      return CustomFunctions.ToDbValue(pValue, pEmptyValue);
    }

    public static object cxToDbValue(this short pValue, short pEmptyValue)
    {
      return CustomFunctions.ToDbValue(pValue, pEmptyValue);
    }

    public static object cxToDbValue(this int pValue, int pEmptyValue)
    {
      return CustomFunctions.ToDbValue(pValue, pEmptyValue);
    }

    public static object cxToDbValue(this long pValue, long pEmptyValue)
    {
      return CustomFunctions.ToDbValue(pValue, pEmptyValue);
    }

    public static object cxToDbValue_DateTime(this DateTime pValue)
    {
      return CustomFunctions.ToDbValue_DateTime(pValue);
    }

    public static object cxToDbValue_DateTime(this DateTime pValue, DateTime pEmptyValue)
    {
      return CustomFunctions.ToDbValue_DateTime(pValue, pEmptyValue);
    }

    public static object cxToDbValueU(this byte pValue)
    {
      return CustomFunctions.ToDbValueU(pValue);
    }

    public static object cxToDbValueU(this short pValue)
    {
      return CustomFunctions.ToDbValueU(pValue);
    }

    public static object cxToDbValueU(this int pValue)
    {
      return CustomFunctions.ToDbValueU(pValue);
    }

    public static object cxToDbValueU(this long pValue)
    {
      return CustomFunctions.ToDbValueU(pValue);
    }

    public static decimal cxToDecimal(this object pValue)
    {
      return CustomFunctions.ToDecimal(pValue);
    }

    public static decimal cxToDecimal(this object pValue, decimal pDefault)
    {
      return CustomFunctions.ToDecimal(pValue, pDefault);
    }

    public static double cxToDouble(this object pValue)
    {
      return CustomFunctions.ToDouble(pValue);
    }

    public static double cxToDouble(this object pValue, double pDefault)
    {
      return CustomFunctions.ToDouble(pValue, pDefault);
    }

    public static short cxToInt16(this object pValue)
    {
      return CustomFunctions.ToInt16(pValue);
    }

    public static short cxToInt16(this object pValue, short pDefault)
    {
      return CustomFunctions.ToInt16(pValue, pDefault);
    }

    public static int cxToInt32(this object pValue)
    {
      return CustomFunctions.ToInt32(pValue);
    }

    public static int cxToInt32(this object pValue, int pDefault)
    {
      return CustomFunctions.ToInt32(pValue, pDefault);
    }

    public static long cxToInt64(this object pValue)
    {
      return CustomFunctions.ToInt64(pValue);
    }

    public static long cxToInt64(this object pValue, long pDefault)
    {
      return CustomFunctions.ToInt64(pValue, pDefault);
    }

    public static string cxToSqlDataXML(this List<short> pDataList, string pXmlDataElementName)
    {
      return CustomFunctions.ToSqlDataXML(pDataList, pXmlDataElementName);
    }

    public static string cxToSqlDataXML(this List<int> pDataList, string pXmlDataElementName)
    {
      return CustomFunctions.ToSqlDataXML(pDataList, pXmlDataElementName);
    }

    public static string cxToSqlDataXML(this List<long> pDataList, string pXmlDataElementName)
    {
      return CustomFunctions.ToSqlDataXML(pDataList, pXmlDataElementName);
    }

    public static string cxToSqlDataXML(this List<string> pDataList, string pXmlDataElementName)
    {
      return CustomFunctions.ToSqlDataXML(pDataList, pXmlDataElementName);
    }

    public static string cxToString(this object pValue)
    {
      return CustomFunctions.ToString(pValue);
    }

    public static string cxToString(this object pValue, string pDefault)
    {
      return CustomFunctions.ToString(pValue, pDefault);
    }
  
    public static string cxToString_DateTime(this DateTime pDateTime, string pDateFormat)
    {
      return CustomFunctions.ToString_DateTime(pDateTime, pDateFormat);
    }

    public static bool cxUValueIsEmpty(this byte pValue)
    {
      return CustomFunctions.UValueIsEmpty(pValue);
    }

    public static bool cxUValueIsEmpty(this short pValue)
    {
      return CustomFunctions.UValueIsEmpty(pValue);
    }

    public static bool cxUValueIsEmpty(this int pValue)
    {
      return CustomFunctions.UValueIsEmpty(pValue);
    }

    public static bool cxUValueIsEmpty(this long pValue)
    {
      return CustomFunctions.UValueIsEmpty(pValue);
    }

    public static bool cxUValueNotEmpty(this byte pValue)
    {
      return CustomFunctions.UValueNotEmpty(pValue);
    }

    public static bool cxUValueNotEmpty(this short pValue)
    {
      return CustomFunctions.UValueNotEmpty(pValue);
    }

    public static bool cxUValueNotEmpty(this int pValue)
    {
      return CustomFunctions.UValueNotEmpty(pValue);
    }

    public static bool cxUValueNotEmpty(this long pValue)
    {
      return CustomFunctions.UValueNotEmpty(pValue);
    }

    public static bool cxUValueNullOrEmpty(this byte pValue)
    {
      return CustomFunctions.UValueNullOrEmpty(pValue);
    }

    public static bool cxUValueNullOrEmpty(this short pValue)
    {
      return CustomFunctions.UValueNullOrEmpty(pValue);
    }

    public static bool cxUValueNullOrEmpty(this int pValue)
    {
      return CustomFunctions.UValueNullOrEmpty(pValue);
    }

    public static bool cxUValueNullOrEmpty(this long pValue)
    {
      return CustomFunctions.UValueNullOrEmpty(pValue);
    }

    public static bool cxValueIsEmpty(this byte pValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue);
    }

    public static bool cxValueIsEmpty(this decimal pValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue);
    }

    public static bool cxValueIsEmpty(this double pValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue);
    }

    public static bool cxValueIsEmpty(this short pValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue);
    }

    public static bool cxValueIsEmpty(this int pValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue);
    }

    public static bool cxValueIsEmpty(this long pValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue);
    }

    public static bool cxValueIsEmpty(this object pValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue);
    }

    public static bool cxValueIsEmpty(this string pValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue);
    }

    public static bool cxValueIsEmpty(this byte pValue, byte pEmptyValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueIsEmpty(this decimal pValue, decimal pEmptyValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueIsEmpty(this double pValue, double pEmptyValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueIsEmpty(this short pValue, short pEmptyValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueIsEmpty(this int pValue, int pEmptyValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueIsEmpty(this long pValue, long pEmptyValue)
    {
      return CustomFunctions.ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueIsEmpty_DateTime(this DateTime pValue)
    {
      return CustomFunctions.ValueIsEmpty_DateTime(pValue);
    }

    public static bool cxValueIsEmpty_DateTime(this DateTime pValue, DateTime pEmptyValue)
    {
      return CustomFunctions.ValueIsEmpty_DateTime(pValue, pEmptyValue);
    }

    public static bool cxValueIsNull(this object pValue)
    {
      return CustomFunctions.ValueIsNull(pValue);
    }

    public static bool cxValueIsNull_DateTime(this DateTime pValue)
    {
      return CustomFunctions.ValueIsNull_DateTime(pValue);
    }

    public static bool cxValueNotEmpty(this byte pValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue);
    }

    public static bool cxValueNotEmpty(this decimal pValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue);
    }

    public static bool cxValueNotEmpty(this double pValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue);
    }

    public static bool cxValueNotEmpty(this short pValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue);
    }

    public static bool cxValueNotEmpty(this int pValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue);
    }

    public static bool cxValueNotEmpty(this long pValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue);
    }

    public static bool cxValueNotEmpty(this object pValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue);
    }

    public static bool cxValueNotEmpty(this string pValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue);
    }

    public static bool cxValueNotEmpty(this byte pValue, byte pEmptyValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNotEmpty(this decimal pValue, decimal pEmptyValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNotEmpty(this double pValue, double pEmptyValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNotEmpty(this short pValue, short pEmptyValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNotEmpty(this int pValue, int pEmptyValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNotEmpty(this long pValue, long pEmptyValue)
    {
      return CustomFunctions.ValueNotEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNotEmpty_DateTime(this DateTime pValue)
    {
      return CustomFunctions.ValueNotEmpty_DateTime(pValue);
    }

    public static bool cxValueNotEmpty_DateTime(this DateTime pValue, DateTime pEmptyValue)
    {
      return CustomFunctions.ValueNotEmpty_DateTime(pValue, pEmptyValue);
    }

    public static bool cxValueNotNull(this object pValue)
    {
      return CustomFunctions.ValueNotNull(pValue);
    }

    public static bool cxValueNotNull_DateTime(this DateTime pValue)
    {
      return CustomFunctions.ValueNotNull_DateTime(pValue);
    }

    public static bool cxValueNullOrEmpty(this byte pValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue);
    }

    public static bool cxValueNullOrEmpty(this decimal pValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue);
    }

    public static bool cxValueNullOrEmpty(this double pValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue);
    }

    public static bool cxValueNullOrEmpty(this short pValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue);
    }

    public static bool cxValueNullOrEmpty(this int pValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue);
    }

    public static bool cxValueNullOrEmpty(this long pValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue);
    }

    public static bool cxValueNullOrEmpty(this string pValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue);
    }

    public static bool cxValueNullOrEmpty(this byte pValue, byte pEmptyValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNullOrEmpty(this decimal pValue, decimal pEmptyValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNullOrEmpty(this double pValue, double pEmptyValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNullOrEmpty(this short pValue, short pEmptyValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNullOrEmpty(this int pValue, int pEmptyValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNullOrEmpty(this long pValue, long pEmptyValue)
    {
      return CustomFunctions.ValueNullOrEmpty(pValue, pEmptyValue);
    }

    public static bool cxValueNullOrEmpty_DateTime(this DateTime pValue)
    {
      return CustomFunctions.ValueNullOrEmpty_DateTime(pValue);
    }

    public static bool cxValueNullOrEmpty_DateTime(this DateTime pValue, DateTime pEmptyValue)
    {
      return CustomFunctions.ValueNullOrEmpty_DateTime(pValue, pEmptyValue);
    }
  }
 
  public enum E_BooleanChoice
  {
    Any = -1,
    False = 0,
    True = 1
  }

  public abstract class CustomFunctions
  {
    // Methods
    protected CustomFunctions()
    {
    }

    public static ArrayList BindEnumeration(Type _enum)
    {
      string[] names = Enum.GetNames(_enum);
      int[] values = (int[])Enum.GetValues(_enum);
      ArrayList list = new ArrayList();
      for (int i = 0; i <= (names.Length - 1); i++)
      {
        list.Add(new EnumerationItem(values[i].ToString(), names[i]));
      }
      return list;
    }

    public static object BooleanChoice2BitValue(E_BooleanChoice pBooleanChoice)
    {
      switch (pBooleanChoice)
      {
        case E_BooleanChoice.False:
          return false;

        case E_BooleanChoice.True:
          return true;
      }
      return DBNull.Value;
    }


    public static int CalculateAge(DateTime pCalculateDate)
    {
      return CalculateAge(DateTime.Now, pCalculateDate);
    }

    public static int CalculateAge(DateTime pReferenceDate, DateTime pCalculateDate)
    {
      int num = pReferenceDate.Year - pCalculateDate.Year;
      if ((pReferenceDate.Month < pCalculateDate.Month) || ((pReferenceDate.Month == pCalculateDate.Month) && (pReferenceDate.Day < pCalculateDate.Day)))
      {
        num--;
      }
      return num;
    }

    //public static string CalculateCRC(string Value)
    //{
    //  string str = string.Empty;
    //  MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
    //  byte[] bytes = Encoding.ASCII.GetBytes(Value);
    //  bytes = provider.ComputeHash(bytes);
    //  for (int i = 0; i < bytes.Length; i++)
    //  {
    //    str = str + bytes[i].ToString("x2").ToLower();
    //  }
    //  return str;
    //}

    public static StringBuilder ClearStringBuilder(StringBuilder pStringBuilder)
    {
      return pStringBuilder.Remove(0, pStringBuilder.Length);
    }

    public static void CloseDatabaseConnection(SqlConnection pConnection)
    {
      if ((pConnection != null) && (pConnection.State == ConnectionState.Open))
      {
        pConnection.Close();
      }
    }

    public static void CloseDataReader(SqlDataReader pDataReader)
    {
      if ((pDataReader != null) && !pDataReader.IsClosed)
      {
        pDataReader.Close();
      }
    }

    public static DateTime DateTimeToDate(DateTime pDateTime)
    {
      return DateTimeToDate(pDateTime, EmptyDateTime);
    }

    public static DateTime DateTimeToDate(DateTime pDateTime, DateTime pDefaultValue)
    {
      return ToDateTime(pDateTime.ToString("MM/dd/yyyy"), pDefaultValue);
    }

    public static object DBNullValidateValue(decimal pValue)
    {
      object obj2 = pValue;
      if (ValueIsEmpty(pValue))
      {
        obj2 = DBNull.Value;
      }
      return obj2;
    }

    public static object DBNullValidateValue(double pValue)
    {
      object obj2 = pValue;
      if (ValueIsEmpty(pValue))
      {
        obj2 = DBNull.Value;
      }
      return obj2;
    }

    public static object DBNullValidateValue(short pValue)
    {
      object obj2 = pValue;
      if (ValueIsEmpty(pValue))
      {
        obj2 = DBNull.Value;
      }
      return obj2;
    }

    public static object DBNullValidateValue(int pValue)
    {
      object obj2 = pValue;
      if (ValueIsEmpty(pValue))
      {
        obj2 = DBNull.Value;
      }
      return obj2;
    }

    public static object DBNullValidateValue(long pValue)
    {
      object obj2 = pValue;
      if (ValueIsEmpty(pValue))
      {
        obj2 = DBNull.Value;
      }
      return obj2;
    }

    public static object DBNullValidateValue(string pValue)
    {
      object obj2 = pValue;
      if (ValueIsEmpty(pValue))
      {
        obj2 = DBNull.Value;
      }
      return obj2;
    }

    public static object DBNullValidateValue_DateTime(DateTime pValue)
    {
      object obj2 = pValue;
      if (ValueIsEmpty_DateTime(pValue))
      {
        obj2 = DBNull.Value;
      }
      return obj2;
    }

    public static byte DefaultIfEmptyOrNull(byte pValue, byte pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static decimal DefaultIfEmptyOrNull(decimal pValue, decimal pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static double DefaultIfEmptyOrNull(double pValue, double pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static short DefaultIfEmptyOrNull(short pValue, short pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static int DefaultIfEmptyOrNull(int pValue, int pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static long DefaultIfEmptyOrNull(long pValue, long pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static string DefaultIfEmptyOrNull(string pValue, string pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
        //return "--";
      }
      return pValue;
    }

    public static byte DefaultIfEmptyOrNull(byte pValue, byte pDefaultValue, byte pEmptyValue)
    {
      if (ValueIsEmpty(pValue, pEmptyValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static decimal DefaultIfEmptyOrNull(decimal pValue, decimal pDefaultValue, decimal pEmptyValue)
    {
      if (ValueIsEmpty(pValue, pEmptyValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static double DefaultIfEmptyOrNull(double pValue, double pDefaultValue, double pEmptyValue)
    {
      if (ValueIsEmpty(pValue, pEmptyValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static short DefaultIfEmptyOrNull(short pValue, short pDefaultValue, short pEmptyValue)
    {
      if (ValueIsEmpty(pValue, pEmptyValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static int DefaultIfEmptyOrNull(int pValue, int pDefaultValue, int pEmptyValue)
    {
      if (ValueIsEmpty(pValue, pEmptyValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static long DefaultIfEmptyOrNull(long pValue, long pDefaultValue, long pEmptyValue)
    {
      if (ValueIsEmpty(pValue, pEmptyValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static DateTime DefaultIfEmptyOrNull_DateTime(DateTime pValue, DateTime pDefaultValue)
    {
      if (ValueIsEmpty_DateTime(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static object DefaultIfEmptyOrNull_DateTime(object pValue, object pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static DateTime DefaultIfEmptyOrNull_DateTime(DateTime pValue, DateTime pDefaultValue, DateTime pEmptyValue)
    {
      if (ValueIsEmpty_DateTime(pValue, pEmptyValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static byte DefaultIfEmptyOrNullU(byte pValue, byte pDefaultValue)
    {
      if (UValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static short DefaultIfEmptyOrNullU(short pValue, short pDefaultValue)
    {
      if (UValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static int DefaultIfEmptyOrNullU(int pValue, int pDefaultValue)
    {
      if (UValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static long DefaultIfEmptyOrNullU(long pValue, long pDefaultValue)
    {
      if (UValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      return pValue;
    }

    public static bool EqualValues(string pValue1, string pValue2)
    {
      return EqualValues(pValue1, pValue2, false);
    }

    public static bool EqualValues(string pValue1, string pValue2, bool pCaseSensitive)
    {
      if (pCaseSensitive)
      {
        return (pValue1.Trim() == pValue2.Trim());
      }
      return (pValue1.ToUpper().Trim() == pValue2.ToUpper().Trim());
    }

    //public static string GetAssemblyVersionNumber(string pAssemblyName)
    //{
    //  string str = "0.0.0.0";
    //  foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
    //  {
    //    AssemblyName name = assembly.GetName();
    //    if (EqualValues(name.Name, pAssemblyName))
    //    {
    //      str = name.Version.ToString();
    //    }
    //  }
    //  return str;
    //}

    public static string GetFullWebExceptionMessage(Exception ex, string pMessageSeperatorText)
    {
      string str = string.Empty;
      for (Exception exception = ex; exception != null; exception = exception.InnerException)
      {
        str = str + exception.Message + pMessageSeperatorText;
      }
      return str;
    }

    public static string GetFullWinExceptionMessage(Exception ex)
    {
      string str = string.Empty;
      for (Exception exception = ex; exception != null; exception = exception.InnerException)
      {
        str = str + exception.Message + Environment.NewLine;
      }
      return str;
    }

    public static bool HasValue(object pValue)
    {
      return (pValue != null);
    }

    public static string LeftString(string pValue, int pLength)
    {
      return LeftString(pValue, pLength, string.Empty);
    }

    public static string LeftString(string pValue, int pLength, string pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      if (pLength > pValue.Length)
      {
        return pValue;
      }
      return pValue.Substring(0, pLength);
    }

    public static bool NotEqualOrAllEmpty(decimal pValue1, decimal pValue2)
    {
      return NotEqualOrAllEmpty(pValue1, pValue2, 0M);
    }

    public static bool NotEqualOrAllEmpty(double pValue1, double pValue2)
    {
      return NotEqualOrAllEmpty(pValue1, pValue2, 0.0);
    }

    public static bool NotEqualOrAllEmpty(int pValue1, int pValue2)
    {
      return NotEqualOrAllEmpty(pValue1, pValue2, 0);
    }

    public static bool NotEqualOrAllEmpty(long pValue1, long pValue2)
    {
      return NotEqualOrAllEmpty(pValue1, pValue2, 0L);
    }

    public static bool NotEqualOrAllEmpty(string pValue1, string pValue2)
    {
      if (!(pValue1.Trim() != pValue2.Trim()))
      {
        return false;
      }
      if (pValue1.Trim() == string.Empty)
      {
        return !(pValue2.Trim() == string.Empty);
      }
      return true;
    }

    public static bool NotEqualOrAllEmpty(decimal pValue1, decimal pValue2, decimal pEmptyValue)
    {
      if (!(pValue1 != pValue2))
      {
        return false;
      }
      if (pValue1 == pEmptyValue)
      {
        return !(pValue2 == pEmptyValue);
      }
      return true;
    }

    public static bool NotEqualOrAllEmpty(double pValue1, double pValue2, double pEmptyValue)
    {
      if (pValue1 == pValue2)
      {
        return false;
      }
      if (pValue1 == pEmptyValue)
      {
        return !(pValue2 == pEmptyValue);
      }
      return true;
    }

    public static bool NotEqualOrAllEmpty(int pValue1, int pValue2, int pEmptyValue)
    {
      if (pValue1 == pValue2)
      {
        return false;
      }
      if (pValue1 == pEmptyValue)
      {
        return (pValue2 != pEmptyValue);
      }
      return true;
    }

    public static bool NotEqualOrAllEmpty(long pValue1, long pValue2, long pEmptyValue)
    {
      if (pValue1 == pValue2)
      {
        return false;
      }
      if (pValue1 == pEmptyValue)
      {
        return (pValue2 != pEmptyValue);
      }
      return true;
    }

    public static bool NotEqualOrAllEmpty_DateTime(DateTime pValue1, DateTime pValue2)
    {
      return NotEqualOrAllEmpty_DateTime(pValue1, pValue2, Convert.ToDateTime((string)null));
    }

    public static bool NotEqualOrAllEmpty_DateTime(DateTime pValue1, DateTime pValue2, DateTime pEmptyDateTimeValue)
    {
      if (!(pValue1 != pValue2))
      {
        return false;
      }
      if (pValue1 == pEmptyDateTimeValue)
      {
        return !(pValue2 == pEmptyDateTimeValue);
      }
      return true;
    }

    public static void OpenDatabaseConnection(SqlConnection pConnection)
    {
      if ((pConnection != null) && (pConnection.State == ConnectionState.Closed))
      {
        pConnection.Open();
      }
    }

    //public static object RecordStatus2BitValue(E_RecordStatus pRecordStatus)
    //{
    //  switch (pRecordStatus)
    //  {
    //    case E_RecordStatus.Inactive:
    //      return false;

    //    case E_RecordStatus.Active:
    //      return true;
    //  }
    //  return DBNull.Value;
    //}

    public static string ReplPineStringCharacter(string pSourceString, string pNewValue, int pReplPinePosition)
    {
      StringBuilder builder = new StringBuilder();
      if (ValueNotEmpty(pSourceString))
      {
        for (int i = 0; i < pSourceString.Length; i++)
        {
          if (i == pReplPinePosition)
          {
            builder.Append(pNewValue);
          }
          else
          {
            builder.Append(pSourceString[i]);
          }
        }
      }
      return builder.ToString();
    }

    //public static S_RectangleSize ResizeRectangle(S_RectangleSize pOriginalSize, S_RectangleSize pTargetSize, E_RectangleResizeAction pRectangleResizeAction)
    //{
    //  decimal num = 1M;
    //  decimal num2 = pOriginalSize.Height * pOriginalSize.Width;
    //  decimal num3 = pTargetSize.Height * pTargetSize.Width;
    //  S_RectangleSize size = new S_RectangleSize(pOriginalSize.Height, pOriginalSize.Width);
    //  if ((num2 > num3) && ((pRectangleResizeAction == E_RectangleResizeAction.EnlargeOrReduce) || (pRectangleResizeAction == E_RectangleResizeAction.ReduceOnly)))
    //  {
    //    if (pOriginalSize.Width >= pOriginalSize.Height)
    //    {
    //      if (pOriginalSize.Width > pTargetSize.Width)
    //      {
    //        num = pOriginalSize.Width / pTargetSize.Width;
    //        size.Width = pTargetSize.Width;
    //        size.Height = pOriginalSize.Height / num;
    //        return size;
    //      }
    //      if (pOriginalSize.Height > pTargetSize.Height)
    //      {
    //        num = pOriginalSize.Height / pTargetSize.Height;
    //        size.Height = pTargetSize.Height;
    //        size.Width = pOriginalSize.Width / num;
    //      }
    //      return size;
    //    }
    //    if (pOriginalSize.Height > pTargetSize.Height)
    //    {
    //      num = pOriginalSize.Height / pTargetSize.Height;
    //      size.Height = pTargetSize.Height;
    //      size.Width = pOriginalSize.Width / num;
    //      return size;
    //    }
    //    if (pOriginalSize.Width > pTargetSize.Width)
    //    {
    //      num = pOriginalSize.Width / pTargetSize.Width;
    //      size.Width = pTargetSize.Width;
    //      size.Height = pOriginalSize.Height / num;
    //    }
    //    return size;
    //  }
    //  if ((num2 < num3) && ((pRectangleResizeAction == E_RectangleResizeAction.EnlargeOrReduce) || (pRectangleResizeAction == E_RectangleResizeAction.EnlargeOnly)))
    //  {
    //    if (pOriginalSize.Width >= pOriginalSize.Height)
    //    {
    //      if (pOriginalSize.Width < pTargetSize.Width)
    //      {
    //        num = pTargetSize.Width / pOriginalSize.Width;
    //        size.Width = pTargetSize.Width;
    //        size.Height = pOriginalSize.Height * num;
    //        return size;
    //      }
    //      if (pOriginalSize.Height < pTargetSize.Height)
    //      {
    //        num = pTargetSize.Height / pOriginalSize.Height;
    //        size.Height = pTargetSize.Height;
    //        size.Width = pOriginalSize.Width * num;
    //      }
    //      return size;
    //    }
    //    if (pOriginalSize.Height < pTargetSize.Height)
    //    {
    //      num = pTargetSize.Height / pOriginalSize.Height;
    //      size.Height = pTargetSize.Height;
    //      size.Width = pOriginalSize.Width * num;
    //      return size;
    //    }
    //    if (pOriginalSize.Width < pTargetSize.Width)
    //    {
    //      num = pTargetSize.Width / pOriginalSize.Width;
    //      size.Width = pTargetSize.Width;
    //      size.Height = pOriginalSize.Height * num;
    //    }
    //  }
    //  return size;
    //}

    public static string ReverseString(string pValue)
    {
      char[] array = pValue.ToCharArray();
      Array.Reverse(array);
      return new string(array);
    }

    public static string RightString(string pValue, int pLength)
    {
      return RightString(pValue, pLength, string.Empty);
    }

    public static string RightString(string pValue, int pLength, string pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      if (pLength > pValue.Length)
      {
        return pValue;
      }
      return pValue.Substring(pValue.Length - pLength);
    }

    public static object StringBitToBitValue(string pStringBitValue)
    {
      string str = pStringBitValue.Trim().ToUpper();
      switch (str)
      {
        case "TRUE":
        case "YES":
        case "T":
        case "Y":
        case "1":
          return true;

        case "FALSE":
        case "NO":
        case "F":
        case "N":
        case "0":
          return false;
      }
      return DBNull.Value;
    }

    public static string SubString(string pValue, int pStartIndex)
    {
      return SubString(pValue, pStartIndex, string.Empty);
    }

    public static string SubString(string pValue, int pStartIndex, int pLength)
    {
      return SubString(pValue, pStartIndex, pLength, string.Empty);
    }

    public static string SubString(string pValue, int pStartIndex, string pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      if (pStartIndex > pValue.Length)
      {
        return pValue;
      }
      return pValue.Substring(pStartIndex);
    }

    public static string SubString(string pValue, int pStartIndex, int pLength, string pDefaultValue)
    {
      if (ValueIsEmpty(pValue))
      {
        return pDefaultValue;
      }
      if (pStartIndex > pValue.Length)
      {
        return pValue;
      }
      if ((pStartIndex + pLength) > pValue.Length)
      {
        return pValue.Substring(pStartIndex);
      }
      return pValue.Substring(pStartIndex, pLength);
    }

    public static string ToBitString(bool pValue)
    {
      if (!pValue)
      {
        return "0";
      }
      return "1";
    }

    public static string ToBitString(string pValue)
    {
      string str3;
      if (((str3 = pValue.ToUpper()) != null) && (((str3 == "TRUE") || (str3 == "YES")) || (((str3 == "T") || (str3 == "Y")) || (str3 == "1"))))
      {
        return "1";
      }
      return "0";
    }

    public static bool ToBoolean(int pValue)
    {
      return ToBoolean(pValue, 1);
    }

    public static bool ToBoolean(object pValue)
    {
      return ToBoolean(pValue, false);
    }

    public static bool ToBoolean(string pValue)
    {
      string str2;
      return (((str2 = pValue.ToUpper()) != null) && (((str2 == "TRUE") || (str2 == "YES")) || (((str2 == "T") || (str2 == "Y")) || (str2 == "1"))));
    }

    public static bool ToBoolean(int pValue, int pTrueValue)
    {
      return (pValue == pTrueValue);
    }

    public static bool ToBoolean(object pValue, bool pDefault)
    {
      bool flag = pDefault;
      try
      {
        return Convert.ToBoolean(pValue);
      }
      catch
      {
        return pDefault;
      }
    }

    public static E_BooleanChoice ToBooleanChoice(object pValue, E_BooleanChoice pDefaultValue = E_BooleanChoice.Any)
    {
      int num = ToInt32(pValue, -1);
      E_BooleanChoice choice = pDefaultValue;
      switch (num)
      {
        case 0:
          return E_BooleanChoice.False;

        case 1:
          return E_BooleanChoice.True;
      }
      return choice;
    }

    public static byte ToByte(object pValue)
    {
      return ToByte(pValue, 0);
    }

    public static byte ToByte(object pValue, byte pDefault)
    {
      try
      {
        return Convert.ToByte(pValue);
      }
      catch
      {
        return pDefault;
      }
    }

    public static DateTime ToDateTime(object pValue)
    {
      try
      {
        return Convert.ToDateTime(pValue);
      }
      catch
      {
        return Convert.ToDateTime((string)null);
      }
    }

    public static DateTime ToDateTime(object pValue, DateTime pDefault)
    {
      try
      {
        return Convert.ToDateTime(pValue);
      }
      catch
      {
        return pDefault;
      }
    }

    public static object ToDbValue(byte pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue(decimal pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue(double pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue(short pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue(int pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue(long pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue(string pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue(decimal pValue, decimal pEmptyValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue, pEmptyValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue(double pValue, double pEmptyValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue, pEmptyValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue(short pValue, short pEmptyValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue, pEmptyValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue(int pValue, int pEmptyValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue, pEmptyValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue(long pValue, long pEmptyValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && ValueNotEmpty(pValue, pEmptyValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue_DateTime(DateTime pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull_DateTime(pValue) && ValueNotEmpty_DateTime(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValue_DateTime(DateTime pValue, DateTime pEmptyValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull_DateTime(pValue) && ValueNotEmpty_DateTime(pValue, pEmptyValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValueU(byte pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && UValueNotEmpty(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValueU(short pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && UValueNotEmpty(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValueU(int pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && UValueNotEmpty(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static object ToDbValueU(long pValue)
    {
      object obj2 = DBNull.Value;
      if (ValueNotNull(pValue) && UValueNotEmpty(pValue))
      {
        obj2 = pValue;
      }
      return obj2;
    }

    public static decimal ToDecimal(object pValue)
    {
      return ToDecimal(pValue, 0M);
    }

    public static decimal ToDecimal(object pValue, decimal pDefault)
    {
      try
      {
        return Convert.ToDecimal(pValue);
      }
      catch
      {
        return pDefault;
      }
    }

    public static double ToDouble(object pValue)
    {
      return ToDouble(pValue, 0.0);
    }

    public static double ToDouble(object pValue, double pDefault)
    {
      try
      {
        return Convert.ToDouble(pValue);
      }
      catch
      {
        return pDefault;
      }
    }

    public static string ToHexString(string pValue)
    {
      StringBuilder builder = new StringBuilder();
      foreach (char ch in pValue)
      {
        builder.AppendFormat("{0:X}", ch.cxToInt16());
      }
      return builder.ToString();
    }

    public static short ToInt16(object pValue)
    {
      return ToInt16(pValue, 0);
    }

    public static short ToInt16(object pValue, short pDefault)
    {
      try
      {
        return Convert.ToInt16(pValue);
      }
      catch
      {
        return pDefault;
      }
    }

    public static int ToInt32(object pValue)
    {
      return ToInt32(pValue, 0);
    }

    public static int ToInt32(object pValue, int pDefault)
    {
      try
      {
        return Convert.ToInt32(pValue);
      }
      catch
      {
        return pDefault;
      }
    }

    public static long ToInt64(object pValue)
    {
      return ToInt64(pValue, 0L);
    }

    public static long ToInt64(object pValue, long pDefault)
    {
      try
      {
        return Convert.ToInt64(pValue);
      }
      catch
      {
        return pDefault;
      }
    }

    public static string ToSqlDataXML(List<short> pDataList, string pXmlDataElementName, bool pIncludeItemOrder = false, int pItemOrderStartValue = 0)
    {
      string str = string.Empty;
      if (pDataList.Count <= 0)
      {
        return str;
      }
      int num = pItemOrderStartValue;
      StringBuilder builder = new StringBuilder();
      builder.AppendFormat("<Root>", new object[0]);
      foreach (short num2 in pDataList)
      {
        builder.AppendFormat("<{0} data='{1}' ItemOrder='{2}' />", pXmlDataElementName, num2, num);
        num++;
      }
      builder.AppendFormat("</Root>", new object[0]);
      return builder.ToString();
    }

    public static string ToSqlDataXML(List<int> pDataList, string pXmlDataElementName, bool pIncludeItemOrder = false, int pItemOrderStartValue = 0)
    {
      string str = string.Empty;
      if (pDataList.Count <= 0)
      {
        return str;
      }
      int num = pItemOrderStartValue;
      StringBuilder builder = new StringBuilder();
      builder.AppendFormat("<Root>", new object[0]);
      foreach (int num2 in pDataList)
      {
        builder.AppendFormat("<{0} data='{1}' ItemOrder='{2}' />", pXmlDataElementName, num2, num);
        num++;
      }
      builder.AppendFormat("</Root>", new object[0]);
      return builder.ToString();
    }

    public static string ToSqlDataXML(List<long> pDataList, string pXmlDataElementName, bool pIncludeItemOrder = false, int pItemOrderStartValue = 0)
    {
      string str = string.Empty;
      if (pDataList.Count <= 0)
      {
        return str;
      }
      int num = pItemOrderStartValue;
      StringBuilder builder = new StringBuilder();
      builder.AppendFormat("<Root>", new object[0]);
      foreach (long num2 in pDataList)
      {
        builder.AppendFormat("<{0} data='{1}' ItemOrder='{2}' />", pXmlDataElementName, num2, num);
        num++;
      }
      builder.AppendFormat("</Root>", new object[0]);
      return builder.ToString();
    }

    public static string ToSqlDataXML(List<object> pDataList, string pXmlDataElementName, bool pIncludeItemOrder = false, int pItemOrderStartValue = 0)
    {
      string str = string.Empty;
      if (pDataList.Count <= 0)
      {
        return str;
      }
      int num = pItemOrderStartValue;
      StringBuilder builder = new StringBuilder();
      builder.AppendFormat("<Root>", new object[0]);
      foreach (object obj2 in pDataList)
      {
        builder.AppendFormat("<{0} data='{1}' ItemOrder='{2}' />", pXmlDataElementName, obj2, num);
        num++;
      }
      builder.AppendFormat("</Root>", new object[0]);
      return builder.ToString();
    }

    public static string ToSqlDataXML(List<string> pDataList, string pXmlDataElementName, bool pIncludeItemOrder = false, int pItemOrderStartValue = 0)
    {
      string str = string.Empty;
      if (pDataList.Count <= 0)
      {
        return str;
      }
      int num = pItemOrderStartValue;
      StringBuilder builder = new StringBuilder();
      builder.AppendFormat("<Root>", new object[0]);
      foreach (string str2 in pDataList)
      {
        builder.AppendFormat("<{0} data='{1}' ItemOrder='{2}' />", pXmlDataElementName, str2, num);
        num++;
      }
      builder.AppendFormat("</Root>", new object[0]);
      return builder.ToString();
    }

    public static string ToString(object pValue)
    {
      try
      {
        return Convert.ToString(pValue);
      }
      catch
      {
        return string.Empty;
      }
    }

    public static string ToString(object pValue, string pDefault)
    {
      try
      {
        return Convert.ToString(pValue);
      }
      catch
      {
        return pDefault;
      }
    }

    public static string ToString_DateTime(DateTime pDateTime, string pDateFormat)
    {
      try
      {
        return pDateTime.ToString(pDateFormat);
      }
      catch
      {
        return ToString(pDateTime);
      }
    }

    public static bool UValueIsEmpty(byte pValue)
    {
      return (pValue <= 0);
    }

    public static bool UValueIsEmpty(short pValue)
    {
      return (pValue <= 0);
    }

    public static bool UValueIsEmpty(int pValue)
    {
      return (pValue <= 0);
    }

    public static bool UValueIsEmpty(long pValue)
    {
      return (pValue <= 0L);
    }

    public static bool UValueNotEmpty(byte pValue)
    {
      return !UValueIsEmpty(pValue);
    }

    public static bool UValueNotEmpty(short pValue)
    {
      return !UValueIsEmpty(pValue);
    }

    public static bool UValueNotEmpty(int pValue)
    {
      return !UValueIsEmpty(pValue);
    }

    public static bool UValueNotEmpty(long pValue)
    {
      return !UValueIsEmpty(pValue);
    }

    public static bool UValueNullOrEmpty(byte pValue)
    {
      if (!ValueIsNull(pValue))
      {
        return UValueIsEmpty(pValue);
      }
      return true;
    }

    public static bool UValueNullOrEmpty(short pValue)
    {
      if (!ValueIsNull(pValue))
      {
        return UValueIsEmpty(pValue);
      }
      return true;
    }

    public static bool UValueNullOrEmpty(int pValue)
    {
      if (!ValueIsNull(pValue))
      {
        return UValueIsEmpty(pValue);
      }
      return true;
    }

    public static bool UValueNullOrEmpty(long pValue)
    {
      if (!ValueIsNull(pValue))
      {
        return UValueIsEmpty(pValue);
      }
      return true;
    }

    public static bool ValueIsEmpty(byte pValue)
    {
      return (pValue == 0);
    }

    public static bool ValueIsEmpty(decimal pValue)
    {
      return (pValue == 0M);
    }

    public static bool ValueIsEmpty(double pValue)
    {
      return (pValue == 0.0);
    }

    public static bool ValueIsEmpty(short pValue)
    {
      return (pValue == 0);
    }

    public static bool ValueIsEmpty(int pValue)
    {
      return (pValue == 0);
    }

    public static bool ValueIsEmpty(long pValue)
    {
      return (pValue == 0L);
    }

    public static bool ValueIsEmpty(object pValue)
    {
      return (pValue == null);
    }

    public static bool ValueIsEmpty(string pValue)
    {
      if (pValue != null)
      {
        return (pValue.Trim().Length == 0);
      }
      return true;
    }

    public static bool ValueIsEmpty(byte pValue, byte pEmptyValue)
    {
      return (pValue == pEmptyValue);
    }

    public static bool ValueIsEmpty(decimal pValue, decimal pEmptyValue)
    {
      return (pValue == pEmptyValue);
    }

    public static bool ValueIsEmpty(double pValue, double pEmptyValue)
    {
      return (pValue == pEmptyValue);
    }

    public static bool ValueIsEmpty(short pValue, short pEmptyValue)
    {
      return (pValue == pEmptyValue);
    }

    public static bool ValueIsEmpty(int pValue, int pEmptyValue)
    {
      return (pValue == pEmptyValue);
    }

    public static bool ValueIsEmpty(long pValue, long pEmptyValue)
    {
      return (pValue == pEmptyValue);
    }

    public static bool ValueIsEmpty_DateTime(DateTime pValue)
    {
      return (pValue == ToDateTime(null));
    }

    public static bool ValueIsEmpty_DateTime(DateTime pValue, DateTime pEmptyValue)
    {
      return (pValue == pEmptyValue);
    }

    public static bool ValueIsNull(object pValue)
    {
      return (pValue == null);
    }

    public static bool ValueIsNull_DateTime(DateTime pValue)
    {
      return (pValue == Convert.ToDateTime((string)null));
    }

    public static bool ValueNotEmpty(byte pValue)
    {
      return !ValueIsEmpty(pValue);
    }

    public static bool ValueNotEmpty(decimal pValue)
    {
      return !ValueIsEmpty(pValue);
    }

    public static bool ValueNotEmpty(double pValue)
    {
      return !ValueIsEmpty(pValue);
    }

    public static bool ValueNotEmpty(short pValue)
    {
      return !ValueIsEmpty(pValue);
    }

    public static bool ValueNotEmpty(int pValue)
    {
      return !ValueIsEmpty(pValue);
    }

    public static bool ValueNotEmpty(long pValue)
    {
      return !ValueIsEmpty(pValue);
    }

    public static bool ValueNotEmpty(object pValue)
    {
      return (pValue != null);
    }

    public static bool ValueNotEmpty(string pValue)
    {
      return !ValueIsEmpty(pValue);
    }

    public static bool ValueNotEmpty(byte pValue, byte pEmptyValue)
    {
      return !ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool ValueNotEmpty(decimal pValue, decimal pEmptyValue)
    {
      return !ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool ValueNotEmpty(double pValue, double pEmptyValue)
    {
      return !ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool ValueNotEmpty(short pValue, short pEmptyValue)
    {
      return !ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool ValueNotEmpty(int pValue, int pEmptyValue)
    {
      return !ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool ValueNotEmpty(long pValue, long pEmptyValue)
    {
      return !ValueIsEmpty(pValue, pEmptyValue);
    }

    public static bool ValueNotEmpty_DateTime(DateTime pValue)
    {
      return !ValueIsEmpty_DateTime(pValue);
    }

    public static bool ValueNotEmpty_DateTime(DateTime pValue, DateTime pEmptyValue)
    {
      return !ValueIsEmpty_DateTime(pValue, pEmptyValue);
    }

    public static bool ValueNotNull(object pValue)
    {
      return (pValue != null);
    }

    public static bool ValueNotNull_DateTime(DateTime pValue)
    {
      return !(pValue == Convert.ToDateTime((string)null));
    }

    public static bool ValueNullOrEmpty(byte pValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(decimal pValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(double pValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(short pValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(int pValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(long pValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(string pValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(byte pValue, byte pEmptyValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue, pEmptyValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(decimal pValue, decimal pEmptyValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue, pEmptyValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(double pValue, double pEmptyValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue, pEmptyValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(short pValue, short pEmptyValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue, pEmptyValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(int pValue, int pEmptyValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue, pEmptyValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty(long pValue, long pEmptyValue)
    {
      if (!ValueIsNull(pValue))
      {
        return ValueIsEmpty(pValue, pEmptyValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty_DateTime(DateTime pValue)
    {
      if (!ValueIsNull_DateTime(pValue))
      {
        return ValueIsEmpty_DateTime(pValue);
      }
      return true;
    }

    public static bool ValueNullOrEmpty_DateTime(DateTime pValue, DateTime pEmptyValue)
    {
      if (!ValueIsNull_DateTime(pValue))
      {
        return ValueIsEmpty_DateTime(pValue, pEmptyValue);
      }
      return true;
    }

    // Properties
    public static DateTime EmptyDateTime
    {
      get
      {
        return ToDateTime(null);
      }
    }

    // Nested Types
    private class EnumerationItem
    {
      // Fields
      private string _Code;
      private string _Text;

      // Methods
      public EnumerationItem(string pCode, string pText)
      {
        this._Code = pCode;
        this._Text = pText;
      }

      // Properties
      public string Code
      {
        get
        {
          return this._Code;
        }
      }

      public string Text
      {
        get
        {
          return this._Text;
        }
      }
    }
  }





}
