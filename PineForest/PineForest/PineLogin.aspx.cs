﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PineForest.DataLayer;
using PineForest.CommonLayer;
using System.Net;
using System.Text;
using System.IO;

namespace PineForest
{
    public partial class PineLogin : System.Web.UI.Page
    {

        PineLoginDL pineLoginDL = new PineLoginDL();
        string authenticationCode = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hfIpAddress.Value = GetUserIPAddress();
                hfGeoLocation.Value = GetGeoLocation();
            }
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            mv1.ActiveViewIndex = 1;
            txtEmailIDorMobileNo.Text = "";
            txtAuthenticationCode.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtEmailIDorMobileNo.Text != "")
            {
                if (CheckEmailIDAvailable())
                {
                    if (pineLoginDL.IsAuthenticated)
                    {

                    }
                    else
                    {
                        mv1.ActiveViewIndex = 2;
                    }
                }
            }
        }

        private bool CheckEmailIDAvailable()
        {
            pineLoginDL = new PineLoginDL();
            return pineLoginDL.GetLoginAuthentication(txtLogin.Text);
            //return false;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtEmailIDorMobileNo.Text != "")
            {
                if (CheckEmailIDAvailable())
                {
                    if (txtEmailIDorMobileNo.Text.ToLower() == pineLoginDL.LoginMailID || txtEmailIDorMobileNo.Text.ToLower() == pineLoginDL.LoginMobileNo)
                    {

                    }
                }

                pineLoginDL = new PineLoginDL();
                pineLoginDL.LoginID = 0;
                pineLoginDL.RoleID = 2;
                if (txtEmailIDorMobileNo.Text.Contains("@"))
                {
                    pineLoginDL.LoginMailID = txtEmailIDorMobileNo.Text;
                    pineLoginDL.LoginMobileNo = string.Empty;
                }
                else
                {
                    pineLoginDL.LoginMailID = string.Empty;
                    pineLoginDL.LoginMobileNo = txtEmailIDorMobileNo.Text;
                }

                pineLoginDL.IsAuthenticated = false;
                pineLoginDL.AuthenticationCode = "";
                pineLoginDL.AuthenticationDate = DateTime.Now.Date;
                pineLoginDL.LogininIpAddress = hfIpAddress.Value;
                pineLoginDL.GeoLocation = hfGeoLocation.Value;

                TransactionResult result;
                pineLoginDL.ScreenMode = ScreenMode.Add;
                result = pineLoginDL.Commit();

                // Display the Status - Whether successfully saved or not
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script>alert('" + result.Message.ToString() + ".');");
                sb.Append("</script>");
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);

                // If successful get and display the saved Company
                if (result.Status == TransactionStatus.Success)
                {
                    hfLoginID.Value = pineLoginDL.LoginID.ToString();
                    authenticationCode = pineLoginDL.AuthenticationCode;
                    mv1.ActiveViewIndex = 2;
                }

            }

        }

        protected void btnAuthenticationCode_Click(object sender, EventArgs e)
        {
            pineLoginDL.GetLoginDetails();



            if (authenticationCode.ToLower() == txtAuthenticationCode.Text.ToLower())
            {
                CheckEmailIDAvailable()
                pineLoginDL = new PineLoginDL();
                pineLoginDL.IsAuthenticated = true;
                TransactionResult result;
                pineLoginDL.ScreenMode = ScreenMode.Add;
                pineLoginDL.AddEditOption = 1;
                result = pineLoginDL.Commit();

                // Display the Status - Whether successfully saved or not
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script>alert('" + result.Message.ToString() + ".');");
                sb.Append("</script>");
                ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);

                // If successful get and display the saved Company
                if (result.Status == TransactionStatus.Success)
                {
                    mv1.ActiveViewIndex = 0;
                }
            }
            else
            {
                lblShowAuthenticationMsg.Text = "Authentication Code Incorrect. Try Again!";
            }
        }

        /// <summary>
        /// Get current user ip address.
        /// </summary>
        /// <returns>The IP Address</returns>
        private string GetUserIPAddress()
        {
            var context = GetClientDetailsFromhtml("http://myphpapps.com.cws10.my-hosting-panel.com/getuserip.php");
            context = context.Replace("<html>\r\n<head>\r\n</head>\r\n<body>\r\nIP", "");
            context = context.Replace("IP\r\n</body>\r\n</html>", "");
            string ip = context;
            var geoContext = GetClientDetailsFromhtml("http://myphpapps.com.cws10.my-hosting-panel.com/index.php");



            return ip;
        }

        /// <summary>
        /// Get current user ip address.
        /// </summary>
        /// <returns>The IP Address</returns>
        private string GetGeoLocation()
        {
            var geoContext = GetClientDetailsFromhtml("http://myphpapps.com.cws10.my-hosting-panel.com/geolocation.php");

            string getLongutitudeLattitude = geoContext;
            string getGeoLocation = geoContext;
            return getGeoLocation;
        }


        private string GetClientDetailsFromhtml(string urlValue)
        {
            string uri = string.Empty;
            // This is where we will send it

            //string httpUrl = Page.Request.Url.OriginalString;
            //httpUrl = httpUrl.Replace("PineLogin.aspx", "GetClientDetails.html");

            uri = urlValue;
            try
            {
                // This is what we are sending sample, don't remove or change
                string post_data = "";
                // create a request
                HttpWebRequest request = (HttpWebRequest)
                                         WebRequest.Create(uri);
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "POST";

                // turn our request string into a byte stream
                byte[] postBytes = Encoding.ASCII.GetBytes(post_data);

                // this is important - make sure you specify type this way
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postBytes.Length;
                Stream requestStream = request.GetRequestStream();

                // now send it
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                // grab te response and print it out to the console along with the status code
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var consoleString = (new StreamReader(response.GetResponseStream()).ReadToEnd());
                var consoleStatusString = (response.StatusCode);
                return consoleString;
            }
            catch { }

            return uri;
        }
    }
}