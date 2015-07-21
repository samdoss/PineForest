using System;
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
using System.Net.Mail;

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
                Session["LoginID"] = "";
                Session["EmailID"] = "";
                Session["MobileNumber"] = "";
                hfIpAddress.Value = GetUserIPAddress();
                hfGeoLocation.Value = GetGeoLocation();
            }
        }

        protected void btnNewUser_Click(object sender, EventArgs e)
        {
            mv1.ActiveViewIndex = 1;
            txtEmailIDorMobileNo.Text = "";
            txtAuthenticationCode.Text = "";
            lblNewUserMsg.Text = "";
            lblLoginMsg.Text = "";
            lblShowAuthenticationMsg.Text = "";
            btnBacktoLogin.Visible = false;
        }
             
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text != "")
            {
                if (CheckEmailIDAvailable(txtLogin.Text))
                {
                    if (pineLoginDL.IsAuthenticated)
                    {
                        Session["LoginID"] = pineLoginDL.LoginID;
                        Session["EmailID"] = pineLoginDL.LoginMailID;
                        Session["MobileNumber"] = pineLoginDL.LoginMobileNo;

                        Response.Redirect("~/Booking/PineBooking.aspx");
                    }
                    else
                    {
                        mv1.ActiveViewIndex = 2;
                    }
                }
                else
                {
                    lblLoginMsg.Text = "You EmailID not registered with us. Kindly create a new user account.";
                }
            }
        }

        private void SendmailtoAdmin(string customerMailID, string authenticationCode)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage sm = new MailMessage();
            smtpClient.Credentials = new System.Net.NetworkCredential("info@pineforestmunnar.com", "Mocha$55");
            smtpClient.Host = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"].ToString();
            smtpClient.Port = 25;
            sm.To.Add(customerMailID);
            sm.Bcc.Add("info.pineforestmunnar@gmail.com");
            sm.IsBodyHtml = true;
            sm.From = new MailAddress("info@pineforestmunnar.com");
            sm.Subject = "Welcome to PineForestMunnar.com";
            StringBuilder sbMail = new StringBuilder();
            sbMail.Append("Dear Customer,");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("We are happy to welcome you to the PineForestMunnar.com and are delighted to give you a login to PineForestMunnar Website.");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("Please use the below authentication code and activate the service.");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Kindly login with your E-Mail id for ");
            sbMail.Append("information security reasons.");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Please get back to us with your suggestions, comments and feedback to info@pineforestmunnar.com");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Your Authentication code is given below to booking room in our website,");
            sbMail.Append(Environment.NewLine);

            sbMail.Append("http://pineforestmunnar.com");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Authentication Code : " + authenticationCode);
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            sbMail.Append("Thank you,");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);
            sbMail.Append("Administrator");
            sbMail.Append(Environment.NewLine);
            sbMail.Append("PineForestMunnar.com");
            sbMail.Append(Environment.NewLine);
            sbMail.Append(Environment.NewLine);

            //sm.Body += "<p><font face='Times New Roman' font-size='12'>Josh,</font></p>";
            //sm.Body += "<p><font face='Times New Roman' font-size='12'>" + lblEmployeeName.Text + " needs leave on the following days.";

            //sm.Body += "<p>Kindly find below " + genderStr + " leave application details. Convey this to the Client and send me the response." + "<br /></font></p>";
            //sm.Body += "<p><font face='Times New Roman' font-size='12'><table border=1 cellspacing=2 cellpadding=2><tr><td>S.No</td><td>Client</td><td>Employee Name</td>";
            //sm.Body += "<td>Date of Application</td><td>Leave Wanted From</td><td>Leave Wanted To</td><td>Total No. of Days</td>";
            //sm.Body += "<td>Reason</td><tr>";

            //if (hdfRole.Value.ToString() == "Administrator" || hdfRole.Value.ToString() == "HR")
            //{
            //    sm.Body += "<tr><td>1</td><td>&nbsp;</td><td>" + lblEmployeeName.Text + "</td>";
            //}
            //else
            //{
            //    if (Convert.ToInt32(hdfCompanyID.Value) == Convert.ToInt32(Company.ECGroupMT))
            //    {
            //        sm.Body += "<tr><td>1</td><td>&nbsp;</td><td>" + lblEmployeeName.Text + "</td>";
            //    }
            //    else
            //    {
            //        sm.Body += "<tr><td>1</td><td>" + ddlClient.SelectedItem.Text + "</td><td>" + lblEmployeeName.Text + "</td>";
            //    }
            //}


            //sm.Body += "<td>" + _currentDate.Date.ToShortDateString() + "</td><td>" + txtFromDate.Text + "</td><td>" + txtToDate.Text + "</td><td>" + hdfTotalDaysLeave.Value.ToString() + "</td>";
            //sm.Body += "<td>" + txtReasonforLeave.Text + "</td><tr></table><br /><br />";
            //sm.Body += "<p><font face='Times New Roman' font-size='12'>Thank you, <br />Alice.";
            sm.IsBodyHtml = false;
            sm.Body = sbMail.ToString();

            sm.Priority = MailPriority.Normal;
            try
            {
                smtpClient.Send(sm);
            }
            catch (Exception ex)
            {
                String err_str = "Send Email Failed." + ex.Message;
            }
            smtpClient = null;
            sm = null;
        }

        private bool CheckEmailIDAvailable(string emailIdorMobileNo)
        {
            pineLoginDL = new PineLoginDL();
            return pineLoginDL.GetLoginAuthentication(emailIdorMobileNo);
            //return false;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
            if (txtEmailIDorMobileNo.Text != "")
            {
                if (CheckEmailIDAvailable(txtEmailIDorMobileNo.Text))
                {
                    if (txtEmailIDorMobileNo.Text.ToLower() == pineLoginDL.LoginMailID.ToLower() || txtEmailIDorMobileNo.Text.ToLower() == pineLoginDL.LoginMobileNo.ToLower())
                    {
                        if (pineLoginDL.IsAuthenticated)
                        {
                            lblNewUserMsg.Text = "Already you have a account in PineForestMunnar.com!";
                            btnBacktoLogin.Visible = true;
                            return;
                        }
                        else
                        {
                            lblNewUserMsg.Text = "";
                            lblShowAuthenticationMsg.Text = "";
                            mv1.ActiveViewIndex = 2;
                            btnBacktoLogin.Visible = false;
                        }
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

                //// Display the Status - Whether successfully saved or not
                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //sb.Append("<script>alert('" + result.Message.ToString() + ".');");
                //sb.Append("</script>");
                //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);

                // If successful get and display the saved Company
                if (result.Status == TransactionStatus.Success)
                {
                    hfLoginID.Value = pineLoginDL.LoginID.ToString();
                    authenticationCode = pineLoginDL.AuthenticationCode;
                    if (txtEmailIDorMobileNo.Text.Contains("@"))
                    {
                        SendmailtoAdmin(pineLoginDL.LoginMailID, authenticationCode);
                        //SendMailConfirmation(pineLoginDL.LoginMailID, authenticationCode);
                        //pineLoginDL.LoginMailID = txtEmailIDorMobileNo.Text;
                        //pineLoginDL.LoginMobileNo = string.Empty;
                    }
                    else
                    {
                        //pineLoginDL.LoginMailID = string.Empty;
                        //pineLoginDL.LoginMobileNo = txtEmailIDorMobileNo.Text;
                        //SendMailConfirmation(pineLoginDL.LoginMobileNo, authenticationCode);
                    }
                    mv1.ActiveViewIndex = 2;
                }
            }

        }

        protected void btnBacktoLogin_Click(object sender, EventArgs e)
        {
            btnBacktoLogin.Visible = false;
            mv1.ActiveViewIndex = 0;
        }

        protected void btnAuthenticationCode_Click(object sender, EventArgs e)
        {

            pineLoginDL = new PineLoginDL();
            if (txtEmailIDorMobileNo.Text != null && txtEmailIDorMobileNo.Text != string.Empty)
                pineLoginDL.GetLoginAuthentication(txtEmailIDorMobileNo.Text);
            else
                pineLoginDL.GetLoginAuthentication(txtLogin.Text);

            if (pineLoginDL.AuthenticationCode != null && pineLoginDL.AuthenticationCode.ToLower() == txtAuthenticationCode.Text.ToLower())
            {
                pineLoginDL.IsAuthenticated = true;
                TransactionResult result;
                pineLoginDL.ScreenMode = ScreenMode.Add;
                pineLoginDL.AddEditOption = 1;
                result = pineLoginDL.Commit();

                //// Display the Status - Whether successfully saved or not
                //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //sb.Append("<script>alert('" + result.Message.ToString() + ".');");
                //sb.Append("</script>");
                //ScriptManager.RegisterStartupScript(this.Page, typeof(string), "MyScript", sb.ToString(), false);
                lblShowAuthenticationMsg.Text = "Your Account Activated.";
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