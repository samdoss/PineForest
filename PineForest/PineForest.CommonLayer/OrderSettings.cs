using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PineForest.CommonLayer
{
  public class OrderSettings
  {
    public static Boolean SendMail {
      get
      {
        object _SendMail = System.Configuration.ConfigurationSettings.AppSettings["SendMail"];
        return _SendMail == null ? false : Convert.ToBoolean(_SendMail);
      }
    }
        
  }
}
