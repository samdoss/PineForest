using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PineForest.CommonLayer
{
  public class CommandCheckBox : System.Web.UI.WebControls.CheckBox
  {

    #region "Command event implementation"
    private static readonly object EventCommand = new object();

    public event CommandEventHandler Command
    {
      add
      {
        Events.AddHandler(EventCommand, value);
      }
      remove
      {
        Events.RemoveHandler(EventCommand, value);
      }
    }

    protected virtual void OnCommand(CommandEventArgs args)
    {
      CommandEventHandler ceh = Events[EventCommand] as CommandEventHandler;
      if (ceh != null)
        ceh(this, args);
      base.RaiseBubbleEvent(this, args);
    }
    #endregion

    #region "Properties"
    public string CommandName
    {
      get
      {
        string s = ViewState["CommandName"] as string;
        if (s != null)
          return s;
        return String.Empty;

      }
      set
      {
        ViewState["CommandName"] = value;
      }
    }

    public string CommandArgument
    {
      get
      {
        string s = ViewState["CommandArgument"] as string;
        if (s != null)
          return s;
        return String.Empty;
      }
      set
      {
        ViewState["CommandArgument"] = value;
      }
    }

    #endregion

    #region "Raising the event"

    protected override void OnCheckedChanged(EventArgs e)
    {
      base.OnCheckedChanged(e);

      string strChecked = this.Checked ? "true" : "false";
      if (CommandArgument != String.Empty)
        strChecked += ";" + CommandArgument;

      OnCommand(new CommandEventArgs(this.CommandName, strChecked));
    }

    #endregion
  }


}
