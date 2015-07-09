
namespace PineForest.CommonLayer
{
  public class TransactionResult
  {
    #region Constructor(s)

    //Constructor taking the TransactionStatus Enum
    public TransactionResult(TransactionStatus status)
    {
      _sStatus = status;
    }

    // Constructor taking the TransactionStatus enum, and an Message for the client to inspect
    public TransactionResult(TransactionStatus status, string Message)
    {
      _sStatus = status;
      _sMessage = Message;
    }

    #endregion

    #region Private Fields

    private string _sMessage;
    private TransactionStatus _sStatus;

    #endregion

    #region Public Properties

    // Status of the Transaction (Success or Failure)        
    public TransactionStatus Status
    {
      get { return _sStatus; }
      set { _sStatus = value; }
    }

    // Optional Message for transactions

    public string Message
    {
      get { return _sMessage; }
      set { _sMessage = value; }
    }

    #endregion
  }
}
