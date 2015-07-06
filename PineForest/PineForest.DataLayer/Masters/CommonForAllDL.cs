using PineForest.CommonLayer;

namespace PineForest.DataLayer
{
  public class CommonForAllDL
  {
    #region Variables

    protected PineConnection _myConnection = new PineConnection();

    #endregion

    #region Properties

    public ScreenMode ScreenMode { get; set; }

    public int AddEditOption { get; set; }

    #endregion
  }
}
