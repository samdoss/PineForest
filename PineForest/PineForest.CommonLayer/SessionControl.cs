using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PineForest.CommonLayer
{
  public sealed class SessionControl
  {
    public static int CompanyID
    {
      get
      {
        return HttpContext.Current.Session["CompanyID"].cxToInt32();
      }
      set
      {
        HttpContext.Current.Session["CompanyID"] = value;
      }
    }

    public static int UserID
    {
      get
      {
        return HttpContext.Current.Session["UserID"].cxToInt32();
      }
      set
      {
        HttpContext.Current.Session["UserID"] = value;
      }
    }

    public static int UserName
    {
      get
      {
        return HttpContext.Current.Session["UserName"].cxToInt32();
      }
      set
      {
        HttpContext.Current.Session["UserName"] = value;
      }
    }

    public static string CompanyName
    {
      get
      {
        return HttpContext.Current.Session["CompanyName"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["CompanyName"] = value;
      }
    }

    public static string EmployeeName
    {
      get
      {
        return HttpContext.Current.Session["EmployeeName"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["EmployeeName"] = value;
      }
    }

    public static int EmployeeID
    {
      get
      {
        return HttpContext.Current.Session["EmployeeID"].cxToInt32();
      }
      set
      {
        HttpContext.Current.Session["EmployeeID"] = value;
      }
    }

    public static string EmployeeDOB
    {
      get
      {
        return HttpContext.Current.Session["EmployeeDOB"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["EmployeeDOB"] = value;
      }
    }

    public static string SpouseName
    {
      get
      {
        return HttpContext.Current.Session["SpouseName"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["SpouseName"] = value;
      }
    }

    public static string DateFormat
    {
      get
      {
        return HttpContext.Current.Session["DateFormat"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["DateFormat"] = value;
      }
    }
    public static string Role
    {
      get
      {
        return HttpContext.Current.Session["Role"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["Role"] = value;
      }
    }
    public static int DepartmentID
    {
      get
      {
        return HttpContext.Current.Session["DepartmentID"].cxToInt32();
      }
      set
      {
        HttpContext.Current.Session["DepartmentID"] = value;
      }
    }
    public static string DepartmentName
    {
      get
      {
        return HttpContext.Current.Session["DepartmentName"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["DepartmentName"] = value;
      }
    }
    public static string EmployeeWeddingDate
    {
      get
      {
        return HttpContext.Current.Session["EmployeeWeddingDate"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["EmployeeWeddingDate"] = value;
      }
    }
    public static string LeaveEmpID
    {
      get
      {
        return HttpContext.Current.Session["LeaveEmpID"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["LeaveEmpID"] = value;
      }
    }
    public static string LeaveTypeID
    {
      get
      {
        return HttpContext.Current.Session["LeaveTypeID"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["LeaveTypeID"] = value;
      }
    }
    public static string LeaveStatusID
    {
      get
      {
        return HttpContext.Current.Session["LeaveStatusID"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["LeaveStatusID"] = value;
      }
    }

    public static string FinancialYear
    {
      get
      {
        return HttpContext.Current.Session["FinancialYear"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["FinancialYear"] = value;
      }
    }
    public static string VirtualDirectory
    {
      get
      {
        return HttpContext.Current.Session["VirtualDirectory"].cxToString();
      }
      set
      {
        HttpContext.Current.Session["VirtualDirectory"] = value;
      }
    }

  }
}
