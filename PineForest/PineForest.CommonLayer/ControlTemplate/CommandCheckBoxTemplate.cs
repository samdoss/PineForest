using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace PineForest.CommonLayer
{
  //The template
  public class CommandCheckBoxTemplate : ITemplate
  {
    void ITemplate.InstantiateIn(Control parent)
    {
      CommandCheckBox cb = new CommandCheckBox();
      cb.CommandName = "CheckOrUncheckAll";
      cb.ID = "cbCheckAll";
      cb.AutoPostBack = true;
      parent.Controls.Add(cb);

    }
  }
}
