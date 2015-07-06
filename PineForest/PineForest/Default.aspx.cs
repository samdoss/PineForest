using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PineForest
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var result = Request.Form["datepicker"];
            HtmlControl ctrl = (HtmlControl)this.FindControl("datepicker");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var result = Request.Form["datepicker"];
            HtmlControl ctrl = (HtmlControl)this.FindControl("datepicker");
        }
    }
}