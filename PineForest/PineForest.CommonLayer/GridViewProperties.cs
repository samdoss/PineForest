using System.Drawing;
using System.Web.UI.WebControls;


namespace PineForest.CommonLayer
{
  public static class GridViewProperties
  {
    #region Public Static Method
    /// <summary>
    /// AssignGridViewProperties
    /// </summary>
    /// <param name="_gridView"></param>
    public static void AssignGridViewProperties(GridView _gridView)
    {
      //Common Back Color
      Color _commonBackColor = ColorTranslator.FromHtml("#EFF3FB");

      //Common Fore Color
      Color _commonForeColor = ColorTranslator.FromHtml("#3366CC");

      //Common Properties
      _gridView.CellPadding = 3;
      _gridView.CssClass = "BD_THIN_GRID";
      _gridView.AutoGenerateColumns = false;
      _gridView.GridLines = GridLines.Both;
      _gridView.ForeColor = ColorTranslator.FromHtml("#333333");
      _gridView.BorderColor = Color.Black;
      _gridView.BorderStyle = BorderStyle.Solid;

      //Header Style Properties
      _gridView.HeaderStyle.CssClass = "BD_THIN_HEADERSTYLE";
      _gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml("#DFEBFB");
      _gridView.HeaderStyle.ForeColor = _commonForeColor;
      _gridView.HeaderStyle.Font.Bold = true;

      //Pager Settings
      _gridView.PagerSettings.FirstPageText = "First";
      _gridView.PagerSettings.LastPageText = "Last";
      _gridView.PagerSettings.NextPageText = "Next";
      _gridView.PagerSettings.PreviousPageText = "Previous";
      _gridView.PagerSettings.Mode = PagerButtons.NumericFirstLast;

      //Footer Style
      _gridView.FooterStyle.HorizontalAlign = HorizontalAlign.Right;
      _gridView.FooterStyle.BackColor = ColorTranslator.FromHtml("#DFEBFB");
      _gridView.FooterStyle.ForeColor = _commonForeColor;
      _gridView.FooterStyle.CssClass = "BD_THIN_FOOTERSTYLE";

      //Alternating Row Style
      _gridView.AlternatingRowStyle.CssClass = "BD_THIN_ALTERSTYLE";
      _gridView.AlternatingRowStyle.BackColor = Color.White;

      //Row Style
      _gridView.RowStyle.CssClass = "BD_THIN_NORMALSTYLE";
      _gridView.RowStyle.HorizontalAlign = HorizontalAlign.Left;
      _gridView.RowStyle.VerticalAlign = VerticalAlign.Top;
      _gridView.RowStyle.BackColor = _commonBackColor;

      //Pager Style
      _gridView.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
      _gridView.PagerStyle.BackColor = ColorTranslator.FromHtml("#DFEBFB");
      _gridView.PagerStyle.ForeColor = _commonForeColor;
      _gridView.PagerStyle.Font.Bold = true;
      _gridView.PagerStyle.CssClass = "pager";

      //Empty Grid Attributes

      //_gridView.EmptyDataText = "No Record(s) Found";
      _gridView.Width = Unit.Percentage(100);
    }

    #endregion
  }
}
