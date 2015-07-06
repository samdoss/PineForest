
namespace PineForest.CommonLayer
{
  #region Enum Screen Mode

  //Enums for User's Screen Mode
  public enum ScreenMode
  {
    Add = 1,
    Edit = 2,
    View = 3,
    Delete = 4,
    Exists = 5
  }

  #endregion

  #region Enum for Transactions

  // TransactionStatus defines whether the transaction was successful or failed.
  public enum TransactionStatus
  {
    Success,
    Failure
  }

  #endregion

  public enum SortDirection { Ascending = 0, Descending = 1 }

  #region Enum for AddressTypes

  //Enums for Address Types
  public enum AddressType
  {
    PresentAddress = 1,
    PermanentAddress = 2
  }

  #endregion

  #region Enum for Month Names

  public enum Month
  {
    Jan = 1,
    Feb = 2,
    Mar = 3,
    Apr = 4,
    May = 5,
    Jun = 6,
    Jul = 7,
    Aug = 8,
    Sep = 9,
    Oct = 10,
    Nov = 11,
    Dec = 12
  }

  #endregion

  #region Enum for FeedbackStatus

  //Enums for Feedback Status
  public enum FeedbackStatus
  {
    Opened = 1,
    Pending = 2,
    Closed = 3
  }

  #endregion

  #region Enum for VisitorCardAllocation Type

  //Enums for VisitorCardAllocation Type 
  public enum VisitorCardAllocationType
  {
    Employee = 1,
    Visitor = 2
  }
  #endregion

  #region Enum for VisitorCardAllocation Status

  //Enums for VisitorCardAllocation Status 
  public enum VisitorCardAllocationStatus
  {
    Issued = 0,
    Returned = 1
  }
  #endregion

  #region Enum for TimeSheet Status

  //Enums for TimeSheet Status 
  public enum TimeSheetStatus
  {
    Saved = 1,
    Submitted = 2,
    Approved = 3,
    Billed = 4,
    Rejected = 5
  }
  #endregion

  #region Enum for Leave Status

  //Enums for Leave Status 
  public enum LeaveStatus
  {
    Applied = 1,
    Approved = 2,
    Rejected = 3,
    Availed = 4,
    Cancelled = 5
  }
  #endregion

  #region Enum for Leave Type

  //Enums for Leave Type 
  public enum LeaveType
  {
    CasualLeave = 1,
    SickLeave = 2,
    PrivilegeLeave = 3,
    CompOff = 4,
    LossofPay = 5

  }
  #endregion

  #region Enum for Company

  //Enums for Company
  public enum Company
  {
    PinePetroIT = 11,
    PinePetroMT = 12,
    PinePetroIntl = 13
  }
  #endregion
}
