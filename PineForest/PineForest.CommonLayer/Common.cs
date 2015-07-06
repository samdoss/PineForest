using System;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PineForest.CommonLayer
{
  public static class Common
  {
    #region Public Methods

    /// <summary>
    /// CheckNull
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string CheckNull(object obj)
    {
      if (obj != null)
        return obj.ToString();
      else
        return string.Empty;
    }

    /// <summary>
    /// CheckIntNull
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static int CheckIntNull(object obj)
    {
      if (!string.IsNullOrEmpty(obj.ToString()))
        return Convert.ToInt32(obj, null);
      else
        return 0;
    }

    /// <summary>
    /// CheckBlank
    /// </summary>
    /// <param name="checkString"></param>
    /// <returns></returns>
    public static string CheckBlank(string checkString)
    {
      if (checkString.Trim().Length == 0)
        return "--";
      else
        return checkString;
    }
    /// <summary>
    /// ValidateDate
    /// </summary>
    /// <param name="date"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public static bool ValidateDate(String date, String format)
    {
      try
      {
        System.Globalization.DateTimeFormatInfo dtfi = new
        System.Globalization.DateTimeFormatInfo();
        dtfi.ShortDatePattern = format;
        DateTime dt = DateTime.ParseExact(date, "d", dtfi);
      }
      catch (Exception)
      {
        return false;
      }
      return true;
    }

    /// <summary>
    /// MonthToInt
    /// </summary>
    /// <param name="Input"></param>
    /// <returns></returns>
    public static int MonthToInt(string Input)
    {
      return (int)Enum.Parse(typeof(Month), Input, true);
    }

    /// <summary>
    /// Export
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="gv"></param>
    public static void Export(string fileName, GridView gv)
    {
      HttpContext.Current.Response.Clear();
      HttpContext.Current.Response.AddHeader(
          "content-disposition", string.Format("attachment; filename={0}", fileName));
      HttpContext.Current.Response.ContentType = "application/ms-excel";

      using (StringWriter sw = new StringWriter())
      {
        using (HtmlTextWriter htw = new HtmlTextWriter(sw))
        {
          //  Create a form to contain the grid
          Table table = new Table();

          //  add the header row to the table
          if (gv.HeaderRow != null)
          {
            Common.PrepareControlForExport(gv.HeaderRow);
            table.Rows.Add(gv.HeaderRow);
          }

          //  add each of the data rows to the table
          foreach (GridViewRow row in gv.Rows)
          {
            Common.PrepareControlForExport(row);
            table.Rows.Add(row);
          }

          //  add the footer row to the table
          if (gv.FooterRow != null)
          {
            Common.PrepareControlForExport(gv.FooterRow);
            table.Rows.Add(gv.FooterRow);
          }

          //  render the table into the htmlwriter
          table.RenderControl(htw);

          //  render the htmlwriter into the response
          HttpContext.Current.Response.Write(sw.ToString());
          HttpContext.Current.Response.End();
        }
      }
    }


    /// <summary>
    /// ReplPine any of the contained controls with literals
    /// </summary>
    /// <param name="control"></param>
    private static void PrepareControlForExport(Control control)
    {
      for (int i = 0; i < control.Controls.Count; i++)
      {
        Control current = control.Controls[i];
        if (current is LinkButton)
        {
          control.Controls.Remove(current);
          control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
        }
        else if (current is ImageButton)
        {
          control.Controls.Remove(current);
          control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
        }
        else if (current is HyperLink)
        {
          control.Controls.Remove(current);
          control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
        }
        else if (current is DropDownList)
        {
          control.Controls.Remove(current);
          control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
        }
        else if (current is CheckBox)
        {
          control.Controls.Remove(current);
          control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
        }

        if (current.HasControls())
        {
          Common.PrepareControlForExport(current);
        }
      }
    }


   // private bool formValidation(string _dateFormat, string _fromDate, string _toDate)
    //{

    //  bool rValue = true;
    //  string dtFormat = _dateFormat;
    //  DateTime dTime = new DateTime();
    //  DateTime todayDate = new DateTime();
    //  string sTodayDate;

    //  // Validation

    //  if (_fromDate != "" && _fromDate != null)
    //  {


    //    sTodayDate = Convert.ToString(DateTime.Now.ToString(_dateFormat));
    //    dTime = DateTime.ParseExact(_fromDate, dtFormat, null);
    //    todayDate = DateTime.ParseExact(sTodayDate, dtFormat, null);
    //    if (dTime > todayDate)
    //    {
    //      //txtFromDate.Focus();
    //      System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //      sb.Append("<script>alert('" + "From Date - Cannot Be Greater Than Today Date" + ".');");
    //      sb.Append("</script>");
    //      //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);
    //      rValue = false;
    //      return rValue;
    //    }
    //  }

    //  if (_toDate != "" && _toDate != null)
    //  {

    //    sTodayDate = Convert.ToString(DateTime.Now.ToString(_dateFormat));
    //    dTime = DateTime.ParseExact(_toDate, dtFormat, null);
    //    todayDate = DateTime.ParseExact(sTodayDate, dtFormat, null);
    //    if (dTime > todayDate)
    //    {
    //      //txtToDate.Focus();
    //      System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //      sb.Append("<script>alert('" + "To Date - Cannot Be Greater Than Today Date" + ".');");
    //      sb.Append("</script>");
    //      //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);
    //      rValue = false;
    //      return rValue;
    //    }
    //  }
    //  if (_fromDate != "" && _fromDate != null &&
    //      _toDate.ToString() != "" && _toDate != null)
    //  {
    //    DateTime FromDate = DateTime.ParseExact(_fromDate, dtFormat, null);
    //    DateTime ToDate = DateTime.ParseExact(_toDate, dtFormat, null);

    //    if (ToDate < FromDate)
    //    {
    //      //txtToDate.Focus();
    //      System.Text.StringBuilder sb = new System.Text.StringBuilder();
    //      sb.Append("<script>alert('" + "To Date Should Be Greater Than or Equal To From Date" + ".');");
    //      sb.Append("</script>");
    //      // ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);
    //      rValue = false;
    //      return rValue;
    //    }
    //  }
    //  return rValue;
    //}

    #endregion
  }
}
