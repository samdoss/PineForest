
namespace PineForest.CommonLayer
{
  public class PineConnection
  {
    #region Constructor(s)

      public PineConnection()
    {
      DatabaseName = "PineForest";
    }

    #endregion

    #region Private Variables

    private string _connectionString;
    private string _databaseName;

    #endregion

    #region Public Properties

    public string DatabaseName
    {
      get { return _databaseName; }
      set { _databaseName = value; }
    }

    public string ConnectionString
    {
      get { return _connectionString; }
      set { _connectionString = value; }
    }

    #endregion
  }
}
