using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace PineForest.CommonLayer
{
  //The template
  public class CommandCheckBoxTemplateAdd : ITemplate
  {
    void ITemplate.InstantiateIn(Control parent)
    {
      CommandCheckBox cb = new CommandCheckBox();
      cb.CommandName = "CheckBoxAdd";
      cb.ID = "cbCheckBoxAdd";
      cb.AutoPostBack = true;
      parent.Controls.Add(cb);

    }
  }

}
