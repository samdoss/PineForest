
namespace PineForest.CommonLayer
{
  public class TransactionResult
  {
    #region Constructor(s)

    //Constructor taking the TransactionStatus Enum
    public TransactionResult(TransactionStatus status)
    {
      _Status = status;
    }

    // Constructor taking the TransactionStatus enum, and an Message for the client to inspect
    public TransactionResult(TransactionStatus status, string Message)
    {
      _Status = status;
      _Message = Message;
    }

    #endregion

    #region Private Fields

    private string _Message;
    private TransactionStatus _Status;

    #endregion

    #region Public Properties

    // Status of the Transaction (Success or Failure)        
    public TransactionStatus Status
    {
      get { return _Status; }
      set { _Status = value; }
    }

    // Optional Message for transactions

    public string Message
    {
      get { return _Message; }
      set { _Message = value; }
    }

    #endregion
  }
}
