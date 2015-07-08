using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PineForest
{
    public partial class PineLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            mv1.ActiveViewIndex = 1;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            mv1.ActiveViewIndex = 2;
        }

        protected void btnAuthenticationCode_Click(object sender, EventArgs e)
        {
            mv1.ActiveViewIndex = 0;
        }
    }
}